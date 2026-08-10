using System;
using System.Collections.Generic;
using System.Linq;

namespace EDCrew
{
    /// <summary>
    /// Ensambla el contenido de la pantalla lógica (texto, color, posición) a
    /// partir del estado del host y del Log/cursores del servicio. Es un
    /// ensamblado de texto puro: no conoce Capture ni Direct3D. Reemplaza el
    /// cuerpo de SetDisplay de Form1.
    /// </summary>
    public class PrompterContent
    {
        private const int altofuente = 20;
        private const int MaxLines = 38;

        public List<PromptLine> Build(IPrompterHost host, IReadOnlyDictionary<PromptType, List<string>> log, int cursor, PromptType whatTo)
        {
            var lines = new List<PromptLine>();

            lines.AddRange(CreatePrompt(0x00, 0x7F, 0, 20, 20, Header(host)));
            lines.AddRange(CreatePrompt(0xFF, 0xFF, 0xFF, 20, 40, SectionTitle(host, whatTo)));

            int i = 60;

            switch (whatTo)
            {
                case PromptType.MissionAccepted:
                    {
                        if (host.MissionAccepted != null)
                        {
                            foreach (KeyValuePair<string, JournalMissionAccepted> kv in host.MissionAccepted.ToList())
                            {
                                JournalMissionAccepted journall = kv.Value;
                                String prompt = $"{journall.LocalisedName} {journall.DestinationSystem} {journall.DestinationStation} {journall.Expiry} {journall.Reward}";
                                lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, prompt));
                                i += altofuente + 2;
                            }
                        }
                        break;
                    }
                case PromptType.Statistics:
                    {
                        if (host.JournalStatistics == null) break;

                        String bank = $"Créditos: {host.JournalStatistics.Bank_Account.Current_Wealth} Naves: {host.JournalStatistics.Bank_Account.Owned_Ship_Count} Trajes: {host.JournalStatistics.Bank_Account.Suits_Owned} Armas: {host.JournalStatistics.Bank_Account.Weapons_Owned}";
                        lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, bank));
                        i += altofuente + 2;

                        String combat = $"Recompensas: {host.JournalStatistics.Combat.Bounties_Claimed} - {host.JournalStatistics.Combat.Bounty_Hunting_Profit} créditos";
                        lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, combat));
                        i += altofuente + 2;

                        combat = $"Zonas de conflicto: Baja {host.JournalStatistics.Combat.ConflictZone_Low_Wins}/{host.JournalStatistics.Combat.ConflictZone_Low} Media: {host.JournalStatistics.Combat.ConflictZone_Medium_Wins}/{host.JournalStatistics.Combat.ConflictZone_Medium} Alta: {host.JournalStatistics.Combat.ConflictZone_High_Wins}/{host.JournalStatistics.Combat.ConflictZone_High}";
                        lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, combat));
                        i += altofuente + 2;

                        combat = $"Bonos: {host.JournalStatistics.Combat.Combat_Bonds} - {host.JournalStatistics.Combat.Combat_Bond_Profits} créditos";
                        lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, combat));
                        i += altofuente + 2;

                        String trade = $"Comercio: {host.JournalStatistics.Trading.Goods_Sold} Toneladas {host.JournalStatistics.Trading.Market_Profits} Créditos en {host.JournalStatistics.Trading.Markets_Traded_With} mercados";
                        lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, trade));
                        i += altofuente + 2;

                        break;
                    }
                case PromptType.ExoMastery:
                    {
                        if (host.ExoMasteryRoute != null)
                        {
                            List<ExoMastery> todo = host.ExoMasteryRoute.Where(x => !x.Completado).ToList();
                            int j = 0;
                            foreach (ExoMastery item in todo.Take(todo.Count() > MaxLines ? MaxLines : todo.Count()))
                            {
                                if (cursor != j)
                                {
                                    lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, item.ToString()));
                                }
                                else
                                {
                                    lines.AddRange(CreatePrompt(0xB0, 0xFF, 0x00, 20, i, item.ToString()));
                                }
                                j++;
                                i += altofuente + 2;
                            }
                        }
                        else lines.AddRange(CreatePrompt(0xFF, 0, 0, 20, i, "Sin Ruta Exobiología"));

                        break;
                    }
                case PromptType.Conflictos:
                    {
                        if (host.ConflictosUUCC != null)
                        {
                            int j = 0;
                            foreach (StationListItem item in host.ConflictosUUCC.ToList().Take(host.ConflictosUUCC.Count() > MaxLines ? MaxLines : host.ConflictosUUCC.Count()))
                            {
                                if (cursor != j)
                                {
                                    lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, item.ToString3()));
                                }
                                else
                                {
                                    lines.AddRange(CreatePrompt(0xB0, 0xFF, 0x00, 20, i, item.ToString3()));
                                }
                                j++;
                                i += altofuente + 2;
                            }
                        }
                        else lines.AddRange(CreatePrompt(0xFF, 0, 0, 20, i, "Conflictos sin resultados"));
                        break;
                    }

                case PromptType.Ordenes:
                    {
                        if (host.OrdenesUUCC != null)
                        {
                            int j = 0;
                            foreach (Order item in host.OrdenesUUCC.ToList().Take(host.OrdenesUUCC.Count() > MaxLines ? MaxLines : host.OrdenesUUCC.Count()))
                            {
                                if (cursor != j)
                                {
                                    lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, item.ToString()));
                                }
                                else
                                {
                                    lines.AddRange(CreatePrompt(0xB0, 0xFF, 0x00, 20, i, item.ToString()));
                                }
                                j++;
                                i += altofuente + 2;
                            }
                        }
                        else lines.AddRange(CreatePrompt(0xFF, 0, 0, 20, i, "Sin Órdenes"));
                        break;
                    }

                case PromptType.InterestellarFactor:
                    {
                        if (host.FactoresInterestelar != null)
                        {
                            int j = 0;
                            foreach (StationListItem item in host.FactoresInterestelar.ToList().Take(host.FactoresInterestelar.Count() > MaxLines ? MaxLines : host.FactoresInterestelar.Count()))
                            {
                                if (cursor != j)
                                {
                                    lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, item.ToString2()));
                                }
                                else
                                {
                                    lines.AddRange(CreatePrompt(0xB0, 0xFF, 0x00, 20, i, item.ToString2()));
                                }
                                j++;
                                i += altofuente + 2;
                            }
                        }
                        else lines.AddRange(CreatePrompt(0xFF, 0, 0, 20, i, "Factores interestelar sin resultados"));
                        break;
                    }
                case PromptType.MaterialTrader:
                    {
                        if (host.Comerciantes != null)
                        {
                            int j = 0;
                            foreach (StationListItem item in host.Comerciantes.ToList().Take(host.Comerciantes.Count() > MaxLines ? MaxLines : host.Comerciantes.Count()))
                            {
                                if (cursor != j)
                                {
                                    lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, item.ToString()));
                                }
                                else
                                {
                                    lines.AddRange(CreatePrompt(0xB0, 0xFF, 0x00, 20, i, item.ToString()));
                                }

                                i += altofuente + 2;
                                j++;
                            }
                        }
                        else lines.AddRange(CreatePrompt(0xFF, 0, 0, 20, i, "Comerciantes sin resultados"));
                        break;
                    }
                case PromptType.BodySignals:
                    {
                        if (host.BodySignals != null)
                        {
                            int j = 0;

                            Dictionary<String, Dictionary<String, bool>> Scanned2 = host.DictionaryStore != null ? host.DictionaryStore.LoadScanned2(host.Commander) : new Dictionary<String, Dictionary<String, bool>>();

                            foreach (JournalFSSBodySignals journal in host.BodySignals.ToList())
                            {
                                String message = journal.BodyName;

                                if (journal.Signals != null)
                                {
                                    foreach (JournalFSSBodySignalsSignal s in journal.Signals)
                                    {
                                        message += " " + s.Type_Localised + "(" + s.Count + ")";
                                    }
                                }

                                if (cursor != j)
                                {
                                    lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, message));
                                }
                                else
                                {
                                    lines.AddRange(CreatePrompt(0xB0, 0xFF, 0x00, 20, i, message));
                                }

                                i += altofuente + 2;
                                j++;
                            }

                            String systemaddress = host.SystemAddress.ToString();

                            if (Scanned2.ContainsKey(systemaddress))
                            {
                                foreach (String skey2 in Scanned2[systemaddress].Keys)
                                {
                                    lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, $"{skey2} {Scanned2[systemaddress][skey2]}"));
                                    i += altofuente + 2;
                                }
                            }
                        }
                        break;
                    }
                case PromptType.InventoryPanel:
                    {
                        if (host.CategoriasInventario != null)
                        {
                            int it = 0;
                            String level = "";
                            foreach (List<List<String>> tipo in host.CategoriasInventario.Categorias)
                            {
                                String cabecera = "";
                                level = "";
                                switch (it)
                                {
                                    case 0:
                                        { cabecera = "Materia Prima"; break; }
                                    case 1:
                                        { cabecera = "Manufacturados"; break; }
                                    case 2:
                                        { cabecera = "Codificados"; break; }

                                }
                                lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, level + cabecera));
                                i += altofuente + 2;

                                level = "    ";

                                foreach (List<String> categoria in tipo)
                                {
                                    String display = "";

                                    foreach (String elemento in categoria)
                                    {
                                        if (elemento != String.Empty)
                                        {
                                            display += elemento;
                                            display += ": " + host.CategoriasInventario.Cantidad(elemento) + "/" + host.CategoriasInventario.Maximo(elemento) + " ";
                                        }
                                    }

                                    lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, level + display));
                                    i += altofuente + 2;
                                }
                                it++;
                            }
                        }
                        break;
                    }
                default:
                    {
                        i = Display(log, whatTo, lines, i);
                        if (whatTo == PromptType.Combat && host.EventMarked != null)
                        {
                            String estado = host.EventMarked.LegalStatus == "Wanted" ? $", buscado con recompensa de {host.EventMarked.Bounty} créditos" : "";
                            String pilotname = host.EventMarked.PilotName_Localised != "" ? host.EventMarked.PilotName_Localised : host.EventMarked.PilotName;
                            String modelo = host.EventMarked.Ship_Localised != null ? host.EventMarked.Ship_Localised : host.EventMarked.Ship;
                            String prompt = $"Piloto {pilotname}, modelo {modelo}, facción {host.EventMarked.Faction} {estado}";
                            lines.AddRange(CreatePrompt(0xFF, 0xFF, 0xFF, 20, i, prompt));
                        }
                        break;
                    }
            }

            return lines;
        }

        String Header(IPrompterHost host)
        {
            JournalPowerplayMerits merits = host.JournalPowerMerits;
            JournalPowerplayRank rank = host.JournalPowerRank;

            return String.Format("{3} BRABEN OS v{1} (C) 1984-{1} LICENSED TO CMDR {2} SN {0} {5} {4} [{6}]",
                host.ShipName,
                System.DateTime.Now.Year + 1286,
                host.Commander,
                host.Ship,
                merits != null ? merits.TotalMerits.ToString() : "",
                rank != null ? rank.Power : merits != null ? merits.Power : "",
                rank != null ? rank.Rank.ToString() : "");
        }

        String SectionTitle(IPrompterHost host, PromptType whatTo)
        {
            switch (whatTo)
            {
                case PromptType.Event: return "Eventos";
                case PromptType.Message: return "Mensajes";
                case PromptType.Command: return "Comandos";
                case PromptType.Inventory: return "Inventario";
                case PromptType.Navigation: return "Navegación";
                case PromptType.Combat: return $"Combate {host.Counters.Combat}/{host.FaccionObjetivo}: {host.Counters.Faction}/{host.Counters.Total}";
                case PromptType.MissionAccepted: return "Misiones";
                case PromptType.MissionCompleted: return "Misiones Completadas";
                case PromptType.MissionFailed: return "Misiones Fallidas";

                case PromptType.InterestellarFactor: return $"Factor interestelar {host.StarSystem}";
                case PromptType.MaterialTrader: return $"Comerciantes de materiales {host.StarSystem}";
                case PromptType.Conflictos: return "Conflictos";
                case PromptType.Ordenes: return "Ordenes";
                case PromptType.InventoryPanel: return "Panel de Inventario";
                case PromptType.Help: return "Ayuda";
                case PromptType.BodySignals: return "Señales Planetarias";
                case PromptType.ExoMastery: return "Ruta Exobiología";
                case PromptType.Exceptions: return "Excepciones";
                case PromptType.Statistics: return "Estadisticas";
                case PromptType.Merits: return "Mercancías Potencia";
            }

            return "";
        }

        int Display(IReadOnlyDictionary<PromptType, List<string>> log, PromptType prompttype, List<PromptLine> lines, int i)
        {
            int first = 0;
            int count = 0;
            int last = 0;
            Range(log, prompttype, ref first, ref last, ref count);

            List<string> list = log.TryGetValue(prompttype, out List<string> l) ? l : new List<string>();
            foreach (string s in list.GetRange(first, count))
            {
                lines.AddRange(CreatePrompt(0xFF, 0xB0, 0x00, 20, i, s));
                i += altofuente + 2;
            }

            return i;
        }

        void Range(IReadOnlyDictionary<PromptType, List<string>> log, PromptType prompttype, ref int first, ref int last, ref int count)
        {
            int c = log.TryGetValue(prompttype, out List<string> l) ? l.Count : 0;
            int lc = c > MaxLines ? MaxLines : c;

            first = c - lc;
            last = first + lc;
            count = lc;
        }

        List<PromptLine> CreatePrompt(byte r, byte g, byte b, int posx, int posy, string prompt)
        {
            return new List<PromptLine> { new PromptLine(PrompterService.RemoveBadChars(prompt), r, g, b, posx, posy) };
        }
    }
}
