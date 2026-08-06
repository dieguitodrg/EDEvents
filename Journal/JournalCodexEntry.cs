using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"CodexEntry","EntryID":1400159,"Name":"$Codex_Ent_IceFumarole_CarbonDioxideGeysers_Name;","Name_Localised":"Carbon Dioxide Ice Fumarole","SubCategory":"$Codex_SubCategory_Geology_and_Anomalies;","SubCategory_Localised":"Geology and anomalies","Category":"$Codex_Category_Biology;","Category_Localised":"Biological and Geological","Region":"$Codex_RegionName_18;","Region_Localised":"Inner Orion Spur","System":"Hermitage","SystemAddress":5363877956440,"BodyID":2,"NearestDestination":"$SAA_Unknown_Signal:#type=$SAA_SignalType_Geological;:#index=9;","NearestDestination_Localised":"Surface signal: Geological (9)","Latitude":-31.7349,"Longitude":127.3349,"IsNewEntry":true,"NewTraitsDiscovered":false,"Traits":["Geological"],"VoucherAmount":50000}
        public class JournalCodexEntry : JournalBase
    {
        public int EntryID { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public string SubCategory { get; set; }
        public string SubCategory_Localised { get; set; }
        public string Category { get; set; }
        public string Category_Localised { get; set; }
        public string Region { get; set; }
        public string Region_Localised { get; set; }
        public string System { get; set; }
        public long SystemAddress { get; set; }
        public int BodyID { get; set; }
        public string NearestDestination { get; set; }
        public string NearestDestination_Localised { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsNewEntry { get; set; }
        public bool NewTraitsDiscovered { get; set; }
        public List<string> Traits { get; set; }
        public int VoucherAmount { get; set; }
    }

}