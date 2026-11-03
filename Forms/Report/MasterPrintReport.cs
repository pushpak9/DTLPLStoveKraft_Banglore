using DTPLLogs;
using StockCraft.BusinessLayer;
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
    public partial class MasterPrintReport : Form
    {
        DL_Report objDL_Report = new DL_Report();
        public MasterPrintReport()
        {
            InitializeComponent();
        }

        private void ResetPrintReport_Load(object sender, EventArgs e)
        {

        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            try
            {
                string sReportHeader = string.Empty;
                if (cmbFilter.Text == "MCSerial")
                {
                    sReportHeader = "MCSerial";
                }
                if (cmbFilter.Text == "WorkOrderNo")
                {
                    sReportHeader = "WorkOrderNo";
                }


                DataTable dt = objDL_Report.dtGetReportReset(sReportHeader, txtValue.Text, Datefromdate.Text, DateTodate.Text);
                if (dt.Rows.Count > 0)
                {
                    ReceivingGrid.DataSource = dt;
                    TxtLabelCount.Text = dt != null ? dt.Rows.Count.ToString() : "0";
                }
                else
                {
                    blCommon.ShowMessage("No result found", 3);
                    ReceivingGrid.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
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
                    saveFileDialog.FileName = "ExportData.xls";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string sFilePath = saveFileDialog.FileName;

                        // ✅ Extension fix (important)
                        if (!sFilePath.EndsWith(".xls"))
                        {
                            sFilePath += ".xls";
                        }

                        DataTable dt = (DataTable)ReceivingGrid.DataSource;

                        // ✅ Direct Excel Export (Tab Separated)
                        using (StreamWriter sw = new StreamWriter(sFilePath, false, Encoding.UTF8))
                        {
                            // Column Header
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                sw.Write(dt.Columns[i].ColumnName);
                                if (i < dt.Columns.Count - 1)
                                    sw.Write("\t");
                            }
                            sw.WriteLine();

                            // Rows Data
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
                        PCommon.mAppLog.WriteLog("File exported at: " + sFilePath,
                            DTPLLogsWrite.LogType.Information,
                            MethodBase.GetCurrentMethod());

                        // ✅ Message
                        blCommon.ShowMessage("File export successful at:\n" + sFilePath, 1);

                        // ✅ Auto open file (optional but useful)
                        System.Diagnostics.Process.Start(sFilePath);
                    }
                }
                catch (Exception ex)
                {
                    PCommon.mAppLog.WriteLog(ex.Message,
                        DTPLLogsWrite.LogType.Error,
                        MethodBase.GetCurrentMethod());

                    blCommon.ShowMessage(ex.Message, 3);
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

        private void btnPDFExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ReceivingGrid.Rows.Count > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    DataTable dt = (DataTable)ReceivingGrid.DataSource;
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string sFilePath = saveFileDialog.FileName;
                        blCommon.ExportToPdf(dt, sFilePath, "Data Validation Report");
                        blCommon.ShowMessage("File export successfull", 1);
                    }
                }
                else
                {
                    blCommon.ShowMessage("No data found to export", 2);
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
            finally
            {
                Cursor = Cursors.Default;
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
    }
}
