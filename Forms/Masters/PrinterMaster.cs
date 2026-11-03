using StockCraft.DataLayer;
using StockCraft.PL;
using System;
using System.Data;
using System.Windows.Forms;

namespace StockCraft.Forms.Masters
{
    public partial class PrinterMaster : Form
    {
        DL_PrinterMaster obj = new DL_PrinterMaster();

        private int SelectedId = 0;

        public PrinterMaster()
        {
            InitializeComponent();
        }

        // =========================================================
        // ADD / SAVE
        // =========================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // ADD MODE
                if (btnAdd.Text == "ADD")
                {
                    ClearData();

                    EnableControls(true);

                    txtPrinterIP.Focus();

                    btnAdd.Text = "SAVE";
                    btnEdit.Enabled = false;

                    return;
                }

                // SAVE MODE
                if (!ValidateData())
                    return;

                PrinterMasterModel m = new PrinterMasterModel();

                m.PrinterIP = txtPrinterIP.Text.Trim();
                m.PrinterPort = Convert.ToInt32(txtPrinterPort.Text.Trim());

                m.ScannerIP = txtScannerIP.Text.Trim();
                m.ScannerPort = Convert.ToInt32(textBox1.Text.Trim());
                m.LineCode = TxtLine.Text.Trim();

                m.PLCIP = txtPLCIP.Text.Trim();
                m.PLCPort = Convert.ToInt32(txtPLCPort.Text.Trim());
                m.PrinterIPMC = Txtmcprint.Text.Trim();
  

                // Agar login user id available hai to yahan set karo
                // m.CreatedBy = UserId;

                obj.SavePrinter(m);

                MessageBox.Show("Saved Successfully");

                // Reload List
                LoadData();

                // Clear Controls
                ClearData();

                // Disable Controls
                EnableControls(false);

                // Reset Buttons
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

                    EnableControls(true);
                    txtPrinterIP.Focus();
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

                if (!ValidateData())
                    return;

                PrinterMasterModel m = new PrinterMasterModel();

                // IMPORTANT: ID must be passed
                m.PrinterId = SelectedId;

                m.PrinterIP = txtPrinterIP.Text.Trim();
                m.PrinterPort = Convert.ToInt32(txtPrinterPort.Text.Trim());

                m.PrinterIPMC = Txtmcprint.Text.Trim();


                m.ScannerIP = txtScannerIP.Text.Trim();
                m.ScannerPort = Convert.ToInt32(textBox1.Text.Trim());

                m.PLCIP = txtPLCIP.Text.Trim();
                m.PLCPort = Convert.ToInt32(txtPLCPort.Text.Trim());
                m.LineCode = TxtLine.Text.Trim();

                obj.UpdatePrinter(m);

                MessageBox.Show("Updated Successfully");

                // Reload List
                LoadData();

                // Clear Fields
                ClearData();

                // Disable Fields
                EnableControls(false);

                // Reset Buttons
                btnEdit.Text = "EDIT";
                btnAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // =========================================================
        // EXIT
        // =========================================================
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // =========================================================
        // ENABLE / DISABLE CONTROLS
        // =========================================================
        private void EnableControls(bool flag)
        {
            txtPrinterIP.Enabled = flag;
            txtPrinterPort.Enabled = flag;


            txtScannerIP.Enabled = flag;
            textBox1.Enabled = flag;

            txtPLCIP.Enabled = flag;
            txtPLCPort.Enabled = flag;
            Txtmcprint.Enabled = flag;
        }


        // =========================================================
        // VALIDATION
        // =========================================================
        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtPrinterIP.Text))
            {
                MessageBox.Show("Enter Printer IP");
                txtPrinterIP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrinterPort.Text))
            {
                MessageBox.Show("Enter Printer Port");
                txtPrinterPort.Focus();
                return false;
            }

            if (!int.TryParse(txtPrinterPort.Text.Trim(), out _))
            {
                MessageBox.Show("Enter valid Printer Port");
                txtPrinterPort.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtScannerIP.Text))
            {
                MessageBox.Show("Enter Scanner IP");
                txtScannerIP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Enter Scanner Port");
                textBox1.Focus();
                return false;
            }

            if (!int.TryParse(textBox1.Text.Trim(), out _))
            {
                MessageBox.Show("Enter valid Scanner Port");
                textBox1.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtPLCIP.Text))
            {
                MessageBox.Show("Enter PLC IP");
                txtPLCIP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPLCPort.Text))
            {
                MessageBox.Show("Enter PLC Port");
                txtPLCPort.Focus();
                return false;
            }

            if (!int.TryParse(txtPLCPort.Text.Trim(), out _))
            {
                MessageBox.Show("Enter valid PLC Port");
                txtPLCPort.Focus();
                return false;
            }

            return true;
        }


        // =========================================================
        // CLEAR DATA
        // =========================================================
        private void ClearData()
        {
            txtPrinterIP.Clear();
            txtPrinterPort.Clear();

            txtScannerIP.Clear();
            textBox1.Clear();
            Txtmcprint.Clear();
            txtPLCIP.Clear();
            txtPLCPort.Clear();


            SelectedId = 0;
        }


        // =========================================================
        // LOAD DATA
        // =========================================================
        private void LoadData()
        {
            try
            {
                DataTable dt = obj.GetPrinter();

                lvPrinter.BeginUpdate();

                // Clear old records
                lvPrinter.Items.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    PCommon.FillListView(dt, lvPrinter);
                }

                lvPrinter.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // =========================================================
        // LIST VIEW CLICK
        // =========================================================
        private void lvPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }


        // =========================================================
        // FORM LOAD
        // =========================================================
        private void PrinterMaster_Load(object sender, EventArgs e)
        {
            try
            {
                // Max Length
                txtPrinterIP.MaxLength = 50;
                txtPrinterPort.MaxLength = 10;

                txtScannerIP.MaxLength = 50;
                textBox1.MaxLength = 10;

                txtPLCIP.MaxLength = 50;
                txtPLCPort.MaxLength = 10;

                Txtmcprint.MaxLength = 50;

                // Initially controls disabled
                EnableControls(false);

                // Load ListView
                LoadData();

                // Default Button State
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

        private void lvPrinter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (lvPrinter.SelectedItems.Count == 0)
                    return;

                ListViewItem item = lvPrinter.SelectedItems[0];

                // First column = PrinterId
                SelectedId = Convert.ToInt32(item.SubItems[0].Text);

                txtPrinterIP.Text = item.SubItems[1].Text;
                txtPrinterPort.Text = item.SubItems[2].Text;

                txtScannerIP.Text = item.SubItems[3].Text;
                textBox1.Text = item.SubItems[4].Text;

                txtPLCIP.Text = item.SubItems[5].Text;
                txtPLCPort.Text = item.SubItems[6].Text;
                TxtLine.Text = item.SubItems[7].Text;
                Txtmcprint.Text = item.SubItems[8].Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}