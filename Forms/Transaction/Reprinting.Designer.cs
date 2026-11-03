namespace StockCraft.Forms.Transaction
{
    partial class Reprinting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReprint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvReprintData = new System.Windows.Forms.DataGridView();
            this.txtScannedBarcode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnGetReport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbLineCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrinterIP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReprintData)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReprint
            // 
            this.btnReprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnReprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReprint.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnReprint.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReprint.Location = new System.Drawing.Point(204, 185);
            this.btnReprint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnReprint.Size = new System.Drawing.Size(145, 42);
            this.btnReprint.TabIndex = 51;
            this.btnReprint.Text = "REPRINT";
            this.btnReprint.UseVisualStyleBackColor = false;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(862, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 22);
            this.label2.TabIndex = 49;
            this.label2.Text = "Barcode";
            // 
            // dgvReprintData
            // 
            this.dgvReprintData.AllowUserToAddRows = false;
            this.dgvReprintData.AllowUserToDeleteRows = false;
            this.dgvReprintData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReprintData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReprintData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReprintData.ColumnHeadersHeight = 40;
            this.dgvReprintData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReprintData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReprintData.Location = new System.Drawing.Point(0, 0);
            this.dgvReprintData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvReprintData.Name = "dgvReprintData";
            this.dgvReprintData.RowHeadersWidth = 62;
            this.dgvReprintData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvReprintData.RowTemplate.Height = 28;
            this.dgvReprintData.Size = new System.Drawing.Size(1425, 457);
            this.dgvReprintData.TabIndex = 0;
            // 
            // txtScannedBarcode
            // 
            this.txtScannedBarcode.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtScannedBarcode.Location = new System.Drawing.Point(727, 113);
            this.txtScannedBarcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtScannedBarcode.MaxLength = 200;
            this.txtScannedBarcode.Name = "txtScannedBarcode";
            this.txtScannedBarcode.Size = new System.Drawing.Size(475, 35);
            this.txtScannedBarcode.TabIndex = 50;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgvReprintData);
            this.panel2.Location = new System.Drawing.Point(16, 244);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1428, 544);
            this.panel2.TabIndex = 48;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(405, 185);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnExit.Size = new System.Drawing.Size(141, 42);
            this.btnExit.TabIndex = 47;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.lblHeader.Size = new System.Drawing.Size(907, 34);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "REPRINTING IC";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGetReport
            // 
            this.btnGetReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnGetReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetReport.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnGetReport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGetReport.Location = new System.Drawing.Point(16, 185);
            this.btnGetReport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnGetReport.Size = new System.Drawing.Size(145, 42);
            this.btnGetReport.TabIndex = 46;
            this.btnGetReport.Text = "GET";
            this.btnGetReport.UseVisualStyleBackColor = false;
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(141)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1444, 64);
            this.panel1.TabIndex = 41;
            // 
            // cmbLineCode
            // 
            this.cmbLineCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLineCode.FormattingEnabled = true;
            this.cmbLineCode.Location = new System.Drawing.Point(40, 111);
            this.cmbLineCode.Name = "cmbLineCode";
            this.cmbLineCode.Size = new System.Drawing.Size(275, 37);
            this.cmbLineCode.TabIndex = 52;
            this.cmbLineCode.SelectedIndexChanged += new System.EventHandler(this.cmbLineCode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(134, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 22);
            this.label1.TabIndex = 53;
            this.label1.Text = "LineCode";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(479, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 22);
            this.label3.TabIndex = 55;
            this.label3.Text = "ICIP";
            // 
            // txtPrinterIP
            // 
            this.txtPrinterIP.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtPrinterIP.Location = new System.Drawing.Point(390, 111);
            this.txtPrinterIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrinterIP.MaxLength = 200;
            this.txtPrinterIP.Name = "txtPrinterIP";
            this.txtPrinterIP.Size = new System.Drawing.Size(273, 35);
            this.txtPrinterIP.TabIndex = 56;
            this.txtPrinterIP.TextChanged += new System.EventHandler(this.txtPrinterIP_TextChanged);
            // 
            // Reprinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 731);
            this.Controls.Add(this.txtPrinterIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLineCode);
            this.Controls.Add(this.btnReprint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtScannedBarcode);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGetReport);
            this.Controls.Add(this.panel1);
            this.Name = "Reprinting";
            this.Text = "Reprinting";
            this.Load += new System.EventHandler(this.Reprinting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReprintData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvReprintData;
        private System.Windows.Forms.TextBox txtScannedBarcode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnGetReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbLineCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrinterIP;
    }
}