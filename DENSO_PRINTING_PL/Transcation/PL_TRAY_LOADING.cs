using DENSO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_PRINTING_PL
{
    public class PL_TRAY_LOADING : Common
    {
        public string PartNo { get; set; }
        public string TrayEmp { get; set; }
        public string PacketQrCode { get; set; }
        public string TrayFull { get; set; }
        public string CompMarking { get; set; }
        public string LotNo { get; set; }
        public string TMName { get; set; }
    }
}
