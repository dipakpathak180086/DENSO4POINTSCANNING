using DENSO_PRINTING_BL;
using DENSO_PRINTING_COMMON;
using DENSO_PRINTING_PL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DENSO_PRINTING_APP
{
    public partial class frmLaserScaning : Form
    {

        #region Variables

        private BL_LASER_LOADING _blObj = null;
        private PL_LASER_LOADING _plObj = null;
        private Common _comObj = null;
        private string _runningOldPartNo = string.Empty;
        private string _runningNewPartNo = string.Empty;
        private string _runingPart = string.Empty;
        private DataTable dtBindGrid = new DataTable();
        #endregion

        #region Form Methods

        public frmLaserScaning()
        {
            try
            {
                InitializeComponent();

            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }

        private void frmModelMaster_Load(object sender, EventArgs e)
        {
            try
            {
                //  this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                DisableFields();
                BindView();
                txtChangeOverSheet.Focus();

            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }

        #endregion

        #region Button Event
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {

                Clear();


            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dre = MessageBox.Show("Are you sure want to exit???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dre == DialogResult.No)
            {
                return;
            }
            GlobalVariable.mIsDispose = false;
            this.Close();
        }

        #endregion

        #region Methods

        private void Clear()
        {
            try
            {
                _runningOldPartNo = "";
                lblMessage.BackColor = Color.Transparent;
                lblMessage.Text = "";
                this.lblReflectLabel.Location = new System.Drawing.Point(584, 161);
                this.lblReflectLabel.Size = new System.Drawing.Size(10, 28);
                lblDesiccatorLoaction.Text = lblPartCarryLocation.Text = "XXXXXXXXXXXXX";

                txtChangeOverSheet.Text = txtPacketQR.Text = txtPCBPartNo.Text = txtKanbanModel.Text = txtTMName.Text = "";
                chkFirstStaus.Checked = chkSecondStaus.Checked = false;
                chkFirstStaus.BackColor = chkSecondStaus.BackColor = Color.Yellow;
                DisableFields();
                txtChangeOverSheet.Focus();

            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }
        void BindView()
        {
            try
            {
                _blObj = new BL_LASER_LOADING();
                _plObj = new PL_LASER_LOADING();
                _plObj.DbType = "BIND_VIEW";
                _plObj.Line = GlobalVariable.mLine;
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt.DefaultView;
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        this.dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    }
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }
        void lblShowMessage(string msg = "", int ictr = -1)
        {
            if (ictr == 1)
            {
                lblMessage.BackColor = Color.LightGreen;
                lblMessage.Text = msg;
            }
            else if (ictr == 2)
            {
                lblMessage.BackColor = Color.Red;
                lblMessage.Text = msg;

            }
            else
            {
                lblMessage.BackColor = Color.Transparent;
                lblMessage.Text = msg;
            }
        }
        bool ValidateChangeOverSheet(string barcode)
        {
            bool bReturn = false;
            try
            {
                _blObj = new BL_LASER_LOADING();
                _plObj = new PL_LASER_LOADING();
                _plObj.DbType = "VALIDATE_CHANGE_OVER_SHEET";
                _plObj.ChangeOverSheet = barcode;
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName == "RESULT")
                    {
                        lblShowMessage(dt.Rows[0]["RESULT"].ToString(), 2);
                        PlayValidationSound();
                        ShowAccessScreen();
                        bReturn = false;
                    }
                    else
                    {
                        _runingPart = dt.Rows[0]["RunningModel"].ToString();
                        bReturn = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }

            return bReturn;

        }

        bool ValidateKanbanModel(string barcode)
        {
            bool bReturn = false;
            try
            {
                _blObj = new BL_LASER_LOADING();
                _plObj = new PL_LASER_LOADING();
                _plObj.DbType = "VALIDATE_KANBAN";
                _plObj.ChangeOverSheet = txtChangeOverSheet.Text.Trim();
                _plObj.KanbanModel = barcode;
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName == "RESULT")
                    {
                        lblShowMessage(dt.Rows[0]["RESULT"].ToString(), 2);
                        PlayValidationSound();
                        ShowAccessScreen();
                        bReturn = false;
                    }
                    else
                    {
                        lblPartCarryLocation.Text = dt.Rows[0]["PartCarryLocation"].ToString();
                        lblDesiccatorLoaction.Text = dt.Rows[0]["DesiccatorLocation"].ToString();
                        bReturn = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }

            return bReturn;

        }
        bool ValidatePacketQRCode(string packetQRCode)
        {
            bool bReturn = false;
            try
            {
                _blObj = new BL_LASER_LOADING();
                _plObj = new PL_LASER_LOADING();
                _plObj.DbType = "VALIDATE_PACKET_QR_CODE";
                _plObj.ChangeOverSheet = txtChangeOverSheet.Text.Trim();
                _plObj.KanbanModel = txtKanbanModel.Text.Trim();
                _plObj.PacketQrCode = packetQRCode;
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName == "RESULT")
                    {
                        lblShowMessage(dt.Rows[0]["RESULT"].ToString(), 2);
                        PlayValidationSound();
                        ShowAccessScreen();
                        bReturn = false;
                    }
                    else
                    {
                        bReturn = true;


                    }
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }

            return bReturn;

        }
        bool ValidatePCBPartNo(string pcbPart)
        {
            bool bReturn = false;
            try
            {
                _blObj = new BL_LASER_LOADING();
                _plObj = new PL_LASER_LOADING();
                _plObj.DbType = "VALIDATE_PCB_PART";
                _plObj.ChangeOverSheet = txtChangeOverSheet.Text.Trim();
                _plObj.KanbanModel = txtKanbanModel.Text.Trim();
                _plObj.PacketQrCode = txtPacketQR.Text.Trim();
                _plObj.PCBPartNo = pcbPart;
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName == "RESULT")
                    {
                        lblShowMessage(dt.Rows[0]["RESULT"].ToString(), 2);
                        PlayValidationSound();
                        ShowAccessScreen();
                        txtPCBPartNo.Text = "";
                        bReturn = false;
                    }
                    else
                    {
                        bReturn = true;

                    }
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }

            return bReturn;

        }
        void PlayValidationSound()
        {
            try
            {
                Application.DoEvents();
                SoundPlayer simpleSound = new SoundPlayer(Application.StartupPath + @"\Sound\Beep1.wav");
                simpleSound.Play();
                Thread.Sleep(3000);
                simpleSound.Stop();

            }
            catch (Exception)
            {

                throw;
            }
        }
        void ShowAccessScreen()
        {
            frmAccessPassword oFrmLogin = new frmAccessPassword();
            oFrmLogin.ShowDialog();
            if (GlobalVariable.mAccessUser != "" && oFrmLogin.IsCancel == true)
            {
                lblShowMessage();
            }
        }

        void DisableFields()
        {
            txtChangeOverSheet.Enabled = true;
            txtPacketQR.Enabled = txtPCBPartNo.Enabled = txtKanbanModel.Enabled = txtTMName.Enabled = false;
        }





        #endregion

        #region Label Event

        #endregion

        #region DataGridView Events


        #endregion

        #region TextBox Event
        private void txtChangeOverSheet_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && (e.KeyCode == Keys.C | e.KeyCode == Keys.V))
            //{
            //    e.SuppressKeyPress = true;
            //    return;
            //}
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    _runningOldPartNo = "";
                    lblShowMessage();
                    if (txtChangeOverSheet.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Change Over sheet can't be blank!!!", 2);
                        this.txtChangeOverSheet.SelectAll();
                        this.txtChangeOverSheet.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (ValidateChangeOverSheet(txtChangeOverSheet.Text.Trim()))
                    {
                        txtChangeOverSheet.Enabled = false;
                        txtKanbanModel.Enabled = true;
                        txtKanbanModel.Focus();
                    }
                    else
                    {
                        this.txtChangeOverSheet.SelectAll();
                        this.txtChangeOverSheet.Focus();
                    }


                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }
                finally
                {

                }
            }
        }

        private void txtKanbanModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtChangeOverSheet.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Change Over Sheet can't be blank!!!", 2);
                        this.txtChangeOverSheet.SelectAll();
                        this.txtChangeOverSheet.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtKanbanModel.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Kanban can't be blank!!!", 2);
                        this.txtKanbanModel.SelectAll();
                        this.txtKanbanModel.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (!txtKanbanModel.Text.Trim().Equals(_runingPart))
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Wrong Kanban Scanned with this change oversheet!!!", 2);
                        this.txtKanbanModel.SelectAll();
                        this.txtKanbanModel.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (ValidateKanbanModel(txtKanbanModel.Text.Trim()) )
                    {
                        txtKanbanModel.Enabled = false;
                        txtPacketQR.Enabled = true;
                        chkFirstStaus.Checked = true;
                        txtPacketQR.Focus();
                    }
                    else
                    {
                        this.txtKanbanModel.SelectAll();
                        this.txtKanbanModel.Focus();
                    }






                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }
                finally
                {

                }
            }
        }
        private void txtPacketQR_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && (e.KeyCode == Keys.C | e.KeyCode == Keys.V))
            //{
            //    e.SuppressKeyPress = true;
            //    return;
            //}
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtChangeOverSheet.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Change Over Sheet can't be blank!!!", 2);
                        this.txtChangeOverSheet.SelectAll();
                        this.txtChangeOverSheet.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtKanbanModel.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Kanban can't be blank!!!", 2);
                        this.txtKanbanModel.SelectAll();
                        this.txtKanbanModel.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtPacketQR.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Packet QR Code can't be blank!!!", 2);
                        this.txtPacketQR.SelectAll();
                        this.txtPacketQR.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (ValidatePacketQRCode(txtPacketQR.Text.Trim()))
                    {
                        txtPacketQR.Enabled = false;
                        txtPCBPartNo.Enabled = true;
                        txtPCBPartNo.Focus();
                    }
                    else
                    {
                        this.txtPacketQR.SelectAll();
                        this.txtPacketQR.Focus();
                    }


                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }
                finally
                {

                }
            }

        }
       
        private void txtPCBPartNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtChangeOverSheet.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Change Over Sheet can't be blank!!!", 2);
                        this.txtChangeOverSheet.SelectAll();
                        this.txtChangeOverSheet.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtPacketQR.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Packet QR Code can't be blank!!!", 2);
                        this.txtPacketQR.SelectAll();
                        this.txtPacketQR.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtKanbanModel.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Kanban can't be blank!!!", 2);
                        this.txtKanbanModel.SelectAll();
                        this.txtKanbanModel.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }

                    if (txtPCBPartNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Component Marking  can't be blank!!!", 2);
                        this.txtPCBPartNo.SelectAll();
                        this.txtPCBPartNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (ValidatePCBPartNo(txtPCBPartNo.Text.Trim()))
                    {
                        txtPCBPartNo.Enabled = false;
                        chkSecondStaus.Checked = true;
                        this.lblReflectLabel.Location = new System.Drawing.Point(204, 161);
                        this.lblReflectLabel.Size = new System.Drawing.Size(388, 28);
                        txtTMName.Enabled = true;
                        txtTMName.Focus();
                    }



                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }
                finally
                {

                }
            }
        }
        private void txtLotNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtChangeOverSheet.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Change Over Sheet can't be blank!!!", 2);
                        this.txtChangeOverSheet.SelectAll();
                        this.txtChangeOverSheet.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtPacketQR.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Packet QR Code can't be blank!!!", 2);
                        this.txtPacketQR.SelectAll();
                        this.txtPacketQR.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtKanbanModel.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Kanban can't be blank!!!", 2);
                        this.txtKanbanModel.SelectAll();
                        this.txtKanbanModel.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }

                    if (txtPCBPartNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Component Marking  can't be blank!!!", 2);
                        this.txtPCBPartNo.SelectAll();
                        this.txtPCBPartNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }

                    txtTMName.Enabled = true;
                    txtTMName.Focus();




                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }
                finally
                {

                }
            }
        }



        private void txtTMName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtChangeOverSheet.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Change Over Sheet can't be blank!!!", 2);
                        this.txtChangeOverSheet.SelectAll();
                        this.txtChangeOverSheet.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    
                    if (txtKanbanModel.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Kanban can't be blank!!!", 2);
                        this.txtKanbanModel.SelectAll();
                        this.txtKanbanModel.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtPacketQR.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Packet QR Code can't be blank!!!", 2);
                        this.txtPacketQR.SelectAll();
                        this.txtPacketQR.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtPCBPartNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Component Marking  can't be blank!!!", 2);
                        this.txtPCBPartNo.SelectAll();
                        this.txtPCBPartNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }

                    if (txtTMName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "TM Name can't be blank!!!", 2);
                        this.txtTMName.SelectAll();
                        this.txtTMName.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }

                    _blObj = new BL_LASER_LOADING();
                    _plObj = new PL_LASER_LOADING();
                    _plObj.DbType = "SAVE";
                    _plObj.Line = GlobalVariable.mLine;
                    _plObj.ChangeOverSheet = txtChangeOverSheet.Text.Trim();
                    _plObj.PacketQrCode = txtPacketQR.Text.Trim();
                    _plObj.KanbanModel = txtKanbanModel.Text.Trim();
                    _plObj.PCBPartNo = txtPCBPartNo.Text.Trim();
                    _plObj.DesiccatorLocation = lblDesiccatorLoaction.Text.Trim();
                    _plObj.PartCarryLocation = lblPartCarryLocation.Text.Trim();
                    _plObj.TMName = txtTMName.Text.Trim();
                    DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                    if (dt.Rows.Count > 0)
                    {
                        BindView();
                        txtTMName.Enabled = false;
                    }





                }
                catch (Exception ex)
                {

                    lblShowMessage(ex.Message, 2);
                }
                finally
                {

                }
            }
        }




        #endregion


        private void chkFirstTrayStaus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFirstStaus.Checked)
            {
                chkFirstStaus.BackColor = Color.Green;
            }
            else
            {
                chkFirstStaus.BackColor = Color.Yellow;
            }
        }



        private void chkSecondTrayStaus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSecondStaus.Checked)
            {
                chkSecondStaus.BackColor = Color.Green;
            }
            else
            {
                chkSecondStaus.BackColor = Color.Yellow;
            }
        }
    }
}
