using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T21:13:39Z", "event":"FSDTarget", "Name":"Matire", "SystemAddress":672833021345, "StarClass":"M", "RemainingJumpsInRoute":1 }
public class JournalFSDTarget : JournalBase
    {
        public string Name { get; set; }
        public Int64 SystemAddress { get; set; }
        public string StarClass { get; set; }
        public int RemainingJumpsInRoute { get; set; }
    }


}