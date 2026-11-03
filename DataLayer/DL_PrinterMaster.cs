using StockCraft.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace StockCraft.DataLayer
{
    public class DL_PrinterMaster
    {
        Common obj = new Common();
        SqlCommand cmd;

        //======================== GET ========================

        public DataTable GetPrinter()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_PRINTERMASTER";
                cmd.Parameters.AddWithValue("@Type", "GET");

                DataSet ds = obj.ExecuteDataset(cmd);

                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());
                throw;
            }

            return dt;
        }

        //======================== SAVE ========================

        public DataTable SavePrinter(PrinterMasterModel m)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_PRINTERMASTER";

                cmd.Parameters.AddWithValue("@Type", "SAVE");
                cmd.Parameters.AddWithValue("@PrinterIP", m.PrinterIP);
                cmd.Parameters.AddWithValue("@PrinterPort", m.PrinterPort);
                cmd.Parameters.AddWithValue("@PrinterIPMC", m.PrinterIPMC);
                cmd.Parameters.AddWithValue("@ScannerIP", m.ScannerIP);
                cmd.Parameters.AddWithValue("@ScannerPort", m.ScannerPort);
                cmd.Parameters.AddWithValue("@PLCIP", m.PLCIP);
                cmd.Parameters.AddWithValue("@PLCPort", m.PLCPort);
                cmd.Parameters.AddWithValue("@LineCode", m.LineCode);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);

                DataSet ds = obj.ExecuteDataset(cmd);

                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());
                throw;
            }

            return dt;
        }

        //======================== UPDATE ========================

        public DataTable UpdatePrinter(PrinterMasterModel m)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_PRINTERMASTER";

                cmd.Parameters.AddWithValue("@Type", "UPDATE");
                cmd.Parameters.AddWithValue("@PrinterId", m.PrinterId);
                cmd.Parameters.AddWithValue("@PrinterIP", m.PrinterIP);
                cmd.Parameters.AddWithValue("@PrinterPort", m.PrinterPort);
                cmd.Parameters.AddWithValue("@ScannerIP", m.ScannerIP);
                cmd.Parameters.AddWithValue("@ScannerPort", m.ScannerPort);
                cmd.Parameters.AddWithValue("@PrinterIPMC", m.PrinterIPMC);
                cmd.Parameters.AddWithValue("@PLCIP", m.PLCIP);
                cmd.Parameters.AddWithValue("@PLCPort", m.PLCPort);
                cmd.Parameters.AddWithValue("@LineCode", m.LineCode);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);

                DataSet ds = obj.ExecuteDataset(cmd);

                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());
                throw;
            }

            return dt;
        }

        //======================== DELETE ========================

        public DataTable DeletePrinter(int PrinterId)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_PRINTERMASTER";

                cmd.Parameters.AddWithValue("@Type", "DELETE");
                cmd.Parameters.AddWithValue("@PrinterId", PrinterId);

                DataSet ds = obj.ExecuteDataset(cmd);

                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message,
                    DTPLLogs.DTPLLogsWrite.LogType.Error,
                    MethodBase.GetCurrentMethod());
                throw;
            }

            return dt;
        }
    }
}