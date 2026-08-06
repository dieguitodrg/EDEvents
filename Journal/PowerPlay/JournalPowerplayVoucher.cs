using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"PowerplayVoucher", "Power":"Edmund Mahon", "Systems":[ "LHS 3447", "Sol", "Eranin" ] }
        public class JournalPowerplayVoucher : JournalBase
    {
        public string Power { get; set; }
        public List<string> Systems { get; set; }
    }

}