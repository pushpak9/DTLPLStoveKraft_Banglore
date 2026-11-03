using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using System.Data;
using MaterialSkin;
using StockCraft.DataLayer;
using DTPLLogs;
using StockCraft.BusinessLayer;
using System.Reflection;
using StockCraft.PL;
using System.Drawing;

namespace StockCraft
{
    public partial class UserMaster : MaterialForm
    {
        DL_UserMaster obj = new DL_UserMaster();
        public UserMaster()
        {
            InitializeComponent();
        }

        private void UserMaster_Load(object sender, EventArgs e)
        {
            try
            {
                MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey900, Primary.Blue500,
                Primary.Blue500, Accent.Red100,
                TextShade.WHITE);
                // Loading All data from Database
                setReload();
               
                _EnableDisableControls(false);
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;

            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
        public void setReload()
        {
            try
            {
                obj = new DL_UserMaster();
                DataTable dt = obj.GETUSER();
                lblNoOfRecords.Text = "No Of Records :" + dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    PCommon.FillListView(dt, lvUser);
                    lvUser.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvUser.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        #region Methods related to enable,disable and clear the controls

        void _EnableDisableControls(bool bControl)
        {
            txtUsername.Enabled = bControl;
            txtPassword.Enabled = bControl;
           
            txtUserId.Enabled = bControl;
            chkactive.Enabled = bControl;
        }

        void _ClearControls()
        {
            lvUser.Enabled = true;
            txtPassword.Text = string.Empty;
           
            txtUserId.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            chkactive.Checked = true;
            txtUsername.Focus();
        }

        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEdit.Text != "SAVE")
                {
                    btnAdd.Enabled = false;
                    txtUserId.Enabled = false;
                    txtUsername.Focus();
                    if (txtUserId.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please select the record from grid", 2);
                        return;
                    }
                }
                else
                {
                    if (txtUserId.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter user id", 2);
                        txtUserId.Focus(); return;
                    }
                    if (txtUsername.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter user name", 2);
                        txtUsername.Focus(); return;
                    }                   
                    
                    UserMasterModel plobj = new UserMasterModel();
                    plobj.UserID = txtUserId.Text.Trim();
                    plobj.UserName = txtUsername.Text.Trim();
                    plobj.UserType = cmbUserType.Text;
                    plobj.Password = txtPassword.Text.Trim();
                   
                    if (chkactive.Checked == true)
                    {
                        plobj.Active = "1";
                    }
                    else if (chkactive.Checked == false)
                    {
                        plobj.Active = "0";
                    }
                    DataTable dt = obj.UpdateUser(plobj);
                    if (dt.Rows.Count > 0)
                    {
                        string sResult = dt.Rows[0][0].ToString();
                        if (sResult.StartsWith("SUCCESS~"))
                        {
                            blCommon.ShowMessage("Data saved successfully.", 1);
                        }
                        else
                        {
                            blCommon.ShowMessage(sResult, 2);
                        }
                    }
                    _EnableDisableControls(false);
                    _ClearControls();
                    btnEdit.Text = "EDIT";
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
            finally
            {
                setReload();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "ADD")
                {
                    _ClearControls();
                    _EnableDisableControls(true);
                    txtUserId.Focus();
                    btnAdd.Text = "SAVE";
                }
                else
                {
                    if (txtUserId.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter user id", 2);
                        txtUserId.Focus(); return;
                    }
                    if (txtUsername.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter user name", 2);
                        txtUsername.Focus(); return;
                    }
                  
                    UserMasterModel plobj = new UserMasterModel();
                    plobj.UserID = txtUserId.Text.Trim();
                    plobj.UserName = txtUsername.Text.Trim();
                    plobj.UserType = cmbUserType.Text;
                    plobj.Password = txtPassword.Text.Trim();
                    
                    if (chkactive.Checked == true)
                    {
                        plobj.Active = "1";
                    }
                    else if (chkactive.Checked == false)
                    {
                        plobj.Active = "0";
                    }
                    DataTable dt = obj.SaveUser(plobj);
                    if (dt.Rows.Count > 0)
                    {
                        string sResult = dt.Rows[0][0].ToString();
                        if (sResult.StartsWith("SUCCESS~"))
                        {
                            blCommon.ShowMessage("Data saved successfully.", 1);
                        }
                        else
                        {
                            blCommon.ShowMessage(sResult, 2);
                        }
                    }
                    setReload();
                    _ClearControls();
                    _EnableDisableControls(false);
                    btnAdd.Text = "ADD";
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _ClearControls();
            _EnableDisableControls(false);  
            btnAdd.Enabled = true;
            btnEdit.Enabled = false; 
            btnDelete.Enabled = false;
            btnEdit.Text = "EDIT";
            btnAdd.Text = "ADD";
        }

        private void lvUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                foreach (ListViewItem _item in lvUser.Items)
                {
                    if (_item.Selected == true)
                    {
                        _EnableDisableControls(true);
                        btnEdit.Text = "SAVE";
                        btnAdd.Enabled = false;
                        btnDelete.Enabled = true;
                        btnEdit.Enabled = true;
                        txtUserId.Text = _item.Text.Trim();
                        txtUserId.Enabled = false;
                        txtUsername.Text = _item.SubItems[1].Text.Trim();
                        cmbUserType.Text = _item.SubItems[2].Text.Trim();
                      
                        if (_item.SubItems[4].Text.Trim() == "True" || _item.SubItems[4].Text.Trim() =="1")
                        {
                            chkactive.Checked = true;
                        }
                        else
                        {
                            chkactive.Checked = false;
                        }
                        lvUser.Enabled = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEdit.Text == "Edit")
                {
                    blCommon.ShowMessage("Please select atleast one record from grid", 2);
                    return;
                }
                DialogResult dr = MessageBox.Show("Do you want to delete the record", blCommon.sMessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
                UserMasterModel plobj = new UserMasterModel();
                plobj.UserID = txtUserId.Text.Trim();
                plobj.UserName = txtUsername.Text.Trim();
                plobj.UserType = cmbUserType.Text;
                plobj.Password = txtPassword.Text.Trim();
                if (chkactive.Checked == true)
                {
                    plobj.Active = "1";
                }
                else if (chkactive.Checked == false)
                {
                    plobj.Active = "0";
                }
                DataTable dt = obj.DeleteUser(plobj);
                if (dt.Rows.Count > 0)
                {
                    string sResult = dt.Rows[0][0].ToString();
                    if (sResult.StartsWith("SUCCESS~"))
                    {
                        blCommon.ShowMessage("Data deleted successfully.", 1);
                    }
                    else
                    {
                        blCommon.ShowMessage(sResult, 2);
                    }
                }
                _ClearControls();
                _EnableDisableControls(false);                
                btnEdit.Text = "EDIT";
                btnAdd.Text = "ADD";
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
            finally
            {
                setReload();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lvUser_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            ColumnHeader ch = lvUser.Columns[e.ColumnIndex];
            HorizontalAlignment colHal = ch.TextAlign;
            HorizontalAlignment headHal = colHal;
            ch.TextAlign = HorizontalAlignment.Center;

            SizeF size = e.Graphics.MeasureString(ch.Text, e.Font);

            float x =
                headHal == HorizontalAlignment.Center ? (e.Bounds.Width - size.Width) / 2f :
                headHal == HorizontalAlignment.Right ? (e.Bounds.Width - size.Width) : 0f;

            e.DrawBackground();

            using (SolidBrush brush = new SolidBrush(e.ForeColor))
                e.Graphics.DrawString(ch.Text, e.Font, brush,
                                      e.Bounds.X + x, 5f, StringFormat.GenericDefault);
        }
    }
}
