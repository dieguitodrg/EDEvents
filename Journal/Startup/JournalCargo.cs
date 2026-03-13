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


    public class JournalCargo : JournalBase
    {
        public String Vessel { get; set; }

        public List<JournalCargoInventory> Inventory { get; set;}

        //TODO Si está vacío Inventory hay que leer Cargo.json
    }

    public class JournalCargoInventory : Localizer
    {
        public String Name { get; set; }

        public String Name_Localised { get; set; }

        public String DisplayName
        {
            get
            {
                return this.Show(Name, Name_Localised);
            }
        }

        public Int64 Count { get; set; }

        public int Stolen { get; set; }

        public Int64 MissionID { get; set; }

    }
}


