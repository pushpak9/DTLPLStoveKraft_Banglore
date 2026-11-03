using DTPLLogs;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace StockCraft
{
    public class PCommon
    {
        public static string strLogFile = Application.StartupPath;
        public static DTPLLogs.DTPLLogsWrite mAppLog = new DTPLLogsWrite();

        #region
        public static string sSiteCodePath { get; set; }
        public static string sDeptCodePath { get; set; }
        public static string sMachineCodePath { get; set; }
        public static string sPortNoPath { get; set; }
        public static string sDBSettingPath { get; set; }
        public static string sDbUserID = string.Empty;
        public static string sDbPassword = string.Empty;
        public static string sDbServerName = string.Empty;
        public static string sDbDataBaseName = string.Empty;  

        #endregion
        public static string GroupID = string.Empty;
        public static string UserID = string.Empty;
        public static string SiteCode = string.Empty;
        public static string DeptCode = string.Empty;
        public static string MachineCode = string.Empty;
        public static string GroupType = string.Empty;
        public static string UserName = string.Empty;
        public static string UserType = string.Empty;

        public static string sIPAddress = string.Empty;
        public static string StrCon = string.Empty;
        public static string StrSqlCon = string.Empty;
        public static string sHostName = string.Empty;
        public static string sSystemName = string.Empty;
        public static string iPortNo = string.Empty;
        public static string sIP = string.Empty;

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
        /// <summary>
        /// Fill list view
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="dt"></param>
        public static void FillListView(DataTable dt, ListView lv)
        {
            lv.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());

                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                lv.Items.Add(item);
            }
        }
        public static void KillUnusedExcelProcess()
        {
            Process[] oXlProcess = Process.GetProcessesByName("EXCEL");
            foreach (Process oXLP in oXlProcess)
            {
                oXLP.Kill();
            }
        }               

        //Used to fill the listview
        public static void FillListView(DataTable dt, ListView lv, bool clear)
        {
            if (clear)
                lv.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());

                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                lv.Items.Add(item);
            }
            // lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        public static void BindDropDown(ComboBox cmb, DataTable dt, string strtext, string strvalue)
        {
            if (dt.Rows.Count > 0)
            {
                DataRow dr;
                dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "--Select--" };
                dt.Rows.InsertAt(dr, 0);
                cmb.ValueMember = strvalue;
                cmb.DisplayMember = strtext;
                cmb.DataSource = dt;
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{

                //    cmb.Items.Add(dt.Rows[i][1]);
                //    cmb.ValueMember = dt.Rows[i][0].ToString();
                //}

            }
            else
            {
                cmb.DataSource = null;
            }
        }
    }
}
