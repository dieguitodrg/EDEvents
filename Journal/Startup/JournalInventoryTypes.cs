using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    public class InventoryMaterialType
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
    }

    public class Inventario
    {
        public List<InventoryMaterialType> Raw { get; set; }
        public List<InventoryMaterialType> Manufactured { get; set; }
        public List<InventoryMaterialType> Encoded { get; set; }
    }

}
