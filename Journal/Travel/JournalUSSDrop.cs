using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T23:15:43Z", "event":"USSDrop", "USSType":"$USS_Type_MissionTarget;", "USSType_Localised":"Objetivo", "USSThreat":6 }
public class JournalUSSDrop : JournalBase
    {
        
        
        public string USSType { get; set; }
        public string USSType_Localised { get; set; }
        public int USSThreat { get; set; }
    }


}