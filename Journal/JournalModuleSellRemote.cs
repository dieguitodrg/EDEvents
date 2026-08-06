using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"ModuleSellRemote", "StorageSlot":57, "SellItem":"int_engine_size3_class5", "SellItem_Localised":"Thrusters", "ServerId":3229696256, "SellPrice":495215, "Ship":"krait_mkii", "Ship_Localised":"Krait Mk II", "ShipId":7 }
        public class JournalModuleSellRemote : JournalBase
    {
        public int StorageSlot { get; set; }
        public string SellItem { get; set; }
        public string SellItem_Localised { get; set; }
        public long ServerId { get; set; }
        public int SellPrice { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public int ShipId { get; set; }
    }

}