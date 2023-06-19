using DENSO_PRINTING_PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENSO_PRINTING_DL;


namespace DENSO_PRINTING_BL
{
    public class BL_LASER_LOADING
    {
        public DataTable BL_ExecuteTask(PL_LASER_LOADING objPl)
        {
            DL_LASER_LAODING objDl = new DL_LASER_LAODING();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
