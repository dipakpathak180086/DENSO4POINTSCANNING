using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENSO_PRINTING_COMMON;


namespace DENSO_PRINTING_PL
{
    public class PL_PART_MASTER : Common
    {
        public string Part_No { get; set; }
        public string Set_Part_No { get; set; }
        public string Machine_Part_No { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }

    }
}
