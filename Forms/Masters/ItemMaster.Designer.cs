namespace StockCraft.Forms.Masters
{
    partial class ItemMaster
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
            this.lvItem = new System.Windows.Forms.ListView();
            this.SiteCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SiteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.STATE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProductID = new System.Windows.Forms.Label();
            this.txtProducID = new System.Windows.Forms.TextBox();
            this.Degree = new System.Windows.Forms.Label();
            this.Voltage = new System.Windows.Forms.Label();
            this.TxtVolTage = new System.Windows.Forms.TextBox();
            this.Degree2 = new System.Windows.Forms.TextBox();
            this.Wattage = new System.Windows.Forms.Label();
            this.Model = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtWattage = new System.Windows.Forms.TextBox();
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
            // lvItem
            // 
            this.lvItem.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SiteCode,
            this.SiteName,
            this.STATE,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lvItem.FullRowSelect = true;
            this.lvItem.GridLines = true;
            this.lvItem.HideSelection = false;
            this.lvItem.Location = new System.Drawing.Point(11, 520);
            this.lvItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvItem.Name = "lvItem";
            this.lvItem.Size = new System.Drawing.Size(1123, 252);
            this.lvItem.TabIndex = 49;
            this.lvItem.UseCompatibleStateImageBehavior = false;
            this.lvItem.View = System.Windows.Forms.View.Details;
            this.lvItem.SelectedIndexChanged += new System.EventHandler(this.lvItem_SelectedIndexChanged);
            // 
            // SiteCode
            // 
            this.SiteCode.Text = "ID";
            this.SiteCode.Width = 146;
            // 
            // SiteName
            // 
            this.SiteName.Text = "Product";
            this.SiteName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SiteName.Width = 150;
            // 
            // STATE
            // 
            this.STATE.Text = "Model";
            this.STATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.STATE.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Wattage";
            this.columnHeader1.Width = 193;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Voltage";
            this.columnHeader2.Width = 224;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Degree";
            this.columnHeader3.Width = 160;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ProductID);
            this.groupBox1.Controls.Add(this.txtProducID);
            this.groupBox1.Controls.Add(this.Degree);
            this.groupBox1.Controls.Add(this.Voltage);
            this.groupBox1.Controls.Add(this.TxtVolTage);
            this.groupBox1.Controls.Add(this.Degree2);
            this.groupBox1.Controls.Add(this.Wattage);
            this.groupBox1.Controls.Add(this.Model);
            this.groupBox1.Controls.Add(this.txtModel);
            this.groupBox1.Controls.Add(this.txtWattage);
            this.groupBox1.Location = new System.Drawing.Point(11, 169);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(1124, 255);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
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
            this.ProductID.Text = "ProductID";
            // 
            // txtProducID
            // 
            this.txtProducID.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtProducID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtProducID.Location = new System.Drawing.Point(754, 51);
            this.txtProducID.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtProducID.MaxLength = 10;
            this.txtProducID.Name = "txtProducID";
            this.txtProducID.Size = new System.Drawing.Size(256, 35);
            this.txtProducID.TabIndex = 8;
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
            this.Degree.Text = "Degree Of Protection";
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
            this.Voltage.Text = "Voltage";
            // 
            // TxtVolTage
            // 
            this.TxtVolTage.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.TxtVolTage.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TxtVolTage.Location = new System.Drawing.Point(9, 163);
            this.TxtVolTage.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.TxtVolTage.MaxLength = 10;
            this.TxtVolTage.Name = "TxtVolTage";
            this.TxtVolTage.Size = new System.Drawing.Size(256, 35);
            this.TxtVolTage.TabIndex = 4;
            // 
            // Degree2
            // 
            this.Degree2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.Degree2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Degree2.Location = new System.Drawing.Point(361, 163);
            this.Degree2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Degree2.MaxLength = 50;
            this.Degree2.Name = "Degree2";
            this.Degree2.Size = new System.Drawing.Size(256, 35);
            this.Degree2.TabIndex = 6;
            // 
            // Wattage
            // 
            this.Wattage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Wattage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Wattage.Location = new System.Drawing.Point(370, 9);
            this.Wattage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Wattage.Name = "Wattage";
            this.Wattage.Size = new System.Drawing.Size(145, 22);
            this.Wattage.TabIndex = 2;
            this.Wattage.Text = "Wattage";
            this.Wattage.Click += new System.EventHandler(this.lblSiteName_Click);
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
            this.Model.Text = "Model";
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtModel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtModel.Location = new System.Drawing.Point(5, 51);
            this.txtModel.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtModel.MaxLength = 10;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(256, 35);
            this.txtModel.TabIndex = 1;
            // 
            // txtWattage
            // 
            this.txtWattage.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtWattage.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtWattage.Location = new System.Drawing.Point(361, 51);
            this.txtWattage.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtWattage.MaxLength = 50;
            this.txtWattage.Name = "txtWattage";
            this.txtWattage.Size = new System.Drawing.Size(256, 35);
            this.txtWattage.TabIndex = 2;
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
            this.lblHeader.Text = "Item Master";
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
            // ItemMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 803);
            this.Controls.Add(this.lvItem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNoOfRecords);
            this.Name = "ItemMaster";
            this.Text = "ItemMaster";
            this.Load += new System.EventHandler(this.ItemMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvItem;
        private System.Windows.Forms.ColumnHeader SiteCode;
        private System.Windows.Forms.ColumnHeader SiteName;
        private System.Windows.Forms.ColumnHeader STATE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Wattage;
        private System.Windows.Forms.Label Model;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtWattage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialFlatButton btnMinimize;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblNoOfRecords;
        private System.Windows.Forms.Label ProductID;
        private System.Windows.Forms.TextBox txtProducID;
        private System.Windows.Forms.Label Degree;
        private System.Windows.Forms.Label Voltage;
        private System.Windows.Forms.TextBox TxtVolTage;
        private System.Windows.Forms.TextBox Degree2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}