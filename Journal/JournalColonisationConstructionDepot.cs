using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2025-12-03T02:13:33Z", "event":"ColonisationConstructionDepot", "MarketID":3961417474, "ConstructionProgress":0.719192, "ConstructionComplete":false, "ConstructionFailed":false, "ResourcesRequired":[ { "Name":"$aluminium_name;", "Name_Localised":"Aluminio", "RequiredAmount":45220, "ProvidedAmount":45220, "Payment":3239 }, { "Name":"$ceramiccomposites_name;", "Name_Localised":"Compuestos cerámicos", "RequiredAmount":5068, "ProvidedAmount":5068, "Payment":724 }, { "Name":"$cmmcomposite_name;", "Name_Localised":"Compuestos CMM", "RequiredAmount":51004, "ProvidedAmount":6910, "Payment":6788 }, { "Name":"$computercomponents_name;", "Name_Localised":"Componentes informáticos", "RequiredAmount":410, "ProvidedAmount":410, "Payment":1112 }, { "Name":"$copper_name;", "Name_Localised":"Cobre", "RequiredAmount":2816, "ProvidedAmount":2816, "Payment":1050 }, { "Name":"$foodcartridges_name;", "Name_Localised":"Cartuchos de alimentos", "RequiredAmount":484, "ProvidedAmount":484, "Payment":673 }, { "Name":"$fruitandvegetables_name;", "Name_Localised":"Frutas y verduras", "RequiredAmount":290, "ProvidedAmount":290, "Payment":865 }, { "Name":"$insulatingmembrane_name;", "Name_Localised":"Membrana aislante", "RequiredAmount":1648, "ProvidedAmount":1648, "Payment":11788 }, { "Name":"$liquidoxygen_name;", "Name_Localised":"Oxígeno líquido", "RequiredAmount":17514, "ProvidedAmount":17514, "Payment":2260 }, { "Name":"$medicaldiagnosticequipment_name;", "Name_Localised":"Equipo de diagnóstico médico", "RequiredAmount":50, "ProvidedAmount":50, "Payment":3609 }, { "Name":"$nonlethalweapons_name;", "Name_Localised":"Armas no letales", "RequiredAmount":50, "ProvidedAmount":50, "Payment":2503 }, { "Name":"$polymers_name;", "Name_Localised":"Polímeros", "RequiredAmount":2332, "ProvidedAmount":2332, "Payment":682 }, { "Name":"$powergenerators_name;", "Name_Localised":"Generadores de energía", "RequiredAmount":130, "ProvidedAmount":130, "Payment":3072 }, { "Name":"$semiconductors_name;", "Name_Localised":"Semiconductores", "RequiredAmount":442, "ProvidedAmount":442, "Payment":1526 }, { "Name":"$steel_name;", "Name_Localised":"Acero", "RequiredAmount":67024, "ProvidedAmount":42954, "Payment":5057 }, { "Name":"$superconductors_name;", "Name_Localised":"Superconductores", "RequiredAmount":684, "ProvidedAmount":684, "Payment":7657 }, { "Name":"$titanium_name;", "Name_Localised":"Titanio", "RequiredAmount":39730, "ProvidedAmount":39730, "Payment":5360 }, { "Name":"$water_name;", "Name_Localised":"Agua", "RequiredAmount":7636, "ProvidedAmount":7636, "Payment":662 }, { "Name":"$waterpurifiers_name;", "Name_Localised":"Purificadores de agua", "RequiredAmount":210, "ProvidedAmount":210, "Payment":849 } ] }
    public class ResourcesRequiredType
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public long RequiredAmount { get; set; }
        public long ProvidedAmount { get; set; }
        public long Payment { get; set; }
    }

    public class JournalColonisationConstructionDepot : JournalBase
    {
        public long MarketID { get; set; }
        public double ConstructionProgress { get; set; }
        public bool ConstructionComplete { get; set; }
        public bool ConstructionFailed { get; set; }
        public List<ResourcesRequiredType> ResourcesRequired { get; set; }
    }

    //{ "timestamp":"2025-11-26T20:48:44Z", "event":"ColonisationSystemClaim", "StarSystem":"Synuefe PD-P b52-4", "SystemAddress":9472952247745 }
}