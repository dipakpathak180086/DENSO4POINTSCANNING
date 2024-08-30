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
    public class BL_IMPORT_MODEL_MASTER
    {
        public DataTable BL_ExecuteTask(PL_MODEL_MASTER objPl)
        {
            DL_IMPORT_MODEL_MASTER objDl = new DL_IMPORT_MODEL_MASTER();
            return objDl.DL_ExecuteTask(objPl);
        }


    }
}
