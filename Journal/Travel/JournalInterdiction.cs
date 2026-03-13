using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    public class JournalInterdicition : JournalBase
    {

        public bool Success { get; set; }
        public bool IsPlayer { get; set; }
        public string Faction { get; set; }
    }
}