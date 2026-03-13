using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class JournalNPCPaidWage : JournalBase
    {
        public string NpcCrewName { get; set; }
        public int NpcCrewId { get; set; }
        public int Amount { get; set; }
    }
    
}
