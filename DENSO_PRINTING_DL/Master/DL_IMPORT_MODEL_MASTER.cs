
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

    public class DL_IMPORT_MODEL_MASTER
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_MODEL_MASTER obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@MODEL_NO", SqlDbType.VarChar, 50);
                param[1].Value = obj.Model;
                param[2] = new SqlParameter("@PART1", SqlDbType.VarChar, 500);
                param[2].Value = obj.PartNo1;
                param[3] = new SqlParameter("@PART2", SqlDbType.VarChar, 500);
                param[3].Value = obj.PartNo2;
                param[4] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[4].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_IMPORT_MODEL_MASTER]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
