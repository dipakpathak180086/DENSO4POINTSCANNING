
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

    public class DL_MAP_PATH_MASTER
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_MAP_PATH_MASTER obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@PART_NO", SqlDbType.VarChar, 50);
                param[1].Value = obj.PartNo;
                param[2] = new SqlParameter("@LOC1", SqlDbType.VarChar, 500);
                param[2].Value = obj.Loc1;
                param[3] = new SqlParameter("@LOC2", SqlDbType.VarChar, 500);
                param[3].Value = obj.Loc2;
                param[4] = new SqlParameter("@LOC3", SqlDbType.VarChar, 500);
                param[4].Value = obj.Loc3;
                param[5] = new SqlParameter("@LOC4", SqlDbType.VarChar, 500);
                param[5].Value = obj.Loc4;
                param[6] = new SqlParameter("@LOC5", SqlDbType.VarChar, 500);
                param[6].Value = obj.Loc5;
                param[7] = new SqlParameter("@LOC6", SqlDbType.VarChar, 500);
                param[7].Value = obj.Loc6;
                param[8] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[8].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_IMPORT_DATA]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
