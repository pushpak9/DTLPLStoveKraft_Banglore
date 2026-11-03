using System;
using MaterialSkin.Controls;
using System.Windows.Forms;
using System.Data;
using StockCraft.DataLayer;
using System.Reflection;
using StockCraft.BusinessLayer;
using StockCraft.PL;

namespace StockCraft
{
    public partial class UserRight : MaterialForm
    {
        DL_UserLogin obj = new DL_UserLogin();
        static DataTable dtFillModuleList = new DataTable();
        public UserRight()
        {
            InitializeComponent();
        }

        private void GroupRight_Load(object sender, EventArgs e)
        {
            try
            {
                BindModule();
                BindGroup();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
        public void BindGroup()
        {
            DataTable dt = obj.GetGroupForRights();
            if (dt.Rows.Count > 0)
            {
                blCommon.FillComboBox(cmbGroup, dt, true);

            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void BindModule()
        {
            try
            {
                DataTable dt = obj.GetAllModuleList();
                if (dt.Rows.Count > 0)
                {
                    PCommon.FillListView(dt, lvGroupRight);
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbGroup.Items.Count == 0)
                {
                    blCommon.ShowMessage("Please select Group", 2);
                    cmbGroup.Focus(); return;
                }
                if (cmbGroup.SelectedIndex == 0)
                {
                    blCommon.ShowMessage("Please select Group", 2);
                    cmbGroup.Focus(); return;
                }
                if (lvGroupRight.CheckedItems.Count == 0)
                {
                    blCommon.ShowMessage("Please select at least one module", 2);
                    return;
                }
                DataTable dtUploadModuleList = new DataTable();
                dtUploadModuleList.Columns.Add("ModuleName");
                dtUploadModuleList.Columns.Add("Rights");
                foreach (ListViewItem _item in lvGroupRight.Items)
                {
                    if (_item.Checked == true)
                    {
                        dtUploadModuleList.Rows.Add(_item.SubItems[1].Text.Trim(), true);
                    }
                }
                GroupRigthsModel plobj = new GroupRigthsModel();
                plobj.dtSaveRightsList = dtUploadModuleList;
                plobj.GroupID = cmbGroup.SelectedValue.ToString();
                DataTable dt = obj.SaveUserRights(plobj.GroupID, plobj.dtSaveRightsList);
                if (dt.Rows.Count > 0)
                {
                    string sResult = dt.Rows[0][0].ToString();
                    if (sResult.StartsWith("SUCCESS~"))
                    {
                        blCommon.ShowMessage("Rights assigned successfully.", 1);
                        cmbGroup.SelectedIndex = 0;
                        chkSelectAll.Checked = false;
                        chkSelectAll_CheckedChanged(null, null);
                    }
                    else
                    {
                        blCommon.ShowMessage(sResult, 2);
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }

        }
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSelectAll.CheckState == CheckState.Checked)
                {
                    foreach (ListViewItem listItem in lvGroupRight.Items)
                    {
                        listItem.Checked = true;
                    }
                }
                else
                {
                    foreach (ListViewItem listItem in lvGroupRight.Items)
                    {
                        listItem.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbGroup.SelectedIndex > 0)
                {
                    foreach (ListViewItem listItem in lvGroupRight.Items)
                    {
                        listItem.Checked = false;
                    }
                    DataTable dt = obj.GetUserRights(cmbGroup.SelectedValue.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            foreach (ListViewItem _item in lvGroupRight.Items)
                            {
                                if (_item.SubItems[1].Text == dt.Rows[i][0].ToString())
                                {
                                    _item.Checked = true;
                                }
                            }
                        }
                    }
                    lblGroupCode.Text = cmbGroup.SelectedValue.ToString();
                }
                else
                {
                    foreach (ListViewItem listItem in lvGroupRight.Items)
                    {
                        listItem.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
