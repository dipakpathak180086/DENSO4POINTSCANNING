using DENSO_PRINTING_BL;
using DENSO_PRINTING_COMMON;
using DENSO_PRINTING_PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DENSO_PRINTING_APP
{
    public partial class frmTrayLoadingReport : Form
    {

        #region Variables

        private BL_TRAY_LOADING_REPORT _blObj = null;
        private PL_TRAY_LOADING_REPORT _plObj = null;
        private Common _comObj = null;
        private string _packType = string.Empty;
        private DataTable dtBindGrid = new DataTable();
        #endregion

        #region Form Methods

        public frmTrayLoadingReport()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_TRAY_LOADING_REPORT();
                _plObj = new PL_TRAY_LOADING_REPORT();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void frmReprinting_Load(object sender, EventArgs e)
        {
            try
            {
                //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                BindLine();

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
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
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {


                _plObj = new PL_TRAY_LOADING_REPORT();
                _plObj.DbType = "SHOW";
                _plObj.FromDate = dpFromDate.Value.ToString("yyyy-MM-dd");
                _plObj.ToDate = dpToDate.Value.ToString("yyyy-MM-dd");
                _plObj.Line = cbLine.Text.Trim();
                _plObj.PartNo = cbPartNo.Text.Trim();
                _plObj.Lot = cbLotNo.Text.Trim();
                _plObj.TMName = cbTMUser.Text.Trim();
                DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
                if (dataTable.Rows.Count > 0)
                {
                    dgv.DataSource = dataTable.DefaultView;
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "No Data Found !!!", 2);
                    for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                    {
                        dgv.Rows.RemoveAt(i);
                    }
                }



            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVariable.mIsDispose = false;
            this.Close();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            GlobalVariable.ExportInCSV(dgv);
        }
        #endregion

        #region Methods


        private void Clear()
        {
            try
            {
                for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                {
                    dgv.Rows.RemoveAt(i);
                }
                dpFromDate.Value = dpFromDate.Value = DateTime.Now;
                if (cbLine.SelectedIndex > 0)
                {
                    cbLine.SelectedIndex = 0;
                }
               
                if (cbPartNo.SelectedIndex > 0)
                {
                    cbPartNo.SelectedIndex = 0;
                }
               
                if (cbLotNo.SelectedIndex > 0)
                {
                    cbLotNo.SelectedIndex = 0;
                }
                if (cbTMUser.SelectedIndex > 0)
                {
                    cbTMUser.SelectedIndex = 0;
                }
                
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void BindLine()
        {
            try
            {
                _plObj = new PL_TRAY_LOADING_REPORT();
                _blObj = new BL_TRAY_LOADING_REPORT();
                _plObj.DbType = "BIND_LINE";
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    GlobalVariable.BindCombo(cbLine, dt);
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
  
        private void BindPartNo()
        {
            try
            {
                _plObj = new PL_TRAY_LOADING_REPORT();
                _blObj = new BL_TRAY_LOADING_REPORT();
                _plObj.DbType = "BIND_PART";
                _plObj.Line = cbLine.Text.Trim();
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    GlobalVariable.BindCombo(cbPartNo, dt);
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
       
        private void BindLotNo()
        {
            try
            {
                _plObj = new PL_TRAY_LOADING_REPORT();
                _blObj = new BL_TRAY_LOADING_REPORT();
                _plObj.DbType = "BIND_LOT";
                _plObj.Line = cbLine.Text.Trim();
                _plObj.PartNo = cbPartNo.Text.Trim();
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    GlobalVariable.BindCombo(cbLotNo, dt);
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void BindTMUser()
        {
            try
            {
                _plObj = new PL_TRAY_LOADING_REPORT();
                _blObj = new BL_TRAY_LOADING_REPORT();
                _plObj.DbType = "BIND_USER";
                _plObj.Line = cbLine.Text.Trim();
                _plObj.PartNo = cbPartNo.Text.Trim();
                _plObj.Lot = cbLotNo.Text.Trim();
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    GlobalVariable.BindCombo(cbTMUser, dt);
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }





        private bool ValidateInput()
        {
            try
            {
                //if (dpFromDate.Value > dpToDate.Value)
                //{
                //    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "From date can not be greater than To date!!", 3);
                //    dpToDate.Focus();
                //    return false;
                //}


                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Label Event

        #endregion

        #region DataGridView Events


        #endregion

        #region TextBox Event
        private void dpToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dpToDate_CloseUp(object sender, EventArgs e)
        {


        }
        private void dpFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void dpToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cbPartNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void txtFromLabel_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyNumeric(sender, e);
        }

        private void txtToLabel_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyNumeric(sender, e);
        }



        private void cbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbLine.SelectedIndex > 0)
                {
                    BindPartNo();
                  
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void cbPartNo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (cbPartNo.SelectedIndex > 0)
                {
                    BindLotNo();
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }

        }

       

        private void cbLotNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbLotNo.SelectedIndex > 0)
                {
                    BindTMUser();
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void cbTMUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }












        #endregion

        
    }
}
