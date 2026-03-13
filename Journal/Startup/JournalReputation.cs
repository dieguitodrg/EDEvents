using EDCrew;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{


    public class JournalReputation : JournalBase
    {

        public int Empire { get; set; }
        public int Federation { get; set; }

        public int Independent { get; set; }
        public int Alliance { get; set; }

        public String EmpireNote
        {
            get
            {
                return Note(Empire);
            }
        }

        public String FederationNote
        {
            get
            {
                return Note(Federation);
            }
        }

        public String AllianceNote
        {
            get
            {
                return Note(Alliance);
            }
        }

        public String IndependentNote
        {
            get
            {
                return Note(Independent);
            }
        }
        private String Note(int reputation)
        {
            if (reputation >= 90) return "Aliado";
            if (reputation >= 35) return "Amistoso";
            if (reputation >= 4) return "Cordial";
            if (reputation >= -35) return "Neutral";
            if (reputation >= -90) return "Enemistado";
            return "Hostil";
        }
    }
}