using DNH_COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DNH_PC_APP
{
    public partial class frmPickingUpload : Form
    {
        #region Variable

        #endregion

        #region Method
        private DataTable dataTableFileFormate(DataSet dataSet)
        {
            DataTable dataTable = new DataTable();
            try
            {
                for (int iColumns = 0; iColumns < dataSet.Tables[0].Rows.Count; iColumns++)
                {
                    dataTable.Columns.Add(dataSet.Tables[0].Rows[iColumns][0].ToString());

                }
                for (int iRows = 0; iRows < dataSet.Tables[1].Rows.Count; iRows++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = dataSet.Tables[1].Rows[iRows][0].ToString();
                    dataTable.Rows.Add(dataRow);
                    dataTable.AcceptChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dataTable;
        }
        #endregion

        #region Constructor
        public frmPickingUpload()
        {
            InitializeComponent();

        }
        #endregion

        #region Event
        private void frmPackingUpload_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void picBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog folderBrowserDialog = new OpenFileDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtBrowseFilePath.Text = folderBrowserDialog.FileName;
                }
                clsODBC oOdbc = new clsODBC();
                oOdbc.DataSource = txtBrowseFilePath.Text.Trim();
                if (oOdbc.Connect())
                {
                    string Query = "SELECT * FROM [Sheet1$]";
                    DataTable dtResultSet = oOdbc.GetDataTable(Query);
                    dgv.DataSource = dtResultSet.DefaultView;
                    oOdbc.Disconnect();
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgv.ColumnCount; i++)
                {

                }

            }
            catch (Exception ex)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            txtBrowseFilePath.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFileFormat_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTableCol = new DataTable();
                object[] objRow = new object[dgv.ColumnCount];
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    dataTableCol.Columns.Add(dgv.Columns[i].Name);
                    objRow[i] = "";
                }
                for (int i = 0; i < 1; i++)
                {
                    dataTableCol.NewRow();
                    dataTableCol.Rows.Add(objRow);
                }
                ExcelUtlity obj = new ExcelUtlity();
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = @"C:\";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    obj.WriteDataTableToExcel(dataTableCol, "Sheet1", saveFileDialog.FileName, "");
                }


                MessageBox.Show("Export Successfully");
                Process.Start(saveFileDialog.FileName);


            }
            catch (Exception ex)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion


    }

}
