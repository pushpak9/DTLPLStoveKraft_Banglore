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
    public class DL_lblPrint
    {
        Common obj = new Common();
        SqlCommand cmd = null;

        public DataTable SavePartLabelData(RMLabelModel request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_PartLabel_Save";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerPartNo", request.CustomerPartNo);
                cmd.Parameters.AddWithValue("@MfgDateBatchLotNo", request.MfgDateBatchLotNo);
                cmd.Parameters.AddWithValue("@MfgShift", request.MfgShift);
                cmd.Parameters.AddWithValue("@BatchNo", request.MfgDateBatchLotNo);
                cmd.Parameters.AddWithValue("@CustomerInitials", request.CustomerInitial);
                cmd.Parameters.AddWithValue("@ResetBy", PCommon.UserID);


                DataSet ds = obj.ExecuteDataset(cmd);

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
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
