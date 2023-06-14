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
    public partial class frmImportLaserDataMaster : Form
    {


        #region Variables

        private BL_IMPORT_LASER_MASTER _blObj = null;
        private PL_IMPORT_LASER_MASTER _plObj = null;
        private bool _IsUpdate = false;

        #endregion

        #region Form Methods

        public frmImportLaserDataMaster()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_IMPORT_LASER_MASTER();
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
                txtMapPath.Focus();
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
                    DialogResult dre = MessageBox.Show("Are you sure want to save", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dre == DialogResult.No)
                    { return; }
                    DataTable dataTable = null;
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        _plObj = new PL_IMPORT_LASER_MASTER();
                        _plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;
                        _plObj.DbType = "IMPORT";
                        _plObj.ModelNo = dgv.Rows[i].Cells[0].Value.ToString();
                        _plObj.PCBPartNo = dgv.Rows[i].Cells[1].Value.ToString();
                        _plObj.DesiccatorLocation = dgv.Rows[i].Cells[2].Value.ToString();
                        _plObj.PartCarryLocation = dgv.Rows[i].Cells[3].Value.ToString();
                        _plObj.PacketQRCode = dgv.Rows[i].Cells[4].Value.ToString();

                        dataTable = _blObj.BL_ExecuteTask(_plObj);
                    }
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
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY"))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Part already exist!!", 3);
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
                //txtPartSearch.Text = "";
                Clear();
                BindGrid();

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
                //if (string.IsNullOrEmpty(txtPartNo.Text))
                //{
                //    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Part No. can't be blank!!", 3);
                //    return;
                //}
                //if (GlobalVariable.mStoCustomFunction.ConfirmationMsg(GlobalVariable.mSatoApps, "Äre you sure to delete the record !!"))
                //{
                //    _plObj = new PL_MAP_PATH_MASTER();
                //    _blObj = new BL_MAP_PATH_MASTER();
                //    _plObj.Part_No = txtPartNo.Text.Trim();
                //    _plObj.Set_Part_No = txtSetPartNo.Text.Trim();
                //    _plObj.Machine_Part_No = txtMachinePartNo.Text.Trim();
                //    _plObj.DbType = "DELETE";
                //    DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
                //    if (dataTable.Rows.Count > 0)
                //    {
                //        if (dataTable.Rows[0][0].ToString().StartsWith("Y"))
                //        {
                //            btnReset_Click(sender, e);
                //            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Deleted successfully!!", 1);
                //            frmModelMaster_Load(null, null);
                //        }
                //        else
                //        {
                //            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0][0].ToString(), 3);
                //        }
                //    }


                //}
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
                this.Cursor = Cursors.WaitCursor;
                saveFileDialog1.Filter = "Excel Files|*.xlsx|1997-2003 Excel Files|*.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = dgv.DataSource as DataTable;
                    if (saveFileDialog1.FilterIndex == 1)
                    {
                        GlobalVariable.ExportExcel(dt, saveFileDialog1.FileName);
                    }
                    else if (saveFileDialog1.FilterIndex == 2)
                    {
                        GlobalVariable.ExportExcel(dt, saveFileDialog1.FileName);
                    }

                }
            }
            catch (Exception ex)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            try
            {
                ImportMasterData(ref txtMapPath);
            }
            catch (Exception ex)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        #endregion

        #region Methods
        private void ImportMasterData(ref TextBox obj)
        {
            using (var folderDialog = new OpenFileDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {

                    //this.Cursor = Cursors.WaitCursor;
                    obj.Text = folderDialog.FileName;
                    clsODBC oOdbc = new clsODBC();
                    oOdbc.DataSource = folderDialog.FileName.Trim();
                    if (oOdbc.Connect())
                    {
                        string Query = "SELECT * FROM [Sheet1$]";
                        DataTable dtResultSet = oOdbc.GetDataTable(Query);
                        oOdbc.Disconnect();
                        lblCount.Text = $"Rows Count : {dtResultSet.Rows.Count}";
                        dgv.DataSource = dtResultSet.DefaultView;
                        for (int i = 0; i < dgv.ColumnCount; i++)
                        {
                            this.dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            //this.dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            //this.dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                        //if (rdbImpCaseGTIN.Checked)
                        //    FillListViewFromDatatableCaseGTIN(this, lvImpotedRecords, dtResultSet);
                        //else
                        //    FillListViewFromDatatableBottle(this, lvImpotedRecords, dtResultSet);
                    }
                }
            }
        }
        private void GetLine()
        {
            try
            {
                //_plObj = new PL_MAP_PATH_MASTER();
                //_blObj = new BL_MAP_PATH_MASTER();
                //_plObj.DbType = "BIND_LINE";
                // DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                //if (dt.Rows.Count > 0)
                //{
                //    GlobalVariable.BindCombo(cbLineNo, dt);
                //}
                //else
                //{
                //    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Data not found", 3);
                //}
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void GetPartNo()
        {
            try
            {
                //_plObj = new PL_MAP_PATH_MASTER();
                //_blObj = new BL_MAP_PATH_MASTER();
                //_plObj.DbType = "BIND_PART";
                //DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                //if (dt.Rows.Count > 0)
                //{
                //    GlobalVariable.BindCombo(cbPartNo, dt);
                //}
                //else
                //{
                //    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Data not found", 3);
                //}
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void Clear()
        {
            try
            {
                lblCount.Text = "Rows Count : 0";
                //if (cbPartNo.SelectedIndex > 0)
                //    cbPartNo.SelectedIndex = 0;
                //if (cbLineNo.SelectedIndex > 0)
                //    cbLineNo.SelectedIndex = 0;
                //txtMapPath.Text = "";
                //chkActive.Checked = true;
                //cbPartNo.Enabled = cbLineNo.Enabled= true;
                //_IsUpdate = false;
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }




        private void BindGrid()
        {
            try
            {
                _plObj = new PL_IMPORT_LASER_MASTER();
                _blObj = new BL_IMPORT_LASER_MASTER();
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
                //if (cbLineNo.SelectedIndex<= 0)
                //{
                //    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Line No. can't be blank!!", 3);
                //    cbLineNo.Focus();
                //    return false;
                //}
                //if (cbPartNo.SelectedIndex<= 0)
                //{
                //    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Part No. can't be blank!!", 3);
                //    cbPartNo.Focus();
                //    return false;
                //}
                //if (txtMapPath.Text.Trim().Length == 0)
                //{
                //    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Map Path. can't be blank!!", 3);
                //    txtMapPath.Focus();
                //    return false;
                //}

                if (dgv.Rows.Count == 0 || dgv.DataSource == null)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Select Import data!!", 3);
                    txtMapPath.Focus();
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
                //cbLineNo.Text = dgv.Rows[e.RowIndex].Cells["LineNo"].Value.ToString();
                //cbPartNo.Text = dgv.Rows[e.RowIndex].Cells["PartNo"].Value.ToString();
                //txtMapPath.Text = dgv.Rows[e.RowIndex].Cells["MapPath"].Value.ToString();
                //chkActive.Checked =Convert.ToBoolean( dgv.Rows[e.RowIndex].Cells["Active"].Value.ToString());
                //btnDelete.Enabled = true;
                //cbLineNo.Enabled =cbPartNo.Enabled =false;
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

        private void txtPartSearch_TextChanged(object sender, EventArgs e)
        {
            //   (dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("LineNo LIKE '%{0}%'", txtPartSearch.Text);
        }
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            GlobalVariable.allowOnlyNumeric(sender, e);
        }




        #endregion


    }
}
