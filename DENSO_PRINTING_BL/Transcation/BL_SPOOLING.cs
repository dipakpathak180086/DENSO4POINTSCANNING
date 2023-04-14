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
    public class BL_SPOOLING
    {
        public DataTable BL_ExecuteTask(PL_SPOOLING objPl)
        {
            DL_SPOOLING objDl = new DL_SPOOLING();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
