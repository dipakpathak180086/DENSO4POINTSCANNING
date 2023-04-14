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
using System.Windows.Forms;

namespace DENSO_PRINTING_APP
{
    public partial class frmNGMaster : Form
    {


        #region Variables

        private BL_NG_MASTER _blObj = null;
        private PL_NG_MASTER _plObj = null;
        private bool _IsUpdate = false;
        private string _partNo = string.Empty;


        #endregion

        #region Form Methods

        public frmNGMaster()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_NG_MASTER();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void frmModelMaster_Load(object sender, EventArgs e)
        {
            try
            {
                // this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

                btnDelete.Enabled = false;
                if (GlobalVariable.UserGroup.ToUpper() != "ADMIN")
                {
                    Common common = new Common();
                    common.SetModuleChildSectionRights(this.Text, _IsUpdate, btnSave, btnDelete);
                }
                Clear();
                txtPartNo.Focus();

                BindGrid();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    _plObj = new PL_NG_MASTER();
                    _plObj.Line = GlobalVariable.mLine;
                    _plObj.PartNo = txtPartNo.Text.Trim();
                    _plObj.Lot = txtLotNo.Text.Trim();
                    _plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;
                    _plObj.Active = chkActive.Checked;
                    //If saving data
                    if (_IsUpdate == false)
                    {
                        _plObj.DbType = "INSERT";
                        DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
                        if (dataTable.Rows.Count > 0)
                        {
                            if (dataTable.Rows[0]["RESULT"].ToString() == "Y")
                            {
                                btnReset_Click(sender, e);
                                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Saved successfully!!", 1);
                                frmModelMaster_Load(null, null);
                            }
                            else
                            {
                                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0][0].ToString(), 3);
                            }
                        }
                    }
                    else // if updating data
                    {
                        _plObj.DbType = "UPDATE";
                        DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
                        if (dataTable.Rows.Count > 0)
                        {
                            if (dataTable.Rows[0]["RESULT"].ToString() == "Y")
                            {
                                btnReset_Click(sender, e);
                                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Updated successfully!!", 1);
                            }
                            else
                            {
                                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0][0].ToString(), 3);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY"))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Already exist!!", 3);
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
                }
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = "";
                Clear();
                frmModelMaster_Load(null, null);
                if (GlobalVariable.UserGroup.ToUpper() != "ADMIN")
                {
                    Common common = new Common();
                    common.SetModuleChildSectionRights(this.Text, _IsUpdate, btnSave, btnDelete);
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPartNo.Text))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Crate Code. can't be blank!!", 3);
                    return;
                }
                if (GlobalVariable.mStoCustomFunction.ConfirmationMsg(GlobalVariable.mSatoApps, "Äre you sure to delete the record !!"))
                {
                    _plObj = new PL_NG_MASTER();
                    _blObj = new BL_NG_MASTER();
                    _plObj.Line = txtPartNo.Text.Trim();
                    _plObj.DbType = "DELETE";
                    DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
                    if (dataTable.Rows.Count > 0)
                    {
                        if (dataTable.Rows[0][0].ToString().StartsWith("Y"))
                        {
                            btnReset_Click(sender, e);
                            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Deleted successfully!!", 1);
                            frmModelMaster_Load(null, null);
                        }
                        else
                        {
                            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0][0].ToString(), 3);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("conflicted with the REFERENCE constraint"))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "This is already in use!!!", 3);
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVariable.ExportInCSV(dgv);
            }
            catch (Exception ex)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        #endregion

        #region Methods
        private void Clear()
        {
            try
            {
                txtPartNo.Text = "";
                txtLotNo.Text = "";
                chkActive.Checked = false;
                txtPartNo.Enabled = true;
                txtLotNo.Enabled = true;
                btnDelete.Enabled = false;
                _IsUpdate = false;
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }
        bool ValidatePartNo(string partNo)
        {
            bool bReturn = false;
            try
            {
                Common common = new Common();
                DataTable dt = common.ValidatePart(partNo);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName == "RESULT")
                    {
                        bReturn = false;
                    }
                    else
                    {
                        _partNo = "";
                        _partNo = dt.Rows[0]["RUNNING_PART"].ToString();
                        txtPartNo.Text = _partNo;
                        bReturn = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return bReturn;

        }



        private void BindGrid()
        {
            try
            {
                _plObj = new PL_NG_MASTER();
                _blObj = new BL_NG_MASTER();
                _plObj.DbType = "SELECT";
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                dgv.DataSource = dt;
                lblCount.Text = "Rows Count : " + dgv.Rows.Count;
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }

        private bool ValidateInput()
        {
            try
            {
                if (txtPartNo.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Part No can't be blank!!", 3);
                    txtPartNo.Focus();
                    txtPartNo.SelectAll();
                    return false;
                }
                if (!ValidatePartNo(txtPartNo.Text.Trim()) && _partNo=="")
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Invalida Part No!!!!", 3);
                    txtPartNo.Focus();
                    txtPartNo.SelectAll();
                    return false;
                }
                if (txtLotNo.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Line Desc. can't be blank!!", 3);
                    txtLotNo.Focus();
                    txtLotNo.SelectAll();
                    return false;
                }


                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Label Event

        #endregion

        #region DataGridView Events
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex <= -1)
                {
                    return;
                }
                Clear();
                txtPartNo.Text=_partNo = dgv.Rows[e.RowIndex].Cells["PartNo"].Value.ToString();
                txtLotNo.Text = dgv.Rows[e.RowIndex].Cells["LotNo"].Value.ToString();
                chkActive.Checked = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["Status"].Value.ToString());
                btnDelete.Enabled = true;
                txtPartNo.Enabled = false;
                txtLotNo.Enabled = false;
                _IsUpdate = true;
                if (GlobalVariable.UserGroup.ToUpper() != "ADMIN")
                {
                    Common common = new Common();
                    common.SetModuleChildSectionRights(this.Text, _IsUpdate, btnSave, btnDelete);
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        #endregion

        #region TextBox Event

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("LotNo LIKE '%{0}%'", txtSearch.Text);
        }


        private void txtPartNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtPartNo.Text.Trim().Length == 0)
                    {
                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Part No can't be blank!!", 3);
                        txtPartNo.Focus();
                        txtPartNo.SelectAll();
                        return;
                    }
                    if (!ValidatePartNo(txtPartNo.Text.Trim()))
                    {
                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Invalida Part No!!!!", 3);
                        txtPartNo.Focus();
                        txtPartNo.SelectAll();
                        return;
                    }
                    txtLotNo.Focus();
                }
            }

            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }

        private void txtVatCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyNumeric(sender, e);
        }







        #endregion

        private void txtPartNo_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txtPartNo.Text.Trim().Length == 0)
                {
                    return;
                }
                if (!ValidatePartNo(txtPartNo.Text.Trim()))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Invalida Part No!!!!", 3);
                    txtPartNo.Focus();
                    txtPartNo.SelectAll();
                    return;
                }
                txtLotNo.Focus();

            }

            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }
    }
}
