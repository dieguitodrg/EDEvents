using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"BuySuit", "Name":"TacticalSuit_Class1", "Name_Localised":"Tactician Suit", "Price":1000, "SuitID":1702914472756487, "SuitMods":[ "suit_mod_damage_resistance" ] }
        public class JournalBuySuit : JournalBase
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Price { get; set; }
        public long SuitID { get; set; }
        public List<string> SuitMods { get; set; }
    }

}