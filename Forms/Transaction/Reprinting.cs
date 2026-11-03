using DTPLLogs;
using StockCraft.BusinessLayer;
using StockCraft.DataLayer;
//using StockCraft.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockCraft.Forms.Transaction
{
    public partial class Reprinting : Form
    {
        private string PrinterIP = string.Empty;
        private string PrinterPort = string.Empty;
        DLScanBarcode obj =
                   new DLScanBarcode();
        //string printerIPMc = Inspection.MCPRINTERIP;

        public Reprinting()
        {
            InitializeComponent();
        }

        private void Reprinting_Load(object sender, EventArgs e)
        {
            dgvReprintData.AutoGenerateColumns = false;

            dgvReprintData.Columns.Clear();

            DataGridViewCheckBoxColumn chk =
                new DataGridViewCheckBoxColumn();

            chk.Name = "Select";
            chk.HeaderText = "Select";
            chk.Width = 60;

            dgvReprintData.Columns.Add(chk);


            dgvReprintData.Columns.Add(
                "IBSerial",
                "IB Serial");

            dgvReprintData.Columns.Add(
                "ProductCode",
                "Product Code");

            dgvReprintData.Columns.Add(
                "Model",
                "Model");

            dgvReprintData.Columns.Add(
                "Wattage",
                "Wattage");

            dgvReprintData.Columns.Add(
                "Voltage",
                "Voltage");

            dgvReprintData.Columns.Add(
                "DegreeOfProtection",
                "Degree Of Protection");
            BindItemCode();

        }
        public void BindItemCode()
        {
            try
            {
                DLScanBarcode obj = new DLScanBarcode();

                DataTable dt = obj.dtBindLine();

                if (dt != null && dt.Rows.Count > 0)
                {
                    // System IP / Line mapping check removed.
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
                //ShowLog("Line Load Error: " + ex.Message);

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            try
            {
                /*====================================================
                    1. CHECK GRID DATA
                ====================================================*/

                if (dgvReprintData.Rows.Count == 0)
                {
                    blCommon.ShowMessage(
                        "No data found to reprint.",
                        2);

                    return;
                }


                /*====================================================
                    2. GET PRINTER IP & PORT FROM APP.CONFIG
                ====================================================*/



   

 


                int printerPort = 9100;


                /*====================================================
                    3. GET PRN FILE
                ====================================================*/

                string sCartonPrn =
                    blCommon.GetPrnIC();

                if (string.IsNullOrWhiteSpace(sCartonPrn) ||
                    sCartonPrn.StartsWith("ERROR"))
                {
                    blCommon.ShowMessage(
                        "Carton PRN not found, please contact admin.",
                        2);

                    return;
                }


                /*====================================================
                    4. CHECK SELECTED ROW
                ====================================================*/

                bool isSelected = false;


                for (int i = 0;
                     i < dgvReprintData.Rows.Count;
                     i++)
                {
                    DataGridViewRow row =
                        dgvReprintData.Rows[i];


                    if (row.IsNewRow)
                        continue;


                    bool selected = false;


                    if (row.Cells["Select"].Value != null)
                    {
                        bool.TryParse(
                            row.Cells["Select"].Value.ToString(),
                            out selected);
                    }


                    if (!selected)
                        continue;


                    isSelected = true;


                    /*================================================
                        5. GET IB SERIAL
                    =================================================*/

                    string IBSerial =
                        Convert.ToString(
                            row.Cells["IBSerial"].Value).Trim();


                    if (string.IsNullOrWhiteSpace(IBSerial))
                    {
                        blCommon.ShowMessage(
                            "IB Serial not found in selected row.",
                            2);

                        return;
                    }


                    /*================================================
                        6. GET REPRINT DATA
                    =================================================*/

                    DataTable dtReprint =
                        obj.ReprintChild(IBSerial);


                    if (dtReprint == null ||
                        dtReprint.Rows.Count == 0)
                    {
                        blCommon.ShowMessage(
                            "Reprint data not found for IB Serial: "
                            + IBSerial,
                            2);

                        return;
                    }


                    DataRow printRow =
                        dtReprint.Rows[0];


                    /*================================================
                        7. GET PRINTING VALUES
                    =================================================*/

                    string ProductCode =
                        Convert.ToString(
                            printRow["ProductCode"]).Trim();

                    string Model =
                        Convert.ToString(
                            printRow["Model"]).Trim();

                    string Wattage =
                        Convert.ToString(
                            printRow["Wattage"]).Trim();

                    string Voltage =
                        Convert.ToString(
                            printRow["Voltage"]).Trim();

                    string PartContent =
                        Convert.ToString(
                            printRow["PartContent"]).Trim();

                    string DegreeOfProtection =
                        Convert.ToString(
                            printRow["DegreeOfProtection"]).Trim();


                    /*================================================
                        8. CREATE FINAL PRN
                    =================================================*/

                    //string sFinalPrn =
                    //    blCommon.ReplaceChildReprintPrnValue(
                    //        sCartonPrn,
                    //        IBSerial,
                    //        ProductCode,
                    //        Model,
                    //        Wattage,
                    //        Voltage,
                    //        PartContent,
                    //        DegreeOfProtection);

                    string sFinalPrn =
                     blCommon.ReplaceChildReprintPrnValue(
                         sCartonPrn,
                         IBSerial, 
                         ProductCode);


                    if (string.IsNullOrWhiteSpace(sFinalPrn))
                    {
                        blCommon.ShowMessage(
                            "Final PRN data is empty for IB Serial: "
                            + IBSerial,
                            2);

                        return;
                    }


                    /*================================================
                        9. SEND TO PRINTER
                    =================================================*/

                    blCommon.SendCommandToPrinter(
                        txtPrinterIP.Text,
                        printerPort,
                        sFinalPrn);
                }


                /*====================================================
                    10. NO ROW SELECTED
                ====================================================*/

                if (!isSelected)
                {
                    blCommon.ShowMessage(
                        "Please select at least one record to reprint.",
                        2);

                    return;
                }


                /*====================================================
                    11. SUCCESS
                ====================================================*/

                blCommon.ShowMessage(
                    "Child label reprinted successfully.",
                    1);


                dgvReprintData.Rows.Clear();

               // txtScannedBarcode.Clear();

                //txtScannedBarcode.Focus();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                blCommon.ShowMessage(
                    ex.Message,
                    3);
            }
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            try
            {
                string childBarcode =
                    txtScannedBarcode.Text.Trim();


                if (string.IsNullOrWhiteSpace(childBarcode))
                {
                    blCommon.ShowMessage(
                        "Please enter IB Serial.",
                        2);

                    txtScannedBarcode.Focus();

                    return;
                }


                /*====================================================
                    1. GET PRINTER IP & PORT FROM APP.CONFIG
                ====================================================*/

    


                int printerPort;

        


                /*====================================================
                    2. CLEAR OLD GRID DATA
                ====================================================*/

                dgvReprintData.Rows.Clear();


                /*====================================================
                    3. GET CHILD DATA
                ====================================================*/

                DataTable dtReprint =
                    obj.getReprintData(childBarcode);


                if (dtReprint == null ||
                    dtReprint.Rows.Count == 0)
                {
                    blCommon.ShowMessage(
                        "IB Serial not found or Reprinted.",
                        2);

                    txtScannedBarcode.Focus();

                    return;
                }


                /*====================================================
                    4. BIND DATA TO GRID

                    0 = Select
                    1 = IBSerial
                    2 = ProductCode
                    3 = Model
                    4 = Wattage
                    5 = Voltage
                    6 = DegreeOfProtection
                ====================================================*/

                for (int i = 0;
                     i < dtReprint.Rows.Count;
                     i++)
                {
                    dgvReprintData.Rows.Add(
                        false,

                        dtReprint.Rows[i]["IBSerial"]
                            .ToString(),

                        dtReprint.Rows[i]["ProductCode"]
                            .ToString(),

                        dtReprint.Rows[i]["Model"]
                            .ToString(),

                        dtReprint.Rows[i]["Wattage"]
                            .ToString(),

                        dtReprint.Rows[i]["Voltage"]
                            .ToString(),

                        dtReprint.Rows[i]["DegreeOfProtection"]
                            .ToString()
                    );
                }


                dgvReprintData.ClearSelection();


                blCommon.ShowMessage(
                    "Data loaded successfully.",
                    1);
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                blCommon.ShowMessage(
                    ex.Message,
                    3);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void cmbLineCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbLineCode.SelectedIndex <= 0)
                    return;

             

                DLScanBarcode obj =
                    new DLScanBarcode();

                DataTable dt =
                    obj.getLineDetails(
                        cmbLineCode.Text.Trim());

                if (dt != null &&
                    dt.Rows.Count > 0)
                {
                    txtPrinterIP.Text =
                       dt.Rows[0][0].ToString();

                    cmbLineCode.Enabled = false;
                    txtPrinterIP.Enabled = false;



                }

                //================================================
                // DISABLE CONFIG CONTROLS
                //================================================
        
            }
            catch (Exception ex)
            {
               

                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                blCommon.ShowMessage(
                    ex.Message,
                    3);
            }
        }

        private void txtPrinterIP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
