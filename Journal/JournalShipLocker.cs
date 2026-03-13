using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T21:27:51Z", "event":"ShipLocker", "Items":[ { "Name":"gmeds", "Name_Localised":"Medicinas G", "OwnerID":0, "Count":1 }, { "Name":"healthmonitor", "Name_Localised":"Monitor de salud", "OwnerID":0, "Count":3 }, { "Name":"insight", "OwnerID":0, "Count":1 }, { "Name":"insightdatabank", "Name_Localised":"Banco de datos de Insight", "OwnerID":0, "Count":2 }, { "Name":"compactlibrary", "Name_Localised":"Biblioteca compacta", "OwnerID":0, "Count":7 }, { "Name":"infinity", "OwnerID":0, "Count":4 }, { "Name":"insightentertainmentsuite", "Name_Localised":"Paquete de entretenimiento de Insight", "OwnerID":0, "Count":4 }, { "Name":"degradedpowerregulator", "Name_Localised":"Regulador de potencia degradado", "OwnerID":0, "Count":4 } ], "Components":[ { "Name":"graphene", "Name_Localised":"Grafeno", "OwnerID":0, "Count":1 }, { "Name":"circuitboard", "Name_Localised":"Placa base", "OwnerID":0, "Count":1 }, { "Name":"circuitswitch", "Name_Localised":"Conmutador", "OwnerID":0, "Count":4 }, { "Name":"electricalfuse", "Name_Localised":"Fusible", "OwnerID":0, "Count":1 }, { "Name":"electricalwiring", "Name_Localised":"Cables eléctricos", "OwnerID":0, "Count":3 }, { "Name":"memorychip", "Name_Localised":"Chip de memoria", "OwnerID":0, "Count":1 }, { "Name":"metalcoil", "Name_Localised":"Bobina de metal", "OwnerID":0, "Count":1 }, { "Name":"microsupercapacitor", "Name_Localised":"Microsupercondensador", "OwnerID":0, "Count":3 }, { "Name":"microtransformer", "Name_Localised":"Microtransformador", "OwnerID":0, "Count":4 }, { "Name":"motor", "OwnerID":0, "Count":4 }, { "Name":"opticalfibre", "Name_Localised":"Fibra óptica", "OwnerID":0, "Count":7 }, { "Name":"electromagnet", "Name_Localised":"Electroimán", "OwnerID":0, "Count":3 }, { "Name":"microelectrode", "Name_Localised":"Microelectrodo", "OwnerID":0, "Count":7 } ], "Consumables":[ { "Name":"healthpack", "Name_Localised":"Botiquín", "OwnerID":0, "Count":1 }, { "Name":"energycell", "Name_Localised":"Célula de energía", "OwnerID":0, "Count":2 } ], "Data":[ { "Name":"ballisticsdata", "Name_Localised":"Datos balísticos", "OwnerID":0, "Count":1 }, { "Name":"chemicalformulae", "Name_Localised":"Fórmulas químicas", "OwnerID":0, "Count":1 }, { "Name":"chemicalinventory", "Name_Localised":"Inventario químico", "OwnerID":0, "Count":3 }, { "Name":"mininganalytics", "Name_Localised":"Análisis de minería", "OwnerID":0, "Count":2 }, { "Name":"operationalmanual", "Name_Localised":"Manual de operaciones", "OwnerID":0, "Count":2 } ] }
public class ComponentType
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int OwnerID { get; set; }
        public int Count { get; set; }
    }

    public class ConsumableType
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int OwnerID { get; set; }
        public int Count { get; set; }
    }

    public class DatumType
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int OwnerID { get; set; }
        public int Count { get; set; }
    }

    public class ItemType
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int OwnerID { get; set; }
        public int Count { get; set; }
    }

    public class JournalShipLocker : JournalBase
    {
        
        
        public List<ItemType> Items { get; set; }
        public List<ComponentType> Components { get; set; }
        public List<ConsumableType> Consumables { get; set; }
        public List<DatumType> Data { get; set; }
    }


}