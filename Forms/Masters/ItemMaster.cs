using StockCraft.DataLayer;
using StockCraft.PL;
using System;
using System.Data;
using System.Windows.Forms;

namespace StockCraft.Forms.Masters
{
    public partial class ItemMaster : Form
    {
        DL_ItemMaster obj = new DL_ItemMaster();

        int SelectedId = 0;

        public ItemMaster()
        {
            InitializeComponent();
        }

        private void ItemMaster_Load(object sender, EventArgs e)
        {
            try
            {
                txtModel.MaxLength = 500;

                // Initially controls disabled
                EnableControls(false);

                // Load ListView
                LoadData();

                // Default button state
                btnAdd.Text = "ADD";
                btnAdd.Enabled = true;

                btnEdit.Text = "EDIT";
                btnEdit.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =========================================================
        // ADD / SAVE
        // =========================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // ADD mode
                if (btnAdd.Text == "ADD")
                {
                    ClearData();

                    EnableControls(true);

                    txtModel.Focus();

                    btnAdd.Text = "SAVE";
                    btnEdit.Enabled = false;

                    return;
                }

                // SAVE mode
                if (string.IsNullOrWhiteSpace(txtModel.Text))
                {
                    MessageBox.Show("Enter Item Name");
                    txtModel.Focus();
                    return;
                }

                ItemMasterModel m = new ItemMasterModel();

                m.Model = txtModel.Text.Trim();
                m.Wattage = txtWattage.Text.Trim();
                m.ProductID = txtProducID.Text.Trim();
                m.Voltage = TxtVolTage.Text.Trim();
                m.Degree = Degree2.Text.Trim();

                obj.SaveItem(m);

                MessageBox.Show("Saved Successfully");

                // Reload list
                LoadData();

                // Clear controls
                ClearData();

                // Disable controls
                EnableControls(false);

                // Reset buttons
                btnAdd.Text = "ADD";
                btnEdit.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =========================================================
        // EDIT / UPDATE
        // =========================================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // EDIT MODE
                if (btnEdit.Text == "EDIT")
                {
                    if (SelectedId == 0)
                    {
                        MessageBox.Show("Select record first");
                        return;
                    }

                    // Enable fields for editing
                    EnableControls(true);

                    txtModel.Focus();

                    btnEdit.Text = "UPDATE";
                    btnAdd.Enabled = false;

                    return;
                }

                // UPDATE MODE
                if (SelectedId == 0)
                {
                    MessageBox.Show("Select record first");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtModel.Text))
                {
                    MessageBox.Show("Enter Item Name");
                    txtModel.Focus();
                    return;
                }

                ItemMasterModel m = new ItemMasterModel();

                // IMPORTANT: ID must be passed
                m.ItemId = SelectedId;

                m.Model = txtModel.Text.Trim();
                m.Wattage = txtWattage.Text.Trim();
                m.ProductID = txtProducID.Text.Trim();
                m.Voltage = TxtVolTage.Text.Trim();
                m.Degree = Degree2.Text.Trim();

                obj.UpdateItem(m);

                MessageBox.Show("Updated Successfully");

                // Reload list
                LoadData();

                // Clear fields
                ClearData();

                // Disable fields
                EnableControls(false);

                // Reset buttons
                btnEdit.Text = "EDIT";
                btnAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =========================================================
        // LISTVIEW SELECT
        // =========================================================
        private void lvItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvItem.SelectedItems.Count == 0)
                    return;

                ListViewItem item = lvItem.SelectedItems[0];

                

                // 0 = ID
                SelectedId = Convert.ToInt32(item.SubItems[0].Text);

                // 1 = Product / ProductID
                txtProducID.Text = item.SubItems[1].Text;

                // 2 = Model
                txtModel.Text = item.SubItems[2].Text;

                // 3 = Wattage
                txtWattage.Text = item.SubItems[3].Text;

                // 4 = Voltage
                TxtVolTage.Text = item.SubItems[4].Text;

                // 5 = Degree
                Degree2.Text = item.SubItems[5].Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =========================================================
        // LOAD DATA
        // =========================================================
        private void LoadData()
        {
            try
            {
                DataTable dt = obj.GetItem();

                lvItem.BeginUpdate();

                // Clear old records
                lvItem.Items.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    PCommon.FillListView(dt, lvItem);
                }

                lvItem.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =========================================================
        // CLEAR DATA
        // =========================================================
        private void ClearData()
        {
            txtModel.Clear();
            txtWattage.Clear();
            txtProducID.Clear();
            TxtVolTage.Clear();
            Degree2.Clear();

            SelectedId = 0;

            // Remove ListView selection
            lvItem.SelectedItems.Clear();
        }

        // =========================================================
        // ENABLE / DISABLE CONTROLS
        // =========================================================
        private void EnableControls(bool flag)
        {
            txtModel.Enabled = flag;
            txtWattage.Enabled = flag;
            txtProducID.Enabled = flag;
            TxtVolTage.Enabled = flag;
            Degree2.Enabled = flag;
        }

        // =========================================================
        // EXIT
        // =========================================================
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblSiteName_Click(object sender, EventArgs e)
        {
        }

     
    }
}