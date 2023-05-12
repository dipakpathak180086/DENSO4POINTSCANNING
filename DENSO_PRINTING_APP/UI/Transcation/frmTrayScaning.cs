﻿using DENSO_PRINTING_BL;
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dre = MessageBox.Show("Are you sure want to exit???", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dre == DialogResult.No)
            {
                return;
            }
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


                txtEmptyTray.Text = txtPacketQR.Text = txtLotNo.Text = txtFullTray.Text = txtTMName.Text = "";
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
                        _runingPart = dt.Rows[0]["RESULT"].ToString();
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
                        if (_runningOldPartNo == _runningNewPartNo)
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
        bool ValidatePartNoAndLot(string fullTray)
        {
            bool bReturn = false;
            try
            {
                _blObj = new BL_TRAY_LOADING();
                _plObj = new PL_TRAY_LOADING();
                _plObj.DbType = "VALIDATE_TRAY";
                _plObj.Line = GlobalVariable.mLine;
                _plObj.TrayEmp = txtEmptyTray.Text.Trim();
                _plObj.PacketQrCode = txtPacketQR.Text.Trim();
                _plObj.TrayFull = fullTray;
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
            txtPacketQR.Enabled = txtLotNo.Enabled = txtFullTray.Enabled = txtTMName.Enabled = false;
        }





        #endregion

        #region Label Event

        #endregion

        #region DataGridView Events


        #endregion

        #region TextBox Event
        private void txtEmptyTray_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C | e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
                return;
            }
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
            if (e.Control && (e.KeyCode == Keys.C | e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
                return;
            }
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
                        // chkSoolSelection.Checked = true;
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
        private void txtFeederPartNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C | e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtEmptyTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Old Part No can't be blank!!!", 2);
                        this.txtEmptyTray.SelectAll();
                        this.txtEmptyTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtPacketQR.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "New Part No can't be blank!!!", 2);
                        this.txtPacketQR.SelectAll();
                        this.txtPacketQR.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtFullTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Lot No can't be blank!!!", 2);
                        this.txtFullTray.SelectAll();
                        this.txtFullTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtLotNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Feeder Part No can't be blank!!!", 2);
                        this.txtLotNo.SelectAll();
                        this.txtLotNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    string sfeeder = txtLotNo.Text.Substring(1);
                    string sfeederNew = sfeeder.Replace("-", "");
                    sfeederNew = sfeederNew + " -";
                    if (!sfeeder.EndsWith("-"))
                    {
                        sfeeder = sfeeder + "-";
                    }
                    if (sfeeder == _runningOldPartNo || sfeederNew == _runningOldPartNo)
                    {
                        txtLotNo.Enabled = false;
                        //chkSpoolLoading.Checked = true;
                        txtTMName.Enabled = true;
                        txtTMName.Focus();
                    }
                    else
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Wrong Feeder Selected!!!", 2);
                        this.txtLotNo.SelectAll();
                        this.txtLotNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
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
                    if (txtLotNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Feeder Part No can't be blank!!!", 2);
                        this.txtLotNo.SelectAll();
                        this.txtLotNo.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtFullTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Lot No can't be blank!!!", 2);
                        this.txtFullTray.SelectAll();
                        this.txtFullTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtTMName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "TM can't be blank!!!", 2);
                        this.txtTMName.SelectAll();
                        this.txtTMName.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }

                    txtTMName.Enabled = false;





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

        private void txtFinalPart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C | e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    lblShowMessage();
                    if (txtEmptyTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Old Part No can't be blank!!!", 2);
                        this.txtEmptyTray.SelectAll();
                        this.txtEmptyTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtPacketQR.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "New Part No can't be blank!!!", 2);
                        this.txtEmptyTray.SelectAll();
                        this.txtEmptyTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtLotNo.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Feeder Part No can't be blank!!!", 2);
                        this.txtLotNo.SelectAll();
                        this.txtLotNo.Focus();

                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtFullTray.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "Lot No can't be blank!!!", 2);
                        this.txtFullTray.SelectAll();
                        this.txtFullTray.Focus();
                        PlayValidationSound();
                        ShowAccessScreen();
                        return;
                    }
                    if (txtTMName.Text.Length == 0)
                    {
                        GlobalVariable.MesseageInfo(lblMessage, "TM can't be blank!!!", 2);
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
                    //_plObj.OldPartNo = txtEmptyTray.Text.Trim();
                    //_plObj.NewPartNo = txtPacketQR.Text.Trim();
                    //_plObj.FeederPartNo = txtLotNo.Text.Trim();
                    //_plObj.Lot = txtFullTray.Text.Trim();
                    //_plObj.TMBarcode = txtTMName.Text.Trim();
                    //_plObj.FinalPartNo = txtFinalPart.Text.Trim();
                    //_plObj.CreatedBy = GlobalVariable.UserName;
                    //_plObj.SpoolType = GlobalVariable.mSpoolType;
                    //_plObj.Model = GlobalVariable.mModel;
                    //_plObj.PartNo = GlobalVariable.mPart;
                    DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                    if (dt.Rows.Count > 0)
                    {
                        BindView();
                        txtTMName.Enabled = false;
                        chkFirstTrayStaus.Checked = true;

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

        
    }
}
