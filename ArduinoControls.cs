using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDCrew
{
    public partial class ArduinoControls : Form
    {
        private List<Comandos> comandos;

        public ArduinoControls()
        {
            InitializeComponent();

            try
            {
                comandos = JsonConvert.DeserializeObject<List<Comandos>>(System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Gramatica.json"));
            }
            catch (Exception exj)
            {
                comandos = System.Text.Json.JsonSerializer.Deserialize<List<Comandos>>(System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Gramatica.json"));
            }

            if (comandos != null)
            {
                comandos = (from Comandos c in comandos where c.control != null && c.control[0] == 1 select c).ToList();
            }

            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {

                    CheckBox check = new CheckBox();
                    //r.Width = 24;

                    check.Left = ((j + 2) * check.Width) + 2;
                    check.Top = ((i + 1) * check.Height) + 2;
                    check.Name = $"radio_{i}_{j}";
                    check.Enabled = j > i;
                    arduinobuttonscontrol.Controls.Add(check);


                    if (i == 0)
                    {
                        Label lbl = new Label();
                        lbl.Left = ((j + 1) * check.Width) + 2;
                        lbl.Top = (i * check.Height) + 2;
                        lbl.Text = j.ToString();
                        arduinobuttonscontrol.Controls.Add(lbl);

                    }

                    if (j == 0)
                    {
                        Label lbl = new Label();
                        lbl.Left = (j * check.Width) + 2;
                        lbl.Top = ((i + 1) * check.Height) + 2;
                        lbl.Text = i.ToString();
                        arduinobuttonscontrol.Controls.Add(lbl);

                    }


                }

                
            }

            foreach(Comandos c in comandos)
            {
                byte b0 = c.control[1];
                byte b1 = c.control[2];

                CheckBox check = (CheckBox)arduinobuttonscontrol.Controls[$"radio_{b0}_{b1}"];
                check.Checked = true;
                check.Text += c.command + "\r\n";
            }
        }

        
    }
}
