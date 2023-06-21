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
    public class BL_HARDWARE_REPORT
    {
        public DataTable BL_ExecuteTask(PL_HARDWARE_REPORT objPl)
        {
            DL_HARDWARE_REPORT objDl = new DL_HARDWARE_REPORT();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
