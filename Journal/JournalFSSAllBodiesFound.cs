using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"FSSAllBodiesFound", "SystemName":"Col 285 Sector YX-N b21-1", "SystemAddress":2867561768401, "Count":12 }
        public class JournalFSSAllBodiesFound : JournalBase
    {
        public string SystemName { get; set; }
        public long SystemAddress { get; set; }
        public int Count { get; set; }
    }

}