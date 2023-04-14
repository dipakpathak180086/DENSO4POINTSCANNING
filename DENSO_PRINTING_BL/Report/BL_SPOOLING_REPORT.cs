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
    public class BL_SPOOLING_REPORT
    {
        public DataTable BL_ExecuteTask(PL_SPOOLING_REPORT objPl)
        {
            DL_SPOOLING_REPORT objDl = new DL_SPOOLING_REPORT();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
