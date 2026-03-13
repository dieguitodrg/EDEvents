using EDCrew;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{


    public class JournalLoadout : JournalBase
    {
        public String Ship { get; set; }

        public String ShipName { get; set; }

        public int ShipID { get; set; }

        public String ShipIdent { get; set; }

        public int HullValue { get; set; }

        public int ModulesValue { get; set; }

        public Decimal HullHealth { get; set; }

        public Decimal UnladenMass { get; set; }

        public JournalLoadOutFuelCapacity FuelCapacity { get; set; }

        public int CargoCapacity { get; set; }

        public Decimal MaxJumpRange { get; set; }

        public int Rebuy { get; set; }

        public int Hot { get; set; }

        public List<JournalLoadoutModule> Modules { get; set; }

        public String ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{ShipIdent} {ShipName}");
            sb.AppendLine($"Valor: {HullValue} {ModulesValue}");
            sb.AppendLine($"Recompra: {Rebuy}");
            sb.AppendLine($"Masa: Casco {UnladenMass} Fuel {FuelCapacity.Main + FuelCapacity.Reserve}");
            sb.AppendLine($"Capacidad de carga: {CargoCapacity}");
            sb.AppendLine($"Capacidad de salto: {MaxJumpRange}");

            if (Modules != null && Modules.Count != 0)
            {
                sb.AppendLine("Módulos");
                foreach(JournalLoadoutModule m in Modules)
                {
                    sb.AppendLine(m.ToString());
                }
            }

            return sb.ToString();
        }

    }

    public class JournalLoadOutFuelCapacity
    {
        public Decimal Main { get; set; }

        public Decimal Reserve { get; set; }

    }

    public class JournalLoadoutModule
    {
        public string Slot { get; set; }

        public string Item { get; set; }

        public bool On { get; set; }

        public int Priority { get; set; }

        public int AmmoInClip { get; set; }

        public int AmmoInHopper { get; set; }

        public Decimal Health { get; set; }

        public int Value { get; set; }

        public List<JournalLoadoutModuleEngineering> Engineering { get; set; }

        public String ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Slot} {Item} {Priority} {AmmoInClip} {AmmoInHopper} {Health}");

            if (Engineering != null && Engineering.Count != 0)
            {
                foreach(JournalLoadoutModuleEngineering e in Engineering)
                {
                    sb.AppendLine(e.ToString());

                    

                }
            }

            return sb.ToString();

        }


    }

    public class JournalLoadoutModuleEngineering : Localizer
    {
        public String Engineer { get; set; }

        public int EngineerID { get; set; }
        public int BlueprintID { get; set; }

        public int BlueprintName { get; set; }

        public int Level { get; set; }

        public Decimal Quality { get; set; }

        public string ExperimentalEffect { get; set; }

        public string ExperimentalEffect_Localised { get; set; }

        public List<JournalModuleEngineeringModifier> Modifiers { get; set; }

        public String DisplayExperimentalEffect()
        {
            return Show(ExperimentalEffect, ExperimentalEffect_Localised);
        }

        public String ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.BlueprintName} {this.Level} {this.Quality} {this.DisplayExperimentalEffect()}");

            if (Modifiers != null && Modifiers.Count != 0)
            {
                foreach(JournalModuleEngineeringModifier em in Modifiers)
                {
                    Decimal v = em.Value != null ? em.Value : em.OriginalValue;
                    sb.AppendLine($"{em.Label} {v} {em.Increase}");
                }
            }
            return sb.ToString();

            
        }

    }

    public class JournalModuleEngineeringModifier
    {
        public String Label { get; set; }

        public Decimal Value { get; set; }
        public Decimal OriginalValue { get; set; }

        public int LessIsGood { get; set; }

        public Decimal Increase
        {
            get
            {
                try
                {
                    if (LessIsGood == 0)
                    {
                        if (Value == 0) return 1.0M;

                        return (OriginalValue / Value);
                    }
                    else
                    {
                        if (OriginalValue == 0) return 1.0M;

                        return (Value / OriginalValue);
                    }

                }
                catch (Exception ex)
                {
                    return 1.0M;
                }
            }
        }

    }

    public class BlueprintFormatter
    {
        public string Show(string value)
        {

            /*
            
            Weapon_Overcharged

             */

            return value != null ? value : "";
        }
    }

}