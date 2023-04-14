using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENSO_PRINTING_DL;
using DENSO_PRINTING_PL;

namespace DENSO_PRINTING_BL
{
    public class BL_NG_MASTER
    {
        public DataTable BL_ExecuteTask(PL_NG_MASTER objPl)
        {
            DL_NG_MASTER objDl = new DL_NG_MASTER();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
