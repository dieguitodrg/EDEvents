using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SellOrganicData", "MarketID":3228964864, "BioData":[ { "Genus":"Tubus", "Genus_Localised":"Tubus", "Species":"Tubus Conifer", "Species_Localised":"Tubus Conifer", "Variant":"Tubus Conifer - Indigo", "Variant_Localised":"Tubus Conifer - Indigo", "Value":2415500, "Bonus":9662000 } ] }
        public class JournalSellOrganicDataBioDatum
    {
        public string Genus { get; set; }
        public string Genus_Localised { get; set; }
        public string Species { get; set; }
        public string Species_Localised { get; set; }
        public string Variant { get; set; }
        public string Variant_Localised { get; set; }
        public int Value { get; set; }
        public int Bonus { get; set; }
    }

    public class JournalSellOrganicData : JournalBase
    {
        public long MarketID { get; set; }
        public List<JournalSellOrganicDataBioDatum> BioData { get; set; }
    }

}