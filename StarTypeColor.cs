using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class StarTypesType
    {
        public Dictionary<String, StarTypeColor> StarTypes { get; set; }

        public StarTypesType()
        {
            StarTypes = new Dictionary<string, StarTypeColor>();

            string startypes = @"
{
  ""O"":   { ""hex"": ""#4B6CFF"", ""rgb_256"": { ""r"": 75,  ""g"": 108, ""b"": 255 }, ""description"": ""O - Azul intenso (ingame)"" },
  ""B"":   { ""hex"": ""#6A8CFF"", ""rgb_256"": { ""r"": 106, ""g"": 140, ""b"": 255 }, ""description"": ""B - Azul brillante (ingame)"" },
  ""A"":   { ""hex"": ""#AFCBFF"", ""rgb_256"": { ""r"": 175, ""g"": 203, ""b"": 255 }, ""description"": ""A - Blanco azulado (ingame)"" },
  ""F"":   { ""hex"": ""#FFF4D6"", ""rgb_256"": { ""r"": 255, ""g"": 244, ""b"": 214 }, ""description"": ""F - Blanco cálido (ingame)"" },
  ""G"":   { ""hex"": ""#FFE39C"", ""rgb_256"": { ""r"": 255, ""g"": 227, ""b"": 156 }, ""description"": ""G - Amarillo (ingame)"" },
  ""K"":   { ""hex"": ""#FFB56B"", ""rgb_256"": { ""r"": 255, ""g"": 181, ""b"": 107 }, ""description"": ""K - Naranja (ingame)"" },
  ""M"":   { ""hex"": ""#FF6B6B"", ""rgb_256"": { ""r"": 255, ""g"": 107, ""b"": 107 }, ""description"": ""M - Rojo (ingame)"" },

  ""L"":   { ""hex"": ""#A65A2A"", ""rgb_256"": { ""r"": 166, ""g"": 90,  ""b"": 42  }, ""description"": ""L - Marrón rojizo (ingame)"" },
  ""T"":   { ""hex"": ""#6B4E8A"", ""rgb_256"": { ""r"": 107, ""g"": 78,  ""b"": 138 }, ""description"": ""T - Violeta apagado (ingame)"" },
  ""Y"":   { ""hex"": ""#4A3A5A"", ""rgb_256"": { ""r"": 74,  ""g"": 58,  ""b"": 90  }, ""description"": ""Y - Violeta oscuro (ingame)"" },

  ""AeBe"": { ""hex"": ""#C6E1FF"", ""rgb_256"": { ""r"": 198, ""g"": 225, ""b"": 255 }, ""description"": ""Herbig Ae/Be - Azul pálido (ingame)"" },
  ""TTS"":  { ""hex"": ""#FFD1A3"", ""rgb_256"": { ""r"": 255, ""g"": 209, ""b"": 163 }, ""description"": ""T Tauri - Naranja suave (ingame)"" },

  ""W"":   { ""hex"": ""#FF9ECF"", ""rgb_256"": { ""r"": 255, ""g"": 158, ""b"": 207 }, ""description"": ""Wolf-Rayet - Rosa/magenta (ingame)"" },
  ""WN"":  { ""hex"": ""#FF8ABF"", ""rgb_256"": { ""r"": 255, ""g"": 138, ""b"": 191 }, ""description"": ""WR tipo WN - Magenta suave (ingame)"" },
  ""WC"":  { ""hex"": ""#FF7A9E"", ""rgb_256"": { ""r"": 255, ""g"": 122, ""b"": 158 }, ""description"": ""WR tipo WC - Rosa fuerte (ingame)"" },
  ""WO"":  { ""hex"": ""#FF6A8A"", ""rgb_256"": { ""r"": 255, ""g"": 106, ""b"": 138 }, ""description"": ""WR tipo WO - Magenta intenso (ingame)"" },

  ""C"":   { ""hex"": ""#D6A3FF"", ""rgb_256"": { ""r"": 214, ""g"": 163, ""b"": 255 }, ""description"": ""Carbono C - Violeta claro (ingame)"" },
  ""CS"":  { ""hex"": ""#C48CFF"", ""rgb_256"": { ""r"": 196, ""g"": 140, ""b"": 255 }, ""description"": ""Carbono CS - Violeta (ingame)"" },
  ""CN"":  { ""hex"": ""#B57AFF"", ""rgb_256"": { ""r"": 181, ""g"": 122, ""b"": 255 }, ""description"": ""Carbono CN - Violeta saturado (ingame)"" },
  ""CJ"":  { ""hex"": ""#A366FF"", ""rgb_256"": { ""r"": 163, ""g"": 102, ""b"": 255 }, ""description"": ""Carbono CJ - Púrpura (ingame)"" },
  ""CH"":  { ""hex"": ""#8F52FF"", ""rgb_256"": { ""r"": 143, ""g"": 82,  ""b"": 255 }, ""description"": ""Carbono CH - Púrpura fuerte (ingame)"" },
  ""CHd"": { ""hex"": ""#7A3FFF"", ""rgb_256"": { ""r"": 122, ""g"": 63,  ""b"": 255 }, ""description"": ""Carbono CHd - Púrpura oscuro (ingame)"" },

  ""D"":   { ""hex"": ""#FFFFFF"", ""rgb_256"": { ""r"": 255, ""g"": 255, ""b"": 255 }, ""description"": ""Enana blanca D - Blanco (ingame)"" },
  ""DA"":  { ""hex"": ""#F0F8FF"", ""rgb_256"": { ""r"": 240, ""g"": 248, ""b"": 255 }, ""description"": ""DA - Blanco azulado (ingame)"" },
  ""DAB"": { ""hex"": ""#E6F0FF"", ""rgb_256"": { ""r"": 230, ""g"": 240, ""b"": 255 }, ""description"": ""DAB - Blanco frío (ingame)"" },
  ""DAO"": { ""hex"": ""#DDEAFF"", ""rgb_256"": { ""r"": 221, ""g"": 234, ""b"": 255 }, ""description"": ""DAO - Blanco azulado suave (ingame)"" },
  ""DAZ"": { ""hex"": ""#D4E4FF"", ""rgb_256"": { ""r"": 212, ""g"": 228, ""b"": 255 }, ""description"": ""DAZ - Blanco frío (ingame)"" },
  ""DAV"": { ""hex"": ""#CADDFF"", ""rgb_256"": { ""r"": 202, ""g"": 221, ""b"": 255 }, ""description"": ""DAV - Blanco azulado (ingame)"" },
  ""DB"":  { ""hex"": ""#DDE0FF"", ""rgb_256"": { ""r"": 221, ""g"": 224, ""b"": 255 }, ""description"": ""DB - Blanco violeta muy pálido (ingame)"" },
  ""DBZ"": { ""hex"": ""#D0D4FF"", ""rgb_256"": { ""r"": 208, ""g"": 212, ""b"": 255 }, ""description"": ""DBZ - Blanco violeta (ingame)"" },
  ""DBV"": { ""hex"": ""#C3C8FF"", ""rgb_256"": { ""r"": 195, ""g"": 200, ""b"": 255 }, ""description"": ""DBV - Blanco violeta suave (ingame)"" },
  ""DO"":  { ""hex"": ""#B8BDFF"", ""rgb_256"": { ""r"": 184, ""g"": 189, ""b"": 255 }, ""description"": ""DO - Blanco violeta (ingame)"" },
  ""DOV"": { ""hex"": ""#AEB3FF"", ""rgb_256"": { ""r"": 174, ""g"": 179, ""b"": 255 }, ""description"": ""DOV - Blanco violeta oscuro (ingame)"" },
  ""DQ"":  { ""hex"": ""#A3A8FF"", ""rgb_256"": { ""r"": 163, ""g"": 168, ""b"": 255 }, ""description"": ""DQ - Blanco violeta (ingame)"" },
  ""DC"":  { ""hex"": ""#999EFF"", ""rgb_256"": { ""r"": 153, ""g"": 158, ""b"": 255 }, ""description"": ""DC - Violeta muy pálido (ingame)"" },
  ""DCV"": { ""hex"": ""#8F94FF"", ""rgb_256"": { ""r"": 143, ""g"": 148, ""b"": 255 }, ""description"": ""DCV - Violeta suave (ingame)"" },
  ""DX"":  { ""hex"": ""#858AFF"", ""rgb_256"": { ""r"": 133, ""g"": 138, ""b"": 255 }, ""description"": ""DX - Violeta (ingame)"" },

  ""N"":   { ""hex"": ""#A0E6FF"", ""rgb_256"": { ""r"": 160, ""g"": 230, ""b"": 255 }, ""description"": ""Neutrones - Azul cian (ingame)"" },

  ""H"":   { ""hex"": ""#000000"", ""rgb_256"": { ""r"": 0,   ""g"": 0,   ""b"": 0   }, ""description"": ""Agujero negro"" },
  ""SupermassiveBlackHole"": { ""hex"": ""#000000"", ""rgb_256"": { ""r"": 0, ""g"": 0, ""b"": 0 }, ""description"": ""Agujero negro supermasivo"" },

  ""ProtoStar"": { ""hex"": ""#FFD8A8"", ""rgb_256"": { ""r"": 255, ""g"": 216, ""b"": 168 }, ""description"": ""Protoestrella - Naranja pastel (ingame)"" },

  ""X"": { ""hex"": ""#FFFFFF"", ""rgb_256"": { ""r"": 255, ""g"": 255, ""b"": 255 }, ""description"": ""Tipo exótico"" },
  ""Unknown"": { ""hex"": ""#888888"", ""rgb_256"": { ""r"": 136, ""g"": 136, ""b"": 136 }, ""description"": ""Desconocido"" }
}

";

            StarTypes = JsonConvert.DeserializeObject<Dictionary<string, StarTypeColor>>(startypes);

        }
    }
    public class StarTypeColor
    {
        [JsonProperty("hex")]
        public string Hex { get; set; }

        [JsonProperty("rgb_256")]
        public RGB RGB256 { get; set; }

        [JsonProperty("rgb_100")]
        public RGB2 RGB100 { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public class RGB
        {
            [JsonProperty("r")]
            public byte R { get; set; }

            [JsonProperty("g")]
            public byte G { get; set; }

            [JsonProperty("b")]
            public byte B { get; set; }
        }

        public class RGB2
        {
            [JsonProperty("r")]
            public double R { get; set; }

            [JsonProperty("g")]
            public double G { get; set; }

            [JsonProperty("b")]
            public double B { get; set; }
        }

    }

    /*
     using Newtonsoft.Json;

string jsonPath = "star_colors.json"; // Ruta al archivo JSON
string jsonContent = File.ReadAllText(jsonPath);

var starColors = JsonConvert.DeserializeObject<Dictionary<string, StarTypeColor>>(jsonContent);

// Ejemplo de uso
if (starColors.TryGetValue("G", out var gType))
{
    Console.WriteLine($"Tipo G: {gType.Description}");
    Console.WriteLine($"HEX: {gType.Hex}");
    Console.WriteLine($"RGB 256: {gType.RGB256.R}, {gType.RGB256.G}, {gType.RGB256.B}");
}
*/

/*
 {
"O": {
"hex": "#4B6CFF",
"rgb_256": { "r": 75, "g": 108, "b": 255 },
"rgb_100": { "r": 29.3, "g": 42.2, "b": 100.0 },
"description": "Estrella tipo O: gigante azul, extremadamente caliente y luminosa"
},
"B": {
"hex": "#7FAFFF",
"rgb_256": { "r": 127, "g": 175, "b": 255 },
"rgb_100": { "r": 49.6, "g": 68.4, "b": 100.0 },
"description": "Estrella tipo B: azul-blanca, muy caliente, de vida corta"
},
"A": {
"hex": "#FFFFFF",
"rgb_256": { "r": 255, "g": 255, "b": 255 },
"rgb_100": { "r": 100.0, "g": 100.0, "b": 100.0 },
"description": "Estrella tipo A: blanca brillante, con espectro fuerte de hidrógeno"
},
"F": {
"hex": "#FFFACD",
"rgb_256": { "r": 255, "g": 250, "b": 205 },
"rgb_100": { "r": 100.0, "g": 98.0, "b": 80.4 },
"description": "Estrella tipo F: blanco-amarilla, ligeramente más caliente que el Sol"
},
"G": {
"hex": "#FFD700",
"rgb_256": { "r": 255, "g": 215, "b": 0 },
"rgb_100": { "r": 100.0, "g": 84.3, "b": 0.0 },
"description": "Estrella tipo G: amarilla, como el Sol, estable y común"
},
"K": {
"hex": "#FFA500",
"rgb_256": { "r": 255, "g": 165, "b": 0 },
"rgb_100": { "r": 100.0, "g": 64.7, "b": 0.0 },
"description": "Estrella tipo K: naranja, más fría que el Sol, longeva"
},
"M": {
"hex": "#FF4500",
"rgb_256": { "r": 255, "g": 69, "b": 0 },
"rgb_100": { "r": 100.0, "g": 27.1, "b": 0.0 },
"description": "Estrella tipo M: roja, pequeña y fría, muy abundante"
},
"White Dwarf": {
"hex": "#E0FFFF",
"rgb_256": { "r": 224, "g": 255, "b": 255 },
"rgb_100": { "r": 87.8, "g": 100.0, "b": 100.0 },
"description": "Enana blanca: remanente estelar denso y caliente, sin fusión activa"
},
"Neutron": {
"hex": "#E0FFFF",
"rgb_256": { "r": 224, "g": 255, "b": 255 },
"rgb_100": { "r": 87.8, "g": 100.0, "b": 100.0 },
"description": "Estrella de neutrones: núcleo colapsado, extremadamente denso y energético"
}
}
*/
}
