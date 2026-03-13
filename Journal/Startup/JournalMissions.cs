using EDCrew;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{


    public class JournalMissions : JournalBase
    {
        //{ "timestamp":"2023-02-02T22:30:51Z", "event":"ShipTargeted", "TargetLocked":true, "Ship":"cobramkiii", "Ship_Localised":"Cobra Mk III", "ScanStage":3, "PilotName":"$npc_name_decorate:#name=Gareth Knipe;", "PilotName_Localised":"Gareth Knipe", "PilotRank":"Mostly Harmless", "ShieldHealth":0.000000, "HullHealth":100.000000, "Faction":"Candy Crew Guild", "LegalStatus":"Wanted", "Bounty":112347 }

        public List<JournalMissionMission> Active { get; set; }

        public List<JournalMissionMission> Failed { get; set; }

        public List<JournalMissionMission> Complete { get; set; }

    }


    public class JournalMissionMission
    {
        public Int64 MissionID { get; set; }
        public String Name { get; set; }
        public Boolean PassengerMission { get; set; }
        public int Expires { get; set; }

    }
}