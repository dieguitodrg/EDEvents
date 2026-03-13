using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-01-22T00:06:04Z", "event":"MaterialTrade", "MarketID":3224818944, "TraderType":"encoded", "Paid":{ "Material":"scanarchives", "Material_Localised":"Archivos de escáner no identificados", "Category":"Encoded", "Quantity":102 }, "Received":{ "Material":"consumerfirmware", "Material_Localised":"Firmware de consumo modificado", "Category":"Encoded", "Quantity":17 } }
public class MaterialTradeDetailType
    {
        public string Material { get; set; }
        public string Material_Localised { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }

    public class JournalMaterialTrade : JournalBase
    {
        
        
        public Int64 MarketID { get; set; }
        public string TraderType { get; set; }
        public MaterialTradeDetailType Paid { get; set; }
        public MaterialTradeDetailType Received { get; set; }
    }


}