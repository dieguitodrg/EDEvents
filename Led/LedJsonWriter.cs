using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EDCrew.Led
{
    /// <summary>
    /// Escribe el color de la estrella actual en currentstar.json dentro de una
    /// carpeta configurada que LuminaController vigila con FileSystemWatcher.
    /// </summary>
    public class LedJsonWriter : Pipeline.ILedWriter
    {
        private readonly string _folder;
        private readonly StarTypesType _starTypes = new StarTypesType();
        private StarTypeColor _current;
        private StarTypeColor _next;

        public LedJsonWriter(string folder)
        {
            _folder = folder;
        }

        public bool Enabled { get; set; }

        public void OnStartJump(string starClass)
        {
            if (!Enabled || String.IsNullOrWhiteSpace(_folder)) return;

            if (!_starTypes.StarTypes.TryGetValue(starClass ?? String.Empty, out StarTypeColor next))
            {
                _starTypes.StarTypes.TryGetValue("Unknown", out next);
            }

            _next = next;

            if (_current == null)
            {
                _current = new StarTypeColor()
                {
                    RGB256 = new StarTypeColor.RGB() { R = 0, G = 0, B = 0 }
                };
            }

            List<AnimationStep> steps = new List<AnimationStep>
            {
                new AnimationStep()
                {
                    color = ToLightColor(_current),
                    time = 500,
                    transitiontime = 1000
                },
                new AnimationStep()
                {
                    color = ToLightColor(_next),
                    time = 500,
                    transitiontime = 1000
                }
            };

            Write(steps);
        }

        public void OnArrival()
        {
            if (!Enabled || String.IsNullOrWhiteSpace(_folder)) return;

            _current = _next;

            List<AnimationStep> steps = new List<AnimationStep>
            {
                new AnimationStep()
                {
                    color = ToLightColor(_current),
                    time = 500,
                    transitiontime = 1000
                },
                new AnimationStep()
                {
                    color = new LightColor() { r = 0, g = 0, b = 0, progress = 100, warmwhite = 0 },
                    time = 500,
                    transitiontime = 1000
                }
            };

            Write(steps);
        }

        private static LightColor ToLightColor(StarTypeColor star)
        {
            return new LightColor()
            {
                r = star?.RGB256?.R ?? 0,
                g = star?.RGB256?.G ?? 0,
                b = star?.RGB256?.B ?? 0,
                progress = 100,
                warmwhite = 0
            };
        }

        private void Write(List<AnimationStep> steps)
        {
            try
            {
                Directory.CreateDirectory(_folder);
                File.WriteAllText(Path.Combine(_folder, "currentstar.json"), JsonConvert.SerializeObject(steps, Formatting.Indented));
            }
            catch (Exception)
            {
            }
        }
    }
}
