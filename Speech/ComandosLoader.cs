using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EDCrew.Speech
{
    public static class ComandosLoader
    {
        public static List<Comandos> Load(string filePath)
        {
            string json = File.ReadAllText(filePath);
            try
            {
                return JsonConvert.DeserializeObject<List<Comandos>>(json);
            }
            catch (Exception exj)
            {
                return System.Text.Json.JsonSerializer.Deserialize<List<Comandos>>(json);
            }
        }

        public static List<Comandos> Expand(List<Comandos> comandos)
        {
            List<Comandos> comandosfinales = new List<Comandos>();

            foreach (Comandos c in comandos)
            {
                if (c.subcommands != null)
                {
                    foreach (SubComando sc in c.subcommands)
                    {
                        String fc = String.Format(c.command, sc.Item.ToLower());
                        Comandos comandofinal = (Comandos)c.Clone();
                        comandofinal.subcommands = null;
                        comandofinal.command = fc;
                        comandofinal.subsystem = sc.Argument;
                        comandofinal.code += c.code + sc.Argument;
                        comandosfinales.Add(comandofinal);
                    }
                }
                else
                {
                    comandosfinales.Add(c);
                }
            }

            IReadOnlyDictionary<int, string> catalogo = MaterialesInara.Catalogo;
            foreach (int m in catalogo.Keys)
            {
                string name = catalogo[m];
                Comandos comandos1 = new Comandos();
                comandos1.command = $"Mostrar oferta de {name}";
                comandos1.subsystem = m.ToString();
                comandos1.method = "MostrarOferta";
                comandos1.category = "Compra Materiales";
                comandosfinales.Add(comandos1);

                Comandos comandos2 = new Comandos();
                comandos2.command = $"Mostrar demanda de {name}";
                comandos2.method = "MostrarDemanda";
                comandos2.subsystem = m.ToString();
                comandos2.category = "Venta Materiales";
                comandosfinales.Add(comandos2);

            }

            return comandosfinales;
        }

        public static List<string> BuildChoices(List<Comandos> comandos)
        {
            List <string>             choices = BuildChoicesMaterials();
            choices.AddRange((from Comandos c in comandos select c.command).ToList());
            //return (from Comandos c in comandos select c.command).ToList();
            return choices;
        }

        public static List<string> BuildChoicesMaterials()
        {
            List<string> choices = new List<string>();
            IReadOnlyDictionary<int, string> catalogo = MaterialesInara.Catalogo;
            foreach (int m in catalogo.Keys)
            {
                string name = catalogo[m];
                choices.Add($"Mostrar oferta de {name}");
                choices.Add($"Mostrar demanda de {name}");
            }
            return choices;
        }
    }
}
