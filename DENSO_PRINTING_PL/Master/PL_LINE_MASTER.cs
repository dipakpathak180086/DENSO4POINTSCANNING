using DENSO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_PRINTING_PL
{
    public class PL_LINE_MASTER:Common
    {
        public string Line { get; set; }
        public string LineDesc { get; set; }
        public bool Status { get; set; }
    }
}
