using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"DatalinkVoucher","Reward":50000,"VictimFaction":"Lencali Freedom Party","PayeeFaction":"Jarildekald Public Industry"}
        public class JournalDatalinkVoucher : JournalBase
    {
        public int Reward { get; set; }
        public string VictimFaction { get; set; }
        public string PayeeFaction { get; set; }
    }

}