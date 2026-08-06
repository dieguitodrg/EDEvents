using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-12-10T19:01:40Z", "event":"CargoTransfer", "Transfers":[ { "Type":"gallite", "Type_Localised":"Galita", "Count":788, "Direction":"toship" } ] }
        public class JournalCargoTransfer : JournalBase
    {
        public List<JournalCargoTransferTransfer> Transfers { get; set; }
    }

    public class JournalCargoTransferTransfer
    {
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public int Count { get; set; }
        public string Direction { get; set; }
    }

}