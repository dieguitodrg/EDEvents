using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Capture.Hook.Common;
using Capture.Interface;

namespace EDCrew
{
    /// <summary>
    /// Construye ImageElement para el overlay DX11 normalizando siempre la
    /// imagen fuente a un bitmap Format32bppArgb standalone (patrón DXFont) y
    /// enviándola por IPC como bytes PNG (propiedad Image), nunca como Bitmap.
    /// El Bitmap no sobrevive a la serialización por Remoting (handle GDI+
    /// nativeImage roto en el proceso inyectado) y hace fallar
    /// DXImage.Initialise; los bytes se decodifican de nuevo en el proceso
    /// destino vía Image.ToBitmap(). Evita también el Debug.Assert de
    /// DXImage.Initialise (exige 32bppArgb, que el PNG normalizado garantiza).
    /// No modifica la librería Capture: solo prepara el elemento que se
    /// serializa por IPC.
    /// </summary>
    public static class OverlayImage
    {
        /// <summary>
        /// Crea una copia independiente en Format32bppArgb (píxeles y formato).
        /// La copia es un bitmap desvinculado del origen (archivo/stream/objeto
        /// de llamada), seguro para serializar por Remoting.
        /// </summary>
        public static Bitmap Normalize(Bitmap source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            Bitmap copy = new Bitmap(source.Width, source.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(copy))
            {
                g.DrawImage(source, 0, 0, source.Width, source.Height);
            }
            return copy;
        }

        /// <summary>
        /// Carga una imagen desde archivo y la normaliza a 32bppArgb.
        /// </summary>
        public static Bitmap FromFile(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Se requiere una ruta de archivo.", nameof(filePath));

            using (Bitmap source = new Bitmap(filePath))
            {
                return Normalize(source);
            }
        }

        /// <summary>
        /// Carga una imagen desde bytes (PNG/JPEG/...) y la normaliza a 32bppArgb.
        /// </summary>
        public static Bitmap FromBytes(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            using (MemoryStream ms = new MemoryStream(data))
            using (Bitmap source = (Bitmap)Image.FromStream(ms))
            {
                return Normalize(source);
            }
        }

        /// <summary>
        /// Crea un ImageElement desde un bitmap. La imagen viaja por IPC como
        /// bytes PNG (nunca como Bitmap) y el proceso inyectado la decodifica.
        /// </summary>
        public static ImageElement CreateImageElement(Bitmap source, Point location, float scale = 1.0f, float angle = 0f, Color? tint = null)
        {
            using (Bitmap normalized = Normalize(source))
            {
                return CreateImageElement(normalized, null, location, scale, angle, tint);
            }
        }

        /// <summary>
        /// Crea un ImageElement desde un archivo de imagen.
        /// </summary>
        public static ImageElement CreateImageElement(string filePath, Point location, float scale = 1.0f, float angle = 0f, Color? tint = null)
        {
            using (Bitmap normalized = FromFile(filePath))
            {
                return CreateImageElement(normalized, filePath, location, scale, angle, tint);
            }
        }

        /// <summary>
        /// Crea un ImageElement desde bytes de imagen (PNG/JPEG/...).
        /// </summary>
        public static ImageElement CreateImageElement(byte[] data, Point location, float scale = 1.0f, float angle = 0f, Color? tint = null)
        {
            using (Bitmap normalized = FromBytes(data))
            {
                return CreateImageElement(normalized, null, location, scale, angle, tint);
            }
        }

        private static ImageElement CreateImageElement(Bitmap normalized, string filePath, Point location, float scale, float angle, Color? tint)
        {
            return new ImageElement
            {
                Image = normalized.ToByteArray(System.Drawing.Imaging.ImageFormat.Png),
                Filename = filePath,
                Location = location,
                Scale = scale,
                Angle = angle,
                Tint = tint ?? Color.White
            };
        }
    }
}
