using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"AsteroidCracked", "Body":"Pru Aescs FN-S c4-71 4" }
        public class JournalAsteroidCracked : JournalBase
    {
        public string Body { get; set; }
    }

}