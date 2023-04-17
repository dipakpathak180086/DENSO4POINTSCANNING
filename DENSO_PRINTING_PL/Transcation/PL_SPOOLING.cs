using DENSO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_PRINTING_PL
{
    public class PL_SPOOLING:Common
    {
        public string Model { get; set; }
        public string OldPartNo { get; set; }
        public string NewPartNo { get; set; }
        public string FeederPartNo { get; set; }
        public string Lot { get; set; }
        public string  TMBarcode { get; set; }
        public string FinalPartNo { get; set; }
        public string  SpoolType { get; set; }
        public string PartNo { get; set; }
    }
}
