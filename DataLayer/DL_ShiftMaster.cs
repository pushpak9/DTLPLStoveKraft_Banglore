using StockCraft.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace StockCraft.DataLayer
{
    public class DL_ShiftMaster
    {
        Common obj = new Common();
        SqlCommand cmd = null;

       
        public DataTable GetShift()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SHIFTMASTER";
                cmd.Parameters.AddWithValue("@type", "GET");

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

        // 🔹 GET BY ID
        public DataTable dtShiftByID(int shiftId)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SHIFTMASTER";
                cmd.Parameters.AddWithValue("@type", "GETBYID");
                cmd.Parameters.AddWithValue("@ShiftId", shiftId);

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

        // 🔹 SAVE
        public DataTable SaveShift(ShiftMasterModel request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SHIFTMASTER";
                cmd.Parameters.AddWithValue("@type", "SAVE");
                cmd.Parameters.AddWithValue("@ShiftName", request.ShiftName);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);

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

        // 🔹 UPDATE
        public DataTable UpdateShift(ShiftMasterModel request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SHIFTMASTER";
                cmd.Parameters.AddWithValue("@type", "UPDATE");
                cmd.Parameters.AddWithValue("@ShiftId", request.ShiftId);
                cmd.Parameters.AddWithValue("@ShiftName", request.ShiftName);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);

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

        // 🔹 DELETE (optional)
        public DataTable DeleteShift(ShiftMasterModel request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SHIFTMASTER";
                cmd.Parameters.AddWithValue("@type", "DELETE");
                cmd.Parameters.AddWithValue("@ShiftId", request.ShiftId);

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