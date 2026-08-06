using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"EscapeInterdiction", "Interdictor":"Cmdr Vega", "IsPlayer":true, "IsThargoid":false }
        public class JournalEscapeInterdiction : JournalBase
    {
        public string Interdictor { get; set; }
        public bool IsPlayer { get; set; }
        public bool IsThargoid { get; set; }
    }

}