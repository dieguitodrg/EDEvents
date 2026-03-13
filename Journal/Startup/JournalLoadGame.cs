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


    public class JournalLoadGame: JournalBase
    {

        public String Commander { get; set; }
        public String FID { get; set; }

        public bool Horizons { get; set; }

        public bool Odyssey { get; set; }
        public String Ship { get; set; }
        public int ShipID { get; set; }

        public bool StartLanded { get; set; }
        public bool StartDead { get; set; }

        public String GroupName { get; set; }

        public String ShipName { get; set; }

        public String ShipIdent { get; set; }

        public Decimal FuelLevel { get; set; }

        public int FuelCapacity { get; set; }

        public String GameMode { get; set; }

        public string language { get; set; }

        public string gameversion { get; set; }

        public string build { get; set; }

        public bool IsOpenGame { get
            {
                return GameMode == "Open";
            }
        }

        public bool IsGroupGame
        {
            get
            {
                return GameMode == "Group";
            }
        }

        public Int64 Credits { get; set; }

        public Int64 Loan { get; set; }

        public bool IsSoloGame
        {
            get
            {
                return GameMode == "Solo";
            }
        }

    }

}