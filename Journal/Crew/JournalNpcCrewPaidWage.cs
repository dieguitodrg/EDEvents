using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class JournalNpcCrewPaidWage : JournalBase
    {
        public string NpcCrewName { get; set; }
        public Int64 NpcCrewId { get; set; }
        public int Amount { get; set; }
    }
    
}
