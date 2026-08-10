using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using CsQuery;
using CsQuery.Implementation;
using Newtonsoft.Json;

namespace EDCrew
{
    /// <summary>
    /// Acceso a Inara (scraping HTML). Centraliza las consultas de comerciantes
    /// de materiales, factores interestelares y conflictos que antes vivían en
    /// Form1. Mantiene la cache JSON de resultados por sistema.
    /// </summary>
    public class InaraService
    {
        private readonly HttpClient _client;
        private readonly string _dataDirectory;

        public InaraService()
        {
            _client = new HttpClient();
            _dataDirectory = System.IO.Path.GetDirectoryName(typeof(InaraService).Assembly.Location);
        }

        public async Task<List<StationListItem>> MaterialTrader(string starsystem)
        {
            string url = $"https://inara.cz/elite/nearest-stations/?formbrief=1&ps1={starsystem}&pi13=&pi14=0&pi15=0&pi16=&pi1=0&pi18=3&pi19=5000&pi17=1&pa1[]=25&ps2=&pi25=0&pi8=&pi9=0&pi26=0&pi3=&pi4=0&pi5=0&pi7=0&pi23=0&pi6=0&ps3=&pi24=0&language=4";

            return await GetNearestStationsAsync(starsystem, "MaterialTrader", url, MaterialTraderMapRow, true);
        }

        public async Task<List<StationListItem>> FactorInterestelar(string starsystem)
        {
            string url = $"https://inara.cz/elite/nearest-stations/?formbrief=1&ps1={starsystem}&pi13=&pi14=0&pi15=0&pi16=&pi1=0&pi18=0&pi19=0&pi17=0&pa1%5B%5D=18&ps2=&pi25=0&pi8=&pi9=0&pi26=0&pi3=&pi4=0&pi5=0&pi7=0&pi23=0&pi6=0&ps3=&pi24=0";

            return await GetNearestStationsAsync(starsystem, "FactorInterestelar", url, FactorInterestelarMapRow, false);
        }

        public async Task<List<StationListItem>> Conflictos()
        {
            List<StationListItem> result = new List<StationListItem>();

            try
            {
                HttpResponseMessage httpresponse = await _client.GetAsync($"https://inara.cz/elite/minorfaction-conflicts/35226");

                httpresponse.EnsureSuccessStatusCode();

                String response = await httpresponse.Content.ReadAsStringAsync();

                CsQuery.CQ document = response;

                CsQuery.CQ cells = document["td"];

                for (int i = 0; i < cells.Count(); i = i + 8)
                {
                    DomElement celllocation = (DomElement)cells[i];
                    DomElement cellFaction0 = (DomElement)cells[i + 1];
                    DomElement cellFaction1 = (DomElement)cells[i + 3];
                    DomElement cellTipo = (DomElement)cells[i + 2];
                    DomElement cellResultado = (DomElement)cells[i + 4];

                    String faction0 = GetFirstAnchorText(cellFaction0);
                    String faction1 = GetFirstAnchorText(cellFaction1);

                    if (faction0.Contains("Union Cosmos") || faction1.Contains("Union Cosmos"))
                    {
                        StationListItem listitem = new StationListItem();

                        listitem.Sistema = GetFirstAnchorText(celllocation);
                        listitem.DistanciaSistema = faction0;
                        listitem.DistanciaEstrella = faction1;
                        listitem.Tipo = cellTipo.InnerText;
                        listitem.Estacion = cellResultado.InnerText;

                        result.Add(listitem);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<List<Order>> Ordenes()
        {
            List<Order> result = null;

            String foldername = _dataDirectory + "\\Data\\Ordenes";

            System.IO.Directory.CreateDirectory(foldername);

            String filename = $"{foldername}\\ordenes.json";

            if (System.IO.File.Exists(filename))
            {
                result = JsonConvert.DeserializeObject<List<Order>>(System.IO.File.ReadAllText(filename));
                return result;
            }

            return result;
        }

        private async Task<List<StationListItem>> GetNearestStationsAsync(string starsystem, string cacheName, string url, Func<CsQuery.CQ, StationListItem> mapRow, bool swallowErrors)
        {
            String foldername = _dataDirectory + "\\Data";

            System.IO.Directory.CreateDirectory(foldername);

            String filename = $"{foldername}\\{cacheName}.{starsystem}.json";

            if (System.IO.File.Exists(filename))
            {
                return JsonConvert.DeserializeObject<List<StationListItem>>(System.IO.File.ReadAllText(filename));
            }

            List<StationListItem> result = new List<StationListItem>();

            try
            {
                HttpResponseMessage httpresponse = await _client.GetAsync(url);

                httpresponse.EnsureSuccessStatusCode();

                String response = await httpresponse.Content.ReadAsStringAsync();

                CsQuery.CQ document = response;

                CsQuery.CQ rows = document["tr"];

                for (int i = 1; i < rows.Count(); i++)
                {
                    DomElement row = (DomElement)rows[i];

                    CsQuery.CQ cqrow = CsQuery.CQ.Create(row);

                    CsQuery.CQ cells = cqrow["td"];

                    result.Add(mapRow(cells));
                }
            }
            catch (Exception ex)
            {
                if (!swallowErrors) throw;
            }

            if (result != null && result.Count != 0)
                System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(result));

            return result;
        }

        private static StationListItem MaterialTraderMapRow(CsQuery.CQ cells)
        {
            StationListItem listitem = new StationListItem();

            DomElement cell = (DomElement)cells[0];

            listitem.Tipo = cell.InnerHTML.Replace("<span class=\"minor\">", "").Replace("<span class=\"positive\">", "").Replace("</span>", "");

            cell = (DomElement)cells[1];

            listitem.Estacion = GetFirstAnchorText(cell);

            cell = (DomElement)cells[2];

            listitem.Sistema = GetFirstAnchorText(cell);

            cell = (DomElement)cells[6];

            listitem.DistanciaEstrella = cell.InnerText;

            cell = (DomElement)cells[7];

            listitem.DistanciaSistema = cell.InnerText;

            return listitem;
        }

        private static StationListItem FactorInterestelarMapRow(CsQuery.CQ cells)
        {
            StationListItem listitem = new StationListItem();

            DomElement cell = (DomElement)cells[0];

            listitem.Estacion = GetFirstAnchorText(cell);

            cell = (DomElement)cells[1];

            listitem.Sistema = GetFirstAnchorText(cell);

            cell = (DomElement)cells[5];

            listitem.DistanciaEstrella = cell.InnerText;

            cell = (DomElement)cells[6];

            listitem.DistanciaSistema = cell.InnerText;

            return listitem;
        }

        private static String GetFirstAnchorText(DomElement cell)
        {
            CsQuery.CQ cqcell = CsQuery.CQ.Create(cell);
            CsQuery.CQ cqcontent = cqcell["a"];
            return cqcontent.FirstElement().InnerText;
        }
    }
}
