using DTPLLogs;
using Modbus.Device;
using StockCraft.BusinessLayer;
using StockCraft.DataLayer;
using StockCraft.PL;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockCraft.Forms.Transaction
{
    public partial class Inspection : Form
    {
        //========================================================
        // PLC
        //========================================================
        private TcpClient _plcClient;
        private ModbusIpMaster _modbusMaster;
        private System.Windows.Forms.Timer _plcTimer;
        private System.Windows.Forms.Timer _reconnectTimer;

        // Ek Modbus connection par read/write ek saath nahi ho sakte
        private readonly object _modbusLock = new object();

        public string MCPRINTERIP = "";

        private bool _previousPLCState = false;   // rising edge detection
        private bool _plcProcessing = false;      // child print chal raha hai
        private bool _tickBusy = false;           // PLC read chal raha hai
        private bool _plcStarted = false;         // user ne Start dabaya hai
        private bool _reconnecting = false;
        private bool _starting = false;

        private string _plcIpCfg = "";
        private int _plcPortCfg = 0;

        private int ngCount = 0;
        int scancount = 0;

        //========================================================
        // SINGLE INSTANCE PER LINE (same PC / same PLC)
        //========================================================
        private static readonly HashSet<string> ActiveLines = new HashSet<string>();
        private System.Threading.Mutex _lineMutex;
        private string _lineName = "";

        //========================================================
        // BACKGROUND WORK CONTROL
        //========================================================
        // Child print, scan processing - ek time par ek hi kaam
        private readonly System.Threading.SemaphoreSlim _workSem =
            new System.Threading.SemaphoreSlim(1, 1);

        // Dashboard update / work order complete - ek time par ek hi
        private readonly System.Threading.SemaphoreSlim _dashSem =
            new System.Threading.SemaphoreSlim(1, 1);

        //========================================================
        // LOG (DB save background thread par)
        //========================================================
        private readonly BlockingCollection<string> _logQueue =
            new BlockingCollection<string>();
        private readonly object _logLock = new object();
        private string _lastDbLog = "";
        private DateTime _lastDbLogTime = DateTime.MinValue;

        //========================================================
        // Scanner
        //========================================================
        // ClsSocket ki jagah safe ScannerClient (ScannerClient.cs)
        private ScannerClient objBin = new ScannerClient();

        //========================================================
        // Printing Data
        //========================================================
        private string ProductCode = "";
        private string Model = "";
        private string Wattage = "";
        private string Voltage = "";
        private string DegreeOfProtection = "";
        private string ICSERIALN = "";
        private string MCSERIALNO = "";
        private string PackSize = "";
        private string orderQty = "";
        private string OrderNumber = "";
        private string PartContent = "";

        //========================================================
        // UI VALUES SNAPSHOT (background thread UI control touch
        // nahi karega)
        //========================================================
        private class PrintContext
        {
            public string WorkOrder;
            public bool WorkOrderSelected;
            public string PartCode;
            public string PrinterIP;
            public string PrinterPort;
        }

        private PrintContext CaptureContext()
        {
            return new PrintContext
            {
                WorkOrder = cmbWorkOrderNo.Text.Trim(),
                WorkOrderSelected = cmbWorkOrderNo.SelectedIndex > 0,
                PartCode = TxtPartCode.Text.Trim(),
                PrinterIP = txtPrinterIP.Text.Trim(),
                PrinterPort = txtPrinterPort.Text.Trim()
            };
        }

        //========================================================
        // CONSTRUCTOR
        //========================================================
        public Inspection()
        {
            InitializeComponent();
            this.FormClosing += Inspection_FormClosing;

            // Multiple lines (forms) ek hi process me chalti hain. Har line ka
            // PLC read, save aur print thread pool use karta hai, isliye pool ko
            // pehle se taiyaar rakho (naye thread dene me der na lage).
            System.Threading.ThreadPool.SetMinThreads(32, 32);

            StartLogWorker();

            BindItemCode();
            BindWorkOrder();
        }

        private void Inspection_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StopPLC();   // PLC + scanner + timers + line lock sab band
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());
            }

            try { _logQueue.CompleteAdding(); } catch { }
        }

        //========================================================
        // THREAD SAFE UI HELPERS
        //========================================================
        private void RunOnUI(Action action)
        {
            try
            {
                if (IsDisposed || Disposing)
                    return;

                if (InvokeRequired)
                    BeginInvoke(action);
                else
                    action();
            }
            catch
            {
                // form band ho raha ho to ignore
            }
        }

        private void ShowMessageSafe(string message, int type)
        {
            RunOnUI(() => blCommon.ShowMessage(message, type));
        }

        private void SetHardwareStatus(string text, System.Drawing.Color color)
        {
            RunOnUI(() =>
            {
                Hardware.Text = text;
                Hardware.BackColor = color;
            });
        }

        private void AppendLog(string message)
        {
            RunOnUI(() => lstLog.Items.Add(message));
        }

        //========================================================
        // LOG
        // UI list turant update, DB save alag thread par
        // (same message 3 sec ke andar dobara aaye to DB skip)
        //========================================================
        private void StartLogWorker()
        {
            System.Threading.Thread t = new System.Threading.Thread(() =>
            {
                foreach (string m in _logQueue.GetConsumingEnumerable())
                {
                    try
                    {
                        new DLScanBarcode().SaveApplicationLog(m);
                    }
                    catch
                    {
                        // Do not throw from logging
                    }
                }
            });

            t.IsBackground = true;
            t.Name = "InspectionLogWriter";
            t.Start();
        }

        private void ShowLog(string message)
        {
            try
            {
                RunOnUI(() =>
                {
                    lstLog.Items.Clear();

                    if (!string.IsNullOrWhiteSpace(message))
                        lstLog.Items.Add(message);
                });

                if (string.IsNullOrWhiteSpace(message))
                    return;

                bool skip;

                lock (_logLock)
                {
                    skip = message == _lastDbLog &&
                           (DateTime.Now - _lastDbLogTime).TotalSeconds < 3;

                    if (!skip)
                    {
                        _lastDbLog = message;
                        _lastDbLogTime = DateTime.Now;
                    }
                }

                if (!skip && !_logQueue.IsAddingCompleted)
                    _logQueue.Add(message);
            }
            catch
            {
                // Do not throw from logging method
            }
        }

        //========================================================
        // BIND LINE
        //========================================================
        public void BindItemCode()
        {
            try
            {
                DLScanBarcode obj = new DLScanBarcode();

                DataTable dt = obj.dtBindLine();

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Same system can run multiple lines.
                    blCommon.FillComboBox(
                        cmbLineCode,
                        dt,
                        true);
                }
                else
                {
                    blCommon.ShowMessage(
                        "No line found.",
                        3);
                }
            }
            catch (Exception ex)
            {
                ShowLog("Line Load Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private string GetLineCodeByIP(string systemIP)
        {
            string configPath = Path.Combine(
                Application.StartupPath,
                "LineConfig.txt");

            if (!File.Exists(configPath))
                return "";

            string[] lines = File.ReadAllLines(configPath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] data = line.Split('=');

                if (data.Length == 2)
                {
                    string ip = data[0].Trim();
                    string lineCode = data[1].Trim();

                    if (ip == systemIP)
                        return lineCode;
                }
            }

            return "";
        }

        private string GetSystemIP()
        {
            foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }

            return "";
        }

        private string GetNextSerial(string serial)
        {
            if (string.IsNullOrWhiteSpace(serial))
                return "";

            Match match = Regex.Match(
                serial.Trim(),
                @"^(.*?)(\d+)$");

            if (!match.Success)
                return "";

            string prefix = match.Groups[1].Value;
            string number = match.Groups[2].Value;

            try
            {
                BigInteger currentNumber = BigInteger.Parse(number);
                BigInteger nextNumber = currentNumber + 1;

                return prefix + nextNumber.ToString().PadLeft(number.Length, '0');
            }
            catch
            {
                return "";
            }
        }

        //========================================================
        // BIND WORK ORDER
        //========================================================
        public void BindWorkOrder()
        {
            try
            {
                DLWorkOrder obj = new DLWorkOrder();

                DataTable dt = obj.dtBindWorkOrder();

                if (dt != null && dt.Rows.Count > 0)
                {
                    blCommon.FillComboBox(
                        cmbWorkOrderNo,
                        dt,
                        true);
                }
            }
            catch (Exception ex)
            {
                ShowLog("Work Order Load Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        //========================================================
        // CHILD PRINT (save first, then print)
        // Background thread par chalta hai - UI control touch nahi
        // karta, sirf ctx use karta hai.
        //========================================================
        private bool GetPrintringData(PrintContext ctx)
        {
            ProductCode = "";
            Model = "";
            Wattage = "";
            Voltage = "";
            DegreeOfProtection = "";
            MCSERIALNO = "";
            ICSERIALN = "";
            PackSize = "";
            orderQty = "";
            OrderNumber = "";
            PartContent = "";

            try
            {
                ShowLog("");

                //================================================
                // 1. VALIDATION
                //================================================
                if (!ctx.WorkOrderSelected)
                {
                    ShowLog("Please select Work Order.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(ctx.PartCode))
                {
                    ShowLog("Please select Part Code.");
                    return false;
                }

                //================================================
                // 2. GET CHILD PRINT DATA
                // GETSERIAL mein SQL already next unprinted
                // serial dega.
                //================================================
                DLScanBarcode obj = new DLScanBarcode();

                DataTable dt =
                    obj.GetChildPrintDataDetails(
                        ctx.WorkOrder,
                        ctx.PartCode);

                if (dt == null || dt.Rows.Count == 0)
                {
                    ShowLog("No unprinted child serial found.");
                    return false;
                }

                //================================================
                // 3. GET DATA
                //================================================
                DataRow row = dt.Rows[0];

                ProductCode = row[0]?.ToString().Trim();
                Model = row[1]?.ToString().Trim();
                Wattage = row[2]?.ToString().Trim();
                Voltage = row[3]?.ToString().Trim();
                DegreeOfProtection = row[4]?.ToString().Trim();
                ICSERIALN = row[5]?.ToString().Trim();
                MCSERIALNO = row[6]?.ToString().Trim();
                PackSize = row[7]?.ToString().Trim();
                orderQty = row[8]?.ToString().Trim();
                OrderNumber = row[9]?.ToString().Trim();
                PartContent = row[10]?.ToString().Trim();

                //================================================
                // 4. DATA VALIDATION
                //================================================
                if (string.IsNullOrWhiteSpace(ProductCode))
                {
                    ShowLog("Product Code Missing.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(ICSERIALN))
                {
                    ShowLog("IB Serial Missing.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(MCSERIALNO))
                {
                    ShowLog("Master Carton Serial Missing.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(PackSize))
                {
                    ShowLog("Pack Size Missing.");
                    return false;
                }

                //================================================
                // 5. LOG CURRENT SERIAL
                //================================================
                ShowLog(
                    "Next Child Serial | IC: " +
                    ICSERIALN +
                    " | MC: " +
                    MCSERIALNO);

                //================================================
                // 6. FINAL DUPLICATE + NEXT SERIAL CHECK
                //================================================
                DL_Printing ob = new DL_Printing();

                DataTable dtNext =
                    ob.CheckNextChild(
                        ctx.WorkOrder,
                        ctx.PartCode,
                        ICSERIALN.Trim());

                if (dtNext == null || dtNext.Rows.Count == 0)
                {
                    ShowLog("Serial validation failed.");
                    return false;
                }

                string checkResult =
                    dtNext.Rows[0]["Result"]
                    .ToString()
                    .Trim()
                    .ToUpper();

                //================================================
                // 7. DUPLICATE
                //================================================
                if (checkResult == "DUPLICATE")
                {
                    ShowLog(
                        "DUPLICATE PRINT BLOCKED | IC: " +
                        ICSERIALN +
                        " | MC: " +
                        MCSERIALNO);

                    return false;
                }

                //================================================
                // 8. WRONG NEXT SERIAL
                //================================================
                if (checkResult == "NOTNEXT")
                {
                    string expectedIC =
                        dtNext.Rows[0]["ExpectedICSerial"].ToString().Trim();

                    string expectedMC =
                        dtNext.Rows[0]["ExpectedMCSerial"].ToString().Trim();

                    ShowLog(
                        "WRONG SERIAL | Expected IC: " +
                        expectedIC +
                        " | Received IC: " +
                        ICSERIALN);

                    ShowLog(
                        "Expected MC: " +
                        expectedMC +
                        " | Received MC: " +
                        MCSERIALNO);

                    return false;
                }

                //================================================
                // 9. ALL PRINTED
                //================================================
                if (checkResult == "COMPLETE")
                {
                    ShowLog("All Child Serials Already Printed.");
                    return false;
                }

                //================================================
                // 10. ERROR
                //================================================
                if (checkResult != "AVAILABLE")
                {
                    string message =
                        dtNext.Rows[0]["Message"].ToString().Trim();

                    ShowLog("Serial Check Error: " + message);
                    return false;
                }

                //================================================
                // 11. SERIAL OK
                //================================================
                ShowLog(
                    "Serial Validation OK | IC: " +
                    ICSERIALN +
                    " | MC: " +
                    MCSERIALNO);

                //================================================
                // 12. PRINT PRE-CHECK
                // Save aur print saath chalenge, isliye pehle dekh lo
                // ki print ho sakta hai. Warna serial "printed" mark ho
                // jayega aur label nahi niklega.
                //================================================
                if (!File.Exists(Path.Combine(Application.StartupPath, "STOCKCRAFT.prn")))
                {
                    ShowLog("Child Printer Command File Not Found.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(ctx.PrinterIP) ||
                    !int.TryParse(ctx.PrinterPort, out _))
                {
                    ShowLog("Printer IP / Port Missing or Invalid.");
                    return false;
                }

                //================================================
                // 13. SAVE + PRINT EK SAATH (turant save, turant print)
                // Save background task me, print isi thread par.
                // Total time = max(save, print), save + print nahi.
                //================================================
                string wo = ctx.WorkOrder;
                string part = ctx.PartCode;
                string pc = ProductCode;
                string mdl = Model;
                string wat = Wattage;
                string vol = Voltage;
                string dop = DegreeOfProtection;
                string ic = ICSERIALN;
                string mc = MCSERIALNO;
                string pack = PackSize;
                string content = PartContent;

                Task<DataTable> saveTask = Task.Run(() =>
                    ob.SaveChildPrint(
                        wo,
                        part,
                        content,
                        pc,
                        mdl,
                        wat,
                        vol,
                        dop,
                        ic,
                        mc,
                        pack,
                        false));

                ShowLog("Saving + Printing Child Label | IC: " + ic);

                bool printStatus =
                    PrintLabel(
                        ctx,
                        pc,
                        mdl,
                        wat,
                        vol,
                        dop,
                        ic);

                //================================================
                // 14. SAVE RESULT
                //================================================
                DataTable dtSave = null;
                string saveError = "";

                try
                {
                    dtSave = saveTask.GetAwaiter().GetResult();
                }
                catch (Exception saveEx)
                {
                    saveError = saveEx.Message;

                    PCommon.mAppLog.WriteLog(
                        saveEx.Message,
                        DTPLLogsWrite.LogType.Error,
                        MethodBase.GetCurrentMethod());
                }

                string saveResult =
                    (dtSave != null && dtSave.Rows.Count > 0)
                        ? dtSave.Rows[0][0].ToString().Trim().ToUpper()
                        : "";

                bool saveOk = saveResult.StartsWith("SUCCESS");

                //================================================
                // 15. SAVE FAILED
                //================================================
                if (!saveOk)
                {
                    string why =
                        saveError != "" ? saveError :
                        saveResult != "" ? saveResult :
                        "no response";

                    if (printStatus)
                    {
                        // Label nikal chuka hai par DB me save nahi hua:
                        // agla trigger yahi serial dobara print karega.
                        ShowLog(
                            "LABEL PRINT HO GAYA PAR SAVE FAIL | IC: " +
                            ic + " | " + why);

                        ShowMessageSafe(
                            "Label print ho gaya par save fail hua (IC: " + ic +
                            ").\nIs label ko hata do, agla trigger yahi serial dobara print karega.",
                            3);
                    }
                    else
                    {
                        ShowLog("Child Print Save Error: " + why);
                    }

                    return false;
                }

                //================================================
                // 16. PRINT FAILED (save ho chuka hai)
                //================================================
                if (!printStatus)
                {
                    ShowLog(
                        "Child Print Failed (save ho chuka hai) | IC: " +
                        ic);

                    return false;
                }

                //================================================
                // 17. SAVED + PRINTED
                //================================================
                ShowLog(
                    "Child Print Saved + Printed | IC: " +
                    ic +
                    " | MC: " +
                    mc);

                ShowLog(
                    "PRINTING COMPLETED | IC: " +
                    ic +
                    " | MC: " +
                    mc);

                return true;
            }
            catch (Exception ex)
            {
                ShowLog("Get Printing Data Error: " + ex.Message);
                ShowMessageSafe(ex.Message, 3);
                return false;
            }
        }

        //========================================================
        // PRINTER SEND (timeout ke saath)
        // blCommon.SendCommandToPrinter ka timeout pata nahi,
        // isliye 8 sec se zyada nahi rukenge.
        //========================================================
        private void SendToPrinterSafe(string ip, int port, string data)
        {
            Task t = Task.Run(() =>
            {
                blCommon.SendCommandToPrinter(ip, port, data);
            });

            bool finished;

            try
            {
                finished = t.Wait(8000);
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException ?? ae;
            }

            if (!finished)
                throw new Exception("Printer timeout (" + ip + ":" + port + ").");
        }

        //========================================================
        // CHILD LABEL PRINT
        //========================================================
        private bool PrintLabel(
            PrintContext ctx,
            string ProductCode,
            string Model,
            string Wattage,
            string Voltage,
            string DegreeOfProtection,
            string ICSERIALN)
        {
            try
            {
                ShowLog("");

                //================================================
                // 1. IC SERIAL VALIDATION
                //================================================
                if (string.IsNullOrWhiteSpace(ICSERIALN))
                {
                    ShowLog("IC Serial Missing.");
                    return false;
                }

                //================================================
                // 2. PRINTER COMMAND FILE
                //================================================
                string filePath =
                    Path.Combine(
                        Application.StartupPath,
                        "STOCKCRAFT.prn");

                if (!File.Exists(filePath))
                {
                    ShowLog("Child Printer Command File Not Found.");
                    return false;
                }

                //================================================
                // 3. PRINTER IP VALIDATION
                //================================================
                if (string.IsNullOrWhiteSpace(ctx.PrinterIP))
                {
                    ShowLog("Printer IP Missing.");
                    return false;
                }

                //================================================
                // 4. PRINTER PORT VALIDATION
                //================================================
                int printerPort;

                if (!int.TryParse(ctx.PrinterPort, out printerPort))
                {
                    ShowLog("Invalid Printer Port.");
                    return false;
                }

                //================================================
                // 5. READ PRN FILE + REPLACE PRINT DATA
                //================================================
                string tempFileTextLine = File.ReadAllText(filePath);

                tempFileTextLine =
                    tempFileTextLine.Replace("ProductCode", ProductCode ?? "");

                tempFileTextLine =
                    tempFileTextLine.Replace("HVARBARCODE", ICSERIALN ?? "");

                tempFileTextLine =
                    tempFileTextLine.Replace("Text", ICSERIALN ?? "");

                //================================================
                // 6. SEND CHILD PRINT
                //================================================
                SendToPrinterSafe(
                    ctx.PrinterIP,
                    printerPort,
                    tempFileTextLine);

                ShowLog("Child Label Printed Successfully.");

                return true;
            }
            catch (Exception ex)
            {
                ShowLog("Child Print Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                ShowMessageSafe(ex.Message, 3);

                return false;
            }
        }

        //========================================================
        // SCANNER CONNECTION
        // Background thread par chalta hai (Open() block kar sakta hai)
        //========================================================
        public bool FMSConnection(string scannerIP, int scannerPort)
        {
            try
            {
                ShowLog("");

                if (string.IsNullOrWhiteSpace(scannerIP))
                {
                    ShowLog("Scanner IP Missing.");
                    return false;
                }

                objBin.IPAddress = scannerIP;
                objBin.Port = scannerPort;

                // Purana event hata ke naya lagao (duplicate event nahi)
                objBin.DataArrived -= objBin_DataArrived;
                objBin.DataArrived += objBin_DataArrived;
                objBin.ConnectionChanged -= objBin_ConnectionChanged;
                objBin.ConnectionChanged += objBin_ConnectionChanged;

                if (!objBin.Open())
                {
                    ShowLog("Scanner Connection Failed. Auto reconnect chalu hai.");
                    return false;
                }

                ShowLog("Scanner Connected.");

                return true;
            }
            catch (Exception ex)
            {
                ShowLog("Scanner Connection Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                ShowMessageSafe(ex.Message, 3);

                return false;
            }
        }

        //========================================================
        // SCANNER CLOSE
        // Event hatao, socket band karo, thread band karo.
        //========================================================
        private void CloseScanner()
        {
            try
            {
                objBin.DataArrived -= objBin_DataArrived;
                objBin.ConnectionChanged -= objBin_ConnectionChanged;
                objBin.Close();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());
            }
        }

        //========================================================
        // SCANNER CONNECT / DISCONNECT (auto reconnect ke saath)
        // Scanner thread se aata hai - sirf thread-safe helpers use.
        //========================================================
        private void objBin_ConnectionChanged(bool connected)
        {
            if (connected)
            {
                ShowLog("Scanner Connected.");

                if (_modbusMaster != null)
                {
                    SetHardwareStatus(
                        "All Hardware Connected",
                        System.Drawing.Color.Green);
                }
            }
            else
            {
                ShowLog("Scanner Disconnected - reconnecting...");

                SetHardwareStatus(
                    "Scanner Disconnected",
                    System.Drawing.Color.Red);
            }
        }

        //========================================================
        // SCANNER DATA ARRIVED
        // Scanner thread se UI thread par shift
        //========================================================
        private void objBin_DataArrived(
            string ClientIP,
            string Message)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Message))
                    return;

                string barcode = Message.Trim();

                if (barcode.StartsWith("001"))
                {
                    barcode = barcode.Substring(3).Trim();
                }

                if (this.IsDisposed || !this.IsHandleCreated)
                    return;

                this.BeginInvoke(new Action(() => HandleScan(barcode)));
            }
            catch (Exception ex)
            {
                ShowLog("Scanner Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());
            }
        }

        //========================================================
        // HANDLE SCAN (UI thread par start, kaam background mein)
        // Scans line mein lagte hain - ek ke baad ek process honge
        //========================================================
        private async void HandleScan(string barcode)
        {
            try
            {
                await _workSem.WaitAsync();

                try
                {
                    PrintContext ctx = CaptureContext();

                    await Task.Run(() => ProcessScanBarcode(barcode, ctx));
                }
                finally
                {
                    _workSem.Release();
                }
            }
            catch (Exception ex)
            {
                ShowLog("Scan Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());
            }
        }

        //========================================================
        // PROCESS SCANNED CHILD SERIAL (background thread)
        //
        // IBSerial -> MCBoxSerial
        // Same MCBoxSerial ka scan count increment hoga.
        // PackSize match hone par master print hoga.
        //========================================================
        private void ProcessScanBarcode(
            string barcode,
            PrintContext ctx)
        {
            try
            {
                if (!ValidatePrintedScan(barcode, ctx))
                    return;

                if (string.IsNullOrWhiteSpace(barcode))
                    return;

                if (!ctx.WorkOrderSelected)
                {
                    ShowLog("Please select Work Order.");
                    SendNGSignal();
                    return;
                }

                if (string.IsNullOrWhiteSpace(ctx.PartCode))
                {
                    ShowLog("Part Code Missing.");
                    SendNGSignal();
                    return;
                }

                DLScanBarcode objPrinting = new DLScanBarcode();

                //================================================
                // UPDATE SCAN COUNT
                //================================================
                DataTable dt =
                    objPrinting.UpdateScanCount(
                        ctx.WorkOrder,
                        ctx.PartCode,
                        barcode);

                if (dt == null || dt.Rows.Count == 0)
                {
                    ShowLog("Scan data not found.");
                    SendNGSignal();
                    return;
                }

                string result =
                    dt.Rows[0]["Result"]
                    .ToString()
                    .Trim()
                    .ToUpper();

                //================================================
                // ERROR
                //================================================
                if (result == "ERROR")
                {
                    ShowLog(dt.Rows[0]["Message"].ToString());
                    SendNGSignal();
                    return;
                }

                //================================================
                // DUPLICATE
                //================================================
                if (result == "DUPLICATE")
                {
                    ShowLog("Duplicate Child Serial: " + barcode);
                    SendNGSignal();
                    return;
                }

                //================================================
                // MASTER ALREADY COMPLETED
                //================================================
                if (result == "COMPLETED")
                {
                    ShowLog("Master Carton already completed.");
                    return;
                }

                //================================================
                // SUCCESS
                //================================================
                if (result == "SUCCESS")
                {
                    int scanCount = Convert.ToInt32(dt.Rows[0]["ScanCount"]);
                    int packSize = Convert.ToInt32(dt.Rows[0]["PackSize"]);
                    string mcBoxSerial = dt.Rows[0]["MCBoxSerial"].ToString();
                    string ibSerial = dt.Rows[0]["IBSerial"].ToString();

                    //============================================
                    // SAVE SCAN HISTORY
                    //============================================
                    try
                    {
                        DL_Printing objHistory = new DL_Printing();

                        objHistory.SaveScanHistory(
                            ctx.WorkOrder,
                            ctx.PartCode,
                            "",
                            barcode,
                            ibSerial,
                            mcBoxSerial,
                            packSize.ToString(),
                            scanCount,
                            "SUCCESS");
                    }
                    catch (Exception historyEx)
                    {
                        PCommon.mAppLog.WriteLog(
                            historyEx.Message,
                            DTPLLogs.DTPLLogsWrite.LogType.Error,
                            MethodBase.GetCurrentMethod());
                    }

                    //============================================
                    // DISPLAY CURRENT SCAN
                    //============================================
                    ShowLog("Master Carton: " + mcBoxSerial);
                    AppendLog("Child Serial: " + barcode);
                    AppendLog("Scan Count: " + scanCount + " / " + packSize);

                    //============================================
                    // PACK SIZE MATCH -> MASTER PRINT
                    //============================================
                    if (scanCount >= packSize)
                    {
                        if (!PrintMasterLabel(mcBoxSerial, packSize, ctx))
                        {
                            SendNGSignal();
                            return;
                        }

                        ShowLog("Master Carton Printed Successfully.");
                        AppendLog("MC Serial: " + mcBoxSerial);
                        AppendLog("Child Scan: " + scanCount + " / " + packSize);
                    }

                    RunOnUI(UpdateDashboard);
                }
            }
            catch (Exception ex)
            {
                ShowLog("Scan Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                ShowMessageSafe(ex.Message, 3);
            }
        }

        //========================================================
        // MASTER LABEL PRINT (save first, then print)
        //========================================================
        private bool PrintMasterLabel(
            string mcBoxSerial,
            int packSize,
            PrintContext ctx)
        {
            try
            {
                ShowLog("");

                if (string.IsNullOrWhiteSpace(mcBoxSerial))
                {
                    ShowLog("Master Carton Serial Missing.");
                    return false;
                }

                string filePath =
                    Path.Combine(
                        Application.StartupPath,
                        "STOCKRAFMC.prn");

                if (!File.Exists(filePath))
                {
                    ShowLog("Master Printer Command File Not Found.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(MCPRINTERIP))
                {
                    ShowLog("Master Printer IP Missing.");
                    return false;
                }

                //================================================
                // MASTER PRINT HISTORY - FIRST SAVE
                //================================================
                try
                {
                    DL_Printing objHistory = new DL_Printing();

                    objHistory.SaveMasterPrint(
                        ctx.WorkOrder,
                        ctx.PartCode,
                        "",
                        ProductCode,
                        Model,
                        Wattage,
                        Voltage,
                        DegreeOfProtection,
                        mcBoxSerial,
                        packSize,
                        false);
                }
                catch (Exception historyEx)
                {
                    PCommon.mAppLog.WriteLog(
                        historyEx.Message,
                        DTPLLogs.DTPLLogsWrite.LogType.Error,
                        MethodBase.GetCurrentMethod());

                    ShowLog("Master Print History Save Failed: " + historyEx.Message);

                    return false;
                }

                //================================================
                // PRN FILE DATA
                //================================================
                string tempFileTextLine = File.ReadAllText(filePath);

                tempFileTextLine =
                    tempFileTextLine.Replace("HvarBarcode", mcBoxSerial);

                tempFileTextLine =
                    tempFileTextLine.Replace("Text", mcBoxSerial);

                tempFileTextLine =
                    tempFileTextLine.Replace("ProductCode", ctx.PartCode);

                int printerPortMc = 9100;

                //================================================
                // SEND MASTER PRINT - AFTER SAVE
                //================================================
                SendToPrinterSafe(
                    MCPRINTERIP,
                    printerPortMc,
                    tempFileTextLine);

                return true;
            }
            catch (Exception ex)
            {
                ShowLog("Master Print Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                ShowMessageSafe(ex.Message, 3);

                return false;
            }
        }

        //========================================================
        // DASHBOARD
        // UI thread par call karo (DB kaam background mein hota hai).
        // Ek time par ek hi update chalega.
        //========================================================
        private async void UpdateDashboard()
        {
            await _dashSem.WaitAsync();

            try
            {
                string workOrder = cmbWorkOrderNo.Text.Trim();
                string partCode = TxtPartCode.Text.Trim();

                if (string.IsNullOrWhiteSpace(workOrder))
                    return;

                if (string.IsNullOrWhiteSpace(partCode))
                    return;

                DL_Printing objPrinting = new DL_Printing();

                DataTable dt =
                    await Task.Run(() =>
                        objPrinting.GetDashboardData(workOrder, partCode));

                if (dt == null || dt.Rows.Count == 0)
                    return;

                DataRow row = dt.Rows[0];

                // TOP ROW
                int totalMCQty = Convert.ToInt32(row["TotalMCQty"]);
                int completedMC = Convert.ToInt32(row["CompletedMC"]);
                int balanceMC = Convert.ToInt32(row["BalanceMC"]);
                int masterPrint = Convert.ToInt32(row["MasterPrint"]);

                // BOTTOM ROW
                int packSize = Convert.ToInt32(row["PackSize"]);
                int scannedCount = Convert.ToInt32(row["ScannedCount"]);
                int balance = Convert.ToInt32(row["Balance"]);
                int icPrint = Convert.ToInt32(row["ICPrint"]);

                //================================================
                // WORK ORDER COMPLETE
                //================================================
                if (totalMCQty > 0 && totalMCQty == completedMC)
                {
                    DataTable dtComplete =
                        await Task.Run(() =>
                            objPrinting.CompleteWorkOrder(workOrder));

                    if (dtComplete == null || dtComplete.Rows.Count == 0)
                    {
                        ShowLog("Work Order completion failed.");
                        return;
                    }

                    string completeResult =
                        dtComplete.Rows[0]["Result"]
                        .ToString()
                        .Trim()
                        .ToUpper();

                    if (completeResult == "SUCCESS")
                    {
                        ShowLog("WORK ORDER COMPLETED: " + workOrder);

                        // DASHBOARD CLEAR
                        lblTotalCount.Text = "0";
                        lblCompletedMc.Text = "0";
                        lblBanlmcCount.Text = "0";
                        lblMsterPrint.Text = "0";

                        txtpacksize.Text = "0";
                        txtScannedCount.Text = "0";
                        txtbalanceIC.Text = "0";
                        Icprintm.Text = "0";

                        // SERIAL / PRINT DATA CLEAR
                        ProductCode = "";
                        Model = "";
                        Wattage = "";
                        Voltage = "";
                        DegreeOfProtection = "";
                        MCSERIALNO = "";
                        ICSERIALN = "";
                        PackSize = "";
                        orderQty = "";
                        OrderNumber = "";

                        // TEXTBOX CLEAR
                        txtPlcTrigger.Text = "";
                        TxtPartCode.Clear();

                        // WORK ORDER COMBO RESET
                        cmbWorkOrderNo.SelectedIndex = -1;

                        ShowLog("Work Order Completed Successfully.");

                        MessageBox.Show(
                            "Work Order Completed Successfully.",
                            "Work Order Complete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        return;
                    }

                    // COMPLETE FAILED
                    ShowLog(dtComplete.Rows[0]["Message"].ToString());

                    return;
                }

                //================================================
                // NORMAL DASHBOARD UPDATE
                //================================================
                lblTotalCount.Text = totalMCQty.ToString();
                lblCompletedMc.Text = completedMC.ToString();
                lblBanlmcCount.Text = balanceMC.ToString();
                lblMsterPrint.Text = masterPrint.ToString();

                txtpacksize.Text = packSize.ToString();
                txtScannedCount.Text = scannedCount.ToString();
                txtbalanceIC.Text = balance.ToString();
                Icprintm.Text = icPrint.ToString();
            }
            catch (Exception ex)
            {
                lstLog.Items.Clear();
                lstLog.Items.Add("Dashboard Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());
            }
            finally
            {
                _dashSem.Release();
            }
        }

        //========================================================
        // SINGLE INSTANCE LOCK
        // Same PC par same PLC (IP:Port) ke liye ek hi Inspection
        // chal sakta hai. Same exe ka doosra instance bhi block
        // hoga aur same exe ke andar doosra form bhi.
        //========================================================
        private bool AcquireLineLock(string ip, int port)
        {
            ReleaseLineLock();

            string name = "StockCraft_Inspection_" + ip.Replace(':', '_') + "_" + port;

            // Same process ke andar doosra form
            lock (ActiveLines)
            {
                if (!ActiveLines.Add(name))
                {
                    ShowLog("This line is already running (" + ip + ":" + port + ").");
                    return false;
                }
            }

            // Same PC ke doosre exe instance
            try
            {
                System.Threading.Mutex m =
                    new System.Threading.Mutex(false, @"Global\" + name);

                bool got;

                try
                {
                    got = m.WaitOne(0);
                }
                catch (System.Threading.AbandonedMutexException)
                {
                    // Pichla instance crash hua tha, ab hamara hai
                    got = true;
                }

                if (!got)
                {
                    m.Close();

                    lock (ActiveLines) { ActiveLines.Remove(name); }

                    ShowLog("This line is already running on this system (" + ip + ":" + port + ").");
                    return false;
                }

                _lineMutex = m;
            }
            catch (Exception ex)
            {
                // Mutex na ban sake to bhi kaam rukna nahi chahiye
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());
            }

            _lineName = name;

            return true;
        }

        private void ReleaseLineLock()
        {
            try
            {
                if (_lineMutex != null)
                {
                    try { _lineMutex.ReleaseMutex(); } catch { }
                    _lineMutex.Close();
                    _lineMutex = null;
                }

                if (_lineName != "")
                {
                    lock (ActiveLines) { ActiveLines.Remove(_lineName); }
                    _lineName = "";
                }
            }
            catch
            {
                // ignore
            }
        }

        //========================================================
        // PLC CONNECT (timeout ke saath)
        //========================================================
        private TcpClient ConnectWithTimeout(string ip, int port, int timeoutMs = 3000)
        {
            TcpClient c = new TcpClient();

            try
            {
                IAsyncResult ar = c.BeginConnect(ip, port, null, null);

                if (!ar.AsyncWaitHandle.WaitOne(timeoutMs))
                {
                    c.Close();
                    throw new Exception("PLC connection timeout (" + ip + ":" + port + ").");
                }

                c.EndConnect(ar);

                c.SendTimeout = 2000;
                c.ReceiveTimeout = 2000;

                return c;
            }
            catch
            {
                c.Close();
                throw;
            }
        }

        private ModbusIpMaster CreateMaster(TcpClient client)
        {
            ModbusIpMaster m = ModbusIpMaster.CreateIp(client);

            // Agar in 3 lines par build error aaye (library version),
            // inhe hata do - socket timeout upar set ho chuka hai.
            m.Transport.ReadTimeout = 2000;
            m.Transport.WriteTimeout = 2000;
            m.Transport.Retries = 1;

            return m;
        }

        //========================================================
        // START PLC
        //========================================================
        private async void btnstrt_Click(
            object sender,
            EventArgs e)
        {
            if (_starting)
                return;

            _starting = true;

            Control btn = sender as Control;
            if (btn != null) btn.Enabled = false;

            try
            {
                ShowLog("");

                string plcIp = txtPLCIP.Text.Trim();

                if (string.IsNullOrWhiteSpace(plcIp))
                {
                    ShowLog("PLC IP Missing.");
                    return;
                }

                int port;

                if (!int.TryParse(txtPLCPort.Text.Trim(), out port))
                {
                    ShowLog("Invalid PLC Port.");
                    return;
                }

                string scannerIp = txtScannerIP.Text.Trim();
                int scannerPort;

                if (string.IsNullOrWhiteSpace(scannerIp))
                {
                    ShowLog("Scanner IP Missing.");
                    return;
                }

                if (!int.TryParse(txtScannerPort.Text.Trim(), out scannerPort))
                {
                    ShowLog("Invalid Scanner Data Port.");
                    return;
                }

                //================================================
                // STOP OLD PLC / SCANNER
                //================================================
                StopPLC();

                //================================================
                // ONE LINE = ONE INSTANCE
                //================================================
                if (!AcquireLineLock(plcIp, port))
                    return;

                //================================================
                // CONNECT PLC (background, UI freeze nahi hoga)
                //================================================
                TcpClient client =
                    await Task.Run(() => ConnectWithTimeout(plcIp, port));

                lock (_modbusLock)
                {
                    _plcClient = client;
                    _modbusMaster = CreateMaster(client);
                }

                _plcIpCfg = plcIp;
                _plcPortCfg = port;
                _plcStarted = true;

                //================================================
                // RESET STATE + TIMER
                //================================================
                _previousPLCState = false;
                _plcProcessing = false;
                _tickBusy = false;

                StartPollTimer();

                ShowLog("PLC Connected Successfully.");

                //================================================
                // CONNECT SCANNER (background)
                //================================================
                bool scannerOk =
                    await Task.Run(() => FMSConnection(scannerIp, scannerPort));

                if (scannerOk)
                {
                    SetHardwareStatus(
                        "All Hardware Connected",
                        System.Drawing.Color.Green);
                }
                else
                {
                    SetHardwareStatus(
                        "Scanner Not Connected",
                        System.Drawing.Color.Red);
                }
            }
            catch (Exception ex)
            {
                StopPLC();

                SetHardwareStatus(
                    "PLC Not Connected",
                    System.Drawing.Color.Red);

                ShowLog("PLC Connection Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                blCommon.ShowMessage(ex.Message, 3);
            }
            finally
            {
                _starting = false;

                if (btn != null && !btn.IsDisposed)
                    btn.Enabled = true;
            }
        }

        //========================================================
        // POLL TIMER
        //========================================================
        private void StartPollTimer()
        {
            StopPollTimer();

            _plcTimer = new System.Windows.Forms.Timer();
            _plcTimer.Interval = 10;
            _plcTimer.Tick += PlcTimer_Tick;
            _plcTimer.Start();
        }

        private void StopPollTimer()
        {
            if (_plcTimer != null)
            {
                _plcTimer.Stop();
                _plcTimer.Tick -= PlcTimer_Tick;
                _plcTimer.Dispose();
                _plcTimer = null;
            }
        }

        //========================================================
        // PLC TIMER
        // PLC read background thread par hota hai, UI freeze nahi
        // hota. Sirf Rising Edge par process hoga.
        //
        // OFF -> ON = 1 trigger
        // ON -> ON  = no new trigger
        // ON -> OFF = reset
        //
        // Print chal raha ho tab aaya trigger ignore hoga
        // (pehle jaisa behaviour), lekin PLC state padhna band
        // nahi hota, isliye galat edge nahi banega.
        //========================================================
        private async void PlcTimer_Tick(
            object sender,
            EventArgs e)
        {
            if (_tickBusy)
                return;

            _tickBusy = true;

            try
            {
                ModbusIpMaster master = _modbusMaster;

                if (master == null)
                    return;

                ushort address;

                if (!ushort.TryParse(
                    ConfigurationManager.AppSettings["PLC_SENSOR_ADDRESS"],
                    out address))
                {
                    StopPollTimer();
                    ShowLog("Invalid PLC_SENSOR_ADDRESS in App.config.");
                    return;
                }

                bool[] result =
                    await Task.Run(() =>
                    {
                        lock (_modbusLock)
                        {
                            return master.ReadCoils(address, 1);
                        }
                    });

                bool currentPLCState =
                    result != null &&
                    result.Length > 0 &&
                    result[0];

                bool risingEdge = currentPLCState && !_previousPLCState;

                _previousPLCState = currentPLCState;

                if (risingEdge && !_plcProcessing)
                {
                    ProcessPlcTrigger();
                }
            }
            catch (Exception ex)
            {
                HandlePlcError(ex);
            }
            finally
            {
                _tickBusy = false;
            }
        }

        //========================================================
        // PLC TRIGGER -> CHILD PRINT
        //========================================================
        private async void ProcessPlcTrigger()
        {
            _plcProcessing = true;

            try
            {
                scancount++;
                txtPlcTrigger.Text = scancount.ToString();

                await _workSem.WaitAsync();

                try
                {
                    PrintContext ctx = CaptureContext();

                    bool ok = await Task.Run(() => GetPrintringData(ctx));

                    if (ok)
                        UpdateDashboard();
                }
                finally
                {
                    _workSem.Release();
                }
            }
            catch (Exception ex)
            {
                ShowLog("Trigger Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());
            }
            finally
            {
                _plcProcessing = false;
            }
        }

        //========================================================
        // PLC ERROR -> timer roko, ek baar log, auto reconnect
        // (pehle har 100 ms par error + DB log hota tha)
        //========================================================
        private void HandlePlcError(Exception ex)
        {
            StopPollTimer();
            _previousPLCState = false;

            CloseModbus();

            ShowLog("PLC Error: " + ex.Message);

            PCommon.mAppLog.WriteLog(
                ex.Message,
                DTPLLogs.DTPLLogsWrite.LogType.Error,
                MethodBase.GetCurrentMethod());

            SetHardwareStatus(
                "PLC Disconnected - Reconnecting...",
                System.Drawing.Color.Red);

            if (_plcStarted)
                StartReconnectTimer();
        }

        private void StartReconnectTimer()
        {
            StopReconnectTimer();

            _reconnectTimer = new System.Windows.Forms.Timer();
            _reconnectTimer.Interval = 3000;
            _reconnectTimer.Tick += ReconnectTimer_Tick;
            _reconnectTimer.Start();
        }

        private void StopReconnectTimer()
        {
            if (_reconnectTimer != null)
            {
                _reconnectTimer.Stop();
                _reconnectTimer.Tick -= ReconnectTimer_Tick;
                _reconnectTimer.Dispose();
                _reconnectTimer = null;
            }
        }

        private async void ReconnectTimer_Tick(
            object sender,
            EventArgs e)
        {
            if (_reconnecting || !_plcStarted)
                return;

            _reconnecting = true;

            try
            {
                string ip = _plcIpCfg;
                int port = _plcPortCfg;

                TcpClient client =
                    await Task.Run(() => ConnectWithTimeout(ip, port));

                if (!_plcStarted)
                {
                    client.Close();
                    return;
                }

                lock (_modbusLock)
                {
                    _plcClient = client;
                    _modbusMaster = CreateMaster(client);
                }

                StopReconnectTimer();

                _previousPLCState = false;
                _tickBusy = false;

                StartPollTimer();

                ShowLog("PLC Reconnected.");

                if (objBin.IsConnected)
                {
                    SetHardwareStatus(
                        "All Hardware Connected",
                        System.Drawing.Color.Green);
                }
                else
                {
                    SetHardwareStatus(
                        "Scanner Disconnected",
                        System.Drawing.Color.Red);
                }
            }
            catch
            {
                // Agle 3 sec baad phir try hoga
            }
            finally
            {
                _reconnecting = false;
            }
        }

        //========================================================
        // NG SIGNAL
        // Naya TCP connection nahi - existing Modbus connection
        // use hoti hai (lock ke saath).
        //========================================================
        private void SendNGSignal()
        {
            int n = System.Threading.Interlocked.Increment(ref ngCount);

            RunOnUI(() => lblNGCount.Text = n.ToString());

            ushort coilAddress;

            if (!ushort.TryParse(
                ConfigurationManager.AppSettings["PLC_NGADDRESS"],
                out coilAddress))
            {
                ShowLog("Invalid PLC_NGADDRESS in App.config.");
                return;
            }

            Task.Run(() =>
            {
                try
                {
                    byte slaveId = 1;

                    lock (_modbusLock)
                    {
                        if (_modbusMaster != null)
                            _modbusMaster.WriteSingleCoil(slaveId, coilAddress, true);
                    }
                }
                catch (Exception ex)
                {
                    PCommon.mAppLog.WriteLog(
                        ex.Message,
                        DTPLLogs.DTPLLogsWrite.LogType.Error,
                        MethodBase.GetCurrentMethod());

                    ShowLog("NG Signal Error: " + ex.Message);
                }
            });
        }

        //========================================================
        // MODBUS CLOSE
        //========================================================
        private void CloseModbus()
        {
            TcpClient client = _plcClient;
            ModbusIpMaster master = _modbusMaster;

            // Pehle socket band - chalta hua read turant fail ho jayega
            try { if (client != null) client.Close(); } catch { }

            lock (_modbusLock)
            {
                try { if (master != null) master.Dispose(); } catch { }

                _modbusMaster = null;
                _plcClient = null;
            }
        }

        //========================================================
        // STOP PLC (Stop button / Form close / Restart)
        // PLC, scanner, timers, line lock - sab saaf
        //========================================================
        private void StopPLC()
        {
            try
            {
                _plcStarted = false;

                StopReconnectTimer();
                StopPollTimer();
                CloseModbus();
                CloseScanner();
                ReleaseLineLock();

                _previousPLCState = false;
                _tickBusy = false;
            }
            catch
            {
                // Do not throw while stopping
            }
        }

        //========================================================
        // WORK ORDER CHANGE
        //========================================================
        private void cmbWorkOrderNo_SelectedIndexChanged_1(
            object sender,
            EventArgs e)
        {
            try
            {
                if (cmbWorkOrderNo.SelectedIndex <= 0)
                    return;

                ShowLog("");

                txtPrinterIP.Text = "";
                txtPrinterPort.Text = "";

                DLScanBarcode obj = new DLScanBarcode();

                //================================================
                // GET PART CODE + PACK SIZE
                //================================================
                DataTable dt =
                    obj.getProductCodeDetails(
                        cmbWorkOrderNo.Text.Trim());

                if (dt != null && dt.Rows.Count > 0)
                {
                    TxtPartCode.Text = dt.Rows[0][0].ToString();
                    txtpacksize.Text = dt.Rows[0][1].ToString();
                }

                //================================================
                // TOTAL MC
                //================================================
                DataTable dt2 =
                    obj.GetTotalMC(
                        cmbWorkOrderNo.Text.Trim());

                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    lblTotalCount.Text = dt2.Rows[0][0].ToString();
                }

                UpdateDashboard();
            }
            catch (Exception ex)
            {
                ShowLog("Work Order Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        //========================================================
        // LINE CHANGE
        //========================================================
        private void cmbLineCode_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                if (cmbLineCode.SelectedIndex <= 0)
                    return;

                ShowLog("");

                txtPrinterIP.Text = "";
                txtPrinterPort.Text = "";

                DLScanBarcode obj = new DLScanBarcode();

                DataTable dt =
                    obj.getLineDetails(
                        cmbLineCode.Text.Trim());

                if (dt != null && dt.Rows.Count > 0)
                {
                    txtPrinterIP.Text = dt.Rows[0][0].ToString();
                    txtPrinterPort.Text = dt.Rows[0][1].ToString();
                    txtPLCIP.Text = dt.Rows[0][2].ToString();
                    txtPLCPort.Text = dt.Rows[0][3].ToString();
                    txtScannerIP.Text = dt.Rows[0][4].ToString();
                    txtScannerPort.Text = dt.Rows[0][5].ToString();
                    MCPRINTERIP = dt.Rows[0][6].ToString();
                }

                //================================================
                // DISABLE CONFIG CONTROLS
                //================================================
                txtPrinterIP.Enabled = false;
                txtPrinterPort.Enabled = false;

                txtPLCIP.Enabled = false;
                txtPLCPort.Enabled = false;

                txtScannerIP.Enabled = false;
                txtScannerPort.Enabled = false;

                cmbWorkOrderNo.Enabled = false;
                cmbLineCode.Enabled = false;

                TxtPartCode.Enabled = false;

                UpdateDashboard();
            }
            catch (Exception ex)
            {
                ShowLog("Line Selection Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        //========================================================
        // FORM LOAD
        //========================================================
        private void Inspection_Load(
            object sender,
            EventArgs e)
        {
            cmbWorkOrderNo.DropDownStyle = ComboBoxStyle.DropDown;
            cmbWorkOrderNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbWorkOrderNo.AutoCompleteSource = AutoCompleteSource.ListItems;

            try
            {
                // Dashboard load par bhi update hoga
                UpdateDashboard();
            }
            catch (Exception ex)
            {
                ShowLog("Load Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());
            }
        }

        //========================================================
        // STOP BUTTON
        //========================================================
        private void btnstop_Click(object sender, EventArgs e)
        {
            try
            {
                StopPLC();   // PLC + scanner + timers + line lock

                this.Close();
                System.Windows.Forms.Application.Exit();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        //========================================================
        // VALIDATE SCANNED IC (background thread)
        //========================================================
        private bool ValidatePrintedScan(string barcode, PrintContext ctx)
        {
            try
            {
                barcode = barcode.Trim();

                if (string.IsNullOrWhiteSpace(barcode))
                {
                    ShowLog("Barcode is empty.");
                    SendNGSignal();
                    return false;
                }

                //================================================
                // DATABASE VALIDATION
                //================================================
                DL_Printing obj = new DL_Printing();

                DataTable dt = obj.CheckPrintedScan(
                    ctx.WorkOrder,
                    ctx.PartCode,
                    barcode);

                //================================================
                // NO RESPONSE
                //================================================
                if (dt == null || dt.Rows.Count == 0)
                {
                    ShowLog("Scan validation failed.");
                    SendNGSignal();
                    return false;
                }

                DataRow row = dt.Rows[0];

                string result =
                    row["Result"]
                    .ToString()
                    .Trim()
                    .ToUpper();

                string message = "";

                if (dt.Columns.Contains("Message") &&
                    row["Message"] != DBNull.Value)
                {
                    message = row["Message"].ToString().Trim();
                }

                int printCount = 0;

                if (dt.Columns.Contains("PrintCount") &&
                    row["PrintCount"] != DBNull.Value)
                {
                    printCount = Convert.ToInt32(row["PrintCount"]);
                }

                int scanCount = 0;

                if (dt.Columns.Contains("ScanCount") &&
                    row["ScanCount"] != DBNull.Value)
                {
                    scanCount = Convert.ToInt32(row["ScanCount"]);
                }

                //================================================
                // LIMIT EXCEEDED
                //================================================
                if (result == "LIMITEXCEEDED")
                {
                    ShowLog(
                        "SCAN BLOCKED | " +
                        "Printed: " +
                        printCount +
                        " | Scanned: " +
                        scanCount +
                        " | No more scan allowed.");

                    SendNGSignal();
                    return false;
                }

                //================================================
                // IC NOT PRINTED
                //================================================
                if (result == "NOTPRINTED")
                {
                    ShowLog(
                        "SCAN REJECTED | " +
                        "IC was not printed: " +
                        barcode);

                    SendNGSignal();
                    return false;
                }

                //================================================
                // DUPLICATE
                //================================================
                if (result == "DUPLICATE")
                {
                    ShowLog(
                        "DUPLICATE SCAN BLOCKED | " +
                        "IC: " +
                        barcode);

                    SendNGSignal();
                    return false;
                }

                //================================================
                // MC NOT COMPLETE
                //================================================
                if (result == "MCNOTCOMPLETE")
                {
                    string currentMC = "";
                    string activeMC = "";
                    int activeMCPrintCount = 0;
                    int activeMCScanCount = 0;

                    if (dt.Columns.Contains("MCBoxSerial") &&
                        row["MCBoxSerial"] != DBNull.Value)
                    {
                        currentMC = row["MCBoxSerial"].ToString().Trim();
                    }

                    if (dt.Columns.Contains("ActiveMCSerial") &&
                        row["ActiveMCSerial"] != DBNull.Value)
                    {
                        activeMC = row["ActiveMCSerial"].ToString().Trim();
                    }

                    if (dt.Columns.Contains("ActiveMCPrintCount") &&
                        row["ActiveMCPrintCount"] != DBNull.Value)
                    {
                        activeMCPrintCount = Convert.ToInt32(row["ActiveMCPrintCount"]);
                    }

                    if (dt.Columns.Contains("ActiveMCScanCount") &&
                        row["ActiveMCScanCount"] != DBNull.Value)
                    {
                        activeMCScanCount = Convert.ToInt32(row["ActiveMCScanCount"]);
                    }

                    ShowLog(
                        "SCAN BLOCKED | " +
                        "Current MC: " +
                        currentMC +
                        " | Active MC: " +
                        activeMC +
                        " | Scan: " +
                        activeMCScanCount +
                        "/" +
                        activeMCPrintCount +
                        " | Complete Active MC first.");

                    SendNGSignal();
                    return false;
                }

                //================================================
                // AVAILABLE
                //================================================
                if (result == "AVAILABLE")
                {
                    string mcSerial = "";
                    int currentMCPrintCount = 0;
                    int newMCScanCount = 0;

                    if (dt.Columns.Contains("MCBoxSerial") &&
                        row["MCBoxSerial"] != DBNull.Value)
                    {
                        mcSerial = row["MCBoxSerial"].ToString().Trim();
                    }

                    if (dt.Columns.Contains("CurrentMCPrintCount") &&
                        row["CurrentMCPrintCount"] != DBNull.Value)
                    {
                        currentMCPrintCount = Convert.ToInt32(row["CurrentMCPrintCount"]);
                    }

                    if (dt.Columns.Contains("NewMCScanCount") &&
                        row["NewMCScanCount"] != DBNull.Value)
                    {
                        newMCScanCount = Convert.ToInt32(row["NewMCScanCount"]);
                    }

                    if (newMCScanCount >= currentMCPrintCount)
                    {
                        ShowLog(
                            "SCAN OK | " +
                            "IC: " +
                            barcode +
                            " | MC: " +
                            mcSerial +
                            " | MC Scan: " +
                            newMCScanCount +
                            "/" +
                            currentMCPrintCount +
                            " | MC COMPLETE");
                    }
                    else
                    {
                        ShowLog(
                            "SCAN OK | " +
                            "IC: " +
                            barcode +
                            " | MC: " +
                            mcSerial +
                            " | MC Scan: " +
                            newMCScanCount +
                            "/" +
                            currentMCPrintCount);
                    }

                    return true;
                }

                //================================================
                // UNKNOWN RESULT
                //================================================
                ShowLog(
                    string.IsNullOrWhiteSpace(message)
                        ? "Scan validation failed."
                        : message);

                SendNGSignal();

                return false;
            }
            catch (Exception ex)
            {
                ShowLog("Scan Validation Error: " + ex.Message);

                SendNGSignal();

                return false;
            }
        }
    }
}