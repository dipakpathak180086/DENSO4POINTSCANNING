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
    public class DL_HARDWARE_LAODING
    {

        
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_HARDWARE_LOADING obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@LINE", SqlDbType.VarChar, 50);
                param[1].Value = obj.Line;
                param[2] = new SqlParameter("@CHANGE_OVER_SHEET", SqlDbType.VarChar, 500);
                param[2].Value = obj.ChangeOverSheet;
                param[3] = new SqlParameter("@CS", SqlDbType.VarChar, 500);
                param[3].Value = obj.CS;
                param[4] = new SqlParameter("@RUNNING_TAG_FIRST", SqlDbType.VarChar, 500);
                param[4].Value = obj.RunningFirstTag;
                param[5] = new SqlParameter("@RUNNING_TAG_SECOND", SqlDbType.VarChar, 500);
                param[5].Value = obj.RunningSecondTag;
                param[6] = new SqlParameter("@NRC", SqlDbType.VarChar, 500);
                param[6].Value = obj.NRC;
                param[7] = new SqlParameter("@KANBAN_QR_CODE", SqlDbType.VarChar, 500);
                param[7].Value = obj.KanbanQRCode;
                param[8] = new SqlParameter("@KC", SqlDbType.VarChar, 500);
                param[8].Value = obj.KC;
                param[9] = new SqlParameter("@PRD_QR_CODE", SqlDbType.VarChar, 500);
                param[9].Value = obj.PRD_QR_Code;
                param[10] = new SqlParameter("@HC", SqlDbType.VarChar, 500);
                param[10].Value = obj.HC;
                param[11] = new SqlParameter("@TM_NAME", SqlDbType.VarChar, 500);
                param[11].Value = obj.TMName;
                param[12] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[12].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_HARDWARE_LOADING]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      
    }
}
