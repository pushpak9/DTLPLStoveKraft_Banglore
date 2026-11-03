using DTPLLogs;
using iTextSharp.text.xml.simpleparser.handler;
using StockCraft.BusinessLayer;
using StockCraft.Forms.Masters;
using StockCraft.Forms.Report;

//using StockCraft.Forms.Report;
using StockCraft.Forms.Transaction;
using StockCraft.PL;
using StockCraft.Reports;

//using StockCraft.Reports;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace StockCraft
{
    public partial class MainWindow : Form
    {
        DataLayer.DL_UserLogin obj = new DataLayer.DL_UserLogin();
        static DataTable DTTEMP = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
            int x = (pnlHeader.Size.Width - lblHeader.Size.Width) / 2;
            lblHeader.Location = new Point(x, lblHeader.Location.Y);
            lblConnection.Text = "Database Name :  " + PCommon.sDbDataBaseName + ", Login User :  " + PCommon.UserName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void siteMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SiteMaster obj = new SiteMaster();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.BlanchedAlmond, ButtonBorderStyle.Solid);
            Panel panel = (Panel)sender;
            float width = (float)4.0;
            Pen pen = new Pen(SystemColors.ControlDark, width);
            pen.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(pen, 0, 0, 0, panel.Height - 0);
            e.Graphics.DrawLine(pen, 0, 0, panel.Width - 0, 0);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, 0, panel.Height - 1);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, panel.Width - 1, 0);
        }




        private void userMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

      

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                UserMasterModel plobj = new UserMasterModel();
                if (PCommon.UserType.ToUpper() != "ADMIN")
                {
                    userRightstoformDisable();
                    DataTable dt = new DataTable();
                    dt = obj.GetUserRights(PCommon.UserID);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int iCount = 0;
                            string strControlVal = dt.Rows[i].ItemArray[0].ToString();
                            foreach (ToolStripMenuItem item in menuStrip1.Items)
                            {
                                for (int k = 0; k < item.DropDown.Items.Count; k++)
                                {
                                    if (strControlVal.Trim().ToUpper() == item.DropDown.Items[k].Text.Trim().ToUpper())
                                    {
                                        item.DropDown.Items[k].Visible = true;
                                        iCount++;
                                        break;
                                    }
                                }
                                if (iCount == 1)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        blCommon.ShowMessage("You does not have right to access, Please contact to admin.", 3);
                        Application.Exit();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
        private void userRightstoformDisable()
        {
            try
            {
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    for (int k = 0; k < item.DropDown.Items.Count; k++)
                    {
                        item.DropDown.Items[k].Visible = false;
                        if (item.DropDown.Items[k].Text.ToUpper().Trim() == "CHANGE PASSWORD")
                        {
                            item.DropDown.Items[k].Visible = true;
                        }
                        if (item.DropDown.Items[k].Text.ToUpper().Trim() == "LOGOUT")
                        {
                            item.DropDown.Items[k].Visible = true;
                        }
                        if (item.DropDown.Items[k].Text.ToUpper().Trim() == "EXIT")
                        {
                            item.DropDown.Items[k].Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }        

        private void groupRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }




        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {

        }

        private void transactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void mastersToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void siteMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SiteMaster b2 = new SiteMaster();
                b2.ShowDialog();
        }

        private void userMasterToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            try
            {
                UserMaster obj = new UserMaster();
                obj.Show();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void groupRightsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                UserRight obj = new UserRight();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

      
 
   


     

    
        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemMaster B1 = new ItemMaster();
            B1.Show();
        }

        private void lineMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineMaster b1 = new LineMaster();
                b1.Show();
        }

        private void printerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterMaster b1 = new PrinterMaster();
            b1.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //WorkOrderInspection b1 = new WorkOrderInspection();
            //b1.Show();
            Inspection b1 = new Inspection();
            b1.Show();
        }

        private void iCREPRINTToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
            Reprinting b1 = new Reprinting();
                b1.Show();
        }

        private void mCREPRINTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReprintMC b1 = new ReprintMC();
            b1.Show();
        }

        private void childPrintReporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildPrintReport b1 = new ChildPrintReport();
            b1.Show();
        }

        private void mCPrintReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterPrintReport b1 = new MasterPrintReport();
                b1.ShowDialog();
        }

        private void inspectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report b1 = new Report();
                b1.Show();
        }

        private void latestScanReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LatestScanReport b1 = new LatestScanReport();
            b1.Show();
        }

        private void missingScanReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MissingScanReport b1 = new MissingScanReport();
            b1.Show();
        }
    }
}
