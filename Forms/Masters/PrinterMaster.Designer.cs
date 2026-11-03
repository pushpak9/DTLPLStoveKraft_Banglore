namespace StockCraft.Forms.Masters
{
    partial class PrinterMaster
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
            this.btnMinimize = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProductID = new System.Windows.Forms.Label();
            this.txtScannerIP = new System.Windows.Forms.TextBox();
            this.Degree = new System.Windows.Forms.Label();
            this.Voltage = new System.Windows.Forms.Label();
            this.txtPLCIP = new System.Windows.Forms.TextBox();
            this.txtPLCPort = new System.Windows.Forms.TextBox();
            this.Wattage = new System.Windows.Forms.Label();
            this.Model = new System.Windows.Forms.Label();
            this.txtPrinterIP = new System.Windows.Forms.TextBox();
            this.txtPrinterPort = new System.Windows.Forms.TextBox();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.STATE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SiteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SiteCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPrinter = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LineCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtLine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txtmcprint = new System.Windows.Forms.TextBox();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMinimize
            // 
            this.btnMinimize.AutoSize = true;
            this.btnMinimize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMinimize.Depth = 0;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.Location = new System.Drawing.Point(1427, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMinimize.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Primary = false;
            this.btnMinimize.Size = new System.Drawing.Size(8, 64);
            this.btnMinimize.TabIndex = 10;
            this.btnMinimize.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(141)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1435, 64);
            this.panel1.TabIndex = 56;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(275, 10);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(898, 34);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Printer  Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(326, 9);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnExit.Size = new System.Drawing.Size(115, 42);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.Location = new System.Drawing.Point(11, 9);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnAdd.Size = new System.Drawing.Size(115, 42);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(147, 7);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnEdit.Size = new System.Drawing.Size(115, 42);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Location = new System.Drawing.Point(19, 357);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1124, 62);
            this.panel2.TabIndex = 57;
            // 
            // ProductID
            // 
            this.ProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ProductID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ProductID.Location = new System.Drawing.Point(774, 18);
            this.ProductID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProductID.Name = "ProductID";
            this.ProductID.Size = new System.Drawing.Size(253, 22);
            this.ProductID.TabIndex = 7;
            this.ProductID.Text = "ScannerIP";
            // 
            // txtScannerIP
            // 
            this.txtScannerIP.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtScannerIP.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtScannerIP.Location = new System.Drawing.Point(711, 51);
            this.txtScannerIP.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtScannerIP.MaxLength = 10;
            this.txtScannerIP.Name = "txtScannerIP";
            this.txtScannerIP.Size = new System.Drawing.Size(256, 35);
            this.txtScannerIP.TabIndex = 8;
            // 
            // Degree
            // 
            this.Degree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Degree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Degree.Location = new System.Drawing.Point(374, 121);
            this.Degree.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Degree.Name = "Degree";
            this.Degree.Size = new System.Drawing.Size(226, 22);
            this.Degree.TabIndex = 5;
            this.Degree.Text = "PLCPort";
            // 
            // Voltage
            // 
            this.Voltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Voltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Voltage.Location = new System.Drawing.Point(12, 121);
            this.Voltage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Voltage.Name = "Voltage";
            this.Voltage.Size = new System.Drawing.Size(253, 22);
            this.Voltage.TabIndex = 3;
            this.Voltage.Text = "PLCIP";
            // 
            // txtPLCIP
            // 
            this.txtPLCIP.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtPLCIP.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtPLCIP.Location = new System.Drawing.Point(9, 163);
            this.txtPLCIP.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtPLCIP.MaxLength = 10;
            this.txtPLCIP.Name = "txtPLCIP";
            this.txtPLCIP.Size = new System.Drawing.Size(256, 35);
            this.txtPLCIP.TabIndex = 4;
            // 
            // txtPLCPort
            // 
            this.txtPLCPort.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtPLCPort.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtPLCPort.Location = new System.Drawing.Point(361, 163);
            this.txtPLCPort.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtPLCPort.MaxLength = 50;
            this.txtPLCPort.Name = "txtPLCPort";
            this.txtPLCPort.Size = new System.Drawing.Size(256, 35);
            this.txtPLCPort.TabIndex = 6;
            // 
            // Wattage
            // 
            this.Wattage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Wattage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Wattage.Location = new System.Drawing.Point(398, 9);
            this.Wattage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Wattage.Name = "Wattage";
            this.Wattage.Size = new System.Drawing.Size(145, 22);
            this.Wattage.TabIndex = 2;
            this.Wattage.Text = "PrinterPort";
            // 
            // Model
            // 
            this.Model.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Model.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Model.Location = new System.Drawing.Point(8, 9);
            this.Model.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(253, 22);
            this.Model.TabIndex = 0;
            this.Model.Text = "PrinterIP ";
            // 
            // txtPrinterIP
            // 
            this.txtPrinterIP.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtPrinterIP.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtPrinterIP.Location = new System.Drawing.Point(5, 51);
            this.txtPrinterIP.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtPrinterIP.MaxLength = 10;
            this.txtPrinterIP.Name = "txtPrinterIP";
            this.txtPrinterIP.Size = new System.Drawing.Size(256, 35);
            this.txtPrinterIP.TabIndex = 1;
            // 
            // txtPrinterPort
            // 
            this.txtPrinterPort.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtPrinterPort.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtPrinterPort.Location = new System.Drawing.Point(361, 51);
            this.txtPrinterPort.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtPrinterPort.MaxLength = 50;
            this.txtPrinterPort.Name = "txtPrinterPort";
            this.txtPrinterPort.Size = new System.Drawing.Size(256, 35);
            this.txtPrinterPort.TabIndex = 2;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "PLCIP";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Scannerport";
            this.columnHeader2.Width = 224;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ScannerIP";
            this.columnHeader1.Width = 193;
            // 
            // STATE
            // 
            this.STATE.Text = "PrinterPort";
            this.STATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.STATE.Width = 150;
            // 
            // SiteName
            // 
            this.SiteName.Text = "PrinterIP";
            this.SiteName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SiteName.Width = 150;
            // 
            // SiteCode
            // 
            this.SiteCode.Text = "ID";
            this.SiteCode.Width = 146;
            // 
            // lvPrinter
            // 
            this.lvPrinter.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPrinter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SiteCode,
            this.SiteName,
            this.STATE,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.LineCode,
            this.columnHeader5});
            this.lvPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lvPrinter.FullRowSelect = true;
            this.lvPrinter.GridLines = true;
            this.lvPrinter.HideSelection = false;
            this.lvPrinter.Location = new System.Drawing.Point(0, 441);
            this.lvPrinter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvPrinter.Name = "lvPrinter";
            this.lvPrinter.Size = new System.Drawing.Size(1425, 372);
            this.lvPrinter.TabIndex = 54;
            this.lvPrinter.UseCompatibleStateImageBehavior = false;
            this.lvPrinter.View = System.Windows.Forms.View.Details;
            this.lvPrinter.SelectedIndexChanged += new System.EventHandler(this.lvPrinter_SelectedIndexChanged_1);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "PLCPPORT";
            this.columnHeader4.Width = 162;
            // 
            // LineCode
            // 
            this.LineCode.Text = "LineCode";
            this.LineCode.Width = 166;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Txtmcprint);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtLine);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.ProductID);
            this.groupBox1.Controls.Add(this.txtScannerIP);
            this.groupBox1.Controls.Add(this.Degree);
            this.groupBox1.Controls.Add(this.Voltage);
            this.groupBox1.Controls.Add(this.txtPLCIP);
            this.groupBox1.Controls.Add(this.txtPLCPort);
            this.groupBox1.Controls.Add(this.Wattage);
            this.groupBox1.Controls.Add(this.Model);
            this.groupBox1.Controls.Add(this.txtPrinterIP);
            this.groupBox1.Controls.Add(this.txtPrinterPort);
            this.groupBox1.Location = new System.Drawing.Point(10, 82);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(1412, 269);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(1086, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "LineCode";
            // 
            // TxtLine
            // 
            this.TxtLine.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.TxtLine.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TxtLine.Location = new System.Drawing.Point(1037, 51);
            this.TxtLine.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.TxtLine.MaxLength = 10;
            this.TxtLine.Name = "TxtLine";
            this.TxtLine.Size = new System.Drawing.Size(256, 35);
            this.TxtLine.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(760, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "ScannerPort";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.textBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox1.Location = new System.Drawing.Point(711, 163);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 35);
            this.textBox1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(1073, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "PrinterIP MC";
            // 
            // Txtmcprint
            // 
            this.Txtmcprint.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.Txtmcprint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Txtmcprint.Location = new System.Drawing.Point(1037, 163);
            this.Txtmcprint.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Txtmcprint.MaxLength = 10;
            this.Txtmcprint.Name = "Txtmcprint";
            this.Txtmcprint.Size = new System.Drawing.Size(256, 35);
            this.Txtmcprint.TabIndex = 14;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "PrinterIpMC";
            // 
            // PrinterMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 811);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lvPrinter);
            this.Controls.Add(this.groupBox1);
            this.Name = "PrinterMaster";
            this.Text = "PrinterMaster";
            this.Load += new System.EventHandler(this.PrinterMaster_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton btnMinimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ProductID;
        private System.Windows.Forms.TextBox txtScannerIP;
        private System.Windows.Forms.Label Degree;
        private System.Windows.Forms.Label Voltage;
        private System.Windows.Forms.TextBox txtPLCIP;
        private System.Windows.Forms.TextBox txtPLCPort;
        private System.Windows.Forms.Label Wattage;
        private System.Windows.Forms.Label Model;
        private System.Windows.Forms.TextBox txtPrinterIP;
        private System.Windows.Forms.TextBox txtPrinterPort;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader STATE;
        private System.Windows.Forms.ColumnHeader SiteName;
        private System.Windows.Forms.ColumnHeader SiteCode;
        private System.Windows.Forms.ListView lvPrinter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtLine;
        private System.Windows.Forms.ColumnHeader LineCode;
        private System.Windows.Forms.TextBox Txtmcprint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}