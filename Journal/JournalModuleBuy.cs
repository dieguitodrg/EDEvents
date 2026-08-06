using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2025-01-19T10:57:07Z", "event":"ModuleBuy", "Slot":"Slot04_Size1", "BuyItem":"$int_cargorack_size1_class1_name;", "BuyItem_Localised":"Bodega de carga", "MarketID":3229696256, "BuyPrice":975, "Ship":"viper", "ShipID":19 }
        public class JournalModuleBuy : JournalBase
    {
        public string Slot { get; set; }
        public string BuyItem { get; set; }
        public string BuyItem_Localised { get; set; }
        public long MarketID { get; set; }
        public int BuyPrice { get; set; }
        public string Ship { get; set; }
        public int ShipID { get; set; }
    }

}