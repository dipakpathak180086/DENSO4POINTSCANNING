using DENSO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_PRINTING_PL
{
    public class PL_TRAY_LOADING_REPORT : Common
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string PartNo { get; set; }
        public string Lot { get; set; }
        public string TMName { get; set; }
    }
}
