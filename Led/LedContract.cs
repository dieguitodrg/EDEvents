using System;

namespace EDCrew.Led
{
    /// <summary>
    /// Contrato de color con LuminaController. Se serializa con fields públicos
    /// para producir un JSON byte-idéntico al que espera el programa externo.
    /// </summary>
    public class LightColor
    {
        public byte r;
        public byte g;
        public byte b;
        public byte progress;
        public byte warmwhite;
    }

    /// <summary>
    /// Paso de animación con el mismo formato que LuminaController.
    /// </summary>
    public class AnimationStep
    {
        public LightColor color;
        public int time;
        public int transitiontime;
    }
}
