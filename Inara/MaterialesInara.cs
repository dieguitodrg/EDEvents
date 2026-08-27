using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDCrew
{
    /// <summary>
    /// Catálogo de materiales/commodities de Inara: data-value (id) como clave
    /// y nombre localizado como valor. Fuente: desplegable de
    /// https://inara.cz/elite/commodities/ (option data-value).
    /// </summary>
    public static class MaterialesInara
    {
        public static readonly IReadOnlyDictionary<int, string> Catalogo = new Dictionary<int, string>
        {
            { 5, "Aceite mineral" },
            { 10487, "Acero" },
            { 96, "Agentes nerviosos" },
            { 139, "Agua" },
            { 10249, "Alejandrita" },
            { 15, "Algas" },
            { 37, "Aluminio" },
            { 10270, "Anomaly Particles" },
            { 91, "Antigüedades" },
            { 88, "Armas de batalla" },
            { 78, "Armas no letales" },
            { 79, "Armas personales" },
            { 121, "Artefactos antiguos" },
            { 131, "Arte poco común" },
            { 65, "Autofabricantes" },
            { 10211, "Bancos de genes" },
            { 135, "Baratijas de fortuna oculta" },
            { 51, "Bauxita" },
            { 10247, "Benitoíta" },
            { 38, "Berilio" },
            { 52, "Bertrandita" },
            { 106, "Bismuto" },
            { 80, "Blindaje reactivo" },
            { 152, "Bobina de emisión magnética" },
            { 10456, "Bone Fragments" },
            { 148, "Bromellita" },
            { 17, "Café" },
            { 122, "Cajas negras" },
            { 10212, "Capsulas del tiempo" },
            { 16, "Carne de animales" },
            { 23, "Carne sintética" },
            { 19, "Cartuchos de alimentos" },
            { 61, "Catalizadores avanzados" },
            { 10, "Cerveza" },
            { 77, "Chatarra" },
            { 39, "Cobalto" },
            { 40, "Cobre" },
            { 159, "Colector de escape" },
            { 55, "Coltán" },
            { 4, "Combustible de hidrógeno" },
            { 104, "Componentes de deslizador" },
            { 67, "Componentes informáticos" },
            { 100, "Compuestos cerámicos" },
            { 140, "Compuestos CMM" },
            { 161, "Conductos de transf. de energía" },
            { 102, "Constructores" },
            { 153, "Convertidor de energía" },
            { 10451, "Coral Sap" },
            { 10235, "Corazón Thargoide" },
            { 172, "Correspondencia encriptada" },
            { 110, "Criolita" },
            { 146, "Cristales de monohidrato de metanol" },
            { 73, "Cuero" },
            { 10488, "Curated Commodity Package" },
            { 10459, "Cyst Specimen" },
            { 10215, "Cápsula de escape dañada" },
            { 129, "Cápsula de escape ocupada" },
            { 10440, "Cápsula de escape vacía" },
            { 158, "Células energía auxiliar" },
            { 36, "Células madre" },
            { 134, "Datos comerciales" },
            { 173, "Datos encriptados" },
            { 180, "Datos tácticos" },
            { 162, "Deflector de radiación" },
            { 144, "Diamante de baja temperatura" },
            { 160, "Distribuidor de iones" },
            { 10159, "Efectos personales" },
            { 9, "Electrodomésticos" },
            { 10161, "Enlace Thargoide" },
            { 71, "Enriquecimiento terrestre" },
            { 164, "Equipamiento de supervivencia" },
            { 103, "Equipamiento geológico" },
            { 86, "Equipamiento marino" },
            { 154, "Equipo de diagnóstico médico" },
            { 53, "Esclavos" },
            { 49, "Esclavos imperiales" },
            { 119, "Escáner muónico" },
            { 10251, "Esporas de molusco" },
            { 34, "Estabilizadores de combate" },
            { 97, "Estabilizadores de superficie" },
            { 3, "Explosivos" },
            { 31, "Extractores de minerales" },
            { 10264, "Fertilizante Rockforth" },
            { 10255, "Fluido de molusco" },
            { 20, "Frutas y verduras" },
            { 10153, "Féretro guardián" },
            { 41, "Galio" },
            { 56, "Galita" },
            { 83, "Generadores de energía" },
            { 111, "Goslarita" },
            { 10248, "Grandidierita" },
            { 21, "Grano" },
            { 10486, "Haematite" },
            { 124, "Hafnio 178" },
            { 145, "Hidrato de metano" },
            { 147, "Hidróxido de litio" },
            { 85, "Hornos microbianos" },
            { 10452, "Impure Spire Mineral" },
            { 43, "Indio" },
            { 57, "Indita" },
            { 126, "Inteligencia militar" },
            { 151, "Interconect. de eyector térmico" },
            { 178, "Investigaciones científicas" },
            { 168, "Jadeíta" },
            { 10209, "Joyería antigua" },
            { 107, "Lantano" },
            { 58, "Lepidolita" },
            { 95, "Licor de caña" },
            { 11, "Licores" },
            { 44, "Litio" },
            { 10240, "Llave antigua" },
            { 66, "Líquenes biorreductores" },
            { 185, "Mangueras de microtejidos" },
            { 10160, "Materia biológica Thargoide" },
            { 10220, "Materiales de investigación prohibida" },
            { 1, "Medicinas agrícolas" },
            { 166, "Medicinas avanzadas" },
            { 33, "Medicinas básicas" },
            { 141, "Membrana aislante" },
            { 10252, "Membrana de molusco" },
            { 125, "Memorias de reconocimiento grandes" },
            { 10208, "Memorias de reconocimiento pequeñas" },
            { 101, "Metaaleaciones" },
            { 156, "Microcontroladores" },
            { 118, "Minas terrestres" },
            { 116, "Moissanita" },
            { 10245, "Monacita" },
            { 62, "Monitores de animales" },
            { 182, "Motores de articulación" },
            { 10439, "Muestra de tejido caústico" },
            { 10236, "Muestra de tejido de basilisco Thargoide" },
            { 10234, "Muestra de tejido de cíclope Thargoide" },
            { 10238, "Muestra de tejido de explorador Thargoide" },
            { 10447, "Muestra de tejido de fauces de Titan" },
            { 10441, "Muestra de tejido de Glaive Thargoide" },
            { 10239, "Muestra de tejido de Hidra Thargoide" },
            { 10237, "Muestra de tejido de medusa Thargoide" },
            { 10443, "Muestra de tejido de Titan" },
            { 10446, "Muestra de tejido parcial de fauces de Titan" },
            { 10444, "Muestra de tejido parcial de Titan" },
            { 10445, "Muestra de tejido profundo de fauces de Titan" },
            { 10442, "Muestra de tejido profundo de Titan" },
            { 179, "Muestras científicas" },
            { 170, "Muestras comerciales" },
            { 10163, "Muestras de tecnología Thargoide" },
            { 174, "Muestras geológicas" },
            { 10246, "Musgravita" },
            { 10253, "Mycelium de molusco" },
            { 167, "Nanorrompedores" },
            { 12, "Narcóticos" },
            { 183, "Neotejido aislante" },
            { 10166, "Núcleo de datos" },
            { 90, "Núcleos SAP-8" },
            { 10435, "Onionhead Gamma Strain" },
            { 10154, "Orbe guardián" },
            { 10458, "Organ Sample" },
            { 42, "Oro" },
            { 72, "Osmio" },
            { 137, "Oxígeno líquido" },
            { 84, "Painita" },
            { 45, "Paladio" },
            { 184, "Paquete de telemetría" },
            { 138, "Peróxido de hidrógeno" },
            { 18, "Pescado" },
            { 6, "Pesticidas" },
            { 10165, "Piedras preciosas" },
            { 112, "Pirofilita" },
            { 163, "Placa de anclaje reforzada" },
            { 169, "Planes de asalto" },
            { 127, "Planes militares" },
            { 133, "Planos técnicos" },
            { 46, "Plata" },
            { 81, "Platino" },
            { 26, "Polímeros" },
            { 35, "Potenciadores de rendimiento" },
            { 143, "Praseodimio" },
            { 177, "Prisioneros políticos" },
            { 87, "Procesadores atmosféricos" },
            { 10449, "Protective Membrane Scrap" },
            { 130, "Prototipos tecnológicos" },
            { 82, "Purificadores de agua" },
            { 123, "Químicos experimentales" },
            { 98, "Reagentes sintéticos" },
            { 149, "Red de energía" },
            { 99, "Refugio de evacuación" },
            { 117, "Reguladores estructurales" },
            { 175, "Rehenes" },
            { 10155, "Reliquia guardián" },
            { 10437, "Reliquia no clasificada" },
            { 89, "Reliquias de IA" },
            { 10210, "Reliquias de la vieja Tierra" },
            { 10164, "Reliquias de pioneros espaciales" },
            { 76, "Residuos biológicos" },
            { 32, "Residuos químicos" },
            { 54, "Residuos tóxicos" },
            { 10162, "Resina Thargoide" },
            { 10207, "Restos de accidentes" },
            { 10221, "Restos de fósiles" },
            { 10243, "Rhodplumsita" },
            { 70, "Robótica" },
            { 7, "Ropa" },
            { 59, "Rutilo" },
            { 142, "Samario" },
            { 29, "Segadoras de cultivos" },
            { 10453, "Semi-Refined Spire Mineral" },
            { 28, "Semiconductores" },
            { 155, "Sensor diagnóstico de hardware" },
            { 10226, "Sensor Thargoide" },
            { 69, "Separadores resonantes" },
            { 10244, "Serendibita" },
            { 63, "Sistemas de hidroponía" },
            { 186, "Sonda Thargoide" },
            { 27, "Superconductores" },
            { 150, "Suspensión HN" },
            { 120, "Taaffeíta" },
            { 13, "Tabaco" },
            { 10156, "Tablilla guardián" },
            { 108, "Talio" },
            { 47, "Tantalio" },
            { 8, "Tecnología de consumo" },
            { 157, "Tejido de categoría militar" },
            { 10256, "Tejido de cerebro de molusco" },
            { 10261, "Tejido de cáscara de cápsula" },
            { 10263, "Tejido de la vaina" },
            { 10259, "Tejido de núcleo de cápsula" },
            { 10258, "Tejido de superficie de cápsula" },
            { 10260, "Tejido exterior de cápsula" },
            { 10257, "Tejido muerto de cápsula" },
            { 165, "Tejidos conductivos" },
            { 74, "Tejidos naturales" },
            { 75, "Tejidos sintéticos" },
            { 10254, "Tejido suave de molusco" },
            { 181, "Terminales modulares" },
            { 10450, "Thargoid Bio-storage Capsule" },
            { 10438, "Thargoid Orthrus Tissue Sample" },
            { 10448, "Thargoid Scythe Tissue Sample" },
            { 10457, "Titan Drive Component" },
            { 48, "Titanio" },
            { 109, "Torio" },
            { 68, "Trajes de protección" },
            { 132, "Transmisiones rebeldes" },
            { 10268, "Tratamiento agronómico" },
            { 10269, "Tritio" },
            { 22, "Té" },
            { 10157, "Tótem guardián" },
            { 10167, "Unidad de confinamiento de antimateria" },
            { 176, "Unidad de datos inestable" },
            { 105, "Unidades de enfriamiento térmico" },
            { 60, "Uraninita" },
            { 50, "Uranio" },
            { 10158, "Urna guardián" },
            { 10262, "Vaina de mesoglea" },
            { 171, "Valija diplomática" },
            { 14, "Vino" },
            { 10219, "Ídolo misterioso" },
            { 10250, "Ópalo de vacío" }
        };

        static readonly Dictionary<string, int> _porNombre =
            Catalogo.ToDictionary(kv => Normalizar(kv.Value), kv => kv.Key, StringComparer.Ordinal);

        /// <summary>
        /// Nombre del material dado su id (data-value). null si no existe.
        /// </summary>
        public static string GetNombre(int key)
        {
            return Catalogo.TryGetValue(key, out string nombre) ? nombre : null;
        }

        /// <summary>
        /// Nombre del material dado su id. Devuelve false si no existe.
        /// </summary>
        public static bool TryGetNombre(int key, out string nombre)
        {
            return Catalogo.TryGetValue(key, out nombre);
        }

        /// <summary>
        /// Id del material dado su nombre (ignora mayúsculas y acentos).
        /// null si no existe.
        /// </summary>
        public static int? GetId(string nombre)
        {
            if (String.IsNullOrEmpty(nombre)) return null;
            return _porNombre.TryGetValue(Normalizar(nombre), out int id) ? id : (int?)null;
        }

        /// <summary>
        /// Id del material dado su nombre (ignora mayúsculas y acentos).
        /// Devuelve false si no existe.
        /// </summary>
        public static bool TryGetId(string nombre, out int id)
        {
            id = 0;
            if (String.IsNullOrEmpty(nombre)) return false;
            return _porNombre.TryGetValue(Normalizar(nombre), out id);
        }

        static string Normalizar(string text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder(formD.Length);
            foreach (char c in formD)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().ToLowerInvariant();
        }
    }
}
