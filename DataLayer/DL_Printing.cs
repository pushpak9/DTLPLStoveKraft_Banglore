using StockCraft.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace StockCraft.DataLayer
{
    public class DL_Printing
    {
        Common obj = new Common();
        SqlCommand cmd;

        // =========================================================
        // SAVE PRINTING DATA
        // =========================================================
        public DataTable SavePrintingData(
            string ProductCode,
            string Model,
            string Wattage,
            string Voltage,
            string DegreeOfProtection,
            string ICSERIALN,
            string MCSERIALNO,
            string PackSize,
            string orderQty,
            string OrderNumber)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_GetOrderSerial";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Type", "SAVE");

                cmd.Parameters.AddWithValue("@OrderNumber",
                    (object)OrderNumber ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@ProductCode",
                    (object)ProductCode ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Model",
                    (object)Model ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Wattage",
                    (object)Wattage ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Voltage",
                    (object)Voltage ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@DegreeOfProtection",
                    (object)DegreeOfProtection ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@IBSerial",
                    (object)ICSERIALN ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@MCBoxSerial",
                    (object)MCSERIALNO ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@PackSize",
                    (object)PackSize ?? DBNull.Value);

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


        // =========================================================
        // DASHBOARD
        // =========================================================
        public DataTable GetDashboardData(
      string WorkOrderNo,
      string PartCode)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_GetOrderSerial";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "DASHBOARD");

                cmd.Parameters.AddWithValue(
                    "@OrderNumber",
                    WorkOrderNo);

                cmd.Parameters.AddWithValue(
                    "@PartCode",
                    PartCode);

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



        // =========================================================
        // CHILD PRINT
        // =========================================================
        public DataTable SaveChildPrint(
            string WorkOrderNo,
            string PartCode,
            string PartContent,
            string ProductCode,
            string Model,
            string Wattage,
            string Voltage,
            string DegreeOfProtection,
            string IBSerial,
            string MCBoxSerial,
            string PackSize,
            bool IsReprint
            )
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_GetOrderSerial";
                cmd.CommandType = CommandType.StoredProcedure;

                if (IsReprint)
                {
                    cmd.Parameters.AddWithValue(
                        "@Type",
                        "SAVECHILDREPRINT");
                }
                else
                {
                    cmd.Parameters.AddWithValue(
                        "@Type",
                        "SAVECHILDPRINT");
                }

                cmd.Parameters.AddWithValue("@OrderNumber",
                    (object)WorkOrderNo ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@PartCode",
                    (object)PartCode ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@PartContent",
                    (object)PartContent ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@ProductCode",
                    (object)ProductCode ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Model",
                    (object)Model ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Wattage",
                    (object)Wattage ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Voltage",
                    (object)Voltage ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@DegreeOfProtection",
                    (object)DegreeOfProtection ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@IBSerial",
                    (object)IBSerial ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@MCBoxSerial",
                    (object)MCBoxSerial ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@PackSize",
                    (object)PackSize ?? DBNull.Value);
                

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


        // =========================================================
        // MASTER PRINT
        // =========================================================
        public DataTable SaveMasterPrint(
            string WorkOrderNo,
            string PartCode,
            string PartContent,
            string ProductCode,
            string Model,
            string Wattage,
            string Voltage,
            string DegreeOfProtection,
            string MCBoxSerial,
           int packSize,
            bool IsReprint)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_GetOrderSerial";
                cmd.CommandType = CommandType.StoredProcedure;

                if (IsReprint)
                {
                    cmd.Parameters.AddWithValue(
                        "@Type",
                        "SAVEMASTERREPRINT");
                }
                else
                {
                    cmd.Parameters.AddWithValue(
                        "@Type",
                        "SAVEMASTERPRINT");
                }

                cmd.Parameters.AddWithValue("@OrderNumber",
                    (object)WorkOrderNo ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@PartCode",
                    (object)PartCode ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@PartContent",
                    (object)PartContent ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@ProductCode",
                    (object)ProductCode ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Model",
                    (object)Model ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Wattage",
                    (object)Wattage ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Voltage",
                    (object)Voltage ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@DegreeOfProtection",
                    (object)DegreeOfProtection ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@MCBoxSerial",
                    (object)MCBoxSerial ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@PackSize",
                    (object)packSize ?? DBNull.Value);

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


        // =========================================================
        // SCAN COUNT / SCAN
        // =========================================================
        public DataTable SaveScan(
            string WorkOrderNo,
            string PartCode,
            string PartContent,
            string Barcode)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_GetOrderSerial";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "UpdateScanCount");

                cmd.Parameters.AddWithValue(
                    "@OrderNumber",
                    (object)WorkOrderNo ?? DBNull.Value);

                cmd.Parameters.AddWithValue(
                    "@PartCode",
                    (object)PartCode ?? DBNull.Value);

                cmd.Parameters.AddWithValue(
                    "@PartContent",
                    (object)PartContent ?? DBNull.Value);

                cmd.Parameters.AddWithValue(
                    "@Barcode",
                    (object)Barcode ?? DBNull.Value);

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

        public DataTable CheckDuplicate(
         string WorkOrderNo,
         string PartCode,
         string ICSerial)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_GetOrderSerial";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "CHECKDUPLICATE");

                cmd.Parameters.AddWithValue(
                    "@OrderNumber",
                    WorkOrderNo ?? "");

                cmd.Parameters.AddWithValue(
                    "@PartCode",
                    PartCode ?? "");

                cmd.Parameters.AddWithValue(
                    "@IBSerial",
                    ICSerial ?? "");

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

        public DataTable CheckPrintedScan(
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

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "CHECKPRINTEDSCAN");

                cmd.Parameters.AddWithValue(
                    "@OrderNumber",
                    WorkOrderNo ?? "");

                cmd.Parameters.AddWithValue(
                    "@PartCode",
                    PartCode ?? "");

                cmd.Parameters.AddWithValue(
                    "@Barcode",
                    Barcode ?? "");

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

        public DataTable CompleteWorkOrder(
string WorkOrderNo)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText =
                    "USP_GET_WORKORDER";

                cmd.CommandType =
                    CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue(
                    "@Type",
                    "COMPLETEWORKORDER");


                cmd.Parameters.AddWithValue(
                    "@OrderNumber",
                    WorkOrderNo ?? "");


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

        public DataTable CheckNextChild(
    string WorkOrderNo,
    string PartCode,
    string ICSerial)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_GetOrderSerial";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "CHECKNEXTCHILD");

                cmd.Parameters.AddWithValue(
                    "@OrderNumber",
                    WorkOrderNo ?? "");

                cmd.Parameters.AddWithValue(
                    "@PartCode",
                    PartCode ?? "");

                cmd.Parameters.AddWithValue(
                    "@IBSerial",
                    ICSerial ?? "");

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


        public DataTable CheckNextSerial(
    string WorkOrderNo,
    string PartCode,
    string ICSerial,
    string MCSerial)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_GetOrderSerial";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "CHECKNEXTSERIAL");

                cmd.Parameters.AddWithValue(
                    "@OrderNumber",
                    WorkOrderNo ?? "");

                cmd.Parameters.AddWithValue(
                    "@PartCode",
                    PartCode ?? "");

                cmd.Parameters.AddWithValue(
                    "@IBSerial",
                    ICSerial ?? "");

                cmd.Parameters.AddWithValue(
                    "@MCBoxSerial",
                    MCSerial ?? "");

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

        public DataTable UpdateSerial(
            string WorkOrderNo,
            string PartCode,
            string ICSerial,
            string MCSerial)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_GetOrderSerial";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "UPDATESERIAL");

                cmd.Parameters.AddWithValue(
                    "@OrderNumber",
                    WorkOrderNo ?? "");

                cmd.Parameters.AddWithValue(
                    "@PartCode",
                    PartCode ?? "");

                cmd.Parameters.AddWithValue(
                    "@IBSerial",
                    ICSerial ?? "");

                cmd.Parameters.AddWithValue(
                    "@MCBoxSerial",
                    MCSerial ?? "");

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



        // =========================================================
        // SCAN HISTORY
        // =========================================================
        public DataTable SaveScanHistory(
            string WorkOrderNo,
            string PartCode,
            string PartContent,
            string Barcode,
            string IBSerial,
            string MCBoxSerial,
            string PackSize,
            int ScanCount,
            string Status)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_GetOrderSerial";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "SAVESCAN");

                cmd.Parameters.AddWithValue(
                    "@OrderNumber",
                    (object)WorkOrderNo ?? DBNull.Value);

                cmd.Parameters.AddWithValue(
                    "@PartCode",
                    (object)PartCode ?? DBNull.Value);

                cmd.Parameters.AddWithValue(
                    "@PartContent",
                    (object)PartContent ?? DBNull.Value);

                cmd.Parameters.AddWithValue(
                    "@Barcode",
                    (object)Barcode ?? DBNull.Value);

                cmd.Parameters.AddWithValue(
                    "@IBSerial",
                    (object)IBSerial ?? DBNull.Value);

                cmd.Parameters.AddWithValue(
                    "@MCBoxSerial",
                    (object)MCBoxSerial ?? DBNull.Value);

                cmd.Parameters.AddWithValue(
                    "@PackSize",
                    (object)PackSize ?? DBNull.Value);

                cmd.Parameters.AddWithValue(
                    "@ScanCount",
                    ScanCount);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    (object)Status ?? DBNull.Value);

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


        public DataTable GetLastPrintedSerial(
    string WorkOrderNo,
    string PartCode)
        {
            DataTable dt = new DataTable();

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "USP_GetOrderSerial";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Type",
                    "GETLASTPRINTED");

                cmd.Parameters.AddWithValue(
                    "@OrderNumber",
                    WorkOrderNo);

                cmd.Parameters.AddWithValue(
                    "@PartCode",
                    PartCode);

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
    }
}