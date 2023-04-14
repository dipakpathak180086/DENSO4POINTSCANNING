using DENSO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_PRINTING_PL
{
    public class PL_NG_MASTER : Common
    {
        public string PartNo { get; set; }
        public string Lot { get; set; }
        public bool Active { get; set; }

    }
}
