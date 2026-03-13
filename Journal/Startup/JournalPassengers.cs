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
using System.Xml.Linq;

namespace EDCrew
{


    public class JournalPassengers: JournalBase
    {

        public List<JournalPassengersManifest> Manifest { get; set; }
    }

    public class JournalPassengersManifest
    {
        public Int64 MissionID { get; set; }

        public String Type { get; set; }

        public bool VIP { get; set; }

        public bool Wanted { get; set; }

        public int Count { get; set; }
    }


}