
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

    public class DL_IMPORT_TRAY_MASTER
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_IMPORT_TRAY_MASTER obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@PART_NO", SqlDbType.VarChar, 50);
                param[1].Value = obj.PartNo;
                param[2] = new SqlParameter("@TRY", SqlDbType.VarChar, 500);
                param[2].Value = obj.Tray;
                param[3] = new SqlParameter("@COMPONENT_MARKING", SqlDbType.VarChar, 500);
                param[3].Value = obj.ComponentMarking;
                param[4] = new SqlParameter("@PACKET_QRCODE", SqlDbType.VarChar, 500);
                param[4].Value = obj.PacketQRCode;
                param[5] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[5].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_IMPORT_TRY_DATA]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
