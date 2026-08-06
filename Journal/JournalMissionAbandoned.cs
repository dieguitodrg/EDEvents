using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-08-06T12:00:00Z", "event":"MissionAbandoned", "Name":"Mission_Collect_Industrial_name", "LocalisedName":"Recolectar bienes industriales", "MissionID":901234567, "Fine":500 }
        public class JournalMissionAbandoned : JournalBase
    {
        public string Name { get; set; }
        public string LocalisedName { get; set; }
        public Int64 MissionID { get; set; }
        public int Fine { get; set; }
    }

}