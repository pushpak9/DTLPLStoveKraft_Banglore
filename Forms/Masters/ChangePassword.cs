using DTPLLogs;
using MaterialSkin.Controls;
using StockCraft;
using StockCraft.BusinessLayer;
using StockCraft.DataLayer;
using StockCraft.PL;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace StockCraft
{
    public partial class ChangePassword : MaterialForm
    {
        public ChangePassword()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.Text = string.Empty;
            //txtPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            //txtPassword.Focus();
        }
        DL_UserLogin obj = new DL_UserLogin();
        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                string sResult = string.Empty;
                //if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                //{
                //    blCommon.ShowMessage("Please enter password", 1);
                //    txtPassword.Focus();
                //    return;
                //}
                if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
                {
                    blCommon.ShowMessage("Please enter new password", 1);
                    txtNewPassword.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
                {
                    blCommon.ShowMessage("Please enter confirm password", 1);
                    txtNewPassword.Focus();
                    return;
                }
                //if (txtNewPassword.Text.Trim() == txtPassword.Text.Trim())
                //{
                //    blCommon.ShowMessage("New password and password should not be same", 1);
                //    txtPassword.Focus();
                //    txtPassword.Text = string.Empty;
                //    txtNewPassword.Text = string.Empty;
                //    txtConfirmPassword.Text = string.Empty;
                //    return;
                //}
                if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    blCommon.ShowMessage("New password and confirm password should be same", 1);
                    txtNewPassword.Focus();
                    txtNewPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                    return;
                }
                UserMasterModel plobj = new UserMasterModel();
                DataTable dt = new DataTable();
                dt = obj.ChangePassword(PCommon.UserID, txtNewPassword.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    sResult = dt.Rows[0][0].ToString();
                    if (sResult.StartsWith("N~"))
                    {
                        blCommon.ShowMessage(sResult.Split('~')[1], 2);
                        txtNewPassword.Focus();
                        txtNewPassword.Text = string.Empty;
                        txtConfirmPassword.Text = string.Empty;
                        return;
                    }
                    else
                    {
                        blCommon.ShowMessage(sResult.Split('~')[1], 1);
                        txtNewPassword.Focus();
                        txtNewPassword.Text = string.Empty;
                        txtConfirmPassword.Text = string.Empty;
                        return;
                       
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
    }
}
