using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StockCraft.PL;

namespace StockCraft.DataLayer
{
    internal class DL_Report
    {
        Common obj = new Common();
        SqlCommand cmd = null;
        public DataTable dtGetReport(string sFilterType,string sFilterValue,string sFromDate,string sToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_DataValidationReport";
                cmd.Parameters.AddWithValue("@type", "GETREPORT");
                cmd.Parameters.AddWithValue("@FROMDATE", sFromDate);
                cmd.Parameters.AddWithValue("@TODATE", sToDate);
                cmd.Parameters.AddWithValue("@FilterValue", sFilterValue);
                cmd.Parameters.AddWithValue("@FilterType", sFilterType);
                cmd.Parameters.AddWithValue("@SITECODE", PCommon.SiteCode);
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

        public DataTable dtGetReportInspectionNew(string sFilterType, string sFilterValue, string sFromDate, string sToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_DataValidationReport";
                cmd.Parameters.AddWithValue("@type", "GETREPORTInspecTionLast");
                cmd.Parameters.AddWithValue("@FROMDATE", sFromDate);
                cmd.Parameters.AddWithValue("@TODATE", sToDate);
                cmd.Parameters.AddWithValue("@FilterValue", sFilterValue);
                cmd.Parameters.AddWithValue("@FilterType", sFilterType);
                cmd.Parameters.AddWithValue("@SITECODE", PCommon.SiteCode);
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

        public DataTable dtGetReportInspectionMissing(string sFilterType, string sFilterValue, string sFromDate, string sToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_DataValidationReport";
                cmd.Parameters.AddWithValue("@type", "GETMISSINGSCAN");
                cmd.Parameters.AddWithValue("@FROMDATE", sFromDate);
                cmd.Parameters.AddWithValue("@TODATE", sToDate);
                cmd.Parameters.AddWithValue("@FilterValue", sFilterValue);
                cmd.Parameters.AddWithValue("@FilterType", sFilterType);
                cmd.Parameters.AddWithValue("@SITECODE", PCommon.SiteCode);
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

        public DataTable dtGetReportInspection(string sFilterType, string sFilterValue, string sFromDate, string sToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_DataValidationReport";
                cmd.Parameters.AddWithValue("@type", "GETREPORTInspecTion");
                cmd.Parameters.AddWithValue("@FROMDATE", sFromDate);
                cmd.Parameters.AddWithValue("@TODATE", sToDate);
                cmd.Parameters.AddWithValue("@FilterValue", sFilterValue);
                cmd.Parameters.AddWithValue("@FilterType", sFilterType);
                cmd.Parameters.AddWithValue("@SITECODE", PCommon.SiteCode);
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

        public DataTable dtGetReportReset(string sFilterType, string sFilterValue, string sFromDate, string sToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_DataValidationReport";
                cmd.Parameters.AddWithValue("@type", "GETMasterREPORT");
                cmd.Parameters.AddWithValue("@FROMDATE", sFromDate);
                cmd.Parameters.AddWithValue("@TODATE", sToDate);
                cmd.Parameters.AddWithValue("@FilterValue", sFilterValue);
                cmd.Parameters.AddWithValue("@FilterType", sFilterType);
                cmd.Parameters.AddWithValue("@SITECODE", PCommon.SiteCode);
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
