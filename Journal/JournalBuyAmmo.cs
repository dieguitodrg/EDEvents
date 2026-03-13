using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:52:32Z", "event":"BuyAmmo", "Cost":179 }
public class JournalBuyAmmo : JournalBase
    {
        
        
        public int Cost { get; set; }
    }


}