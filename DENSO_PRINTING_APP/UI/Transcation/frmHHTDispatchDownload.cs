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
    public partial class frmHHTDispatchDownload : Form
    {
        #region Variable
      
        #endregion

        #region Method
        private DataTable dataTableFileFormate(DataSet dataSet)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable.Columns.Add("NAMES");
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
        public frmHHTDispatchDownload()
        {
            InitializeComponent();
        
        }
        #endregion

        #region Event
        private void frmTargetMaster_Load(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {

              
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                



            }
            catch (Exception ex)
            {

               
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
           
        }
        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion


    }

}
