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

            return comandosfinales;
        }

        public static List<string> BuildChoices(List<Comandos> comandos)
        {
            return (from Comandos c in comandos select c.command).ToList();
        }
    }
}
