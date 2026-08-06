using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"FetchRemoteModule", "StorageSlot":42, "StoredItem":"int_hyperdrive_size5_class5", "StoredItem_Localised":"Frame Shift Drive", "ServerId":3229696256, "TransferCost":675820, "Ship":"krait_mkii", "Ship_Localised":"Krait Mk II", "ShipId":7, "TransferTime":465 }
        public class JournalFetchRemoteModule : JournalBase
    {
        public int StorageSlot { get; set; }
        public string StoredItem { get; set; }
        public string StoredItem_Localised { get; set; }
        public long ServerId { get; set; }
        public int TransferCost { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public int ShipId { get; set; }
        public int TransferTime { get; set; }
    }

}