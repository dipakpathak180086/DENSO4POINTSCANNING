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
    public class DL_LASER_LAODING
    {

        
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_LASER_LOADING obj)
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
                param[3] = new SqlParameter("@KANABAN", SqlDbType.VarChar, 500);
                param[3].Value = obj.KanbanModel;
                param[4] = new SqlParameter("@PART", SqlDbType.VarChar, 500);
                param[4].Value = obj.PCBPartNo;
                param[5] = new SqlParameter("@DESICCATOR_LOCATION", SqlDbType.VarChar, 500);
                param[5].Value = obj.DesiccatorLocation;
                param[6] = new SqlParameter("@PART_CARRY_LOCATION", SqlDbType.VarChar, 500);
                param[6].Value = obj.PartCarryLocation;
                param[7] = new SqlParameter("@PACKET_QR_CODE", SqlDbType.VarChar, 500);
                param[7].Value = obj.PacketQrCode;
                param[8] = new SqlParameter("@TM_NAME", SqlDbType.VarChar, 500);
                param[8].Value = obj.TMName;
                param[9] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[9].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_LASER_LOADING]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      
    }
}
