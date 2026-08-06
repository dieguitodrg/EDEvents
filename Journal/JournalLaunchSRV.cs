using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"LaunchSRV", "Loadout":"starter", "ID":1, "SRVType":"scarab", "SRVType_Localised":"Scarab" }
        public class JournalLaunchSRV : JournalBase
    {
        public string Loadout { get; set; }
        public int ID { get; set; }
        public string SRVType { get; set; }
        public string SRVType_Localised { get; set; }
    }

}