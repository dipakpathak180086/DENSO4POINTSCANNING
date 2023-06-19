using DENSO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_PRINTING_PL
{
    public class PL_LASER_LOADING : Common
    {
        public string ChangeOverSheet { get; set; }
        public string KanbanModel { get; set; }
        public string PCBPartNo { get; set; }
        public string DesiccatorLocation { get; set; }
        public string PartCarryLocation { get; set; }
        public string PacketQrCode { get; set; }
        public string TMName { get; set; }
    }
}
