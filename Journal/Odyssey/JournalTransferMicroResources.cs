using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"TransferMicroResources", "Transfers":[ { "Name":"healthpack", "Name_Localised":"Medkit", "Category":"Consumable", "Count":1, "Direction":"ToBackpack" }, { "Name":"energycell", "Name_Localised":"Energy Cell", "Category":"Consumable", "Count":1, "Direction":"ToBackpack" } ] }
        public class JournalTransferMicroResources : JournalBase
    {
        public List<JournalTransferMicroResourcesTransfer> Transfers { get; set; }
    }

    public class JournalTransferMicroResourcesTransfer
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
        public string Direction { get; set; }
    }

}