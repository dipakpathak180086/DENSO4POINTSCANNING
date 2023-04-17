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
    public class DL_SPOOLING
    {

        
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_SPOOLING obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@LINE", SqlDbType.VarChar, 50);
                param[1].Value = obj.Line;
                param[2] = new SqlParameter("@OLD_PART", SqlDbType.VarChar, 500);
                param[2].Value = obj.OldPartNo;
                param[3] = new SqlParameter("@NEW_PART", SqlDbType.VarChar, 500);
                param[3].Value = obj.NewPartNo;
                param[4] = new SqlParameter("@FEEDER_PART", SqlDbType.VarChar, 500);
                param[4].Value = obj.FeederPartNo;
                param[5] = new SqlParameter("@LOT_NO", SqlDbType.VarChar, 500);
                param[5].Value = obj.Lot;
                param[6] = new SqlParameter("@TM_NAME", SqlDbType.VarChar, 500);
                param[6].Value = obj.TMBarcode;
                param[7] = new SqlParameter("@FINAL_PART", SqlDbType.VarChar, 500);
                param[7].Value = obj.FinalPartNo;
                param[8] = new SqlParameter("@SPOOL_TYPE", SqlDbType.VarChar, 500);
                param[8].Value = obj.SpoolType;
                param[9] = new SqlParameter("@MODEL", SqlDbType.VarChar, 500);
                param[9].Value = obj.Model;
                param[10] = new SqlParameter("@PART", SqlDbType.VarChar, 500);
                param[10].Value = obj.PartNo;
                param[11] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[11].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_SPOOLING]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      
    }
}
