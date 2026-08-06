using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"TechnologyBroker", "BrokerType":"Human", "MarketID":3229696256, "ItemsUnlocked":[ { "Name":"Hpt_PlasmaShockCannon_Fixed_Medium", "Name_Localised":"Shock Cannon" } ], "Commodities":[ { "Name":"iondistributor", "Name_Localised":"Ion Distributor", "Count":6 } ], "Materials":[ { "Name":"vanadium", "Count":30, "Category":"Raw" }, { "Name":"technetium", "Count":30, "Category":"Raw" } ] }
        public class JournalTechnologyBrokerCommodity
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
    }

    public class JournalTechnologyBrokerItemsUnlocked
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
    }

    public class JournalTechnologyBrokerMaterial
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string Category { get; set; }
    }

    public class JournalTechnologyBroker : JournalBase
    {
        public string BrokerType { get; set; }
        public long MarketID { get; set; }
        public List<JournalTechnologyBrokerItemsUnlocked> ItemsUnlocked { get; set; }
        public List<JournalTechnologyBrokerCommodity> Commodities { get; set; }
        public List<JournalTechnologyBrokerMaterial> Materials { get; set; }
    }

}