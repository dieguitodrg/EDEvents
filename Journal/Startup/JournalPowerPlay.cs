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


    public class JournalPowerPlay : JournalBase
    {

        public string Power { get; set; }
        public int Rank { get; set; }
        public int Merits { get; set; }
        public int Votes { get; set; }
        public int TimePledged { get; set; }
    }
}