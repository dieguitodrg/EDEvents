namespace EDCrew.Pipeline
{
    /// <summary>
    /// Exportador del color de la estrella al programa externo de LEDs
    /// (LuminaController) mediante un JSON en una carpeta vigilada.
    /// </summary>
    public interface ILedWriter
    {
        bool Enabled { get; set; }

        void OnStartJump(string starClass);

        void OnArrival();
    }
}
