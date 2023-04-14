using ASTI_PRINTING_BL;
using ASTI_PRINTING_COMMON;
using ASTI_PRINTING_PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASTI_PRINTING_APP
{
    public partial class frmBoxLabelPrinting : Form
    {

        #region Variables

        private BL_BOX_LABEL_PRINTING _blObj = null;
        private PL_BOX_LABEL_PRINTING _plObj = null;
        private Common _comObj = null;
        private string _packType = string.Empty;
        private DataTable dtBindGrid = new DataTable();
        #endregion

        #region Form Methods

        public frmBoxLabelPrinting()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_BOX_LABEL_PRINTING();
                SetColumns();
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
                //  this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

                BindPendingDataInGrid();
                BindTempDT();
                txtBarcode.Focus();

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods
        private string AppendBin(string sBinNo)
        {
            string returnstr = string.Empty;
            for (int i = 0; i < dtBindGrid.Rows.Count; i++)
            {
                if (dtBindGrid.Rows[i]["BinNo"].ToString() != sBinNo)
                {
                    returnstr = dtBindGrid.Rows[i]["BinNo"].ToString() + "," + sBinNo;
                }
                else
                {
                    returnstr = dtBindGrid.Rows[i]["BinNo"].ToString();
                }
            }
            return returnstr;
        }
        private string AppendProdDate(string sProdDate)
        {
            string returnstr = string.Empty;
            for (int i = 0; i < dtBindGrid.Rows.Count; i++)
            {
                if (dtBindGrid.Rows[i]["PRDDate"].ToString() != sProdDate)
                {
                    returnstr = dtBindGrid.Rows[i]["PRDDate"].ToString() + "," + sProdDate;
                }
                else
                {
                    returnstr = dtBindGrid.Rows[i]["PRDDate"].ToString();
                }
            }
            return returnstr;
        }
        private string AppendLotNo(string sLotNo)
        {
            string returnstr = string.Empty;
            for (int i = 0; i < dtBindGrid.Rows.Count; i++)
            {
                if (dtBindGrid.Rows[i]["LotNo"].ToString() != sLotNo)
                {
                    returnstr = dtBindGrid.Rows[i]["LotNo"].ToString() + "," + sLotNo;
                }
                else
                {
                    returnstr = dtBindGrid.Rows[i]["LotNo"].ToString();
                }
            }
            return returnstr;
        }

        private string AppendPackDate(string sPackDate)
        {
            string returnstr = string.Empty;
            for (int i = 0; i < dtBindGrid.Rows.Count; i++)
            {
                if (dtBindGrid.Rows[i]["PackDate"].ToString() != sPackDate)
                {
                    returnstr = dtBindGrid.Rows[i]["PackDate"].ToString() + "," + sPackDate;
                }
                else
                {
                    returnstr = dtBindGrid.Rows[i]["PackDate"].ToString();
                }
            }
            return returnstr;
        }

        private void UpdateBoxBarcodeInGrid(string boxBarcode)
        {
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    item.Cells["BoxBarcode"].Value = boxBarcode;
                }
            }
        }
        private void ScanBinBarcode()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                lblMessage.Text = string.Empty;
                string[] arrBarcode = null;
                if (ValidateInput())
                {
                    arrBarcode = txtBarcode.Text.Trim().Split(';');
                    _plObj = new PL_BOX_LABEL_PRINTING();
                    _blObj = new BL_BOX_LABEL_PRINTING();
                    Common common = new Common();
                    _plObj.DbType = "BIN_SCAN";
                    _plObj.BinInputBarcode = txtBarcode.Text.Trim();
                    _plObj.Part_No = arrBarcode[0];//Part No
                    _plObj.PRD_Date_Append =  AppendProdDate(arrBarcode[1]);//Append Production Date
                    _plObj.PRD_Date = arrBarcode[1];//Production Date
                    _plObj.Lot_No_Append = AppendLotNo(arrBarcode[2]);//Append Lot No
                    _plObj.Lot_No = arrBarcode[2];//Lot No
                    _plObj.PCK_Date_Append = AppendPackDate( arrBarcode[3]);//Append Packing Date
                    _plObj.PCK_Date = arrBarcode[3];//Packing Date
                    _plObj.Bin_No_Appned =  AppendBin(arrBarcode[4]);//Append Bin No
                    _plObj.Bin_No = arrBarcode[4];//Bin No
                    _plObj.Qty = Convert.ToInt32(arrBarcode[5]);//Qty
                    _plObj.Sealed_Date = common.GetSystemDate();
                    _plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;

                    DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
                    if (dataTable.Rows.Count > 0)
                    {
                        if (dataTable.Rows[0][0].ToString() == "OK" && dataTable.Rows[0][1].ToString() == "")
                        {
                            lblBinCount.Text = Convert.ToString(Convert.ToInt32(lblBinCount.Text) + 1);
                            dgv.Rows.Add(new string[] { txtBarcode.Text.Trim(), "", GlobalVariable.mSatoAppsLoginUser });
                            DataRow dataRows = dtBindGrid.NewRow();
                            dataRows["PartNo"] = arrBarcode[0];
                            dataRows["PRDDate"] = arrBarcode[1];
                            dataRows["LotNo"] = arrBarcode[2];
                            dataRows["PackDate"] = arrBarcode[3];
                            dataRows["BinNo"] = arrBarcode[4];
                            dataRows["Qty"] = arrBarcode[5];
                            dtBindGrid.Rows.Add(dataRows);
                            txtBarcode.Text = "";
                        }
                        else if (dataTable.Rows[0][0].ToString() == "OK" && dataTable.Rows[0][1].ToString() != "")
                        {
                            dgv.Rows.Add(new string[] { txtBarcode.Text.Trim(), "", GlobalVariable.mSatoAppsLoginUser });
                            lblBinCount.Text = Convert.ToString(Convert.ToInt32(lblBinCount.Text) + 1);
                            UpdateBoxBarcodeInGrid(dataTable.Rows[0][1].ToString());
                            //Printing code here
                            GlobalVariable.MesseageInfo(lblMessage, "Box Label Printed Successfully!!!",1);
                            txtBarcode.Text = "";
                        }
                        else
                        {
                            GlobalVariable.MesseageInfo(lblMessage, dataTable.Rows[0][0].ToString(), 3);

                            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0][0].ToString(), 2);
                            txtBarcode.Text = "";
                        }
                    }
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);

            }
            finally
            {
                this.Cursor = Cursors.Default;
                txtBarcode.Text = "";
            }
        }
        private void SetColumns()
        {
            try
            {

                dtBindGrid.Columns.AddRange(new[]
                {
                     new DataColumn("PartNo", typeof(string)),
                     new DataColumn("PRDDate", typeof(string)),
                     new DataColumn("LotNo", typeof(string)),
                      new DataColumn("PackDate", typeof(string)),
                       new DataColumn("BinNo", typeof(string)),
                     new DataColumn("Qty", typeof(int)),
                });

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
                lblMessage.Text = "";
                txtBarcode.Text = "";
                lblBinCount.Text = "0";


            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void BindPendingDataInGrid()
        {
            try
            {
                _plObj = new PL_BOX_LABEL_PRINTING();
                _blObj = new BL_BOX_LABEL_PRINTING();
                _plObj.DbType = "BIND_GRID";
                DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
                if (dataTable.Rows.Count > 0)
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        dgv.Rows.Add(new string[] { dataTable.Rows[i]["BinBarcode"].ToString(), dataTable.Rows[i]["BoxBarcode"].ToString(), dataTable.Rows[i]["PrintedBy"].ToString() });
                    }
                    
                    lblBinCount.Text = dgv.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void BindTempDT()
        {
            try
            {
                dtBindGrid = null;
                _plObj = new PL_BOX_LABEL_PRINTING();
                _blObj = new BL_BOX_LABEL_PRINTING();
                _plObj.DbType = "BIND_TEMP_DT";
                dtBindGrid = _blObj.BL_ExecuteTask(_plObj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }










        private bool ValidateInput()
        {
            try
            {

                if (txtBarcode.Text.Length == 0)
                {
                    GlobalVariable.MesseageInfo(lblMessage, "Barcode can't be blank!!!", 2);
                    this.txtBarcode.Focus();
                    return false;
                }
                if (!txtBarcode.Text.Contains(";"))
                {
                    GlobalVariable.MesseageInfo(lblMessage, "Invalid Barcode!!!", 2);
                    this.txtBarcode.Focus();
                    return false;
                }
                if (dgv.Rows.Count == 2)
                {
                    dgv.Rows.Clear();
                    lblBinCount.Text = "0";
                }


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
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    ScanBinBarcode();

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }















        #endregion


    }
}
