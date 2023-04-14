using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENSO_PRINTING_COMMON;
using DENSO_PRINTING_PL;

using SatoLib;


namespace DENSO_PRINTING_DL
{
    public class DL_SPOOLING_REPORT
    {

        
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_SPOOLING_REPORT obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@FROM_DATE", SqlDbType.VarChar, 50);
                param[1].Value = obj.FromDate;
                param[2] = new SqlParameter("@TO_DATE", SqlDbType.VarChar, 500);
                param[2].Value = obj.ToDate;
                param[3] = new SqlParameter("@LINE", SqlDbType.VarChar, 500);
                param[3].Value = obj.Line;
                param[4] = new SqlParameter("@PART", SqlDbType.VarChar, 500);
                param[4].Value = obj.PartNo;
                param[5] = new SqlParameter("@FEEDER", SqlDbType.VarChar, 500);
                param[5].Value = obj.FeederPartNo;
                param[6] = new SqlParameter("@LOT", SqlDbType.VarChar, 500);
                param[6].Value = obj.LotNo;
                param[7] = new SqlParameter("@USER", SqlDbType.VarChar, 500);
                param[7].Value = obj.TMUserName;
                param[8] = new SqlParameter("@SPOOL_TYPE", SqlDbType.VarChar, 500);
                param[8].Value = obj.SpoolType;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_SPOOLING_REPORT]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      
    }
}
