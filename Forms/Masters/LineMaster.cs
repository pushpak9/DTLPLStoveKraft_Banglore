
using StockCraft.DataLayer;
using StockCraft.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockCraft.Forms.Masters
{
    public partial class LineMaster : Form
    {
        DL_LineMaster obj = new DL_LineMaster();
        int SelectedId = 0;
        public LineMaster()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "ADD")
                {
                    ClearData();
                    EnableControls(true);
                    txtLinemName.Focus();
                    btnAdd.Text = "SAVE";
                    btnEdit.Enabled = false;
                }
                else
                {
                    if (txtLinemName.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter Item Name");
                        return;
                    }

                    LineMasterModel m = new LineMasterModel();
                    m.LineName = txtLinemName.Text.Trim();
                    m.LineCode = txtLineCode.Text.Trim();

                    obj.SaveItem(m);

                    MessageBox.Show("Saved Successfully");

                    LoadData();
                    ClearData();
                    EnableControls(false);

                    btnAdd.Text = "ADD";
                    btnEdit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ItemMaster_Load(object sender, EventArgs e)
        {
            txtLinemName.MaxLength = 500;
            LoadData();
            EnableControls(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEdit.Text == "EDIT")
                {
                    if (SelectedId == 0)
                    {
                        MessageBox.Show("Select record first");
                        return;
                    }

                    EnableControls(true);
                    btnEdit.Text = "UPDATE";
                    btnAdd.Enabled = false;
                }
                else
                {
                   LineMasterModel m = new LineMasterModel();
                    m.ItemId = SelectedId;
                    m.LineName = txtLinemName.Text.Trim();
                    m.LineCode = txtLineCode.Text.Trim();

                    obj.UpdateItem(m);

                    MessageBox.Show("Updated Successfully");

                    LoadData();
                    ClearData();
                    EnableControls(false);

                    btnEdit.Text = "EDIT";
                    btnAdd.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPrinter.SelectedItems.Count > 0)
            {
                SelectedId = Convert.ToInt32(lvPrinter.SelectedItems[0].SubItems[0].Text);
                txtLinemName.Text = lvPrinter.SelectedItems[0].SubItems[1].Text;
                txtLineCode.Text = lvPrinter.SelectedItems[0].SubItems[2].Text;
            }
        }

        void LoadData()
        {
            DataTable dt = obj.GetItem();
            if (dt.Rows.Count > 0)
            {
                PCommon.FillListView(dt, lvPrinter);
            }
        }

        // 🔹 COMMON
        void ClearData()
        {
            txtLinemName.Text = "";
            txtLineCode.Text = "";
            SelectedId = 0;
        }

        void EnableControls(bool flag)
        {
            txtLinemName.Enabled = flag;
            txtLineCode.Enabled = flag;
        }

        private void lblSiteName_Click(object sender, EventArgs e)
        {

        }
    }
}
