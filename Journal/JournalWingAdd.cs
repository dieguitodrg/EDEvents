using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-12-08T00:10:20Z", "event":"WingAdd", "Name":"KOSKERG" }
        public class JournalWingAdd : JournalBase
    {
        public string Name { get; set; }
    }

}