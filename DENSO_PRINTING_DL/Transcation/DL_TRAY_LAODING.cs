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
    public class DL_TRAY_LAODING
    {

        
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_TRAY_LOADING obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@LINE", SqlDbType.VarChar, 50);
                param[1].Value = obj.Line;
                param[2] = new SqlParameter("@PART", SqlDbType.VarChar, 500);
                param[2].Value = obj.PartNo;
                param[3] = new SqlParameter("@TRAY_EMP", SqlDbType.VarChar, 500);
                param[3].Value = obj.TrayEmp;
                param[4] = new SqlParameter("@PACKET_QR_CODE", SqlDbType.VarChar, 500);
                param[4].Value = obj.PacketQrCode;
                param[5] = new SqlParameter("@TRAY_FULL", SqlDbType.VarChar, 500);
                param[5].Value = obj.PacketQrCode;
                param[6] = new SqlParameter("@COMP_MARKING", SqlDbType.VarChar, 500);
                param[6].Value = obj.CompMarking;
                param[7] = new SqlParameter("@LOT_NO", SqlDbType.VarChar, 500);
                param[7].Value = obj.LotNo;
                param[8] = new SqlParameter("@TM_NAME", SqlDbType.VarChar, 500);
                param[8].Value = obj.TMName;
                param[9] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[9].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_TRAY_LOADING]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      
    }
}
