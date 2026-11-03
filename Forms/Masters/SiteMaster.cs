using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using System.Data;
using StockCraft.DataLayer;
using StockCraft.BusinessLayer;
using DTPLLogs;
using System.Reflection;
using StockCraft.PL;

namespace StockCraft
{
    public partial class SiteMaster : MaterialForm
    {
        DL_SiteMaster obj = new DL_SiteMaster();
        public SiteMaster()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
              Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setReload()
        {
            try
            {
                obj = new DL_SiteMaster();
                DataTable dt = obj.dtGetSite();
                lblNoOfRecords.Text = "No Of Records :" + dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    PCommon.FillListView(dt, lvSite);
                    if (dt.Rows.Count >= 1)
                    {
                        //btnAdd.Enabled = false;
                        lvSite.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        lvSite.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
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
            txtId.Enabled = bControl;
            txtName.Enabled = bControl;
            txtState.Enabled = bControl;
            txtCity.Enabled = bControl;
            txtCity.Enabled = bControl;
            txtAddress.Enabled = bControl;
        }


        void _ClearControls()
        {
            txtState.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtId.Focus();
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                _ClearControls();
                _EnableDisableControls(false);
                btnEdit.Text = "EDIT";
                btnAdd.Text = "ADD";
                //btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                txtId.Focus();
                if (lvSite.Items.Count >= 1)
                {
                    btnAdd.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
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
                    txtId.Focus();
                    btnAdd.Text = "SAVE";
                    btnEdit.Enabled = false;
                }
                else
                {
                    if (txtId.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter site code", 2);
                        txtId.Focus(); return;
                    }
                    if (txtName.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter site name", 2);
                        txtName.Focus(); return;
                    }
                    if (txtState.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter state", 2);
                        txtState.Focus(); return;
                    }
                    if (txtCity.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter City", 2);
                        txtState.Focus(); return;
                    }
                    if (txtAddress.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter Address", 2);
                        txtState.Focus(); return;
                    }
                    SiteMasterModel plobj = new SiteMasterModel();
                    plobj.SiteCode = txtId.Text.Trim();
                    plobj.SiteName = txtName.Text.Trim();
                    plobj.SiteAddress = txtAddress.Text.Trim();
                    plobj.State = txtState.Text.Trim();
                    plobj.City = txtCity.Text.Trim();
                    DataTable dt = obj.SaveSite(plobj);
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
                    btnEdit.Enabled = true;
                    btnAdd.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEdit.Text != "SAVE")
                {
                    btnAdd.Enabled = false;
                    txtId.Enabled = false;
                    txtName.Focus();
                    if (txtId.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please select the record from grid", 2);
                        return;
                    }
                }
                else
                {
                    if (txtId.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter site code", 2);
                        txtId.Focus(); return;
                    }
                    if (txtName.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter site name", 2);
                        txtName.Focus(); return;
                    }
                    if (txtState.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter state", 2);
                        txtState.Focus(); return;
                    }
                    if (txtCity.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter City", 2);
                        txtState.Focus(); return;
                    }
                    if (txtAddress.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter Address", 2);
                        txtState.Focus(); return;
                    }
                    SiteMasterModel plobj = new SiteMasterModel();
                    plobj.SiteCode = txtId.Text.Trim();
                    plobj.SiteName = txtName.Text.Trim();
                    plobj.SiteAddress = txtAddress.Text.Trim();
                    plobj.State = txtState.Text.Trim();
                    plobj.City = txtCity.Text.Trim();
                    DataTable dt = obj.UpdateSite(plobj);
                    if (dt.Rows.Count > 0)
                    {
                        string sResult = dt.Rows[0][0].ToString();
                        if (sResult.StartsWith("SUCCESS~"))
                        {
                            blCommon.ShowMessage("Data Update successfully.", 1);
                        }
                        else
                        {
                            blCommon.ShowMessage(sResult, 2);
                        }
                    }
                    _ClearControls();
                    _EnableDisableControls(false);
                    btnEdit.Enabled = true;
                    _ClearControls();
                    setReload();
                    btnEdit.Text = "EDIT";
                    if (lvSite.Items.Count >= 1)
                    {
                        btnAdd.Enabled = false;
                    }
                    else
                    {
                        btnAdd.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }

        }

        private void lvSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnClear_Click(sender, e);
                foreach (ListViewItem _item in lvSite.Items)
                {
                    if (_item.Selected == true)
                    {
                        btnEdit.Text = "SAVE";
                        btnAdd.Enabled = false;
                        txtId.Text = _item.Text.Trim();
                        _EnableDisableControls(true);
                        txtId.Enabled = false;
                        txtName.Text = _item.SubItems[1].Text.Trim();
                        txtAddress.Text = _item.SubItems[4].Text.Trim().ToString();
                        txtState.Text = _item.SubItems[2].Text.Trim();
                        txtCity.Text = _item.SubItems[3].Text.Trim().ToString();
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

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
        }


        private void SiteMaster_Load(object sender, EventArgs e)
        {
            try
            {               
                setReload();
                _EnableDisableControls(false);
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }



        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            blCommon.OnlyNumeric(e);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text.Trim() == "")
                {
                    blCommon.ShowMessage("Please select the record from grid", 2);
                    return;
                }

                else
                {

                    SiteMasterModel plobj = new SiteMasterModel();
                    plobj.SiteCode = txtId.Text.Trim();
                    plobj.SiteName = txtName.Text.Trim();
                    DataTable dt = obj.DeleteSite(plobj);
                    if (dt.Rows.Count > 0)
                    {
                        string sResult = dt.Rows[0][0].ToString();
                        if (sResult.StartsWith("SUCCESS~"))
                        {
                            blCommon.ShowMessage("Data delete successfully.", 1);
                        }
                        else
                        {
                            blCommon.ShowMessage(sResult, 2);
                        }
                    }
                    _ClearControls();
                    _EnableDisableControls(false);
                    setReload();
                    _ClearControls();
                    setReload();
                    if (lvSite.Items.Count >= 1)
                    {
                        btnAdd.Enabled = false;
                    }
                    else
                    {
                        btnAdd.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }

        }

        private void lblStates_Click(object sender, EventArgs e)
        {

        }

        private void lblSiteName_Click(object sender, EventArgs e)
        {

        }

        private void lblDesc_Click(object sender, EventArgs e)
        {

        }

        private void lblSiteId_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtState_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblNoOfRecords_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
