using DTPLLogs;
using StockCraft.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockCraft.Forms.Report
{
    public partial class LatestScanReport : Form
    {
        DL_Report objDL_Report = new DL_Report();
        public LatestScanReport()
        {
            InitializeComponent();
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            try
            {
                string sReportHeader = string.Empty;

                if (cmbFilter.Text == "IBSerial")
                {
                    sReportHeader = "IBSerial";
                }

                if (cmbFilter.Text == "Barcode")
                {
                    sReportHeader = "Barcode";
                }

                if (cmbFilter.Text == "WorkOrderNo")
                {
                    sReportHeader = "WorkOrderNo";
                }



                DataTable dt = objDL_Report.dtGetReportInspectionNew(
                    cmbFilter.Text,
                    txtValue.Text,
                    Datefromdate.Text,
                    DateTodate.Text
                );

                if (dt.Rows.Count > 0)
                {
                    ReceivingGrid.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No result found");
                    ReceivingGrid.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod()
                );

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (ReceivingGrid.Rows.Count >= 1)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
                    saveFileDialog.FileName = "ReportData.xls";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string sFilePath = saveFileDialog.FileName;

                        // ✅ Extension fix
                        if (!sFilePath.EndsWith(".xls"))
                        {
                            sFilePath += ".xls";
                        }

                        DataTable dt = (DataTable)ReceivingGrid.DataSource;

                        // ✅ Direct Export
                        using (StreamWriter sw = new StreamWriter(sFilePath, false, Encoding.UTF8))
                        {
                            // Header
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                sw.Write(dt.Columns[i].ColumnName);
                                if (i < dt.Columns.Count - 1)
                                    sw.Write("\t");
                            }
                            sw.WriteLine();

                            // Data
                            foreach (DataRow row in dt.Rows)
                            {
                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    sw.Write(row[i].ToString());
                                    if (i < dt.Columns.Count - 1)
                                        sw.Write("\t");
                                }
                                sw.WriteLine();
                            }
                        }

                        // ✅ Log
                        PCommon.mAppLog.WriteLog("Report exported at: " + sFilePath,
                            DTPLLogsWrite.LogType.Information,
                            MethodBase.GetCurrentMethod());

                        // ✅ Message
                        MessageBox.Show("Report export successful");

                        // ✅ Auto open (optional)
                        System.Diagnostics.Process.Start(sFilePath);
                    }
                }
                catch (Exception ex)
                {
                    PCommon.mAppLog.WriteLog(ex.Message,
                        DTPLLogsWrite.LogType.Error,
                        MethodBase.GetCurrentMethod());

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("No Record to Export !");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ReceivingGrid.DataSource = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LatestScanReport_Load(object sender, EventArgs e)
        {

        }
    }
}
