namespace StockCraft.Forms.Transaction
{
    partial class ReprintMC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtMCSerial = new System.Windows.Forms.TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.REPRINT = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvMasterReprintData = new System.Windows.Forms.DataGridView();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.Get = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrinterIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLineCode = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterReprintData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMCSerial
            // 
            this.txtMCSerial.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtMCSerial.Location = new System.Drawing.Point(814, 88);
            this.txtMCSerial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMCSerial.MaxLength = 200;
            this.txtMCSerial.Name = "txtMCSerial";
            this.txtMCSerial.Size = new System.Drawing.Size(499, 35);
            this.txtMCSerial.TabIndex = 61;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(274, 16);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1063, 34);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "REPRINTING MC";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(141)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1600, 50);
            this.panel1.TabIndex = 52;
            // 
            // REPRINT
            // 
            this.REPRINT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.REPRINT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.REPRINT.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.REPRINT.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.REPRINT.Location = new System.Drawing.Point(901, 139);
            this.REPRINT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.REPRINT.Name = "REPRINT";
            this.REPRINT.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.REPRINT.Size = new System.Drawing.Size(145, 42);
            this.REPRINT.TabIndex = 73;
            this.REPRINT.Text = "REPRINT";
            this.REPRINT.UseVisualStyleBackColor = false;
            this.REPRINT.Click += new System.EventHandler(this.REPRINT_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvMasterReprintData);
            this.panel2.Location = new System.Drawing.Point(16, 186);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1428, 544);
            this.panel2.TabIndex = 70;
            // 
            // dgvMasterReprintData
            // 
            this.dgvMasterReprintData.AllowUserToAddRows = false;
            this.dgvMasterReprintData.AllowUserToDeleteRows = false;
            this.dgvMasterReprintData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMasterReprintData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMasterReprintData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvMasterReprintData.ColumnHeadersHeight = 40;
            this.dgvMasterReprintData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMasterReprintData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Barcode});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMasterReprintData.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgvMasterReprintData.Location = new System.Drawing.Point(2, 44);
            this.dgvMasterReprintData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMasterReprintData.Name = "dgvMasterReprintData";
            this.dgvMasterReprintData.RowHeadersWidth = 62;
            this.dgvMasterReprintData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMasterReprintData.RowTemplate.Height = 28;
            this.dgvMasterReprintData.Size = new System.Drawing.Size(1425, 457);
            this.dgvMasterReprintData.TabIndex = 1;
            // 
            // Barcode
            // 
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.MinimumWidth = 8;
            this.Barcode.Name = "Barcode";
            this.Barcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Barcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1084, 139);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.button2.Size = new System.Drawing.Size(123, 42);
            this.button2.TabIndex = 69;
            this.button2.Text = "EXIT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Get
            // 
            this.Get.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.Get.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Get.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.Get.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Get.Location = new System.Drawing.Point(696, 145);
            this.Get.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Get.Name = "Get";
            this.Get.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.Get.Size = new System.Drawing.Size(145, 42);
            this.Get.TabIndex = 68;
            this.Get.Text = "GET";
            this.Get.UseVisualStyleBackColor = false;
            this.Get.Click += new System.EventHandler(this.Get_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(1036, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 22);
            this.label1.TabIndex = 78;
            this.label1.Text = "MC Barcode";
            // 
            // txtPrinterIP
            // 
            this.txtPrinterIP.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtPrinterIP.Location = new System.Drawing.Point(417, 86);
            this.txtPrinterIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrinterIP.MaxLength = 200;
            this.txtPrinterIP.Name = "txtPrinterIP";
            this.txtPrinterIP.Size = new System.Drawing.Size(273, 35);
            this.txtPrinterIP.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(506, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 22);
            this.label3.TabIndex = 81;
            this.label3.Text = "IP";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(161, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 22);
            this.label2.TabIndex = 80;
            this.label2.Text = "LineCode";
            // 
            // cmbLineCode
            // 
            this.cmbLineCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLineCode.FormattingEnabled = true;
            this.cmbLineCode.Location = new System.Drawing.Point(67, 86);
            this.cmbLineCode.Name = "cmbLineCode";
            this.cmbLineCode.Size = new System.Drawing.Size(275, 37);
            this.cmbLineCode.TabIndex = 79;
            this.cmbLineCode.SelectedIndexChanged += new System.EventHandler(this.cmbLineCode_SelectedIndexChanged);
            // 
            // ReprintMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 672);
            this.Controls.Add(this.txtPrinterIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLineCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.REPRINT);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Get);
            this.Controls.Add(this.txtMCSerial);
            this.Controls.Add(this.panel1);
            this.Name = "ReprintMC";
            this.Text = "ReprintMC";
            this.Load += new System.EventHandler(this.ReprintMC_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterReprintData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMCSerial;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button REPRINT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Get;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMasterReprintData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.TextBox txtPrinterIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLineCode;
    }
}