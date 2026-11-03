using DTPLLogs;
using Pipelines.Sockets.Unofficial;
using StockCraft.BusinessLayer;
using StockCraft.DataLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockCraft.Forms.Transaction
{
    public partial class WorkOrderInspection : Form
    {
        private TcpListener _plcListener;
        private CancellationTokenSource _plcCancellation;

        // PLC ka port
        private int _plcPort = 5000;
        public WorkOrderInspection()
        {
            InitializeComponent();
            BindItemCode();
            BindWorkOrder();
         
        }


        public void BindItemCode()
        {
            try
            {
                DLScanBarcode obj = new DLScanBarcode();
                DataTable dt = obj.dtBindLine();
                if (dt.Rows.Count > 0)
                {
                    blCommon.FillComboBox(cmbLineCode, dt, true);
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        public void BindWorkOrder()
        {
            try
            {
                DLWorkOrder obj = new DLWorkOrder();
                DataTable dt = obj.dtBindWorkOrder();
                if (dt.Rows.Count > 0)
                {
                    blCommon.FillComboBox(CmbWorkOrderNo, dt, true);
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }



        private void WorkOrderInspection_Load(object sender, EventArgs e)
        {
            try
            {
                
               
                cmbLineCode.Focus();

                // System IP
                IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName())
                    .FirstOrDefault(x =>
                        x.AddressFamily == AddressFamily.InterNetwork);

                ////lblSystemIP.Text = ip != null
                //    ? ip.ToString()
                //    : "IP Not Found";

                // PLC listener start
                StartPLCListener();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "PLC Listener Start Error : " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void StartPLCListener()
        {
            try
            {
                _plcCancellation = new CancellationTokenSource();

                _plcListener = new TcpListener(
                    IPAddress.Any,
                    _plcPort);

                _plcListener.Start();

                Task.Run(
                    () => ListenForPLCTrigger(
                        _plcCancellation.Token));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to start PLC listener.\r\n" +
                    ex.Message);
            }
        }

        private async Task ListenForPLCTrigger(
    CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    TcpClient client =
                        await _plcListener.AcceptTcpClientAsync();

                    _ = Task.Run(
                        () => HandlePLCClient(
                            client,
                            cancellationToken),
                        cancellationToken);
                }
                catch
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;
                }
            }
        }

        private async Task HandlePLCClient(
    TcpClient client,
    CancellationToken cancellationToken)
        {
            try
            {
                using (client)
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];

                    int bytesRead = await stream.ReadAsync(
                        buffer,
                        0,
                        buffer.Length,
                        cancellationToken);

                    if (bytesRead <= 0)
                        return;

                    string plcData = Encoding.ASCII
                        .GetString(buffer, 0, bytesRead)
                        .Trim();

                    // PLC se kya aaya check karo
                    if (plcData == "1")
                    {
                        BeginInvoke(new Action(() =>
                        {
                            ProcessData();
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                BeginInvoke(new Action(() =>
                {
                    MessageBox.Show(
                        "PLC Communication Error : " +
                        ex.Message);
                }));
            }
        }

        private void ProcessData()
        {
            try
            {
    

                MessageBox.Show("PLC Trigger Received");

            
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Process Error : " + ex.Message);
            }
        }

        private void txtIPAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbLineCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbLineCode.SelectedIndex > 0)
                {
                    txtIPAddress.Text = string.Empty;
                    txtPort.Text = string.Empty;
                    DLScanBarcode obj = new DLScanBarcode();
                    DataTable dt = obj.getLineDetails(cmbLineCode.Text);
                    if (dt.Rows.Count > 0)
                    {
                        txtIPAddress.Text = dt.Rows[0][0].ToString();
                        txtPort.Text = dt.Rows[0][1].ToString();
                        Txtplc.Text = dt.Rows[0][2].ToString();
                        txtPortt.Text = dt.Rows[0][3].ToString();
                        TxtScannerIP.Text = dt.Rows[0][4].ToString();
                        TxtScannerport.Text = dt.Rows[0][5].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
               
        }



        private void CmbWorkOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
