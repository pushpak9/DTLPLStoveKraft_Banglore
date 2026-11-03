namespace StockCraft.Forms.Transaction
{
    partial class Inspection
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.TableLayoutPanel tblDetails;

        private System.Windows.Forms.Label lblWorkOrderNo;
        private System.Windows.Forms.ComboBox cmbWorkOrderNo;
        private System.Windows.Forms.Label lblPartCode;
        private System.Windows.Forms.Label lblLineCode;
        private System.Windows.Forms.ComboBox cmbLineCode;
        private System.Windows.Forms.Label lblPrinterIP;
        private System.Windows.Forms.TextBox txtPrinterIP;
        private System.Windows.Forms.Label lblPLCIP;
        private System.Windows.Forms.TextBox txtPLCIP;
        private System.Windows.Forms.Label lblPLCPort;
        private System.Windows.Forms.TextBox txtPLCPort;
        private System.Windows.Forms.Label lblScannerIP;
        private System.Windows.Forms.TextBox txtScannerIP;
        private System.Windows.Forms.Label lblScannerPort;
        private System.Windows.Forms.TextBox txtScannerPort;

        private System.Windows.Forms.Panel pnlStatus;

        private System.Windows.Forms.Panel pnlOK;
        private System.Windows.Forms.Label lblOKTitle;
        private System.Windows.Forms.Label lblOKCount;

        private System.Windows.Forms.Panel pnlOKPercent;
        private System.Windows.Forms.Label lblOKPercentTitle;
        private System.Windows.Forms.Label lblOKPercent;

        private System.Windows.Forms.Panel pnlNGPercent;
        private System.Windows.Forms.Label lblNGPercentTitle;
        private System.Windows.Forms.Label lblNGPercent;

        private System.Windows.Forms.Panel pnlExtra3;
        private System.Windows.Forms.Label lblExtra3Title;
        private System.Windows.Forms.Label lblExtra3Count;

        private System.Windows.Forms.Panel pnlExtra4;
        private System.Windows.Forms.Label lblExtra4Title;
        private System.Windows.Forms.Label lblExtra4Count;

        private System.Windows.Forms.Panel pnlInspection;
        private System.Windows.Forms.Label lblInspectionArea;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.tblDetails = new System.Windows.Forms.TableLayoutPanel();
            this.Hardware = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrinterPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPartCode = new System.Windows.Forms.TextBox();
            this.lblWorkOrderNo = new System.Windows.Forms.Label();
            this.cmbWorkOrderNo = new System.Windows.Forms.ComboBox();
            this.lblPLCIP = new System.Windows.Forms.Label();
            this.txtPLCIP = new System.Windows.Forms.TextBox();
            this.lblPartCode = new System.Windows.Forms.Label();
            this.lblPLCPort = new System.Windows.Forms.Label();
            this.txtPLCPort = new System.Windows.Forms.TextBox();
            this.lblLineCode = new System.Windows.Forms.Label();
            this.cmbLineCode = new System.Windows.Forms.ComboBox();
            this.lblScannerIP = new System.Windows.Forms.Label();
            this.txtScannerIP = new System.Windows.Forms.TextBox();
            this.lblPrinterIP = new System.Windows.Forms.Label();
            this.txtPrinterIP = new System.Windows.Forms.TextBox();
            this.lblScannerPort = new System.Windows.Forms.Label();
            this.txtScannerPort = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.tblStatus = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.pnlRemaining = new System.Windows.Forms.Panel();
            this.lblCompletedMc = new System.Windows.Forms.Label();
            this.lblRemainingTitle = new System.Windows.Forms.Label();
            this.pnlScan = new System.Windows.Forms.Panel();
            this.txtPlcTrigger = new System.Windows.Forms.Label();
            this.lblScanTitle = new System.Windows.Forms.Label();
            this.pnlNG = new System.Windows.Forms.Panel();
            this.lblNGCount = new System.Windows.Forms.Label();
            this.lblNGTitle = new System.Windows.Forms.Label();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.txtpacksize = new System.Windows.Forms.Label();
            this.lblInnerTitle = new System.Windows.Forms.Label();
            this.pnlMaster = new System.Windows.Forms.Panel();
            this.txtScannedCount = new System.Windows.Forms.Label();
            this.ScannedCount = new System.Windows.Forms.Label();
            this.pnlPLC = new System.Windows.Forms.Panel();
            this.txtbalanceIC = new System.Windows.Forms.Label();
            this.lblPLCTitle = new System.Windows.Forms.Label();
            this.pnlExtra2 = new System.Windows.Forms.Panel();
            this.Icprintm = new System.Windows.Forms.Label();
            this.IcPrint = new System.Windows.Forms.Label();
            this.pnlOK = new System.Windows.Forms.Panel();
            this.lblOKTitle = new System.Windows.Forms.Label();
            this.lblOKCount = new System.Windows.Forms.Label();
            this.pnlOKPercent = new System.Windows.Forms.Panel();
            this.lblOKPercentTitle = new System.Windows.Forms.Label();
            this.lblOKPercent = new System.Windows.Forms.Label();
            this.pnlNGPercent = new System.Windows.Forms.Panel();
            this.lblNGPercentTitle = new System.Windows.Forms.Label();
            this.lblNGPercent = new System.Windows.Forms.Label();
            this.pnlExtra3 = new System.Windows.Forms.Panel();
            this.lblExtra3Title = new System.Windows.Forms.Label();
            this.lblExtra3Count = new System.Windows.Forms.Label();
            this.pnlExtra4 = new System.Windows.Forms.Panel();
            this.lblExtra4Title = new System.Windows.Forms.Label();
            this.lblExtra4Count = new System.Windows.Forms.Label();
            this.pnlInspection = new System.Windows.Forms.Panel();
            this.btnstrt = new System.Windows.Forms.Button();
            this.btnstop = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.lblInspectionArea = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlPack = new System.Windows.Forms.Panel();
            this.lblMsterPrint = new System.Windows.Forms.Label();
            this.lblPackTitle = new System.Windows.Forms.Label();
            this.pnlExtra1 = new System.Windows.Forms.Panel();
            this.lblBanlmcCount = new System.Windows.Forms.Label();
            this.lblExtra1Title = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.tblDetails.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.tblStatus.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlRemaining.SuspendLayout();
            this.pnlScan.SuspendLayout();
            this.pnlNG.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.pnlMaster.SuspendLayout();
            this.pnlPLC.SuspendLayout();
            this.pnlExtra2.SuspendLayout();
            this.pnlInspection.SuspendLayout();
            this.pnlPack.SuspendLayout();
            this.pnlExtra1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(85)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1600, 55);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1600, 55);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "WORK ORDER INSPECTION";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.pnlDetails.Controls.Add(this.tblDetails);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetails.Location = new System.Drawing.Point(0, 55);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
            this.pnlDetails.Size = new System.Drawing.Size(1600, 190);
            this.pnlDetails.TabIndex = 2;
            // 
            // tblDetails
            // 
            this.tblDetails.BackColor = System.Drawing.Color.White;
            this.tblDetails.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblDetails.ColumnCount = 4;
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblDetails.Controls.Add(this.Hardware, 3, 4);
            this.tblDetails.Controls.Add(this.label2, 2, 4);
            this.tblDetails.Controls.Add(this.txtPrinterPort, 1, 4);
            this.tblDetails.Controls.Add(this.label1, 0, 4);
            this.tblDetails.Controls.Add(this.TxtPartCode, 1, 1);
            this.tblDetails.Controls.Add(this.lblWorkOrderNo, 0, 0);
            this.tblDetails.Controls.Add(this.cmbWorkOrderNo, 1, 0);
            this.tblDetails.Controls.Add(this.lblPLCIP, 2, 0);
            this.tblDetails.Controls.Add(this.txtPLCIP, 3, 0);
            this.tblDetails.Controls.Add(this.lblPartCode, 0, 1);
            this.tblDetails.Controls.Add(this.lblPLCPort, 2, 1);
            this.tblDetails.Controls.Add(this.txtPLCPort, 3, 1);
            this.tblDetails.Controls.Add(this.lblLineCode, 0, 2);
            this.tblDetails.Controls.Add(this.cmbLineCode, 1, 2);
            this.tblDetails.Controls.Add(this.lblScannerIP, 2, 2);
            this.tblDetails.Controls.Add(this.txtScannerIP, 3, 2);
            this.tblDetails.Controls.Add(this.lblPrinterIP, 0, 3);
            this.tblDetails.Controls.Add(this.txtPrinterIP, 1, 3);
            this.tblDetails.Controls.Add(this.lblScannerPort, 2, 3);
            this.tblDetails.Controls.Add(this.txtScannerPort, 3, 3);
            this.tblDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDetails.Location = new System.Drawing.Point(20, 6);
            this.tblDetails.Name = "tblDetails";
            this.tblDetails.RowCount = 5;
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblDetails.Size = new System.Drawing.Size(1560, 178);
            this.tblDetails.TabIndex = 0;
            // 
            // Hardware
            // 
            this.Hardware.BackColor = System.Drawing.Color.Red;
            this.Hardware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hardware.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Hardware.Location = new System.Drawing.Point(1018, 145);
            this.Hardware.Margin = new System.Windows.Forms.Padding(4);
            this.Hardware.Name = "Hardware";
            this.Hardware.Size = new System.Drawing.Size(537, 27);
            this.Hardware.TabIndex = 20;
            this.Hardware.Text = "All Hardware Not Connected";
            this.Hardware.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(783, 141);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(227, 36);
            this.label2.TabIndex = 19;
            this.label2.Text = "Status";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrinterPort
            // 
            this.txtPrinterPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrinterPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrinterPort.Location = new System.Drawing.Point(239, 145);
            this.txtPrinterPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrinterPort.Name = "txtPrinterPort";
            this.txtPrinterPort.Size = new System.Drawing.Size(536, 27);
            this.txtPrinterPort.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 141);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(227, 36);
            this.label1.TabIndex = 17;
            this.label1.Text = "Printer port";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtPartCode
            // 
            this.TxtPartCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPartCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtPartCode.Location = new System.Drawing.Point(239, 40);
            this.TxtPartCode.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPartCode.Name = "TxtPartCode";
            this.TxtPartCode.Size = new System.Drawing.Size(536, 27);
            this.TxtPartCode.TabIndex = 16;
            // 
            // lblWorkOrderNo
            // 
            this.lblWorkOrderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkOrderNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWorkOrderNo.Location = new System.Drawing.Point(4, 1);
            this.lblWorkOrderNo.Name = "lblWorkOrderNo";
            this.lblWorkOrderNo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblWorkOrderNo.Size = new System.Drawing.Size(227, 34);
            this.lblWorkOrderNo.TabIndex = 0;
            this.lblWorkOrderNo.Text = "Work Order No";
            this.lblWorkOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbWorkOrderNo
            // 
            this.cmbWorkOrderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbWorkOrderNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkOrderNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbWorkOrderNo.Location = new System.Drawing.Point(239, 5);
            this.cmbWorkOrderNo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbWorkOrderNo.Name = "cmbWorkOrderNo";
            this.cmbWorkOrderNo.Size = new System.Drawing.Size(536, 28);
            this.cmbWorkOrderNo.TabIndex = 1;
            this.cmbWorkOrderNo.SelectedIndexChanged += new System.EventHandler(this.cmbWorkOrderNo_SelectedIndexChanged_1);
            // 
            // lblPLCIP
            // 
            this.lblPLCIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPLCIP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPLCIP.Location = new System.Drawing.Point(783, 1);
            this.lblPLCIP.Name = "lblPLCIP";
            this.lblPLCIP.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblPLCIP.Size = new System.Drawing.Size(227, 34);
            this.lblPLCIP.TabIndex = 2;
            this.lblPLCIP.Text = "PLC IP";
            this.lblPLCIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPLCIP
            // 
            this.txtPLCIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPLCIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPLCIP.Location = new System.Drawing.Point(1018, 5);
            this.txtPLCIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtPLCIP.Name = "txtPLCIP";
            this.txtPLCIP.Size = new System.Drawing.Size(537, 27);
            this.txtPLCIP.TabIndex = 3;
            // 
            // lblPartCode
            // 
            this.lblPartCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPartCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPartCode.Location = new System.Drawing.Point(4, 36);
            this.lblPartCode.Name = "lblPartCode";
            this.lblPartCode.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblPartCode.Size = new System.Drawing.Size(227, 34);
            this.lblPartCode.TabIndex = 4;
            this.lblPartCode.Text = "Part Code";
            this.lblPartCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPLCPort
            // 
            this.lblPLCPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPLCPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPLCPort.Location = new System.Drawing.Point(783, 36);
            this.lblPLCPort.Name = "lblPLCPort";
            this.lblPLCPort.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblPLCPort.Size = new System.Drawing.Size(227, 34);
            this.lblPLCPort.TabIndex = 6;
            this.lblPLCPort.Text = "PLC Port";
            this.lblPLCPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPLCPort
            // 
            this.txtPLCPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPLCPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPLCPort.Location = new System.Drawing.Point(1018, 40);
            this.txtPLCPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPLCPort.Name = "txtPLCPort";
            this.txtPLCPort.Size = new System.Drawing.Size(537, 27);
            this.txtPLCPort.TabIndex = 7;
            // 
            // lblLineCode
            // 
            this.lblLineCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLineCode.Location = new System.Drawing.Point(4, 71);
            this.lblLineCode.Name = "lblLineCode";
            this.lblLineCode.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblLineCode.Size = new System.Drawing.Size(227, 34);
            this.lblLineCode.TabIndex = 8;
            this.lblLineCode.Text = "Line Code";
            this.lblLineCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbLineCode
            // 
            this.cmbLineCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLineCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLineCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbLineCode.Location = new System.Drawing.Point(239, 75);
            this.cmbLineCode.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLineCode.Name = "cmbLineCode";
            this.cmbLineCode.Size = new System.Drawing.Size(536, 28);
            this.cmbLineCode.TabIndex = 9;
            this.cmbLineCode.SelectedIndexChanged += new System.EventHandler(this.cmbLineCode_SelectedIndexChanged);
            // 
            // lblScannerIP
            // 
            this.lblScannerIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScannerIP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblScannerIP.Location = new System.Drawing.Point(783, 71);
            this.lblScannerIP.Name = "lblScannerIP";
            this.lblScannerIP.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblScannerIP.Size = new System.Drawing.Size(227, 34);
            this.lblScannerIP.TabIndex = 10;
            this.lblScannerIP.Text = "Scanner IP";
            this.lblScannerIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtScannerIP
            // 
            this.txtScannerIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScannerIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtScannerIP.Location = new System.Drawing.Point(1018, 75);
            this.txtScannerIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtScannerIP.Name = "txtScannerIP";
            this.txtScannerIP.Size = new System.Drawing.Size(537, 27);
            this.txtScannerIP.TabIndex = 11;
            // 
            // lblPrinterIP
            // 
            this.lblPrinterIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrinterIP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrinterIP.Location = new System.Drawing.Point(4, 106);
            this.lblPrinterIP.Name = "lblPrinterIP";
            this.lblPrinterIP.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblPrinterIP.Size = new System.Drawing.Size(227, 34);
            this.lblPrinterIP.TabIndex = 12;
            this.lblPrinterIP.Text = "Printer IP";
            this.lblPrinterIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrinterIP
            // 
            this.txtPrinterIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrinterIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrinterIP.Location = new System.Drawing.Point(239, 110);
            this.txtPrinterIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrinterIP.Name = "txtPrinterIP";
            this.txtPrinterIP.Size = new System.Drawing.Size(536, 27);
            this.txtPrinterIP.TabIndex = 13;
            // 
            // lblScannerPort
            // 
            this.lblScannerPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScannerPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblScannerPort.Location = new System.Drawing.Point(783, 106);
            this.lblScannerPort.Name = "lblScannerPort";
            this.lblScannerPort.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblScannerPort.Size = new System.Drawing.Size(227, 34);
            this.lblScannerPort.TabIndex = 14;
            this.lblScannerPort.Text = "Scanner Port";
            this.lblScannerPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtScannerPort
            // 
            this.txtScannerPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScannerPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtScannerPort.Location = new System.Drawing.Point(1018, 110);
            this.txtScannerPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtScannerPort.Name = "txtScannerPort";
            this.txtScannerPort.Size = new System.Drawing.Size(537, 27);
            this.txtScannerPort.TabIndex = 15;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.pnlStatus.Controls.Add(this.tblStatus);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatus.Location = new System.Drawing.Point(0, 245);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Padding = new System.Windows.Forms.Padding(20, 4, 20, 4);
            this.pnlStatus.Size = new System.Drawing.Size(1600, 210);
            this.pnlStatus.TabIndex = 1;
            // 
            // tblStatus
            // 
            this.tblStatus.BackColor = System.Drawing.Color.Transparent;
            this.tblStatus.ColumnCount = 9;
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblStatus.Controls.Add(this.pnlTotal, 0, 0);
            this.tblStatus.Controls.Add(this.pnlRemaining, 2, 0);
            this.tblStatus.Controls.Add(this.pnlScan, 5, 0);
            this.tblStatus.Controls.Add(this.pnlNG, 7, 0);
            this.tblStatus.Controls.Add(this.pnlInner, 0, 1);
            this.tblStatus.Controls.Add(this.pnlMaster, 2, 1);
            this.tblStatus.Controls.Add(this.pnlPLC, 4, 1);
            this.tblStatus.Controls.Add(this.pnlExtra2, 7, 1);
            this.tblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStatus.Location = new System.Drawing.Point(20, 4);
            this.tblStatus.Margin = new System.Windows.Forms.Padding(0);
            this.tblStatus.Name = "tblStatus";
            this.tblStatus.RowCount = 2;
            this.tblStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStatus.Size = new System.Drawing.Size(1560, 202);
            this.tblStatus.TabIndex = 0;
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.White;
            this.pnlTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblStatus.SetColumnSpan(this.pnlTotal, 2);
            this.pnlTotal.Controls.Add(this.lblTotalCount);
            this.pnlTotal.Controls.Add(this.lblTotalTitle);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotal.Location = new System.Drawing.Point(8, 8);
            this.pnlTotal.Margin = new System.Windows.Forms.Padding(8);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(330, 85);
            this.pnlTotal.TabIndex = 0;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTotalCount.Location = new System.Drawing.Point(0, 25);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(328, 58);
            this.lblTotalCount.TabIndex = 0;
            this.lblTotalCount.Text = "0";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.lblTotalTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(328, 25);
            this.lblTotalTitle.TabIndex = 1;
            this.lblTotalTitle.Text = "TOTAL MC COUNT";
            this.lblTotalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRemaining
            // 
            this.pnlRemaining.BackColor = System.Drawing.Color.White;
            this.pnlRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblStatus.SetColumnSpan(this.pnlRemaining, 2);
            this.pnlRemaining.Controls.Add(this.lblCompletedMc);
            this.pnlRemaining.Controls.Add(this.lblRemainingTitle);
            this.pnlRemaining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRemaining.Location = new System.Drawing.Point(354, 8);
            this.pnlRemaining.Margin = new System.Windows.Forms.Padding(8);
            this.pnlRemaining.Name = "pnlRemaining";
            this.pnlRemaining.Size = new System.Drawing.Size(330, 85);
            this.pnlRemaining.TabIndex = 1;
            // 
            // lblCompletedMc
            // 
            this.lblCompletedMc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCompletedMc.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCompletedMc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblCompletedMc.Location = new System.Drawing.Point(0, 25);
            this.lblCompletedMc.Name = "lblCompletedMc";
            this.lblCompletedMc.Size = new System.Drawing.Size(328, 58);
            this.lblCompletedMc.TabIndex = 0;
            this.lblCompletedMc.Text = "0";
            this.lblCompletedMc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRemainingTitle
            // 
            this.lblRemainingTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.lblRemainingTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRemainingTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRemainingTitle.ForeColor = System.Drawing.Color.White;
            this.lblRemainingTitle.Location = new System.Drawing.Point(0, 0);
            this.lblRemainingTitle.Name = "lblRemainingTitle";
            this.lblRemainingTitle.Size = new System.Drawing.Size(328, 25);
            this.lblRemainingTitle.TabIndex = 1;
            this.lblRemainingTitle.Text = "MC COUNT";
            this.lblRemainingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlScan
            // 
            this.pnlScan.BackColor = System.Drawing.Color.White;
            this.pnlScan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblStatus.SetColumnSpan(this.pnlScan, 2);
            this.pnlScan.Controls.Add(this.txtPlcTrigger);
            this.pnlScan.Controls.Add(this.lblScanTitle);
            this.pnlScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScan.Location = new System.Drawing.Point(873, 8);
            this.pnlScan.Margin = new System.Windows.Forms.Padding(8);
            this.pnlScan.Name = "pnlScan";
            this.pnlScan.Size = new System.Drawing.Size(330, 85);
            this.pnlScan.TabIndex = 4;
            // 
            // txtPlcTrigger
            // 
            this.txtPlcTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlcTrigger.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txtPlcTrigger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.txtPlcTrigger.Location = new System.Drawing.Point(0, 25);
            this.txtPlcTrigger.Name = "txtPlcTrigger";
            this.txtPlcTrigger.Size = new System.Drawing.Size(328, 58);
            this.txtPlcTrigger.TabIndex = 0;
            this.txtPlcTrigger.Text = "0";
            this.txtPlcTrigger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScanTitle
            // 
            this.lblScanTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.lblScanTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblScanTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblScanTitle.ForeColor = System.Drawing.Color.White;
            this.lblScanTitle.Location = new System.Drawing.Point(0, 0);
            this.lblScanTitle.Name = "lblScanTitle";
            this.lblScanTitle.Size = new System.Drawing.Size(328, 25);
            this.lblScanTitle.TabIndex = 1;
            this.lblScanTitle.Text = "PLC TRIGGER";
            this.lblScanTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlNG
            // 
            this.pnlNG.BackColor = System.Drawing.Color.White;
            this.pnlNG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblStatus.SetColumnSpan(this.pnlNG, 2);
            this.pnlNG.Controls.Add(this.lblNGCount);
            this.pnlNG.Controls.Add(this.lblNGTitle);
            this.pnlNG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNG.Location = new System.Drawing.Point(1219, 8);
            this.pnlNG.Margin = new System.Windows.Forms.Padding(8);
            this.pnlNG.Name = "pnlNG";
            this.pnlNG.Size = new System.Drawing.Size(333, 85);
            this.pnlNG.TabIndex = 8;
            // 
            // lblNGCount
            // 
            this.lblNGCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNGCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNGCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblNGCount.Location = new System.Drawing.Point(0, 25);
            this.lblNGCount.Name = "lblNGCount";
            this.lblNGCount.Size = new System.Drawing.Size(331, 58);
            this.lblNGCount.TabIndex = 0;
            this.lblNGCount.Text = "0";
            this.lblNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNGTitle
            // 
            this.lblNGTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblNGTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNGTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNGTitle.ForeColor = System.Drawing.Color.White;
            this.lblNGTitle.Location = new System.Drawing.Point(0, 0);
            this.lblNGTitle.Name = "lblNGTitle";
            this.lblNGTitle.Size = new System.Drawing.Size(331, 25);
            this.lblNGTitle.TabIndex = 1;
            this.lblNGTitle.Text = "NG COUNT";
            this.lblNGTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.White;
            this.pnlInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblStatus.SetColumnSpan(this.pnlInner, 2);
            this.pnlInner.Controls.Add(this.txtpacksize);
            this.pnlInner.Controls.Add(this.lblInnerTitle);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(8, 109);
            this.pnlInner.Margin = new System.Windows.Forms.Padding(8);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Size = new System.Drawing.Size(330, 85);
            this.pnlInner.TabIndex = 5;
            // 
            // txtpacksize
            // 
            this.txtpacksize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtpacksize.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txtpacksize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.txtpacksize.Location = new System.Drawing.Point(0, 25);
            this.txtpacksize.Name = "txtpacksize";
            this.txtpacksize.Size = new System.Drawing.Size(328, 58);
            this.txtpacksize.TabIndex = 0;
            this.txtpacksize.Text = "0";
            this.txtpacksize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInnerTitle
            // 
            this.lblInnerTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.lblInnerTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInnerTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblInnerTitle.ForeColor = System.Drawing.Color.White;
            this.lblInnerTitle.Location = new System.Drawing.Point(0, 0);
            this.lblInnerTitle.Name = "lblInnerTitle";
            this.lblInnerTitle.Size = new System.Drawing.Size(328, 25);
            this.lblInnerTitle.TabIndex = 1;
            this.lblInnerTitle.Text = "PACK SIZE";
            this.lblInnerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMaster
            // 
            this.pnlMaster.BackColor = System.Drawing.Color.White;
            this.pnlMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblStatus.SetColumnSpan(this.pnlMaster, 2);
            this.pnlMaster.Controls.Add(this.txtScannedCount);
            this.pnlMaster.Controls.Add(this.ScannedCount);
            this.pnlMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMaster.Location = new System.Drawing.Point(354, 109);
            this.pnlMaster.Margin = new System.Windows.Forms.Padding(8);
            this.pnlMaster.Name = "pnlMaster";
            this.pnlMaster.Size = new System.Drawing.Size(330, 85);
            this.pnlMaster.TabIndex = 6;
            // 
            // txtScannedCount
            // 
            this.txtScannedCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScannedCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txtScannedCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.txtScannedCount.Location = new System.Drawing.Point(0, 25);
            this.txtScannedCount.Name = "txtScannedCount";
            this.txtScannedCount.Size = new System.Drawing.Size(328, 58);
            this.txtScannedCount.TabIndex = 0;
            this.txtScannedCount.Text = "0";
            this.txtScannedCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScannedCount
            // 
            this.ScannedCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.ScannedCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScannedCount.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.ScannedCount.ForeColor = System.Drawing.Color.White;
            this.ScannedCount.Location = new System.Drawing.Point(0, 0);
            this.ScannedCount.Name = "ScannedCount";
            this.ScannedCount.Size = new System.Drawing.Size(328, 25);
            this.ScannedCount.TabIndex = 1;
            this.ScannedCount.Text = "SCAN COUNT";
            this.ScannedCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPLC
            // 
            this.pnlPLC.BackColor = System.Drawing.Color.White;
            this.pnlPLC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblStatus.SetColumnSpan(this.pnlPLC, 2);
            this.pnlPLC.Controls.Add(this.txtbalanceIC);
            this.pnlPLC.Controls.Add(this.lblPLCTitle);
            this.pnlPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPLC.Location = new System.Drawing.Point(700, 109);
            this.pnlPLC.Margin = new System.Windows.Forms.Padding(8);
            this.pnlPLC.Name = "pnlPLC";
            this.pnlPLC.Size = new System.Drawing.Size(330, 85);
            this.pnlPLC.TabIndex = 7;
            // 
            // txtbalanceIC
            // 
            this.txtbalanceIC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbalanceIC.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txtbalanceIC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.txtbalanceIC.Location = new System.Drawing.Point(0, 25);
            this.txtbalanceIC.Name = "txtbalanceIC";
            this.txtbalanceIC.Size = new System.Drawing.Size(328, 58);
            this.txtbalanceIC.TabIndex = 0;
            this.txtbalanceIC.Text = "0";
            this.txtbalanceIC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPLCTitle
            // 
            this.lblPLCTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(65)))));
            this.lblPLCTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPLCTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPLCTitle.ForeColor = System.Drawing.Color.White;
            this.lblPLCTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPLCTitle.Name = "lblPLCTitle";
            this.lblPLCTitle.Size = new System.Drawing.Size(328, 25);
            this.lblPLCTitle.TabIndex = 1;
            this.lblPLCTitle.Text = "BALANCE";
            this.lblPLCTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlExtra2
            // 
            this.pnlExtra2.BackColor = System.Drawing.Color.White;
            this.pnlExtra2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblStatus.SetColumnSpan(this.pnlExtra2, 2);
            this.pnlExtra2.Controls.Add(this.Icprintm);
            this.pnlExtra2.Controls.Add(this.IcPrint);
            this.pnlExtra2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExtra2.Location = new System.Drawing.Point(1219, 109);
            this.pnlExtra2.Margin = new System.Windows.Forms.Padding(8);
            this.pnlExtra2.Name = "pnlExtra2";
            this.pnlExtra2.Size = new System.Drawing.Size(333, 85);
            this.pnlExtra2.TabIndex = 9;
            // 
            // Icprintm
            // 
            this.Icprintm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Icprintm.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.Icprintm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.Icprintm.Location = new System.Drawing.Point(0, 25);
            this.Icprintm.Name = "Icprintm";
            this.Icprintm.Size = new System.Drawing.Size(331, 58);
            this.Icprintm.TabIndex = 0;
            this.Icprintm.Text = "0";
            this.Icprintm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IcPrint
            // 
            this.IcPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(175)))), ((int)(((byte)(180)))));
            this.IcPrint.Dock = System.Windows.Forms.DockStyle.Top;
            this.IcPrint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.IcPrint.ForeColor = System.Drawing.Color.White;
            this.IcPrint.Location = new System.Drawing.Point(0, 0);
            this.IcPrint.Name = "IcPrint";
            this.IcPrint.Size = new System.Drawing.Size(331, 25);
            this.IcPrint.TabIndex = 1;
            this.IcPrint.Text = "IC PRINT";
            this.IcPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOK
            // 
            this.pnlOK.Location = new System.Drawing.Point(0, 0);
            this.pnlOK.Name = "pnlOK";
            this.pnlOK.Size = new System.Drawing.Size(200, 100);
            this.pnlOK.TabIndex = 0;
            // 
            // lblOKTitle
            // 
            this.lblOKTitle.Location = new System.Drawing.Point(0, 0);
            this.lblOKTitle.Name = "lblOKTitle";
            this.lblOKTitle.Size = new System.Drawing.Size(100, 23);
            this.lblOKTitle.TabIndex = 0;
            // 
            // lblOKCount
            // 
            this.lblOKCount.Location = new System.Drawing.Point(0, 0);
            this.lblOKCount.Name = "lblOKCount";
            this.lblOKCount.Size = new System.Drawing.Size(100, 23);
            this.lblOKCount.TabIndex = 0;
            // 
            // pnlOKPercent
            // 
            this.pnlOKPercent.Location = new System.Drawing.Point(0, 0);
            this.pnlOKPercent.Name = "pnlOKPercent";
            this.pnlOKPercent.Size = new System.Drawing.Size(200, 100);
            this.pnlOKPercent.TabIndex = 0;
            // 
            // lblOKPercentTitle
            // 
            this.lblOKPercentTitle.Location = new System.Drawing.Point(0, 0);
            this.lblOKPercentTitle.Name = "lblOKPercentTitle";
            this.lblOKPercentTitle.Size = new System.Drawing.Size(100, 23);
            this.lblOKPercentTitle.TabIndex = 0;
            // 
            // lblOKPercent
            // 
            this.lblOKPercent.Location = new System.Drawing.Point(0, 0);
            this.lblOKPercent.Name = "lblOKPercent";
            this.lblOKPercent.Size = new System.Drawing.Size(100, 23);
            this.lblOKPercent.TabIndex = 0;
            // 
            // pnlNGPercent
            // 
            this.pnlNGPercent.Location = new System.Drawing.Point(0, 0);
            this.pnlNGPercent.Name = "pnlNGPercent";
            this.pnlNGPercent.Size = new System.Drawing.Size(200, 100);
            this.pnlNGPercent.TabIndex = 0;
            // 
            // lblNGPercentTitle
            // 
            this.lblNGPercentTitle.Location = new System.Drawing.Point(0, 0);
            this.lblNGPercentTitle.Name = "lblNGPercentTitle";
            this.lblNGPercentTitle.Size = new System.Drawing.Size(100, 23);
            this.lblNGPercentTitle.TabIndex = 0;
            // 
            // lblNGPercent
            // 
            this.lblNGPercent.Location = new System.Drawing.Point(0, 0);
            this.lblNGPercent.Name = "lblNGPercent";
            this.lblNGPercent.Size = new System.Drawing.Size(100, 23);
            this.lblNGPercent.TabIndex = 0;
            // 
            // pnlExtra3
            // 
            this.pnlExtra3.Location = new System.Drawing.Point(0, 0);
            this.pnlExtra3.Name = "pnlExtra3";
            this.pnlExtra3.Size = new System.Drawing.Size(200, 100);
            this.pnlExtra3.TabIndex = 0;
            // 
            // lblExtra3Title
            // 
            this.lblExtra3Title.Location = new System.Drawing.Point(0, 0);
            this.lblExtra3Title.Name = "lblExtra3Title";
            this.lblExtra3Title.Size = new System.Drawing.Size(100, 23);
            this.lblExtra3Title.TabIndex = 0;
            // 
            // lblExtra3Count
            // 
            this.lblExtra3Count.Location = new System.Drawing.Point(0, 0);
            this.lblExtra3Count.Name = "lblExtra3Count";
            this.lblExtra3Count.Size = new System.Drawing.Size(100, 23);
            this.lblExtra3Count.TabIndex = 0;
            // 
            // pnlExtra4
            // 
            this.pnlExtra4.Location = new System.Drawing.Point(0, 0);
            this.pnlExtra4.Name = "pnlExtra4";
            this.pnlExtra4.Size = new System.Drawing.Size(200, 100);
            this.pnlExtra4.TabIndex = 0;
            // 
            // lblExtra4Title
            // 
            this.lblExtra4Title.Location = new System.Drawing.Point(0, 0);
            this.lblExtra4Title.Name = "lblExtra4Title";
            this.lblExtra4Title.Size = new System.Drawing.Size(100, 23);
            this.lblExtra4Title.TabIndex = 0;
            // 
            // lblExtra4Count
            // 
            this.lblExtra4Count.Location = new System.Drawing.Point(0, 0);
            this.lblExtra4Count.Name = "lblExtra4Count";
            this.lblExtra4Count.Size = new System.Drawing.Size(100, 23);
            this.lblExtra4Count.TabIndex = 0;
            // 
            // pnlInspection
            // 
            this.pnlInspection.BackColor = System.Drawing.Color.White;
            this.pnlInspection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInspection.Controls.Add(this.btnstrt);
            this.pnlInspection.Controls.Add(this.btnstop);
            this.pnlInspection.Controls.Add(this.lstLog);
            this.pnlInspection.Controls.Add(this.lblInspectionArea);
            this.pnlInspection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspection.Location = new System.Drawing.Point(0, 455);
            this.pnlInspection.Name = "pnlInspection";
            this.pnlInspection.Padding = new System.Windows.Forms.Padding(8);
            this.pnlInspection.Size = new System.Drawing.Size(1600, 445);
            this.pnlInspection.TabIndex = 0;
            // 
            // btnstrt
            // 
            this.btnstrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnstrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnstrt.FlatAppearance.BorderSize = 0;
            this.btnstrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstrt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnstrt.ForeColor = System.Drawing.Color.White;
            this.btnstrt.Location = new System.Drawing.Point(1320, 50);
            this.btnstrt.Name = "btnstrt";
            this.btnstrt.Size = new System.Drawing.Size(110, 55);
            this.btnstrt.TabIndex = 10;
            this.btnstrt.Text = "Start";
            this.btnstrt.UseVisualStyleBackColor = false;
            this.btnstrt.Click += new System.EventHandler(this.btnstrt_Click);
            // 
            // btnstop
            // 
            this.btnstop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnstop.BackColor = System.Drawing.Color.Red;
            this.btnstop.FlatAppearance.BorderSize = 0;
            this.btnstop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnstop.ForeColor = System.Drawing.Color.White;
            this.btnstop.Location = new System.Drawing.Point(1440, 50);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(110, 55);
            this.btnstop.TabIndex = 9;
            this.btnstop.Text = "Stop";
            this.btnstop.UseVisualStyleBackColor = false;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // lstLog
            // 
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstLog.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.ItemHeight = 23;
            this.lstLog.Location = new System.Drawing.Point(8, 42);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1582, 441);
            this.lstLog.TabIndex = 0;
            // 
            // lblInspectionArea
            // 
            this.lblInspectionArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.lblInspectionArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInspectionArea.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInspectionArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.lblInspectionArea.Location = new System.Drawing.Point(8, 8);
            this.lblInspectionArea.Name = "lblInspectionArea";
            this.lblInspectionArea.Size = new System.Drawing.Size(1582, 34);
            this.lblInspectionArea.TabIndex = 3;
            this.lblInspectionArea.Text = "INSPECTION LOG";
            this.lblInspectionArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.Start.FlatAppearance.BorderSize = 0;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Start.ForeColor = System.Drawing.Color.White;
            this.Start.Location = new System.Drawing.Point(-1000, -1000);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(105, 32);
            this.Start.TabIndex = 1;
            this.Start.Text = "START";
            this.Start.UseVisualStyleBackColor = false;
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.Stop.FlatAppearance.BorderSize = 0;
            this.Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stop.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Stop.ForeColor = System.Drawing.Color.White;
            this.Stop.Location = new System.Drawing.Point(-1000, -1000);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(105, 32);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "STOP";
            this.Stop.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlPack
            // 
            this.pnlPack.BackColor = System.Drawing.Color.White;
            this.pnlPack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPack.Controls.Add(this.lblMsterPrint);
            this.pnlPack.Controls.Add(this.lblPackTitle);
            this.pnlPack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPack.Location = new System.Drawing.Point(940, 4);
            this.pnlPack.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPack.Name = "pnlPack";
            this.pnlPack.Size = new System.Drawing.Size(304, 60);
            this.pnlPack.TabIndex = 3;
            // 
            // lblMsterPrint
            // 
            this.lblMsterPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMsterPrint.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblMsterPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblMsterPrint.Location = new System.Drawing.Point(0, 25);
            this.lblMsterPrint.Name = "lblMsterPrint";
            this.lblMsterPrint.Size = new System.Drawing.Size(302, 33);
            this.lblMsterPrint.TabIndex = 0;
            this.lblMsterPrint.Text = "0";
            this.lblMsterPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPackTitle
            // 
            this.lblPackTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblPackTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPackTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPackTitle.ForeColor = System.Drawing.Color.White;
            this.lblPackTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPackTitle.Name = "lblPackTitle";
            this.lblPackTitle.Size = new System.Drawing.Size(302, 25);
            this.lblPackTitle.TabIndex = 1;
            this.lblPackTitle.Text = "Master Print";
            this.lblPackTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlExtra1
            // 
            this.pnlExtra1.BackColor = System.Drawing.Color.White;
            this.pnlExtra1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExtra1.Controls.Add(this.lblBanlmcCount);
            this.pnlExtra1.Controls.Add(this.lblExtra1Title);
            this.pnlExtra1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExtra1.Location = new System.Drawing.Point(628, 4);
            this.pnlExtra1.Margin = new System.Windows.Forms.Padding(4);
            this.pnlExtra1.Name = "pnlExtra1";
            this.pnlExtra1.Size = new System.Drawing.Size(304, 60);
            this.pnlExtra1.TabIndex = 2;
            // 
            // lblBanlmcCount
            // 
            this.lblBanlmcCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBanlmcCount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblBanlmcCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblBanlmcCount.Location = new System.Drawing.Point(0, 25);
            this.lblBanlmcCount.Name = "lblBanlmcCount";
            this.lblBanlmcCount.Size = new System.Drawing.Size(302, 33);
            this.lblBanlmcCount.TabIndex = 0;
            this.lblBanlmcCount.Text = "0";
            this.lblBanlmcCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExtra1Title
            // 
            this.lblExtra1Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblExtra1Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExtra1Title.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblExtra1Title.ForeColor = System.Drawing.Color.White;
            this.lblExtra1Title.Location = new System.Drawing.Point(0, 0);
            this.lblExtra1Title.Name = "lblExtra1Title";
            this.lblExtra1Title.Size = new System.Drawing.Size(302, 25);
            this.lblExtra1Title.TabIndex = 1;
            this.lblExtra1Title.Text = "BALANCE MC";
            this.lblExtra1Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Inspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.pnlInspection);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1200, 750);
            this.Name = "Inspection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Work Order Inspection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Inspection_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.tblDetails.ResumeLayout(false);
            this.tblDetails.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.tblStatus.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlRemaining.ResumeLayout(false);
            this.pnlScan.ResumeLayout(false);
            this.pnlNG.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlMaster.ResumeLayout(false);
            this.pnlPLC.ResumeLayout(false);
            this.pnlExtra2.ResumeLayout(false);
            this.pnlInspection.ResumeLayout(false);
            this.pnlPack.ResumeLayout(false);
            this.pnlExtra1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button btnstrt;
        private System.Windows.Forms.Button btnstop;
        private System.Windows.Forms.TextBox TxtPartCode;
        private System.Windows.Forms.TextBox txtPrinterPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Hardware;
        private System.Windows.Forms.TableLayoutPanel tblStatus;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Panel pnlRemaining;
        private System.Windows.Forms.Label lblCompletedMc;
        private System.Windows.Forms.Label lblRemainingTitle;
        private System.Windows.Forms.Panel pnlExtra1;
        private System.Windows.Forms.Label lblBanlmcCount;
        private System.Windows.Forms.Label lblExtra1Title;
        private System.Windows.Forms.Panel pnlPack;
        private System.Windows.Forms.Label lblMsterPrint;
        private System.Windows.Forms.Label lblPackTitle;
        private System.Windows.Forms.Panel pnlScan;
        private System.Windows.Forms.Label txtPlcTrigger;
        private System.Windows.Forms.Label lblScanTitle;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Label txtpacksize;
        private System.Windows.Forms.Label lblInnerTitle;
        private System.Windows.Forms.Panel pnlMaster;
        private System.Windows.Forms.Label txtScannedCount;
        private System.Windows.Forms.Label ScannedCount;
        private System.Windows.Forms.Panel pnlPLC;
        private System.Windows.Forms.Label txtbalanceIC;
        private System.Windows.Forms.Label lblPLCTitle;
        private System.Windows.Forms.Panel pnlNG;
        private System.Windows.Forms.Label lblNGCount;
        private System.Windows.Forms.Label lblNGTitle;
        private System.Windows.Forms.Panel pnlExtra2;
        private System.Windows.Forms.Label Icprintm;
        private System.Windows.Forms.Label IcPrint;
    }
}
