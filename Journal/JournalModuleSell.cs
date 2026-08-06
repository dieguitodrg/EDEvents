using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2025-01-19T10:56:45Z", "event":"ModuleSell", "MarketID":3229696256, "Slot":"Slot04_Size1", "SellItem":"$int_fueltank_size1_class3_name;", "SellItem_Localised":"Tanque de combustible", "SellPrice":975, "Ship":"viper", "ShipID":19 }
        public class JournalModuleSell : JournalBase
    {
        public long MarketID { get; set; }
        public string Slot { get; set; }
        public string SellItem { get; set; }
        public string SellItem_Localised { get; set; }
        public int SellPrice { get; set; }
        public string Ship { get; set; }
        public int ShipID { get; set; }
    }

}