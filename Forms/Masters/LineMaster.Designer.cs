namespace StockCraft.Forms.Masters
{
    partial class LineMaster
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
            this.lvPrinter = new System.Windows.Forms.ListView();
            this.SiteCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SiteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.STATE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSiteName = new System.Windows.Forms.Label();
            this.lblSiteId = new System.Windows.Forms.Label();
            this.txtLinemName = new System.Windows.Forms.TextBox();
            this.txtLineCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblNoOfRecords = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.STATE});
            this.lvPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lvPrinter.FullRowSelect = true;
            this.lvPrinter.GridLines = true;
            this.lvPrinter.HideSelection = false;
            this.lvPrinter.Location = new System.Drawing.Point(11, 524);
            this.lvPrinter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvPrinter.Name = "lvPrinter";
            this.lvPrinter.Size = new System.Drawing.Size(1123, 252);
            this.lvPrinter.TabIndex = 49;
            this.lvPrinter.UseCompatibleStateImageBehavior = false;
            this.lvPrinter.View = System.Windows.Forms.View.Details;
            this.lvPrinter.SelectedIndexChanged += new System.EventHandler(this.lvItem_SelectedIndexChanged);
            // 
            // SiteCode
            // 
            this.SiteCode.Text = "ID";
            this.SiteCode.Width = 146;
            // 
            // SiteName
            // 
            this.SiteName.Text = "Line  Name";
            this.SiteName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SiteName.Width = 150;
            // 
            // STATE
            // 
            this.STATE.Text = "Line Code";
            this.STATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.STATE.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblSiteName);
            this.groupBox1.Controls.Add(this.lblSiteId);
            this.groupBox1.Controls.Add(this.txtLinemName);
            this.groupBox1.Controls.Add(this.txtLineCode);
            this.groupBox1.Location = new System.Drawing.Point(11, 169);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(1124, 255);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            // 
            // lblSiteName
            // 
            this.lblSiteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSiteName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblSiteName.Location = new System.Drawing.Point(395, 18);
            this.lblSiteName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSiteName.Name = "lblSiteName";
            this.lblSiteName.Size = new System.Drawing.Size(145, 22);
            this.lblSiteName.TabIndex = 2;
            this.lblSiteName.Text = "Line Code";
            this.lblSiteName.Click += new System.EventHandler(this.lblSiteName_Click);
            // 
            // lblSiteId
            // 
            this.lblSiteId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSiteId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblSiteId.Location = new System.Drawing.Point(35, 18);
            this.lblSiteId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSiteId.Name = "lblSiteId";
            this.lblSiteId.Size = new System.Drawing.Size(253, 22);
            this.lblSiteId.TabIndex = 0;
            this.lblSiteId.Text = "Line  Name";
            // 
            // txtLinemName
            // 
            this.txtLinemName.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtLinemName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtLinemName.Location = new System.Drawing.Point(12, 60);
            this.txtLinemName.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtLinemName.MaxLength = 10;
            this.txtLinemName.Name = "txtLinemName";
            this.txtLinemName.Size = new System.Drawing.Size(256, 35);
            this.txtLinemName.TabIndex = 1;
            // 
            // txtLineCode
            // 
            this.txtLineCode.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtLineCode.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtLineCode.Location = new System.Drawing.Point(358, 60);
            this.txtLineCode.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtLineCode.MaxLength = 50;
            this.txtLineCode.Name = "txtLineCode";
            this.txtLineCode.Size = new System.Drawing.Size(256, 35);
            this.txtLineCode.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Location = new System.Drawing.Point(11, 428);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1124, 62);
            this.panel2.TabIndex = 52;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(141)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 64);
            this.panel1.TabIndex = 51;
            // 
            // btnMinimize
            // 
            this.btnMinimize.AutoSize = true;
            this.btnMinimize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMinimize.Depth = 0;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.Location = new System.Drawing.Point(1292, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMinimize.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Primary = false;
            this.btnMinimize.Size = new System.Drawing.Size(8, 64);
            this.btnMinimize.TabIndex = 10;
            this.btnMinimize.UseVisualStyleBackColor = true;
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
            this.lblHeader.Size = new System.Drawing.Size(763, 34);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Line Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoOfRecords
            // 
            this.lblNoOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNoOfRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblNoOfRecords.Location = new System.Drawing.Point(12, 495);
            this.lblNoOfRecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoOfRecords.Name = "lblNoOfRecords";
            this.lblNoOfRecords.Size = new System.Drawing.Size(252, 22);
            this.lblNoOfRecords.TabIndex = 53;
            this.lblNoOfRecords.Text = "LINE CODE";
            // 
            // LineMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 803);
            this.Controls.Add(this.lvPrinter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNoOfRecords);
            this.Name = "LineMaster";
            this.Text = "LineMaster";
            this.Load += new System.EventHandler(this.ItemMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvPrinter;
        private System.Windows.Forms.ColumnHeader SiteCode;
        private System.Windows.Forms.ColumnHeader SiteName;
        private System.Windows.Forms.ColumnHeader STATE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSiteName;
        private System.Windows.Forms.Label lblSiteId;
        private System.Windows.Forms.TextBox txtLinemName;
        private System.Windows.Forms.TextBox txtLineCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialFlatButton btnMinimize;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblNoOfRecords;
    }
}