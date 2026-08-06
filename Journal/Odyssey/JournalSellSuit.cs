using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SellSuit", "Name":"tacticalsuit_class1", "Name_Localised":"Tactician Suit", "Price":70000, "SuitID":1702914472756487, "SuitMods":[ "suit_quieterfootsteps" ] }
        public class JournalSellSuit : JournalBase
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Price { get; set; }
        public long SuitID { get; set; }
        public List<string> SuitMods { get; set; }
    }

}