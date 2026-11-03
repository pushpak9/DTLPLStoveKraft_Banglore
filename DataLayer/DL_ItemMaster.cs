using DocumentFormat.OpenXml.Office2010.Excel;
using StockCraft.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace StockCraft.DataLayer
{
    public class DL_ItemMaster
    {
        Common obj = new Common();
        SqlCommand cmd;

        public DataTable GetItem()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_ITEMMASTER";
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

        public DataTable SaveItem(ItemMasterModel m)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_ITEMMASTER";
                cmd.Parameters.AddWithValue("@type", "SAVE");
                cmd.Parameters.AddWithValue("@Model", m.Model);
                cmd.Parameters.AddWithValue("@Wattage", m.Wattage);
                cmd.Parameters.AddWithValue("@ProductCode", m.ProductID);
                cmd.Parameters.AddWithValue("@Voltage", m.Voltage);
                cmd.Parameters.AddWithValue("@DegreeOfProtection", m.Degree);
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

        public DataTable UpdateItem(ItemMasterModel m)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_ITEMMASTER";
                cmd.Parameters.AddWithValue("@type", "UPDATE");
                cmd.Parameters.AddWithValue("@Model", m.Model);
                cmd.Parameters.AddWithValue("@Wattage", m.Wattage);
                cmd.Parameters.AddWithValue("@ProductCode", m.ProductID);
                cmd.Parameters.AddWithValue("@Voltage", m.Voltage);
                cmd.Parameters.AddWithValue("@DegreeOfProtection", m.Degree);
                cmd.Parameters.AddWithValue("@Id", m.ItemId);
                
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
    }
}