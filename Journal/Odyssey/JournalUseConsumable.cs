using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"UseConsumable", "Name":"healthpack", "Type":"Consumable" }
        public class JournalUseConsumable : JournalBase
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

}