using System;
using System.Collections.Generic;
using EDCrew;
using EDCrew.Pipeline;

namespace EDCrew.Tests.Pipeline
{
    /// <summary>
    /// Doble de prueba de ICopilotState. Usa Counters y CategoriasInventario reales.
    /// </summary>
    public class FakeCopilotState : ICopilotState
    {
        public Counters Counters { get; } = new Counters();

        public CategoriasInventario CategoriasInventario { get; }

        public string StarSystem { get; set; }

        public Int64 SystemAddress { get; set; }

        public string StationName { get; set; }

        public JournalPowerplayRank JournalPowerRank { get; set; }

        public JournalPowerplayMerits JournalPowerMerits { get; set; }

        public JournalStatistics JournalStatistics { get; set; }

        public JournalSquadronStartup Squadron { get; set; }

        public Dictionary<string, JournalMissionAccepted> MissionAccepted { get; } = new Dictionary<string, JournalMissionAccepted>();

        public Dictionary<decimal, JournalColonisationConstructionDepot> ColonisationProgress { get; } = new Dictionary<decimal, JournalColonisationConstructionDepot>();

        public string Commander { get; set; }

        public string Ship { get; set; }

        public string ShipName { get; set; }

        public string ShipIdent { get; set; }

        public int ShipId { get; set; }

        public List<JournalFSSBodySignals> BodySignals { get; } = new List<JournalFSSBodySignals>();

        public Int64 OldSystemAddress { get; set; }

        public JournalShipTargeted EventScannedShip { get; set; }

        public JournalShipTargeted EventMarked { get; set; }

        public bool StatusScanned { get; set; }

        public string Promptmfd { get; set; }

        public string Bountyprompt { get; set; }

        public DateTime LastKill { get; set; }

        public Dictionary<string, int> FactionVictims { get; } = new Dictionary<string, int>();

        public string FaccionObjetivo { get; set; }

        public bool SpeakNpc { get; set; }

        public bool SpeakSystem { get; set; }

        public bool FetchingSubsystem { get; set; }

        public string Subsystem { get; set; }

        public Dictionary<string, bool> Scanned { get; } = new Dictionary<string, bool>();

        public Dictionary<string, Dictionary<string, bool>> DictionaryScanned { get; } = new Dictionary<string, Dictionary<string, bool>>();

        public FakeCopilotState()
        {
            CategoriasInventario = new CategoriasInventario();
            CategoriasInventario.Inventario = new Inventario
            {
                Raw = new List<InventoryMaterialType>(),
                Encoded = new List<InventoryMaterialType>(),
                Manufactured = new List<InventoryMaterialType>()
            };
            CategoriasInventario.Categorias = new List<List<List<string>>>
            {
                new List<List<string>> { new List<string>() }
            };
        }

        /// <summary>
        /// Añade un material crudo al inventario y lo registra en una lista propia
        /// de nivel 1 para que Maximo() devuelva 300.
        /// </summary>
        public void AddRawMaterial(string name, string localised, int count)
        {
            CategoriasInventario.Inventario.Raw.Add(new InventoryMaterialType
            {
                Name = name,
                Name_Localised = localised,
                Count = count
            });
            CategoriasInventario.Categorias[0].Add(new List<string> { localised ?? name });
        }

        public void AddMissionAccepted(string key, JournalMissionAccepted mission)
        {
            MissionAccepted[key] = mission;
        }

        public void RemoveMissionAccepted(string key)
        {
            MissionAccepted.Remove(key);
        }

        public void AddScanned(string key, bool value)
        {
            Scanned[key] = value;
        }

        public void AddDictionaryScanned(string systemAddress, string body, string speciesLocalised, bool analysed)
        {
            string key = $"{body}_{speciesLocalised}";
            if (!DictionaryScanned.ContainsKey(systemAddress))
            {
                DictionaryScanned[systemAddress] = new Dictionary<string, bool>();
            }
            DictionaryScanned[systemAddress][key] = analysed;
        }
    }
}
