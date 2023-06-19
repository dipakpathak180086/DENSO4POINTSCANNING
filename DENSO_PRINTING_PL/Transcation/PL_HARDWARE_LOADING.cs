using DENSO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENSO_PRINTING_PL
{
    public class PL_HARDWARE_LOADING : Common
    {
        public string ChangeOverSheet { get; set; }
        public string CS { get; set; }
        public string RunningFirstTag { get; set; }
        public string RunningSecondTag { get; set; }
        public string NRC { get; set; }
        public string KanbanQRCode { get; set; }
        public string KC { get; set; }
        public string PRD_QR_Code { get; set; }
        public string HC { get; set; }
        public string TMName { get; set; }
    }
}
