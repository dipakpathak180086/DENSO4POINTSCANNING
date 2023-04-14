
using DENSO_PRINTING_COMMON;
using DENSO_PRINTING_PL;
using SatoLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_PRINTING_DL
{

    public class DL_PART_MASTER
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_PART_MASTER obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@PART_NO", SqlDbType.VarChar, 50);
                param[1].Value = obj.Part_No;
                param[2] = new SqlParameter("@SET_PART_NO", SqlDbType.VarChar, 50);
                param[2].Value = obj.Set_Part_No;
                param[3] = new SqlParameter("@MACHINE_PART_NO", SqlDbType.VarChar, 50);
                param[3].Value = obj.Machine_Part_No;
                param[4] = new SqlParameter("@PART_DIS", SqlDbType.VarChar, 50);
                param[4].Value = obj.Description;
                param[5] = new SqlParameter("@QTY", SqlDbType.Int, 50);
                param[5].Value = obj.Qty;
                param[6] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[6].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_PART_MASTER]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
