using DTPLLogs;
using StockCraft.BusinessLayer;
using StockCraft.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace StockCraft.Forms.Transaction
{
    public partial class ReprintMC : Form
    {
        private string PrinterIP = string.Empty;
        private string PrinterPort = string.Empty;
        DLScanBarcode obj =
                   new DLScanBarcode();
        //string printerIPMc = Inspection.MCPRINTERIP;


        public ReprintMC()
        {
            InitializeComponent();
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
        private void ReprintMC_Load(object sender, EventArgs e)
        {
            dgvMasterReprintData.AutoGenerateColumns = false;

            dgvMasterReprintData.Columns.Clear();


            /*========================================
                SELECT CHECKBOX
            ========================================*/

            DataGridViewCheckBoxColumn chk =
                new DataGridViewCheckBoxColumn();

            chk.Name = "Select";
            chk.HeaderText = "Select";
            chk.Width = 60;

            dgvMasterReprintData.Columns.Add(chk);


            /*========================================
                MC SERIAL
            ========================================*/

            dgvMasterReprintData.Columns.Add(
                "MCBoxSerial",
                "MC Serial");


            /*========================================
                PART CODE
            ========================================*/

            dgvMasterReprintData.Columns.Add(
                "PartCode",
                "Part Code");


            /*========================================
                BIND ITEM CODE
            ========================================*/

            BindItemCode();
        }
        private void Get_Click(object sender, EventArgs e)
        {
            try
            {
                string MCBoxSerial =
                    txtMCSerial.Text.Trim();

                if (string.IsNullOrWhiteSpace(MCBoxSerial))
                {
                    blCommon.ShowMessage(
                        "Please enter MC Serial.",
                        2);

                    txtMCSerial.Focus();

                    return;
                }


                /*========================================
                    CLEAR OLD GRID
                ========================================*/

                dgvMasterReprintData.Rows.Clear();


                /*========================================
                    GET MASTER DATA
                ========================================*/

                DataTable dt =
                    obj.getMasterReprintData(
                        MCBoxSerial);


                if (dt == null ||
                    dt.Rows.Count == 0)
                {
                    blCommon.ShowMessage(
                        "MC Serial not found or already printed.",
                        2);

                    txtMCSerial.Focus();

                    return;
                }


                /*========================================
                    ADD DATA TO GRID
                ========================================*/

                foreach (DataRow dr in dt.Rows)
                {
                    int rowIndex =
                        dgvMasterReprintData.Rows.Add();

                    DataGridViewRow row =
                        dgvMasterReprintData.Rows[rowIndex];


                    /*====================================
                        SELECT
                    ====================================*/

                    row.Cells["Select"].Value =
                        false;


                    /*====================================
                        MC SERIAL
                    ====================================*/

                    row.Cells["MCBoxSerial"].Value =
                        Convert.ToString(
                            dr["MCBoxSerial"]).Trim();


                    /*====================================
                        PART CODE
                    ====================================*/

                    if (dt.Columns.Contains("PartCode"))
                    {
                        row.Cells["PartCode"].Value =
                            Convert.ToString(
                                dr["PartCode"]).Trim();
                    }
                    else
                    {
                        row.Cells["PartCode"].Value =
                            "";
                    }
                }


                dgvMasterReprintData.ClearSelection();


                blCommon.ShowMessage(
                    "Master Carton data loaded successfully.",
                    1);
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(
                    ex.Message,
                    3);
            }
        }


        private void REPRINT_Click(object sender, EventArgs e)
        {
            try
            {
                /*====================================================
                    1. GRID VALIDATION
                ====================================================*/

                if (dgvMasterReprintData.Rows.Count == 0)
                {
                    blCommon.ShowMessage(
                        "No data found to reprint.",
                        2);

                    return;
                }


                /*====================================================
                    2. GET SELECTED MC SERIALS + PART CODES
                ====================================================*/

                List<string> selectedMCSerials =
                    new List<string>();

                List<string> selectedPartCodes =
                    new List<string>();


                for (int i = 0;
                     i < dgvMasterReprintData.Rows.Count;
                     i++)
                {
                    DataGridViewRow row =
                        dgvMasterReprintData.Rows[i];


                    if (row.IsNewRow)
                        continue;


                    /*============================================
                        CHECK SELECT
                    ============================================*/

                    bool selected = false;

                    if (row.Cells["Select"].Value != null)
                    {
                        bool.TryParse(
                            row.Cells["Select"].Value.ToString(),
                            out selected);
                    }


                    if (!selected)
                        continue;


                    /*============================================
                        GET MC SERIAL
                    ============================================*/

                    string MCBoxSerial =
                        Convert.ToString(
                            row.Cells["MCBoxSerial"].Value)
                        .Trim();


                    /*============================================
                        GET PART CODE
                    ============================================*/

                    string PartCode =
                        Convert.ToString(
                            row.Cells["PartCode"].Value)
                        .Trim();


                    /*============================================
                        MC SERIAL VALIDATION
                    ============================================*/

                    if (string.IsNullOrWhiteSpace(MCBoxSerial))
                    {
                        blCommon.ShowMessage(
                            "MC Serial not found in selected row.",
                            2);

                        return;
                    }


                    /*============================================
                        PART CODE VALIDATION
                    ============================================*/

                    if (string.IsNullOrWhiteSpace(PartCode))
                    {
                        blCommon.ShowMessage(
                            "Part Code not found for MC Serial: "
                            + MCBoxSerial,
                            2);

                        return;
                    }


                    /*============================================
                        ADD BOTH
                    ============================================*/

                    selectedMCSerials.Add(
                        MCBoxSerial);

                    selectedPartCodes.Add(
                        PartCode);
                }


                /*====================================================
                    3. CHECK SELECTION
                ====================================================*/

                if (selectedMCSerials.Count == 0)
                {
                    blCommon.ShowMessage(
                        "Please select at least one MC Serial to reprint.",
                        2);

                    return;
                }


                /*====================================================
                    4. GET PRINTER IP & PORT
                ====================================================*/

                DataTable dtPrinter =
                    obj.getMasterPrinter();


                if (dtPrinter == null ||
                    dtPrinter.Rows.Count == 0)
                {
                    blCommon.ShowMessage(
                        "Printer IP and Port not found.",
                        2);

                    return;
                }


                string printerIP =
                    Convert.ToString(
                        dtPrinter.Rows[0]["PrinterIP"])
                    .Trim();


                /*============================================
                    PORT HARD CODED
                ============================================*/

                int printerPort = 9100;


                if (string.IsNullOrWhiteSpace(printerIP))
                {
                    blCommon.ShowMessage(
                        "Printer IP not found.",
                        2);

                    return;
                }


                /*====================================================
                    5. GET MASTER PRN
                ====================================================*/

                string sMasterPrn =
                    blCommon.GetPrnMC();


                if (string.IsNullOrWhiteSpace(sMasterPrn) ||
                    sMasterPrn.StartsWith("ERROR"))
                {
                    blCommon.ShowMessage(
                        "Master Carton PRN not found, please contact admin.",
                        2);

                    return;
                }


                /*====================================================
                    6. REPRINT SELECTED MC SERIALS
                ====================================================*/

                int successCount = 0;


                for (int i = 0;
                     i < selectedMCSerials.Count;
                     i++)
                {
                    string MCBoxSerial =
                        selectedMCSerials[i];


                    string ProductCode =
                        selectedPartCodes[i];


                    /*================================================
                        GET MASTER REPRINT DATA

                        SP:
                        REPRINT

                        IsReprint = 0
                            -> Reprint allowed
                            -> IsReprint = 1

                        IsReprint = 1
                            -> Already reprinted
                            -> Error
                    =================================================*/

                    DataTable dtReprint =
                        obj.ReprintMaster(
                            MCBoxSerial);


                    if (dtReprint == null ||
                        dtReprint.Rows.Count == 0)
                    {
                        blCommon.ShowMessage(
                            "MC Serial " +
                            MCBoxSerial +
                            " not found or already reprinted.",
                            2);

                        continue;
                    }


                    DataRow resultRow =
                        dtReprint.Rows[0];


                    /*================================================
                        CHECK SP RESULT
                    =================================================*/

                    if (dtReprint.Columns.Contains("Result"))
                    {
                        string result =
                            Convert.ToString(
                                resultRow["Result"])
                            .Trim();


                        if (!result.Equals(
                                "SUCCESS",
                                StringComparison.OrdinalIgnoreCase))
                        {
                            string message =
                                dtReprint.Columns.Contains("Message")
                                ? Convert.ToString(
                                    resultRow["Message"])
                                : "Unable to reprint MC Serial.";


                            blCommon.ShowMessage(
                                message +
                                "\nMC Serial: " +
                                MCBoxSerial,
                                2);

                            continue;
                        }
                    }


                    /*================================================
                        CREATE FINAL PRN

                        Barcode = MCBoxSerial
                        Text    = MCBoxSerial
                        PartCode = ProductCode
                    =================================================*/

                    string sFinalPrn =
                        blCommon.ReplaceMasterReprintPrnValue(
                            sMasterPrn,
                            MCBoxSerial,
                            ProductCode);


                    if (string.IsNullOrWhiteSpace(sFinalPrn))
                    {
                        blCommon.ShowMessage(
                            "Final PRN data is empty for MC Serial: "
                            + MCBoxSerial,
                            2);

                        continue;
                    }


                    /*================================================
                        SEND TO PRINTER
                    =================================================*/

                    blCommon.SendCommandToPrinter(
                        txtPrinterIP.Text,
                        printerPort,
                        sFinalPrn);


                    successCount++;
                }


                /*====================================================
                    7. FINAL RESULT
                ====================================================*/

                if (successCount == 0)
                {
                    blCommon.ShowMessage(
                        "No MC Carton label was reprinted.",
                        2);

                    return;
                }


                blCommon.ShowMessage(
                    successCount +
                    " Master Carton label(s) reprinted successfully.",
                    1);


                /*====================================================
                    8. CLEAR GRID & INPUT
                ====================================================*/

                dgvMasterReprintData.Rows.Clear();

                //txtMCSerial.Clear();

                //txtMCSerial.Focus();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(
                    ex.Message,
                    3);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
                       dt.Rows[0][6].ToString();
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
    }
}
