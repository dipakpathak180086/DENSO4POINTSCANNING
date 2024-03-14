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
    public partial class frmTrayScaning : Form
    {

        #region Variables

        private BL_TRAY_LOADING _blObj = null;
        private PL_TRAY_LOADING _plObj = null;
        private Common _comObj = null;
        private string _runningOldPartNo = string.Empty;
        private string _runningNewPartNo = string.Empty;
        private string _runingPart = string.Empty;
        private DataTable dtBindGrid = new DataTable();
        private bool IsCloseButtonFire = true;
        #endregion

        #region Form Methods

        public frmTrayScaning()
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



                txtEmptyTray.Focus();
                //dgv.Rows.Add(new object[] { "Line-04","3N1HA949532-4410 500","A949528-9860","A949528-9860","DIPAK PATHAK","A949528-9860"
                //    , "A949528-9860",true,true,true,"4-Mar-23","04:33:33" });
                //     dgv.Rows.Add(new object[] { "Line-04","3N1HA949532-4410 500","A949528-9860","A949528-9860","DIPAK PATHAK","A949528-9860"
                //    , "A949528-9860",true,true,true,"4-Mar-23","04:33:33" });
                //for (int i = 0; i < dgv.ColumnCount; i++)
                //{
                //    this.dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //    //this.dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //    //this.dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //}
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
        public bool CheckIfFormIsOpen(string formname)
        {



            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == formname);

            return formOpen;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dre = MessageBox.Show("Are you sure want to exit???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dre == DialogResult.No)
            {
                return;
            }
            IsCloseButtonFire = true;

            var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "frmMenu").FirstOrDefault();
            if (null != frm)
            {
                frm.Close();
                frm = null;
            }
            GlobalVariable.mIsDispose = true;
            frmMenu oFrm = new frmMenu();
            oFrm.Show();
            oFrm.FormClosing += OFrm_FormClosing;

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
                lblReflectLabel.Location = new System.Drawing.Point(578, 206);
                lblReflectLabel.Size = new System.Drawing.Size(10, 27);
                lblRunningPart.Text = "XXXXXXXXXXXXX";
                txtEmptyTray.Text = txtPacketQR.Text = txtPartNo.Text = txtCompMarking.Text = txtLotNo.Text = txtFullTray.Text = txtTMName.Text = "";
                chkFirstTrayStaus.Checked = chkSecondTrayStaus.Checked = false;
                chkFirstTrayStaus.BackColor = chkSecondTrayStaus.BackColor = Color.Yellow;
                DisableFields();
                txtEmptyTray.Focus();

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
                _blObj = new BL_TRAY_LOADING();
                _plObj = new PL_TRAY_LOADING();
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
        bool ValidateEmpTray(string tray)
        {
            bool bReturn = false;
            try
            {
                _blObj = new BL_TRAY_LOADING();
                _plObj = new PL_TRAY_LOADING();
                _plObj.DbType = "VALIDATE_TRAY";
                _plObj.TrayEmp = tray;
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
                        _runingPart = dt.Rows[0]["RUNNING_PART"].ToString();
                        lblRunningPart.Text = _runingPart;
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
                _blObj = new BL_TRAY_LOADING();
                _plObj = new PL_TRAY_LOADING();
                _plObj.DbType = "VALIDATE_PACKET_QR";
                _plObj.TrayEmp = txtEmptyTray.Text.Trim();
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
                        _runningNewPartNo = dt.Rows[0]["RUNNING_PART"].ToString();
                        if (_runingPart == _runningNewPartNo)
                        {
                            bReturn = true;
                        }
                        else
                        {
                            lblShowMessage("WRONG PART PICKUP!!!", 2);
                            PlayValidationSound();
                            ShowAccessScreen();
                            bReturn = false;
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                lblShowMessage(ex.Message, 2);
            }

            return bReturn;

        }
        bool ValidatePartNoAndLot(string lotNo)
        {
            bool bReturn = false;
            try
            {
                _blObj = new BL_TRAY_LOADING();
                _plObj = new PL_TRAY_LOADING();
                _plObj.DbType = "VALIDATE_LOT";
                _plObj.Line = GlobalVariable.mLine;
                _plObj.PartNo = txtPartNo.Text.Trim();
                _plObj.LotNo = lotNo;
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
                        // _runningPartNo = dt.Rows[0]["RUNNING_PART"].ToString();

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
        bool ValidatePacketComponentMakring(string component)
        {
            bool bReturn = false;
            try
            {
                _blObj = new BL_TRAY_LOADING();
                _plObj = new PL_TRAY_LOADING();
                _plObj.DbType = "VALIDATE_COMP_MARKING";
                _plObj.TrayEmp = txtEmptyTray.Text.Trim();
                _plObj.PartNo = txtPartNo.Text.Trim();
                _plObj.PacketQrCode = txtPacketQR.Text.Trim();
                _plObj.CompMarking = component;
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName == "RESULT")
                    {
                        lblShowMessage(dt.Rows[0]["RESULT"].ToString(), 2);
                        PlayValidationSound();
                        ShowAccessScreen();
                        txtCompMarking.Text = "";
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
            txtEmptyTray.Enabled = true;
            txtPacketQR.Enabled = txtCompMarking.Enabled = txtPartNo.Enabled = txtLotNo.Enabled = txtFullTray.Enabled = txtTMName.Enabled = false;
        }





        #endregion

        #region Label Event

        #endregion

        #region DataGridView Events


        #endregion

        #region TextBox Event
        private void txtEmptyTray_KeyDown(object sender, KeyEventArgs e)
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
                    if (txtEmptyTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Empty Tray can't be blank!!!", 2);
                        this.txtEmptyTray.SelectAll();
                        this.txtEmptyTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (ValidateEmpTray(txtEmptyTray.Text.Trim()))
                    {


                        txtEmptyTray.Enabled = false;
                        txtPacketQR.Enabled = true;
                        txtPacketQR.Focus();
                    }
                    else
                    {
                        this.txtEmptyTray.SelectAll();
                        this.txtEmptyTray.Focus();
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
                    if (txtEmptyTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Empaty Tray can't be blank!!!", 2);
                        this.txtEmptyTray.SelectAll();
                        this.txtEmptyTray.Focus();
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
                        chkFirstTrayStaus.Checked = true;
                        txtFullTray.Enabled = true;
                        txtFullTray.Focus();
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
        private void txtFullTray_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtEmptyTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Empaty Tray can't be blank!!!", 2);
                        this.txtEmptyTray.SelectAll();
                        this.txtEmptyTray.Focus();
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
                    if (txtFullTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Full Tray can't be blank!!!", 2);
                        this.txtFullTray.SelectAll();
                        this.txtFullTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (!txtEmptyTray.Text.Trim().Equals(txtFullTray.Text.Trim()))
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Empty Tray and Full Tray should be same!!!", 2);
                        this.txtFullTray.SelectAll();
                        this.txtFullTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }

                    txtFullTray.Enabled = false;
                    txtPartNo.Enabled = true;
                    txtPartNo.Focus();




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
        private void txtPartNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtEmptyTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Empaty Tray can't be blank!!!", 2);
                        this.txtEmptyTray.SelectAll();
                        this.txtEmptyTray.Focus();
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
                    if (txtFullTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Full Tray can't be blank!!!", 2);
                        this.txtFullTray.SelectAll();
                        this.txtFullTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtPartNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "IC/BGA Part No can't be blank!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (!txtPartNo.Text.Trim().Equals(lblRunningPart.Text.Trim()))
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Enter IC/BGA Part and Running Part should be same!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }


                    txtPartNo.Enabled = false;
                    txtCompMarking.Enabled = true;
                    txtCompMarking.Focus();




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
        private void txtCompMarking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtEmptyTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Empaty Tray can't be blank!!!", 2);
                        this.txtEmptyTray.SelectAll();
                        this.txtEmptyTray.Focus();
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
                    if (txtFullTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Full Tray can't be blank!!!", 2);
                        this.txtFullTray.SelectAll();
                        this.txtFullTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtPartNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "IC/BGA Part No can't be blank!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (!txtPartNo.Text.Trim().Equals(lblRunningPart.Text.Trim()))
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Enter IC/BGA Part and Running Part should be same!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtCompMarking.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Component Marking  can't be blank!!!", 2);
                        this.txtCompMarking.SelectAll();
                        this.txtCompMarking.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (ValidatePacketComponentMakring(txtCompMarking.Text.Trim()))
                    {
                        txtCompMarking.Enabled = false;
                        chkSecondTrayStaus.Checked = true;
                        lblReflectLabel.Location = new System.Drawing.Point(169, 206);
                        lblReflectLabel.Size = new System.Drawing.Size(419, 27);
                        txtLotNo.Enabled = true;
                        txtLotNo.Focus();
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
                    if (txtEmptyTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Empaty Tray can't be blank!!!", 2);
                        this.txtEmptyTray.SelectAll();
                        this.txtEmptyTray.Focus();
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
                    if (txtFullTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Full Tray can't be blank!!!", 2);
                        this.txtFullTray.SelectAll();
                        this.txtFullTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtPartNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "IC/BGA Part No can't be blank!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }

                    if (!txtPartNo.Text.Trim().Equals(lblRunningPart.Text.Trim()))
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Enter IC/BGA Part and Running Part should be same!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtCompMarking.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Component Marking  can't be blank!!!", 2);
                        this.txtCompMarking.SelectAll();
                        this.txtCompMarking.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtLotNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Lot No.  can't be blank!!!", 2);
                        this.txtLotNo.SelectAll();
                        this.txtLotNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (!ValidatePartNoAndLot(txtLotNo.Text.Trim()))
                    {
                        this.txtLotNo.SelectAll();
                        this.txtLotNo.Focus();
                        return;
                    }

                    txtLotNo.Enabled = false;
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
                    if (txtEmptyTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Empaty Tray can't be blank!!!", 2);
                        this.txtEmptyTray.SelectAll();
                        this.txtEmptyTray.Focus();
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
                    if (txtFullTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Full Tray can't be blank!!!", 2);
                        this.txtFullTray.SelectAll();
                        this.txtFullTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtPartNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "IC/BGA Part No can't be blank!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }

                    if (!txtPartNo.Text.Trim().Equals(lblRunningPart.Text.Trim()))
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Enter IC/BGA Part and Running Part should be same!!!", 2);
                        this.txtPartNo.SelectAll();
                        this.txtPartNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtCompMarking.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Component Marking  can't be blank!!!", 2);
                        this.txtCompMarking.SelectAll();
                        this.txtCompMarking.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtLotNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Component Marking  can't be blank!!!", 2);
                        this.txtLotNo.SelectAll();
                        this.txtLotNo.Focus();
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

                    _blObj = new BL_TRAY_LOADING();
                    _plObj = new PL_TRAY_LOADING();
                    _plObj.DbType = "SAVE";
                    _plObj.Line = GlobalVariable.mLine;
                    _plObj.TrayEmp = txtEmptyTray.Text.Trim();
                    _plObj.PacketQrCode = txtPacketQR.Text.Trim();
                    _plObj.TrayFull = txtFullTray.Text.Trim();
                    _plObj.PartNo = txtPartNo.Text.Trim();
                    _plObj.CompMarking = txtCompMarking.Text.Trim();
                    _plObj.LotNo = txtLotNo.Text.Trim();
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
            if (chkFirstTrayStaus.Checked)
            {
                chkFirstTrayStaus.BackColor = Color.Green;
            }
            else
            {
                chkFirstTrayStaus.BackColor = Color.Yellow;
            }
        }



        private void chkSecondTrayStaus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSecondTrayStaus.Checked)
            {
                chkSecondTrayStaus.BackColor = Color.Green;
            }
            else
            {
                chkSecondTrayStaus.BackColor = Color.Yellow;
            }
        }

        private void btnSpoolLoading_Click(object sender, EventArgs e)
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
        private void OFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsCloseButtonFire)
                this.Show();
        }
        private void lblFront_Click(object sender, EventArgs e)
        {
            btnFront_Click(sender, e);
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            btnBack_Click(sender, e);
        }
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            pnlSpoolScanning.Visible = false;
        }
    }
}
