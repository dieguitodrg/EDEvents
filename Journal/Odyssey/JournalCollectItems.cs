using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"CollectItems","Name":"personal_computer","Name_Localised":"Personal Computer","Type":"Item","OwnerID":0,"Count":3,"Stolen":false}
        public class JournalCollectItems : JournalBase
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public string Type { get; set; }
        public int OwnerID { get; set; }
        public int Count { get; set; }
        public bool Stolen { get; set; }
    }

}