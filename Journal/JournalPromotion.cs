using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-12-09T19:52:55Z", "event":"Promotion", "Federation":13 }
        public class JournalPromotion : JournalBase
    {
        public int Federation { get; set; }
    }

}