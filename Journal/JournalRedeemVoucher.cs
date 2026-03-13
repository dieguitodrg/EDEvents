using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T23:37:37Z", "event":"RedeemVoucher", "Type":"bounty", "Amount":3743124, "Factions":[ { "Faction":"Hakurei Stargaze Musketeers", "Amount":3743124 } ] }
public class FactionVoucherType
    {
        public string Faction { get; set; }
        public int Amount { get; set; }
    }

    public class JournalRedeemVoucher : JournalBase
    {
        
        
        public string Type { get; set; }
        public int Amount { get; set; }
        public List<FactionVoucherType> Factions { get; set; }
    }


}