using StockCraft.PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCraft.DataLayer
{
    public class DL_CustomerMaster
    {
        Common obj = new Common();
        SqlCommand cmd;

        public DataTable GetCustomer()
        {
            cmd = new SqlCommand();
            cmd.CommandText = "USP_CUSTOMERMASTER";
            cmd.Parameters.AddWithValue("@type", "GET");
            return obj.ExecuteDataset(cmd).Tables[0];
        }

        public DataTable SaveCustomer(CustomerMasterModel m)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "USP_CUSTOMERMASTER";
            cmd.Parameters.AddWithValue("@type", "SAVE");
            cmd.Parameters.AddWithValue("@CustomerName", m.CustomerName);
            cmd.Parameters.AddWithValue("@CustomerInitial", m.CustomerInitial);
            cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);
            return obj.ExecuteDataset(cmd).Tables[0];
        }

        public DataTable UpdateCustomer(CustomerMasterModel m)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "USP_CUSTOMERMASTER";
            cmd.Parameters.AddWithValue("@type", "UPDATE");
            cmd.Parameters.AddWithValue("@CustomerId", m.CustomerId);
            cmd.Parameters.AddWithValue("@CustomerName", m.CustomerName);
            cmd.Parameters.AddWithValue("@CustomerInitial", m.CustomerInitial);
            return obj.ExecuteDataset(cmd).Tables[0];
        }
    }
}
