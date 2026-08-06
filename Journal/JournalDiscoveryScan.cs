using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"DiscoveryScan","SystemAddress":3657533690578,"Bodies":12}
        public class JournalDiscoveryScan : JournalBase
    {
        public long SystemAddress { get; set; }
        public int Bodies { get; set; }
    }

}