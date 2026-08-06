using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CarrierDockingPermission", "CarrierID":3700005632, "DockingAccess":"squadron", "AllowNotorious":true }
        public class JournalCarrierDockingPermission : JournalBase
    {
        public long CarrierID { get; set; }
        public string DockingAccess { get; set; }
        public bool AllowNotorious { get; set; }
    }

}