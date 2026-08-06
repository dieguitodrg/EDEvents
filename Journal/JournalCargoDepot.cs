using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-12-08T00:38:09Z", "event":"CargoDepot", "MissionID":990944830, "UpdateType":"WingUpdate", "StartMarketID":0, "EndMarketID":3229696256, "ItemsCollected":0, "ItemsDelivered":788, "TotalItemsToDeliver":860, "Progress":0.000000 }
        public class JournalCargoDepot : JournalBase
    {
        public Int64 MissionID { get; set; }
        public string UpdateType { get; set; }
        public int StartMarketID { get; set; }
        public long EndMarketID { get; set; }
        public int ItemsCollected { get; set; }
        public int ItemsDelivered { get; set; }
        public int TotalItemsToDeliver { get; set; }
        public double Progress { get; set; }
    }

}