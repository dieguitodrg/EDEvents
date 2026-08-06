using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-08-06T12:00:00Z", "event":"ScanOrganic", "ScanType":"Analyse", "Genus":"$Codex_Ent_Stratum_Genus_Name;", "Genus_Localised":"Stratum", "Species":"$Codex_Ent_Stratum_02_Species_Name;", "Species_Localised":"Stratum cucumisis", "Variant":"$Codex_Ent_Stratum_02_F_Name;", "Variant_Localised":"Frutal", "SystemAddress":223245345, "Body":7, "BodyID":7 }
        public class JournalScanOrganic : JournalBase
    {
        public string ScanType { get; set; }
        public string Genus { get; set; }
        public string Genus_Localised { get; set; }
        public string Species { get; set; }
        public string Species_Localised { get; set; }
        public string Variant { get; set; }
        public string Variant_Localised { get; set; }
        public Int64 SystemAddress { get; set; }
        public int Body { get; set; }
        public int BodyID { get; set; }
    }

}