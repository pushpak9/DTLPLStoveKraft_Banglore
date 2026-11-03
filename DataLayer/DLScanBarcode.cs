using StockCraft.PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace StockCraft.DataLayer
{
    public class DLScanBarcode
    {
        Common obj = new Common();
        SqlCommand cmd = null;

        public DataTable dtGetiMGE(string sItemCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_ITEMMASTER";
                cmd.Parameters.AddWithValue("@type", "GETIMGAGEFROMITEMCODE");
                cmd.Parameters.AddWithValue("@SITECODE", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@ITEMCODE", sItemCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public bool SaveApplicationLog(string sLogMessage)
        {
            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_APPLICATIONLOG";

                cmd.Parameters.AddWithValue(
                    "@TYPE",
                    "SAVELOG");

                cmd.Parameters.AddWithValue(
                    "@LOGMESSAGE",
                    sLogMessage);

                obj.ExecuteDataset(cmd);

                return true;
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                return false;
            }
        }


        public DataTable dtBindLine()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LineMASTER";
                cmd.Parameters.AddWithValue("@type", "BindLine");
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }
        public DataTable getLineDetails(string sLineCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LineMASTER";
                cmd.Parameters.AddWithValue("@type", "BindPrinter");
                cmd.Parameters.AddWithValue("@LINECODE", sLineCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataTable getIp()
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_ChildPrintHistory";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "BindPrinter");

                cmd.Parameters.AddWithValue(
                    "@IBSerial",
                    "");

                DataSet ds = obj.ExecuteDataset(cmd);

                if (ds != null &&
                    ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                throw;
            }

            return dt;
        }

        public DataTable getMasterReprintData(string MCBoxSerial)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText =
                    "USP_MasterPrintHistory";

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "GETREPRINT");

                cmd.Parameters.AddWithValue(
                    "@MCBoxSerial",
                    MCBoxSerial == null
                        ? ""
                        : MCBoxSerial.Trim());

                DataSet ds =
                    obj.ExecuteDataset(cmd);

                if (ds != null &&
                    ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                throw;
            }

            return dt;
        }


        public DataTable ReprintMaster(string MCBoxSerial)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText =
                    "USP_MasterPrintHistory";

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "REPRINT");

                cmd.Parameters.AddWithValue(
                    "@MCBoxSerial",
                    MCBoxSerial == null
                        ? ""
                        : MCBoxSerial.Trim());

                DataSet ds =
                    obj.ExecuteDataset(cmd);

                if (ds != null &&
                    ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                //PCommon.mAppLog.WriteLog(
                //    ex.Message,
                //    DTPLLogs.DTPLLogsWrite.Error,
                //    MethodBase.GetCurrentMethod());

                throw;
            }

            return dt;
        }

        public DataTable getMasterPrinter()
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText =
                    "USP_MasterPrintHistory";

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "BindPrinter");

                cmd.Parameters.AddWithValue(
                    "@MCBoxSerial",
                    "");

                DataSet ds =
                    obj.ExecuteDataset(cmd);

                if (ds != null &&
                    ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                //PCommon.mAppLog.WriteLog(
                //    ex.Message,
                //    DTPLLogs.DTPLLogsWrite.Error,
                //    MethodBase.GetCurrentMethod());

                throw;
            }

            return dt;
        }


        public DataTable getReprintData(string ChildBarcode)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_ChildPrintHistory";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "GETREPRINT");

                cmd.Parameters.AddWithValue(
                    "@IBSerial",
                    ChildBarcode == null
                        ? ""
                        : ChildBarcode.Trim());

                DataSet ds = obj.ExecuteDataset(cmd);

                if (ds != null &&
                    ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                throw;
            }

            return dt;
        }

        public DataTable ReprintChild(string ChildBarcode)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_ChildPrintHistory";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Type", "REPRINT");
                cmd.Parameters.AddWithValue(
                    "@IBSerial",
                    ChildBarcode == null ? "" : ChildBarcode.Trim());

                DataSet ds = obj.ExecuteDataset(cmd);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                throw;
            }

            return dt;
        }


        public DataTable getProductCodeDetails(string OrderNumber)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_GetOrderSerial";
                cmd.Parameters.AddWithValue("@type", "GETPART");
                cmd.Parameters.AddWithValue("@OrderNumber", OrderNumber);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataTable UpdateScanCount(
       string WorkOrderNo,
       string PartCode,
       string Barcode)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_GetOrderSerial";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Type", "UpdateScanCount");
                cmd.Parameters.AddWithValue("@OrderNumber", WorkOrderNo);
                cmd.Parameters.AddWithValue("@PartCode", PartCode);
                cmd.Parameters.AddWithValue("@Barcode", Barcode);

                DataSet ds = obj.ExecuteDataset(cmd);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(
                    ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());

                throw;
            }

            return dt;
        }

        public DataTable GetTotalMC(string OrderNumber)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_GetOrderSerial";
                cmd.Parameters.AddWithValue("@type", "GETTOTALMC");
                cmd.Parameters.AddWithValue("@OrderNumber", OrderNumber);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }
        public DataTable GetChildPrintDataDetails(string OrderNumber, string partcode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_GetOrderSerial";
                cmd.Parameters.AddWithValue("@type", "GETSERIAL");
                cmd.Parameters.AddWithValue("@OrderNumber", OrderNumber);
                cmd.Parameters.AddWithValue("@PartCode", partcode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }
        public DataTable GetPackSize(string ItemCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_Data_Scan";
                cmd.Parameters.AddWithValue("@type", "GETPACKSIZE");
                cmd.Parameters.AddWithValue("@ITEMCODE", ItemCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }
        public DataTable GetScanCount(string ScannedBy,string sLineCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_Data_Scan";
                cmd.Parameters.AddWithValue("@type", "GETSCANCOUNT");
                cmd.Parameters.AddWithValue("@LINECODE", ScannedBy);
                cmd.Parameters.AddWithValue("@SCANNEDBY", sLineCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }
        public DataTable SaveData(string ScannedBy, string sLineCode,string sItemCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_Data_Scan";
                cmd.Parameters.AddWithValue("@type", "SAVEDATA");
                cmd.Parameters.AddWithValue("@LINECODE", ScannedBy);
                cmd.Parameters.AddWithValue("@SCANNEDBY", sLineCode);
                cmd.Parameters.AddWithValue("@ITEMCODE", sItemCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataTable PrintData(string ScannedBy, string sLineCode, string sItemCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_Data_Scan";
                cmd.Parameters.AddWithValue("@type", "PRINTDATA");
                cmd.Parameters.AddWithValue("@LINECODE", sLineCode);
                cmd.Parameters.AddWithValue("@SCANNEDBY", ScannedBy);
                cmd.Parameters.AddWithValue("@ITEMCODE", sItemCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataTable PDIInspection(string ItemBarcode,string sItemCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_Data_Scan";
                cmd.Parameters.AddWithValue("@type", "PDIINSPECTION");
                cmd.Parameters.AddWithValue("@ITEMCODE", sItemCode);
                cmd.Parameters.AddWithValue("@ITEMBARCODE", ItemBarcode);
                cmd.Parameters.AddWithValue("@SCANNEDBY", PCommon.UserID);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }
    }
}
