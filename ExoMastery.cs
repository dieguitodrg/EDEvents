using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class ExoMastery
    {
        [JsonProperty("Nombre del sistema")]
        public string Nombredelsistema { get; set; }

        [JsonProperty("Nombre del cuerpo")]
        public string Nombredelcuerpo { get; set; }

        [JsonProperty("Body Subtype")]
        public string BodySubtype { get; set; }

        [JsonProperty("Distancia para llegar")]
        public string Distanciaparallegar { get; set; }

        [JsonProperty("Landmark Subtype")]
        public string LandmarkSubtype { get; set; }
        public string Value { get; set; }
        public string Count { get; set; }
        public string Saltos { get; set; }

        public bool Completado { get; set; }

        public String ToString()
        {
            return $"{Nombredelsistema} - {Nombredelcuerpo} - {Distanciaparallegar} Ls - {LandmarkSubtype} - {Value}";
        }

    }
}
