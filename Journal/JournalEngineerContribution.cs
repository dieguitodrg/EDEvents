using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"EngineerContribution", "Engineer":"Elvira Martuuk", "EngineerID":300160, "Type":"Commodity", "Commodity":"soontillrelics", "Commodity_Localised":"Soontill Relics", "Quantity":2, "TotalQuantity":3 }
        public class JournalEngineerContribution : JournalBase
    {
        public string Engineer { get; set; }
        public int EngineerID { get; set; }
        public string Type { get; set; }
        public string Commodity { get; set; }
        public string Commodity_Localised { get; set; }
        public int Quantity { get; set; }
        public int TotalQuantity { get; set; }
    }

}