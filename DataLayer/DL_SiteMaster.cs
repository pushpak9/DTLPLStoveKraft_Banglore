using StockCraft.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace StockCraft.DataLayer
{
    public class DL_SiteMaster
    {
        Common obj = new Common();
        SqlCommand cmd = null;
        public DataTable dtGetSite()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SITEMASTER";
                cmd.Parameters.AddWithValue("@type", "GETSITE");
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
        public DataTable dtSiteByID(string sSiteCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SITEMASTER";
                cmd.Parameters.AddWithValue("@type", "GETSITEBYID");
                cmd.Parameters.AddWithValue("@SITECODE", sSiteCode);
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
        public DataTable SaveSite(SiteMasterModel request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SITEMASTER";
                cmd.Parameters.AddWithValue("@type", "SAVE");
                cmd.Parameters.AddWithValue("@SiteCode", request.SiteCode);
                cmd.Parameters.AddWithValue("@SiteName", request.SiteName);
                cmd.Parameters.AddWithValue("@SiteAddress", request.SiteAddress);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);
                cmd.Parameters.AddWithValue("@State", request.City);
                cmd.Parameters.AddWithValue("@City", request.State);
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
        public DataTable UpdateSite(SiteMasterModel request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SITEMASTER";
                cmd.Parameters.AddWithValue("@type", "UPDATE");
                cmd.Parameters.AddWithValue("@SiteCode", request.SiteCode);
                cmd.Parameters.AddWithValue("@SiteName", request.SiteName);
                cmd.Parameters.AddWithValue("@SiteAddress", request.SiteAddress);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);
                cmd.Parameters.AddWithValue("@State", request.City);
                cmd.Parameters.AddWithValue("@City", request.State);
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
        public DataTable DeleteSite(SiteMasterModel request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SITEMASTER";
                cmd.Parameters.AddWithValue("@type", "DELETESITE");
                cmd.Parameters.AddWithValue("@SiteCode", request.SiteCode);
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