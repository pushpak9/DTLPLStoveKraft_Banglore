using DTPLLogs;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Pkcs;
using PPAPMES.BusinessLayer;
using PPAPMES.DataLayer;
using PPAPMES.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAPMES.Forms.Transaction
{
    public partial class RMLabelKitting : Form
    {
        Common obj = new Common();
        DL_Report objDL_Report = new DL_Report();
        public RMLabelKitting()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
           
           
        }

        private void txtScanData_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                
                if (e.KeyChar == 13)
                {
                    
                    if (string.IsNullOrEmpty(txtScanData.Text.Trim()))
                    {
                        MessageBox.Show("Please scan barcode");
                        txtScanData.Focus();
                        return;
                    }
                    RMLabelModel plobj = new RMLabelModel();
                    DL_RMLabelPrinting obj = new DL_RMLabelPrinting();
                    plobj.SiteCode = PCommon.SiteCode;
                    plobj.ParentBarcode = txtScanData.Text;
                    DataTable dt = obj.ValidateData(plobj);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString().StartsWith("ERROR"))
                        {
                            objDL_Report.SaveLogData(MethodBase.GetCurrentMethod(), dt.Rows[0][0].ToString());
                            textBoxItemCode.Text = "";
                            textVendorCode.Text = "";
                            textWeight.Text = "";
                            textLineCode.Text = "";
                            txtScanData.Text = String.Empty;
                            txtScanData.Focus();
                            MessageBox.Show(dt.Rows[0][0].ToString());
                            return;
                        }
                        else
                        {
                            textBoxItemCode.Text= dt.Rows[0][0].ToString();
                            textVendorCode.Text = dt.Rows[0][1].ToString();
                            textWeight.Text = dt.Rows[0][2].ToString();
                            textLineCode.Text = dt.Rows[0][3].ToString();
                            textCategory.Text = dt.Rows[0][5].ToString();
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

     

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            
            if (string.IsNullOrEmpty(txtScanData.Text.Trim()))
            {
                MessageBox.Show("Please scan barcode");
                                                         
                return;
            }
            if (string.IsNullOrEmpty(txtNoPrint.Text.Trim()))
            {
                MessageBox.Show("Please Enter NO of print");
                txtNoPrint.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textWeight.Text.Trim()))
            {
                MessageBox.Show("Scan Barcode First ");
                txtNoPrint.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textCategory.Text.Trim()))
            {
                MessageBox.Show(" Category  not empty");
                textCategory.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textCategory.Text.Trim()))
            {
                MessageBox.Show(" Category  not empty");
                textCategory.Focus();
                return;
            }
            RMLabelModel plobj = new RMLabelModel();
            plobj.Weight = Convert.ToDecimal(textWeight.Text);
            plobj.VendorCode = textVendorCode.Text.Trim();
            plobj.ItemCode = textBoxItemCode.Text.Trim();
            plobj.ParentBarcode = txtScanData.Text.Trim();
            plobj.NumberOfPrint = Convert.ToInt32(txtNoPrint.Text.Trim());
            plobj.LineCode = textLineCode.Text.Trim();
            plobj.Category= textCategory.Text.Trim();
            plobj.PrinterName = Convert.ToString(ConfigurationManager.AppSettings["PrinterName"]);
            decimal weight, noPrint;
            if (decimal.TryParse(textWeight.Text, out weight) && decimal.TryParse(txtNoPrint.Text.Trim(), out noPrint) && noPrint != 0)
            {
                plobj.ChildWeight = weight / noPrint;
            }
            else
            {
                
                MessageBox.Show("Please enter valid numeric values and ensure No Print is not zero.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RawPrinterHelper objclsprint = new RawPrinterHelper();
            bool result = objclsprint.PrinterCheck(plobj.PrinterName);
            if (result == false)
            {
                for (int i = 0; i < plobj.NumberOfPrint; i++)
                {
                    DL_RMLabelPrinting dL_RMLabelPrinting = new DL_RMLabelPrinting();
                    DataTable dt = dL_RMLabelPrinting.SaveRMLabelKitting(plobj);
                    if (dt.Rows.Count > 0)
                    {
                        string sResult = dt.Rows[0][0].ToString();
                        if (sResult.StartsWith("SUCCESS~"))
                        {
                            string sSerialNo = sResult.Split('~')[2].ToString();
                            textBoxItemCode.Text = "";
                            textVendorCode.Text = "";
                            textWeight.Text = "";
                            textLineCode.Text = "";
                            textCategory.Text= "";
                            txtScanData.Text = String.Empty;
                            txtScanData.Focus();
                            plobj.Barcode = sSerialNo;
                            PrintLabel(plobj);

                        }
                        else
                        {
                            blCommon.ShowMessage(sResult, 2);
                            textBoxItemCode.Text = "";
                            textVendorCode.Text = "";
                            textWeight.Text = "";
                            textLineCode.Text = "";
                            textCategory.Text = "";
                            txtScanData.Text = String.Empty;
                            txtScanData.Focus();
                            objDL_Report.SaveLogData(MethodBase.GetCurrentMethod(), dt.Rows[0][0].ToString());
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Printer is not connected");
            }
        }
        public void PrintLabel(RMLabelModel request)
        {
            try
            {
                StreamReader FSOP;
                string FileTextLine;
                string TempFileTextLine;
                if (File.Exists((Application.StartupPath + "\\PPAP.prn")))
                {
                    FSOP = new StreamReader((Application.StartupPath + "\\PPAP.prn"));
                    FileTextLine = FSOP.ReadToEnd();
                    FSOP.Close();
                }
                else
                {
                    MessageBox.Show("Pcl Command Not Found");
                    return;
                }
                TempFileTextLine = FileTextLine;
                TempFileTextLine = TempFileTextLine.Replace("#VendorCode#", ("" + (request.VendorCode + "")));
                TempFileTextLine = TempFileTextLine.Replace("#ItemCode#", ("" + (request.ItemCode + "")));
                TempFileTextLine = TempFileTextLine.Replace("#Weight#", ("" + (request.Weight + "")));
                TempFileTextLine = TempFileTextLine.Replace("#Barcode#", ("" + (request.Barcode + "")));
                TempFileTextLine = TempFileTextLine.Replace("#LineCode#", ("" + (request.LineCode + "")));
                RawPrinterHelper.SendStringToPrinter(request.PrinterName, TempFileTextLine);
                //button1.Enabled = true;// LeeFord Printer Name
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void txtNoPrint_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                blCommon.OnlyNumeric(e);
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void itemcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textVendorCode.Text = "";
            textWeight.Text = "";
            textLineCode.Text = "";
            txtScanData.Text = String.Empty;
            txtScanData.Focus();
            textCategory.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
