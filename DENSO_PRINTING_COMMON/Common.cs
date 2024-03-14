
using SatoLib;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DENSO_PRINTING_COMMON
{
    public class Common : IDisposable
    {

        public string CreatedBy { get; set; }
        public string Line { get; set; }
        public int ModuleId { get; set; }
        public string DbType { get; set; }
        private SqlHelper _SqlHelper = null;
        public DataTable GetGroup()
        {

            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = "SELECT_GROUP";

                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_BIND_COMBO]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetLine()
        {

            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = "BIND_LINE";

                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_BIND_COMBO]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable GetModel()
        {

            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = "BIND_MODEL";

                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_BIND_MODEL_AND_PART_MAIN_MENU]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable GetPart(string model)
        {

            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = "BIND_PART";
                param[1] = new SqlParameter("@MODEL", SqlDbType.VarChar, 100);
                param[1].Value = model;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_BIND_MODEL_AND_PART_MAIN_MENU]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable ValidatePart(string partNo)
        {

            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@PART_BARCODE", SqlDbType.VarChar, 100);
                param[0].Value = partNo;

                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_VALIDATE_PART]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable DeleteImportedData()
        {

            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = DbType;

                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_DELETE_IMPORTED_DATA]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string GetSystemDate()
        {

            _SqlHelper = new SqlHelper();
            try
            {

                string sdate = Convert.ToString(_SqlHelper.ExecuteScalar(GlobalVariable.mMainSqlConString, CommandType.Text, "SELECT CONVERT(VARCHAR(10),GETDATE(),103)"));
                return sdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable GetVersion(string sVersionName)
        {

            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@APP_NAME", SqlDbType.VarChar, 100);
                param[0].Value = "PC";
                param[1] = new SqlParameter("@APP_VERSION", SqlDbType.VarChar, 100);
                param[1].Value = sVersionName;

                DataTable dataTable = _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_GET_VERSION]", param).Tables[0];
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void SetModuleChildSectionRights(string sModule, bool updateflag, params Button[] buttons)
        {
            try
            {
                string btnName = string.Empty;
                StringBuilder _SbQry = new StringBuilder();
                _SqlHelper = new SqlHelper();
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@GROUP_NAME", SqlDbType.VarChar, 100);
                param[0].Value = GlobalVariable.UserGroup;
                param[1] = new SqlParameter("@MODULE_NAME", SqlDbType.VarChar, 100);
                param[1].Value = sModule;
                DataTable dataTable = _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_SET_CHILDSEC_RIGHTS]", param).Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    foreach (var item in buttons)
                    {
                        if (item == null) { continue; }
                        btnName = item.Name.Remove(0, 3);
                        if (updateflag)
                        {
                            if (dataTable.Columns["Save"].ColumnName.Contains(btnName))
                            {
                                item.Enabled = (bool)dataTable.Rows[0]["Update"];

                            }
                        }
                        else
                        {
                            item.Enabled = (bool)dataTable.Rows[0]["Save"];

                        }
                        if (dataTable.Columns["Delete"].ColumnName.Contains(btnName))
                        {
                            item.Enabled = (bool)dataTable.Rows[0]["Delete"];
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }



        
        private void GetFirstAndSecondData(string[] arr, ref string rFirstData, ref string rSecondData)
        {
            StringBuilder stringBuilderFirst = new StringBuilder();
            StringBuilder stringBuilderSecond = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i <= 3)
                {
                    stringBuilderFirst.Append(arr[i].ToString());
                    stringBuilderFirst.Append(",");
                    rFirstData = stringBuilderFirst.ToString();

                }
                else
                {
                    stringBuilderSecond.Append(arr[i].ToString());
                    stringBuilderSecond.Append(",");
                    rSecondData = stringBuilderSecond.ToString();
                }
            }
            rFirstData = rFirstData.TrimEnd(',');
            rSecondData = rSecondData.TrimEnd(',');

        }
        public void GiveAccessToPrint(string sType, string userId, string sPassword)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[3];

                param[0] = new SqlParameter("@Type", SqlDbType.VarChar, 100);
                param[0].Value = sType;
                param[1] = new SqlParameter("@UserID", SqlDbType.VarChar, 100);
                param[1].Value = userId;
                param[2] = new SqlParameter("@Password", SqlDbType.VarChar, 100);
                param[2].Value = sPassword;
                DataTable dataTable = _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_UserMaster]", param).Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    if (dataTable.Rows[0]["RESULT"].ToString() == "Y")
                    {
                        GlobalVariable.mAccessUser = dataTable.Rows[0]["MSG"].ToString();
                    }
                    else
                    {
                        throw new Exception(dataTable.Rows[0]["MSG"].ToString());
                    }


                }
            }
            catch (ArgumentNullException ex)
            {

                throw ex;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
            // free native resources if there are any.
        }


    }
}
