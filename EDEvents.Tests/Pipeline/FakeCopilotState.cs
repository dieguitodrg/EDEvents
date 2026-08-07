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
    }
}
