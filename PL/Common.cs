using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace StockCraft.PL
{
    public class Common
    {
        public DataSet ExecuteDataset(SqlCommand cmd) 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = PCommon.StrSqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public DataTable ExecuteDatatable(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = PCommon.StrSqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }
       
        public void newfillcombo(ComboBox combo, string procname, string mode)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = PCommon.StrSqlCon;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 30000;
            cmd.CommandText = procname;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@TYPE", mode);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sa.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "--Select--";
                dr[1] = "";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                combo.DataSource = ds.Tables[0];
                combo.DisplayMember = ds.Tables[0].Columns[0].ColumnName;
            }
            else
            {
                combo.Items.Clear();
            }
            sa.Dispose();
            ds.Dispose();
            con.Close();

        }
        public void newfillcombo1(ComboBox combo, string procname, string mode)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = PCommon.StrSqlCon;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 30000;
            cmd.CommandText = procname;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@TYPE", mode);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sa.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //DataRow dr = ds.Tables[0].NewRow();
                //dr[0] = "--Select--";
                //dr[1] = "";
                //ds.Tables[0].Rows.InsertAt(dr, 0);
                combo.DataSource = ds.Tables[0];
                combo.DisplayMember = ds.Tables[0].Columns[0].ColumnName;
            }
            else
            {
                combo.Items.Clear();
            }
            sa.Dispose();
            ds.Dispose();
            con.Close();

        }

        public  void GetSelectedData(ComboBox combo, string type, string Search)
        {
            string str = "select distinct  DrawnSizeName,DrawnSizeName from tblDrawnSizeMaster   where DrawnSizeName=" + Search + "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = PCommon.StrSqlCon;
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sa.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                combo.DataSource = ds.Tables[0].Rows;
                combo.DisplayMember = ds.Tables[0].Columns[0].ColumnName;
                //DrawnSizecomboBox.Text = ds.Tables[0].Rows;
            }
            else
            {
                combo.Items.Clear();
            }
            sa.Dispose();
            ds.Dispose();
            con.Close();

        }


    }
}