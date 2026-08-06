using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"Synthesis", "Name":"Repair Basic", "Materials":[ { "Name":"iron", "Count":2 }, { "Name":"nickel", "Count":1 } ] }
        public class JournalSynthesisMaterial
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class JournalSynthesis : JournalBase
    {
        public string Name { get; set; }
        public List<JournalSynthesisMaterial> Materials { get; set; }
    }

}