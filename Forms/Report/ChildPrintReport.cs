using DTPLLogs;
using StockCraft;
using StockCraft.BusinessLayer;
using StockCraft.DataLayer;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace StockCraft.Reports
{
    public partial class ChildPrintReport : Form
    {
        DL_Report objDL_Report = new DL_Report();
        public ChildPrintReport()
        {
            InitializeComponent();
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            try
            {
                string sReportHeader = string.Empty;
                if (cmbFilter.Text == "CHILDSerialNo")
                {
                    sReportHeader = "CHILDSerialNo";
                }
                if (cmbFilter.Text == "MCSerial")
                {
                    sReportHeader = "MCSerial";
                }

                if (cmbFilter.Text == "WorkOrderNo")
                {
                    sReportHeader = "WorkOrderNo";
                }

                DataTable dt = objDL_Report.dtGetReport(sReportHeader, txtValue.Text, Datefromdate.Text, DateTodate.Text);
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
                        blCommon.ShowMessage("Report export successful at:\n" + sFilePath, 1);

                        // ✅ Auto open (optional)
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ReceivingGrid.DataSource = null;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DateTodate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Datefromdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ReceivingGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }
    }
}
