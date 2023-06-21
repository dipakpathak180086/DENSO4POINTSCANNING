using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using DENSO_PRINTING_COMMON;
using DENSO_PRINTING_BL;
using DENSO_PRINTING_PL;
using DENSO_PRINTING_PL;
using DENSO_PRINTING_BL;

namespace DENSO_PRINTING_APP
{
    public partial class frmMenu : Form
    {
        #region Variables




        #endregion

        #region Form Methods

        public frmMenu()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

            }
        }
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                cp.ClassStyle |= 0x08;
                return cp;
            }
        }
        private void frmModelMaster_Load(object sender, EventArgs e)
        {
            try
            {
                // this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                //this.Bounds = Screen.PrimaryScreen.Bounds;
                //this.TopMost = true;
                SetMenuRight();
                lblWelcome.Text = "Hi! " + GlobalVariable.mSatoAppsLoginUser;
                Left = Top = 0;
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Height = Screen.PrimaryScreen.WorkingArea.Height;
                //AutoLogOut timer
                tbReport.SelectedIndex = 1;

            }
            catch (Exception ex)
            {

            }
        }

        private void OFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        #endregion

        #region Button Event

        private void picLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Menu Click Events
        private void picChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword oFrm = new frmChangePassword();
            oFrm.ShowDialog();

        }
        private void picUserMaster_Click(object sender, EventArgs e)
        {
            frmUserMaster frm = new frmUserMaster();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }
        private void picGroupMaster_Click(object sender, EventArgs e)
        {
            frmGroupMaster frm = new frmGroupMaster();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }



        private void picLabelPrinting_Click(object sender, EventArgs e)
        {
            frmSpoolingScaning frm = new frmSpoolingScaning();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }

        private void picPathMaster_Click(object sender, EventArgs e)
        {
            frmImportDataMaster frm = new frmImportDataMaster();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }
        private void picLine4Scanning_Click(object sender, EventArgs e)
        {
            try
            {
                Common common = new Common();
                DataTable dt = common.GetModel();
                if (dt.Rows.Count > 0)
                {
                    GlobalVariable.BindCombo(cbSelectModel, dt);
                }
                if (cbSelectModel.SelectedIndex > 0) { cbSelectModel.SelectedIndex = 0; }
                if (cbPartNo.SelectedIndex > 0) { cbPartNo.SelectedIndex = 0; }
                pnlSpoolScanning.Visible = true;
                lblBack.ForeColor = lblFront.ForeColor = Color.WhiteSmoke;
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }

        }
        private void picLineMaster_Click(object sender, EventArgs e)
        {
            frmLineMaster frm = new frmLineMaster();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }
        private void picNGMaster_Click(object sender, EventArgs e)
        {
            frmNGMaster frm = new frmNGMaster();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }
        private void btnFront_Click(object sender, EventArgs e)
        {
            if (cbSelectModel.SelectedIndex <= 0)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox("Model Selection Failed!!!", "Select Model!!!", 2);
                this.cbSelectModel.Focus();
                return;
            }
            if (cbPartNo.SelectedIndex <= 0)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox("Part Selection Failed!!!", "Select Part!!!", 2);
                this.cbPartNo.Focus();
                return;
            }
            GlobalVariable.mSpoolType = "FRONT";
            GlobalVariable.mModel = cbSelectModel.Text.Trim();
            GlobalVariable.mPart = cbPartNo.Text.Trim();
            pnlSpoolScanning.Visible = false;
            if (cbSelectModel.SelectedIndex > 0) { cbSelectModel.SelectedIndex = 0; }
            if (cbPartNo.SelectedIndex > 0) { cbPartNo.SelectedIndex = 0; }
            frmSpoolingScaning frm = new frmSpoolingScaning();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (cbSelectModel.SelectedIndex <= 0)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox("Model Selection Failed!!!", "Select Model!!!", 2);
                this.cbSelectModel.Focus();
                return;
            }
            if (cbPartNo.SelectedIndex <= 0)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox("Part Selection Failed!!!", "Select Part!!!", 2);
                this.cbPartNo.Focus();
                return;
            }
            GlobalVariable.mSpoolType = "BACK";
            GlobalVariable.mModel = cbSelectModel.Text.Trim();
            GlobalVariable.mPart = cbPartNo.Text.Trim();
            pnlSpoolScanning.Visible = false;
            if (cbSelectModel.SelectedIndex > 0) { cbSelectModel.SelectedIndex = 0; }
            if (cbPartNo.SelectedIndex > 0) { cbPartNo.SelectedIndex = 0; }
            frmSpoolingScaning frm = new frmSpoolingScaning();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }
        private void picSpoolingReport_Click(object sender, EventArgs e)
        {
            frmSpoolingReport frm = new frmSpoolingReport();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }
        private void lblFront_Click(object sender, EventArgs e)
        {
            btnFront_Click(sender, e);
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            btnBack_Click(sender, e);
        }
        private void picImportTrayMaster_Click(object sender, EventArgs e)
        {
            frmImportTrayDataMaster frm = new frmImportTrayDataMaster();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }
        private void picTrayLoading_Click(object sender, EventArgs e)
        {
            frmTrayScaning frm = new frmTrayScaning();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }
        private void picTrayLoadingReport_Click(object sender, EventArgs e)
        {
            frmTrayLoadingReport frm = new frmTrayLoadingReport();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();

        }

        private void picLaserScanning_Click(object sender, EventArgs e)
        {
            frmLaserScaning frm = new frmLaserScaning();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }
        private void picImportLaserMaster_Click(object sender, EventArgs e)
        {
            frmImportLaserDataMaster frm = new frmImportLaserDataMaster();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();

        }
        private void picHardwareScanning_Click(object sender, EventArgs e)
        {
            frmHardwareScaning frm = new frmHardwareScaning();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();

        }
        private void picLaserLoadingReport_Click(object sender, EventArgs e)
        {
            frmLaserReport frm = new frmLaserReport();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();

        }

        private void picHarwareLoadingReport_Click(object sender, EventArgs e)
        {
            frmHardwareReport frm = new frmHardwareReport();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();


        }
        #endregion

        #region Method

        private void SetMenuRight()
        {
            try
            {
                DataTable dt;
                PL_GROUP_MASTER _plObj = new PL_GROUP_MASTER();
                BL_GROUP_MASTER _blObj = new BL_GROUP_MASTER();
                _plObj.DbType = "GET_USER_RIGHTS";
                _plObj.GroupName = GlobalVariable.UserGroup;
                if (GlobalVariable.UserGroup == "ADMIN")
                {
                    dt = _blObj.BL_ExecuteTask(_plObj);
                }
                else
                    dt = _blObj.BL_ExecuteTask(_plObj);

                foreach (DataRow row in dt.Rows)
                {
                    switch (row["ModuleId"].ToString())
                    {
                        case "101":
                            picGroupMaster.Enabled = true;
                            lblGroupMaster.Enabled = true;
                            break;
                        case "102":
                            picUserMaster.Enabled = true;
                            lblUserMaster.Enabled = true;
                            break;

                        case "103":
                            picImportMaster.Enabled = true;
                            lblImportMaster.Enabled = true;
                            break;
                        case "104":
                            picLineMaster.Enabled = true;
                            lblLineMaster.Enabled = true;
                            break;
                        case "105":
                            picNGMaster.Enabled = true;
                            lblNGMaster.Enabled = true;
                            break;

                        case "106":
                            picImportTrayMaster.Enabled = true;
                            lblImportTrayMaster.Enabled = true;
                            break;
                        case "107":
                            picImportLaserMaster.Enabled = true;
                            lblImportLaserMaster.Enabled = true;
                            break;
                        case "201":

                            picScanning.Enabled = true;
                            lblScanning.Enabled = true;
                            break;
                        case "202":

                            picTrayLoading.Enabled = true;
                            lblTrayLoading.Enabled = true;
                            break;
                        case "203":

                            picLaserScanning.Enabled = true;
                            lblLaserScanning.Enabled = true;
                            break;
                        case "204":

                            picHardwareScanning.Enabled = true;
                            lblHardwareScanning.Enabled = true;
                            break;
                        case "301":

                            picSpoolingReport.Enabled = true;
                            lblSpoolingReport.Enabled = true;
                            break;
                        case "302":

                            picTrayLoadingReport.Enabled = true;
                            lblTrayLoadingReport.Enabled = true;
                            break;
                        case "303":

                            picLaserLoadingReport.Enabled = true;
                            lblLaserLoadingReport.Enabled = true;
                            break;
                        case "304":

                            picHarwareLoadingReport.Enabled = true;
                            lblHardwareLoadingReport.Enabled = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        #endregion

        #region Timer Event
        private void timerAutoLogOut_Tick(object sender, EventArgs e)
        {

        }

        private void timerReOiling_Tick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }































        #endregion

        private void cbSelectModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSelectModel.SelectedIndex > 0)
                {
                    Common common = new Common();
                    DataTable dt = common.GetPart(cbSelectModel.SelectedValue.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        GlobalVariable.BindCombo(cbPartNo, dt);
                    }

                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void cbPartNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.mStoCustomFunction.AutoCompleteCombo(cbPartNo, e);
        }

        private void pnlSpoolScanning_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            pnlSpoolScanning.Visible = false;
        }

        
    }
}
