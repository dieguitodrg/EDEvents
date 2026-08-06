using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-12-16T23:14:56Z", "event":"MissionFailed", "Name":"Mission_Collect_Industrial_name", "LocalisedName":"La industria necesita 630 unidades de Oro", "MissionID":992671725 }
        public class JournalMissionFailed : JournalBase
    {
        public string Name { get; set; }
        public string LocalisedName { get; set; }
        public Int64 MissionID { get; set; }
    }

}