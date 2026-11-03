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
    public class DLWorkOrder
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
        public DataTable dtBindWorkOrder()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_GET_WORKORDER";
                cmd.Parameters.AddWithValue("@type", "WORKORDER");
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
                cmd.CommandText = "USP_Data_Scan";
                cmd.Parameters.AddWithValue("@type", "GETLINEDETAILS");
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

        public DataTable PDIInspection(string ItemBarcode, string Remarks,string sItemCode)
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
                cmd.Parameters.AddWithValue("@PDIREMARKS", Remarks);
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
