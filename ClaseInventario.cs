using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class CategoriasInventario
    {
        public List<List<List<String>>> Categorias { get; set; }

        public Inventario Inventario { get; set; }

        public Dictionary<String, int> Deltas;
        public void CargarCategorias()
        {

            try
            {
                Categorias = JsonConvert.DeserializeObject<List<List<List<String>>>>(System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Categorias.json"));
            }
            catch (Exception exj)
            {
                Categorias = System.Text.Json.JsonSerializer.Deserialize<List<List<List<String>>>>(System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Categorias.json"));
            }

        }

        public int Cantidad(String material)
        {
            try
            {
            int cantidad = (from InventoryMaterialType raw in this.Inventario.Raw where raw.Name_Localised == material || raw.Name == material select raw.Count).Sum() +
                      (from InventoryMaterialType manufactured in this.Inventario.Manufactured where manufactured.Name_Localised == material select manufactured.Count).Sum() +
                      (from InventoryMaterialType encoded in this.Inventario.Encoded where encoded.Name_Localised == material select encoded.Count).Sum();

            return cantidad;

            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public int Nivel(String material)
        {
            for (int i = 0; i < Categorias.Count; i++)
            {
                for (int j = 0; j < Categorias[i].Count; j++)
                {
                    for (int k = 0; k < Categorias[i][j].Count; k++)
                    {
                        if (Categorias[i][j][k] == material) return (k + 1);
                    }
                }
            }

            return (0);
        }

        public int Maximo(String material)
        {
            int nivel = Nivel(material);

            if (nivel == 0) return 0;

            return (350 - (nivel * 50));
            
        }

        public int Suma(String material, int cantidad)
        {
            int _cantidad0 = this.Cantidad(material);
            int _cantidad = _cantidad0;
            int _maximo = this.Maximo(material);
            _cantidad += cantidad;
            if (_cantidad > _maximo) _cantidad = _maximo;


            InventoryMaterialType inventory = (from InventoryMaterialType raw in this.Inventario.Raw where raw.Name_Localised == material || raw.Name == material select raw).DefaultIfEmpty(null).FirstOrDefault();
            if (inventory == null) inventory = (from InventoryMaterialType manufactured in this.Inventario.Manufactured where manufactured.Name_Localised == material select manufactured).DefaultIfEmpty(null).FirstOrDefault();
            if (inventory == null) inventory = (from InventoryMaterialType encoded in this.Inventario.Encoded where encoded.Name_Localised == material select encoded).DefaultIfEmpty(null).FirstOrDefault();

            if (inventory == null) return 0;

            inventory.Count = _cantidad;

            if (Deltas == null) Deltas = new Dictionary<string, int>();

            if (!Deltas.ContainsKey(material))
            {
                Deltas.Add(material, 0);
            }

            Deltas[material] += _cantidad - _cantidad0;

            return _cantidad;
        }

    }
}
