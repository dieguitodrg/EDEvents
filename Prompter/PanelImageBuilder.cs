using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace EDCrew
{
    /// <summary>
    /// Pinta un panel estilo juego (fondo, borde, fila resaltada) para los
    /// paneles navegables del prompter. Solo GDI+: no conoce Capture ni
    /// Direct3D. Devuelve un Bitmap 32bppArgb que OverlayImage envía por IPC
    /// como ImageElement. Fuera del panel todo es transparente.
    /// </summary>
    public class PanelImageBuilder
    {
        private const int altofuente = 20;
        private const int RowHeight = altofuente + 2;
        private const int Padding = 10;
        private const int ContentStartY = 60;
        private const int MaxPanelWidth = 1800;

        private static readonly Color PanelBack = Color.FromArgb(80, Color.SaddleBrown);
        private static readonly Color Border = Color.Orange;
        private static readonly Color HighlightBack = Color.FromArgb(230, Color.Orange);
        private static readonly Color HighlightText = Color.SaddleBrown;

        private readonly Font _font;

        public PanelImageBuilder()
        {
            _font = new Font("Euro Caps", altofuente, FontStyle.Regular);
        }

        public Bitmap Build(IReadOnlyList<PromptLine> lines, int cursorRow)
        {
            int width = 0;
            int maxBottom = 0;

            using (Bitmap measure = new Bitmap(1, 1, PixelFormat.Format32bppArgb))
            using (Graphics gm = Graphics.FromImage(measure))
            {
                foreach (PromptLine line in lines)
                {
                    SizeF sz = gm.MeasureString(line.Text, _font, 0, StringFormat.GenericTypographic);
                    int textWidth = (int)Math.Ceiling(sz.Width);
                    int right = line.X + textWidth;
                    if (right > width) width = right;

                    int bottom = line.Y + RowHeight;
                    if (bottom > maxBottom) maxBottom = bottom;
                }
            }

            width += Padding;
            if (width > MaxPanelWidth) width = MaxPanelWidth;
            int height = maxBottom + Padding;

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (SolidBrush back = new SolidBrush(PanelBack))
                {
                    g.FillRectangle(back, 0, 0, width, height);
                }

                using (Pen pen = new Pen(Border, 2))
                {
                    g.DrawRectangle(pen, 1, 1, width - 2, height - 2);
                }

                bool[] highlight = MarkHighlight(lines, cursorRow);

                int contentIndex = 0;

                foreach (PromptLine line in lines)
                {
                    Color textColor = Color.FromArgb(line.R, line.G, line.B);

                    if (line.Y >= ContentStartY)
                    {
                        if (highlight[contentIndex])
                        {
                            using (SolidBrush hl = new SolidBrush(HighlightBack))
                            {
                                g.FillRectangle(hl, 0, line.Y, width, RowHeight);
                            }
                            textColor = HighlightText;
                        }
                        contentIndex++;
                    }

                    using (SolidBrush brush = new SolidBrush(textColor))
                    {
                        g.DrawString(line.Text, _font, brush, line.X, line.Y, StringFormat.GenericTypographic);
                    }
                }
            }

            return bmp;
        }

        /// <summary>
        /// Marca la fila del cursor. La fuente de verdad es el color de
        /// resaltado que ya pone PrompterContent (0xB0,0xFF,0x00); cursorRow
        /// solo se usa como respaldo si no aparece ninguna fila resaltada.
        /// </summary>
        static bool[] MarkHighlight(IReadOnlyList<PromptLine> lines, int cursorRow)
        {
            bool[] marks = new bool[lines.Count];
            int contentIndex = 0;
            bool found = false;

            for (int n = 0; n < lines.Count; n++)
            {
                PromptLine line = lines[n];
                if (line.Y < ContentStartY) continue;

                if (!found && line.R == 0xB0 && line.G == 0xFF && line.B == 0x00)
                {
                    marks[contentIndex] = true;
                    found = true;
                }
                else if (!found && contentIndex == cursorRow)
                {
                    marks[contentIndex] = true;
                }

                contentIndex++;
            }

            return marks;
        }
    }
}
