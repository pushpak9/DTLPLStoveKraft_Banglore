using DocumentFormat.OpenXml.Office2010.Excel;
using StockCraft.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace StockCraft.DataLayer
{
    public class DL_LineMaster
    {
        Common obj = new Common();
        SqlCommand cmd;

        public DataTable GetItem()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LineMASTER";
                cmd.Parameters.AddWithValue("@type", "GET");

                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw;
            }
            return dt;
        }

        public DataTable SaveItem(LineMasterModel m)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LineMASTER";
                cmd.Parameters.AddWithValue("@type", "SAVE");
                cmd.Parameters.AddWithValue("@LineName", m.LineName);
                cmd.Parameters.AddWithValue("@LineCode", m.LineCode);
                cmd.Parameters.AddWithValue("@ItemId", m.ItemId);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);

                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw;
            }
            return dt;
        }

        public DataTable UpdateItem(LineMasterModel m)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LineMASTER";
                cmd.Parameters.AddWithValue("@type", "UPDATE");
                cmd.Parameters.AddWithValue("@LineName", m.LineName);
                cmd.Parameters.AddWithValue("@LineCode", m.LineCode);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);
                cmd.Parameters.AddWithValue("@ItemId", m.ItemId);

                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw;
            }
            return dt;
        }
    }
}