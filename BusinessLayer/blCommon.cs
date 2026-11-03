using DTPLLogs;
using iTextSharp.text;
using iTextSharp.text.pdf;
using StockCraft.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace StockCraft.BusinessLayer
{
    public static class blCommon
    {
        public static bool bPasswordOK = false;
        public static string strLogFile = Application.StartupPath + "\\Log\\";
        public static string sMessageBox = "Mahindra Pharma  APPLICATION [VER : - " + Application.ProductVersion + " ]";
        public static void FillComboBox(ComboBox cbo, DataTable dt, bool isSelect)
        {
            try
            {
                if (isSelect)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "--Select--";



                    dt.Rows.InsertAt(dr, 0);
                }
                cbo.DisplayMember = dt.Columns[0].ToString();
                cbo.ValueMember = dt.Columns[1].ToString();
                cbo.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string getOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            System.Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else
                            operatingSystem = "7";
                        break;
                    default:
                        break;
                }
            }

            if (operatingSystem != "")
            {
                //Got something.  Let's prepend "Windows" and get more info.
                operatingSystem = "Windows " + operatingSystem;
                //See if there's a service pack installed.
                if (os.ServicePack != "")
                {
                    //Append it to the OS name.  i.e. "Windows XP Service Pack 3"
                    operatingSystem += " " + os.ServicePack;
                }
                //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                //operatingSystem += " " + getOSArchitecture().ToString() + "-bit";
            }
            //Return the information we've gathered.
            return operatingSystem;
        }

        public static string ReplaceChildReprintPrnValue(
       string sPrn,
       string IBSerial,
       string ProductCode)
        {
            string sFinalPrn = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(sPrn))
                {
                    throw new Exception("PRN data is empty.");
                }

                /*====================================================
                    CHILD REPRINT PRN VALUES
                ====================================================*/

                sPrn = sPrn.Replace(
                    "HVARBARCODE",
                    IBSerial ?? "");

                sPrn = sPrn.Replace(
                    "Text",
                    IBSerial ?? "");

                sPrn = sPrn.Replace(
                 "ProductCode",
                 ProductCode ?? "");

                //sPrn = sPrn.Replace(
                //    "{Model}",
                //    Model ?? "");

                //sPrn = sPrn.Replace(
                //    "{Wattage}",
                //    Wattage ?? "");

                //sPrn = sPrn.Replace(
                //    "{Voltage}",
                //    Voltage ?? "");

                //sPrn = sPrn.Replace(
                //    "{DegreeOfProtection}",
                //    DegreeOfProtection ?? "");

                //sPrn = sPrn.Replace(
                //  "{parContent}",
                //  parContent ?? "");


                sFinalPrn = sPrn;

                PCommon.mAppLog.WriteLog(
                    "Child Reprint PRN : " + sFinalPrn,
                    DTPLLogsWrite.LogType.Information,
                    MethodBase.GetCurrentMethod());
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                throw;
            }

            return sFinalPrn;
        }

        public static string ReplaceMasterReprintPrnValue(
      string sPrn,
      string MCBoxSerial,
      string PartCode)
        {
            string sFinalPrn = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(sPrn))
                {
                    throw new Exception(
                        "Master Carton PRN data is empty.");
                }

                if (string.IsNullOrWhiteSpace(MCBoxSerial))
                {
                    throw new Exception(
                        "MC Serial is empty.");
                }

                /*========================================
                    BARCODE VALUE
                ========================================*/

                sPrn = sPrn.Replace(
                    "HvarBarcode",
                    MCBoxSerial);


                /*========================================
                    TEXT BELOW BARCODE
                ========================================*/

                sPrn = sPrn.Replace(
                    "Text",
                    MCBoxSerial);

                sPrn = sPrn.Replace(
                   "ProductCode",
                   PartCode);


                sFinalPrn = sPrn;

                PCommon.mAppLog.WriteLog(
                    "Master Reprint PRN : " +
                    sFinalPrn,
                    DTPLLogsWrite.LogType.Information,
                    MethodBase.GetCurrentMethod());
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                throw;
            }

            return sFinalPrn;
        }

        public static void FillSingleColumnCombo(ComboBox cbo, DataTable dt, bool isSelect)
        {
            try
            {
                if (isSelect)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "--Select--";
                    dt.Rows.InsertAt(dr, 0);
                }
                cbo.DisplayMember = dt.Columns[0].ToString();
                cbo.ValueMember = dt.Columns[0].ToString();
                cbo.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ShowMessage(string sMessage, int iWhich)
        {
            switch (iWhich)
            {
                case 1:
                    MessageBox.Show(sMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show(sMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 3:
                    MessageBox.Show(sMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 4:
                    break;
            }
        }
        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            // Create the result table, and gather all properties of a T        
            DataTable table = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Add the properties as columns to the datatable
            foreach (var prop in props)
            {
                Type propType = prop.PropertyType;

                // Is it a nullable type? Get the underlying type 
                if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    propType = new NullableConverter(propType).UnderlyingType;

                table.Columns.Add(prop.Name, propType);
            }

            // Add the property values per T as rows to the datatable
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                    values[i] = props[i].GetValue(item, null);

                table.Rows.Add(values);
            }

            return table;
        }

        public static void OnlyNumeric(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public static void OnlyChar(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        public static void DecimalValidation(KeyPressEventArgs e, object sender)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }
        public static void txtForIP(KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split(',');
            DataTable dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();

                if (str != "")
                {
                    string[] rows = str.Split(',');

                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        public static string ExportToCSVFile(DataTable dtTable)
        {
            StringBuilder sbldr = new StringBuilder();
            try
            {
                if (dtTable.Columns.Count != 0)
                {
                    foreach (DataColumn col in dtTable.Columns)
                    {
                        sbldr.Append(col.ColumnName + ',');
                    }
                    sbldr.Append("\r\n");
                    foreach (DataRow row in dtTable.Rows)
                    {
                        foreach (DataColumn column in dtTable.Columns)
                        {
                            sbldr.Append(row[column].ToString() + ',');
                        }
                        sbldr.Append("\r\n");
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return sbldr.ToString();
        }

        public static DataTable getInstalledPrinters()
        {
            DataTable dtPrinters = new DataTable();
            dtPrinters.Columns.Add("Display");
            dtPrinters.Columns.Add("Value");
            for (int i = 0; i <= System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1; i++)
            {
                DataRow drRow = dtPrinters.NewRow();
                drRow["Display"] = System.Drawing.Printing.PrinterSettings.InstalledPrinters[i].ToString();
                drRow["Value"] = System.Drawing.Printing.PrinterSettings.InstalledPrinters[i].ToString();
                dtPrinters.Rows.Add(drRow);
            }

            return dtPrinters;
        }
        public static string GetPrnIC()
        {
            string sPrn = string.Empty;
            try
            {
                string sPath = System.Windows.Forms.Application.StartupPath + "\\STOCKCRAFT.PRN";
                if (!File.Exists(sPath))
                {
                    return sPrn = "ERROR~Prn not found";
                }
                StreamReader sr = new StreamReader(sPath);
                sPrn = string.Empty;
                sPrn = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return sPrn;
        }

        public static string GetPrnMC()
        {
            string sPrn = string.Empty;
            try
            {
                string sPath = System.Windows.Forms.Application.StartupPath + "\\STOCKRAFMC.PRN";
                if (!File.Exists(sPath))
                {
                    return sPrn = "ERROR~Prn not found";
                }
                StreamReader sr = new StreamReader(sPath);
                sPrn = string.Empty;
                sPrn = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return sPrn;
        }


        public static string SendCommandToPrinter(string sPrinterIP, int iPrinterPort,
            string sPrn
            )
        {
            string sResult = string.Empty;
            TcpClient client = new TcpClient(sPrinterIP, iPrinterPort);
            NetworkStream stream = client.GetStream();
            try
            {

                PCommon.mAppLog.WriteLog("Socket Connect", DTPLLogsWrite.LogType.Information, MethodBase.GetCurrentMethod());
                byte[] sendData = Encoding.ASCII.GetBytes(sPrn);
                PCommon.mAppLog.WriteLog("Command Send", DTPLLogsWrite.LogType.Information, MethodBase.GetCurrentMethod());
                stream.Write(sendData, 0, sendData.Length);
                sResult = "Success";
            }
            catch (SocketException ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                sResult = "ERROR~" + ex.Message;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (client != null)
                {
                    client.Close();
                }
            }
            return sResult;
        }


        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        public static void ExportToPdf(System.Data.DataTable dt, string strFilePath, string sFileName)
        {
            Document document = new Document();
            Paragraph paragraph = new Paragraph(sFileName);
            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.SpacingAfter = 1f;
            paragraph.SpacingAfter = 10f;
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(strFilePath, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);
           // iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + "\\rooppolymerlogo");
           // jpg.ScaleToFit(120f, 100f);

            //Give space before image

           // jpg.SpacingBefore = 10f;

            //Give some space after the image

            //jpg.SpacingAfter = 1f;

           // jpg.Alignment = Element.ALIGN_LEFT;
            //document.Add(jpg);
            document.Add(paragraph);
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
                widths[i] = 4f;

            table.SetWidths(widths);

            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";


            PdfPCell cell = new PdfPCell(new Phrase("Products"));

            cell.Colspan = dt.Columns.Count;

            foreach (DataColumn c in dt.Columns)
            {
                table.AddCell(new Phrase(c.ColumnName, font5));
            }

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int h = 0; h < dt.Columns.Count; h++)
                    {
                        table.AddCell(new Phrase(r[h].ToString(), font5));
                    }
                }
            }
            document.Add(table);
            document.Close();
        }
        public static void exportToExcel1(DataTable dt, string sFilePath)
        {

            /*Set up work book, work sheets, and excel application*/
            Microsoft.Office.Interop.Excel.Application oexcel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Workbook obook = oexcel.Workbooks.Add(misValue);
                Microsoft.Office.Interop.Excel.Worksheet osheet = new Microsoft.Office.Interop.Excel.Worksheet();
                osheet = (Microsoft.Office.Interop.Excel.Worksheet)obook.Sheets["Sheet1"];
                int colIndex = 0;
                int rowIndex = 1;

                foreach (DataColumn dc in dt.Columns)
                {
                    colIndex++;
                    osheet.Cells[1, colIndex] = dc.ColumnName;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    rowIndex++;
                    colIndex = 0;

                    foreach (DataColumn dc in dt.Columns)
                    {
                        colIndex++;
                        if (colIndex == 4 || colIndex==5 || colIndex==12 || colIndex==13 || colIndex==14)
                        {
                            osheet.Cells[rowIndex, colIndex].NumberFormat = "0.000";
                            osheet.Cells[rowIndex, colIndex] = dr[dc.ColumnName];
                            //osheet.Cells[rowIndex, colIndex] = ("'" + dr[dc.ColumnName]);
                        }
                        if(colIndex == 11)
                        {
                            osheet.Cells[rowIndex, colIndex].NumberFormat = "@";
                            osheet.Cells[rowIndex, colIndex] = dr[dc.ColumnName];
                        }
                        else
                        {
                            osheet.Cells[rowIndex, colIndex] = dr[dc.ColumnName];
                        }
                    }
                }

                osheet.Columns.AutoFit();
                string filepath = sFilePath;

                //Release and terminate excel

                obook.SaveAs(filepath);
                obook.Close();
                oexcel.Quit();
                releaseObject(osheet);

                releaseObject(obook);

                releaseObject(oexcel);
                GC.Collect();
            }
            catch (Exception ex)
            {
                oexcel.Quit();
            }
        }
        private static void releaseObject(object o)
        {
            try
            {
                while
                    (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0) { }
            }
            catch { }
            finally { o = null; }
        }

    }


}
