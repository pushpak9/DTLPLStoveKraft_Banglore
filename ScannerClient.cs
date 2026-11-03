using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace StockCraft.Forms.Transaction
{
    /// <summary>
    /// ClsSocket.ClientSocket_MultiSocket ka safe replacement (Inspection form ke liye).
    ///
    /// Purane class ki problems jo yahan theek hain:
    ///  - NoData flag ki wajah se loop me Sleep nahi hota tha (100% CPU)
    ///  - Worker thread foreground tha aur kabhi band nahi hota tha
    ///  - Open() har baar naya thread bana deta tha
    ///  - Exception ka message barcode bankar DataArrived me aa jata tha
    ///  - Close/Disconnect public method hi nahi tha
    ///  - Scanner disconnect hone par pata nahi chalta tha, reconnect bhi nahi
    /// </summary>
    public class ScannerClient : IDisposable
    {
        public delegate void DataArrivalHandler(string ClientIP, string Message);

        // Barcode data aaya
        public event DataArrivalHandler DataArrived;

        // true = connected, false = disconnected
        public event Action<bool> ConnectionChanged;

        public string IPAddress { get; set; }
        public int Port { get; set; }

        // Connect timeout (ms) aur disconnect ke baad reconnect ka gap (ms)
        public int ConnectTimeoutMs { get; set; } = 3000;
        public int ReconnectDelayMs { get; set; } = 3000;
        public bool AutoReconnect { get; set; } = true;

        private readonly object _sync = new object();
        private readonly ManualResetEvent _stop = new ManualResetEvent(false);

        private TcpClient _client;
        private Thread _worker;
        private volatile bool _running;
        private volatile bool _connected;

        public bool IsConnected
        {
            get { return _connected; }
        }

        //========================================================
        // OPEN
        // Pehli connection try karta hai aur background thread start
        // karta hai. Connect na ho paye to bhi thread chalta rehta hai
        // aur AutoReconnect se baad me connect kar leta hai.
        // Return: abhi connected hai ya nahi.
        //========================================================
        public bool Open()
        {
            if (string.IsNullOrWhiteSpace(IPAddress) || Port == 0)
                return false;

            lock (_sync)
            {
                // Pehle se chal raha hai to naya thread nahi banega
                if (_running)
                    return _connected;

                _running = true;
                _stop.Reset();
            }

            if (TryConnect())
                RaiseConnectionChanged(true);

            Thread t = new Thread(Run);
            t.IsBackground = true;   // app band hone par thread khud khatam
            t.Name = "ScannerClient_" + IPAddress + "_" + Port;
            _worker = t;
            t.Start();

            return _connected;
        }

        //========================================================
        // CLOSE
        // Socket band, thread band. Dobara Open() kiya ja sakta hai.
        //========================================================
        public void Close()
        {
            _running = false;
            _connected = false;
            _stop.Set();

            TcpClient c;

            lock (_sync)
            {
                c = _client;
                _client = null;
            }

            try { if (c != null) c.Close(); } catch { }

            Thread w = _worker;
            _worker = null;

            try
            {
                if (w != null && w != Thread.CurrentThread)
                    w.Join(1000);
            }
            catch { }
        }

        public void Dispose()
        {
            Close();
        }

        //========================================================
        // CONNECT (timeout ke saath)
        //========================================================
        private bool TryConnect()
        {
            TcpClient c = new TcpClient();

            try
            {
                IAsyncResult ar = c.BeginConnect(IPAddress, Port, null, null);

                if (!ar.AsyncWaitHandle.WaitOne(ConnectTimeoutMs))
                {
                    c.Close();
                    return false;
                }

                c.EndConnect(ar);
                c.NoDelay = true;

                // TCP keep-alive: cable nikalne par 10 sec me pata chal jayega
                try
                {
                    byte[] keep = new byte[12];
                    BitConverter.GetBytes(1).CopyTo(keep, 0);      // on
                    BitConverter.GetBytes(10000).CopyTo(keep, 4);  // 10 sec idle ke baad
                    BitConverter.GetBytes(5000).CopyTo(keep, 8);   // phir har 5 sec
                    c.Client.IOControl(IOControlCode.KeepAliveValues, keep, null);
                }
                catch
                {
                    // keep-alive set na ho to bhi chalega
                }

                lock (_sync)
                {
                    if (!_running)
                    {
                        c.Close();
                        return false;
                    }

                    _client = c;
                }

                _connected = true;

                return true;
            }
            catch
            {
                try { c.Close(); } catch { }
                return false;
            }
        }

        //========================================================
        // WORKER THREAD
        // Blocking read - data na ho to CPU use nahi hota.
        //========================================================
        private void Run()
        {
            byte[] buffer = new byte[1024];

            while (_running)
            {
                try
                {
                    //============================================
                    // NOT CONNECTED -> wait, phir reconnect
                    //============================================
                    if (!_connected)
                    {
                        if (!AutoReconnect)
                            break;

                        if (_stop.WaitOne(ReconnectDelayMs))
                            break;

                        if (!_running)
                            break;

                        if (TryConnect())
                            RaiseConnectionChanged(true);

                        continue;
                    }

                    //============================================
                    // READ
                    //============================================
                    TcpClient c = _client;

                    if (c == null)
                    {
                        _connected = false;
                        continue;
                    }

                    int n = c.GetStream().Read(buffer, 0, buffer.Length);

                    // 0 = scanner ne connection band kar diya
                    if (n <= 0)
                    {
                        MarkDisconnected();
                        continue;
                    }

                    Dispatch(Encoding.ASCII.GetString(buffer, 0, n));
                }
                catch (Exception)
                {
                    if (!_running)
                        break;

                    MarkDisconnected();
                }
            }
        }

        private void MarkDisconnected()
        {
            bool wasConnected = _connected;

            _connected = false;

            TcpClient c;

            lock (_sync)
            {
                c = _client;
                _client = null;
            }

            try { if (c != null) c.Close(); } catch { }

            if (wasConnected && _running)
                RaiseConnectionChanged(false);
        }

        //========================================================
        // DATA -> har barcode alag event (CR/LF se split)
        //========================================================
        private void Dispatch(string text)
        {
            if (string.IsNullOrEmpty(text))
                return;

            string[] parts = text.Split(
                new[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                string msg = part.Trim();

                if (msg.Length == 0)
                    continue;

                try
                {
                    DataArrivalHandler h = DataArrived;

                    if (h != null)
                        h(IPAddress, msg);
                }
                catch
                {
                    // handler ki error se thread band nahi hoga
                }
            }
        }

        private void RaiseConnectionChanged(bool connected)
        {
            try
            {
                Action<bool> h = ConnectionChanged;

                if (h != null)
                    h(connected);
            }
            catch
            {
                // ignore
            }
        }
    }
}
