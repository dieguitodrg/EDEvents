using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"TradeMicroResources", "Offered":[ { "Name":"mutageniccatalyst", "Name_Localised":"Mutagenic Catalyst", "Count":5 } ], "Received":"californium", "Category":"Raw", "Count":3, "MarketID":3228964864 }
        public class JournalTradeMicroResourcesOffered
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
    }

    public class JournalTradeMicroResources : JournalBase
    {
        public List<JournalTradeMicroResourcesOffered> Offered { get; set; }
        public string Received { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
        public long MarketID { get; set; }
    }

}