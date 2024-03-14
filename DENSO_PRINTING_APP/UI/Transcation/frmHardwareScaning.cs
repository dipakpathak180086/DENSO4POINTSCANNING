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
    public partial class frmHardwareScaning : Form
    {

        #region Variables

        private BL_HARDWAR_LOADING _blObj = null;
        private PL_HARDWARE_LOADING _plObj = null;
        private Common _comObj = null;
        private string _runningCS = string.Empty;
        private string _runningNRC = string.Empty;
        private string _runningKC = string.Empty;
        private string _runningHC = string.Empty;
        private DataTable dtBindGrid = new DataTable();
        #endregion

        #region Form Methods

        public frmHardwareScaning()
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
                DialogResult dre = MessageBox.Show("Are you sure want to next loading???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dre == DialogResult.No)
                {
                    return;
                }

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

                lblMessage.BackColor = Color.Transparent;
                lblMessage.Text = "";
                _runningCS = string.Empty;
                _runningNRC = string.Empty;
                _runningKC = string.Empty;
                _runningHC = string.Empty;
                txtChangeOverSheet.Text = txtRunningTagSecond.Text = txtKanbanQRCode.Text = txtProductQRCode.Text = txtRunningTagFirst.Text = txtTMName.Text = "";
                chkFirstStaus.Checked = chkThirdStatus.Checked = chkFourthStatus.Checked = chkSecondStaus.Checked = false;
                chkFirstStaus.BackColor = chkSecondStaus.BackColor = chkThirdStatus.BackColor = chkFourthStatus.BackColor = Color.Yellow;
                DisableFields();
               
                txtChangeOverSheet.Focus();

            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }
        private void TempClear()
        {
            try
            {

                lblMessage.BackColor = Color.Transparent;
                lblMessage.Text = "";
                _runningNRC = string.Empty;
                _runningKC = string.Empty;
                _runningHC = string.Empty;
                txtRunningTagSecond.Text = txtKanbanQRCode.Text = txtProductQRCode.Text = txtTMName.Text = "";
                chkThirdStatus.Checked = chkFourthStatus.Checked = chkSecondStaus.Checked = false;
                chkSecondStaus.BackColor = chkThirdStatus.BackColor = chkFourthStatus.BackColor = Color.Yellow;
                txtRunningTagSecond.Enabled = true;
                txtChangeOverSheet.Enabled = txtRunningTagFirst.Enabled = false;
                txtRunningTagSecond.Focus();

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
                _blObj = new BL_HARDWAR_LOADING();
                _plObj = new PL_HARDWARE_LOADING();
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
                if (barcode.Length < 19)
                {
                    lblShowMessage("Wrong Change Over Sheet!!", 2);
                    PlayValidationSound();
                    ShowAccessScreen();
                    bReturn = false;
                }
                else
                {
                    _runningCS = "";
                    _runningCS = GlobalVariable.strRight(GlobalVariable.strLeft(barcode, 19), 9);
                    _runningCS += "X";
                    bReturn = true;
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }

            return bReturn;

        }

        bool ValidateFirstRunningTag(string barcode)
        {
            bool bReturn = false;
            try
            {
                if (!_runningCS.Equals(barcode))
                {
                    lblShowMessage("Wrong Running Tag!!", 2);
                    PlayValidationSound();
                    ShowAccessScreen();
                    bReturn = false;
                }
                else
                {
                    //_runningCS = "";
                    //_runningCS = GlobalVariable.strRight(GlobalVariable.strLeft(barcode, 19), 9);
                    //_runningCS += "X";
                    bReturn = true;
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }

            return bReturn;

        }
        bool ValidateSecondRunningTag(string barcode)
        {
            bool bReturn = false;
            try
            {
                if (!_runningCS.Equals(barcode))
                {
                    lblShowMessage("Wrong Running Tag!!", 2);
                    PlayValidationSound();
                    ShowAccessScreen();
                    bReturn = false;
                }
                else
                {
                    _runningNRC = "";
                    _runningNRC = GlobalVariable.strRight(barcode, 4);
                    //_runningNRC += "X";
                    bReturn = true;
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }

            return bReturn;

        }
        bool ValidateKanbanQRCode(string barcode)
        {
            bool bReturn = false;
            try
            {
                if (!_runningCS.Equals(barcode))
                {
                    lblShowMessage("Wrong Kanban QR Code!!", 2);
                    PlayValidationSound();
                    ShowAccessScreen();
                    bReturn = false;
                }
                else
                {
                    _runningKC = GlobalVariable.strRight(barcode, 4) + "X";
                    bReturn = true;
                }

            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }

            return bReturn;

        }
        bool ValidateProductQRCode(string barcode)
        {
            bool bReturn = false;
            try
            {
                if (barcode.Length < 9)
                {
                    lblShowMessage("Wrong Product QR Code!!", 2);
                    PlayValidationSound();
                    ShowAccessScreen();
                    bReturn = false;
                }
                else
                {
                    _runningHC = "";
                    _runningHC = GlobalVariable.strRight(GlobalVariable.strLeft(barcode, 9), 3);
                    _runningHC += "X";
                    if (_runningHC != _runningKC)
                    {
                        lblShowMessage("Wrong Product QR Code!!", 2);
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
            txtRunningTagSecond.Enabled =txtProductQRCode.Enabled=txtKanbanQRCode.Enabled= txtRunningTagFirst.Enabled = txtTMName.Enabled = false;
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
                        txtRunningTagFirst.Enabled = true;
                        txtRunningTagFirst.Focus();
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

        private void txtRunningTagFirst_KeyDown(object sender, KeyEventArgs e)
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
                    if (txtRunningTagFirst.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Running Tag can't be blank!!!", 2);
                        this.txtRunningTagFirst.SelectAll();
                        this.txtRunningTagFirst.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (!txtRunningTagFirst.Text.Trim().Equals(_runningCS))
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Wrong Tag Scanned with this change oversheet!!!", 2);
                        this.txtRunningTagFirst.SelectAll();
                        this.txtRunningTagFirst.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (ValidateFirstRunningTag(txtRunningTagFirst.Text.Trim()))
                    {
                        txtRunningTagFirst.Enabled = false;
                        txtRunningTagSecond.Enabled = true;
                        chkFirstStaus.Checked = true;
                        txtRunningTagSecond.Focus();
                    }
                    else
                    {
                        this.txtRunningTagFirst.SelectAll();
                        this.txtRunningTagFirst.Focus();
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
        private void txtRunningTagSecond_KeyDown(object sender, KeyEventArgs e)
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
                    if (txtRunningTagFirst.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Running Tag can't be blank!!!", 2);
                        this.txtRunningTagFirst.SelectAll();
                        this.txtRunningTagFirst.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtRunningTagSecond.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Running Tag can't be blank!!!", 2);
                        this.txtRunningTagSecond.SelectAll();
                        this.txtRunningTagSecond.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (ValidateSecondRunningTag(txtRunningTagSecond.Text.Trim()))
                    {
                        txtRunningTagSecond.Enabled = false;
                        txtKanbanQRCode.Enabled = true;
                        txtKanbanQRCode.Focus();
                    }
                    else
                    {
                        this.txtRunningTagSecond.SelectAll();
                        this.txtRunningTagSecond.Focus();
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
        private void txtKanbanQRCode_KeyDown(object sender, KeyEventArgs e)
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
                    if (txtRunningTagFirst.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Running Tag can't be blank!!!", 2);
                        this.txtRunningTagFirst.SelectAll();
                        this.txtRunningTagFirst.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtRunningTagSecond.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Running Tag can't be blank!!!", 2);
                        this.txtRunningTagSecond.SelectAll();
                        this.txtRunningTagSecond.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtKanbanQRCode.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Kanban QR can't be blank!!!", 2);
                        this.txtKanbanQRCode.SelectAll();
                        this.txtKanbanQRCode.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtRunningTagSecond.Text.Trim().Equals(txtKanbanQRCode.Text.Trim()))
                    {
                        _runningKC = GlobalVariable.strRight(txtKanbanQRCode.Text.Trim(), 4);
                        chkSecondStaus.Checked = true;
                        txtKanbanQRCode.Enabled = false;
                        txtProductQRCode.Enabled = true;
                        txtProductQRCode.Focus();
                    }
                    else
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Wrong Kanban QR Scanned!!!", 2);
                        this.txtKanbanQRCode.SelectAll();
                        this.txtKanbanQRCode.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
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

        private void txtProductQRCode_KeyDown(object sender, KeyEventArgs e)
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
                    if (txtRunningTagFirst.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Running Tag can't be blank!!!", 2);
                        this.txtRunningTagFirst.SelectAll();
                        this.txtRunningTagFirst.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtRunningTagSecond.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Running Tag can't be blank!!!", 2);
                        this.txtRunningTagSecond.SelectAll();
                        this.txtRunningTagSecond.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtKanbanQRCode.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Kanban QR can't be blank!!!", 2);
                        this.txtKanbanQRCode.SelectAll();
                        this.txtKanbanQRCode.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtProductQRCode.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Product QR can't be blank!!!", 2);
                        this.txtProductQRCode.SelectAll();
                        this.txtProductQRCode.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (ValidateProductQRCode(txtProductQRCode.Text.Trim()))
                    {
                        chkThirdStatus.Checked = true;
                        chkFourthStatus.Checked = true;
                        txtProductQRCode.Enabled = false;
                        txtTMName.Enabled = true;
                        txtTMName.Focus();
                    }
                    else
                    {
                        this.txtProductQRCode.SelectAll();
                        this.txtProductQRCode.Focus();

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
                    if (txtRunningTagFirst.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Running Tag can't be blank!!!", 2);
                        this.txtRunningTagFirst.SelectAll();
                        this.txtRunningTagFirst.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtRunningTagSecond.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Running Tag can't be blank!!!", 2);
                        this.txtRunningTagSecond.SelectAll();
                        this.txtRunningTagSecond.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtKanbanQRCode.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Kanban QR can't be blank!!!", 2);
                        this.txtKanbanQRCode.SelectAll();
                        this.txtKanbanQRCode.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtProductQRCode.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Product QR can't be blank!!!", 2);
                        this.txtProductQRCode.SelectAll();
                        this.txtProductQRCode.Focus();
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

                    _blObj = new BL_HARDWAR_LOADING();
                    _plObj = new PL_HARDWARE_LOADING();
                    _plObj.DbType = "SAVE";
                    _plObj.Line = GlobalVariable.mLine;
                    _plObj.ChangeOverSheet = txtChangeOverSheet.Text.Trim();
                    _plObj.CS = _runningCS;
                    _plObj.RunningFirstTag = txtRunningTagFirst.Text.Trim();
                    _plObj.RunningSecondTag = txtRunningTagSecond.Text.Trim();
                    _plObj.NRC = _runningNRC;
                    _plObj.KanbanQRCode = txtKanbanQRCode.Text.Trim();
                    _plObj.KC = _runningKC;
                    _plObj.PRD_QR_Code = txtProductQRCode.Text.Trim();
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

        private void btnCurrentReset_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dre = MessageBox.Show("Are you sure want to start current loading???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dre == DialogResult.No)
                {
                    return;
                }
                TempClear();
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }
        }

        private void chkThirdStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThirdStatus.Checked)
            {
                chkThirdStatus.BackColor = Color.Green;
            }
            else
            {
                chkThirdStatus.BackColor = Color.Yellow;
            }
        }

        private void chkFourthStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFourthStatus.Checked)
            {
                chkFourthStatus.BackColor = Color.Green;
            }
            else
            {
                chkFourthStatus.BackColor = Color.Yellow;
            }
        }
    }
}
