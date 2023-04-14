﻿
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

    public class DL_NG_MASTER
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_NG_MASTER obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@LINE", SqlDbType.VarChar, 50);
                param[1].Value = obj.Line;
                param[2] = new SqlParameter("@PART", SqlDbType.VarChar, 50);
                param[2].Value = obj.PartNo;
                param[3] = new SqlParameter("@LOT", SqlDbType.VarChar, 50);
                param[3].Value = obj.Lot;
                param[4] = new SqlParameter("@STATUS", SqlDbType.VarChar, 50);
                param[4].Value = obj.Active;
                param[5] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[5].Value = obj.CreatedBy;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_NG_MASTER]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
