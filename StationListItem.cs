using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class StationListItem
    {
        public String Sistema { get; set; }
        public String Estacion { get; set; }

        public String Tipo { get; set; }

        public String DistanciaSistema { get; set; }
        public String DistanciaEstrella { get; set; }

        public String ToString()
        {
            return $"{Sistema} - {DistanciaSistema} - {Tipo} - {Estacion} - {DistanciaEstrella}";
        }

        public String ToString2()
        {
            return $"{Sistema} - {DistanciaSistema} - {Estacion} - {DistanciaEstrella}";
        }

        public String ToString3()
        {
            String resultado = Estacion.Trim();
            return $"{Sistema} - {Tipo} - {DistanciaSistema} VS {DistanciaEstrella} RESULTADO {resultado}";
        }


    }
}
