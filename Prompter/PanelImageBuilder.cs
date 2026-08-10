using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;

namespace EDCrew
{
    /// <summary>
    /// Pinta el panel estilo juego de los paneles navegables del prompter. Sin
    /// borde exterior: fondo SaddleBrown semitransparente con cuatro líneas
    /// naranjas horizontales (sobre la cabecera, entre cabecera y título, entre
    /// título y opciones, y bajo las opciones). La fila del cursor se resalta
    /// con fondo naranja y texto oscuro. El alto de fila y de la barra se
    /// derivan del alto real de la fuente, para que la barra cubra el texto
    /// completo. Solo GDI+: no conoce Capture ni Direct3D. Devuelve un Bitmap
    /// 32bppArgb que OverlayImage envía por IPC como ImageElement.
    /// </summary>
    public class PanelImageBuilder
    {
        private const int altofuente = 12;
        private const int Padding = 2;
        private const int Separator = 2;
        private const int SeparatorGap = 2;
        private const int RowPad = 2;
        private const int RowGap = 2;
        private const int MaxPanelWidth = 1800;

        private static readonly Color PanelBack = Color.FromArgb(60, Color.SaddleBrown);
        private static readonly Color SeparatorColor = Color.Orange;
        private static readonly Color HighlightBack = Color.FromArgb(230, Color.Orange);
        private static readonly Color HighlightText = Color.SaddleBrown;

        private readonly Font _font;

        public PanelImageBuilder()
        {
            _font = new Font("Euro Caps", altofuente, FontStyle.Regular);
        }

        public Bitmap Build(IReadOnlyList<PromptLine> lines, int cursorRow)
        {
            int lineHeight = MeasureLineHeight();

            PromptLine header = lines.Count > 0 ? lines[0] : null;
            PromptLine title = lines.Count > 1 ? lines[1] : null;
            List<PromptLine> content = lines.Skip(2).ToList();

            int width = MeasureWidth(lines);
            int height = ComputeHeight(content.Count, lineHeight);

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                g.Clear(Color.Transparent);

                using (SolidBrush back = new SolidBrush(PanelBack))
                {
                    g.FillRectangle(back, 0, 0, width, height);
                }

                int ySep1 = Padding;
                int yHeader = ySep1 + Separator + SeparatorGap;

                DrawSeparator(g, width, ySep1);

                if (header != null)
                {
                    DrawText(g, header, yHeader);
                }

                if (title != null)
                {
                    int ySep2 = yHeader + lineHeight + SeparatorGap;
                    int yTitle = ySep2 + Separator + SeparatorGap;

                    DrawSeparator(g, width, ySep2);
                    DrawText(g, title, yTitle);

                    int ySep3 = yTitle + lineHeight + SeparatorGap;
                    int yContent0 = ySep3 + Separator + SeparatorGap;

                    if (content.Count > 0)
                    {
                        DrawSeparator(g, width, ySep3);

                        bool[] highlight = MarkHighlight(content, cursorRow);

                        for (int k = 0; k < content.Count; k++)
                        {
                            int y = yContent0 + k * LinePitch(lineHeight);
                            Color textColor = Color.FromArgb(content[k].R, content[k].G, content[k].B);

                            if (highlight[k])
                            {
                                using (SolidBrush hl = new SolidBrush(HighlightBack))
                                {
                                    g.FillRectangle(hl, 0, y - RowPad, width, lineHeight + 2 * RowPad);
                                }
                                textColor = HighlightText;
                            }

                            using (SolidBrush brush = new SolidBrush(textColor))
                            {
                                g.DrawString(content[k].Text, _font, brush, content[k].X, y, StringFormat.GenericTypographic);
                            }
                        }

                        int lastTop = yContent0 + (content.Count - 1) * LinePitch(lineHeight);
                        int ySep4 = lastTop + lineHeight + SeparatorGap;

                        DrawSeparator(g, width, ySep4);
                    }
                    else
                    {
                        DrawSeparator(g, width, ySep3);
                    }
                }
            }

            return bmp;
        }

        int MeasureLineHeight()
        {
            using (Bitmap m = new Bitmap(1, 1, PixelFormat.Format32bppArgb))
            using (Graphics gm = Graphics.FromImage(m))
            {
                return (int)Math.Ceiling(_font.GetHeight(gm));
            }
        }

        int LinePitch(int lineHeight)
        {
            return lineHeight + 2 * RowPad + RowGap;
        }

        int MeasureWidth(IReadOnlyList<PromptLine> lines)
        {
            int width = 0;

            using (Bitmap measure = new Bitmap(1, 1, PixelFormat.Format32bppArgb))
            using (Graphics gm = Graphics.FromImage(measure))
            {
                foreach (PromptLine line in lines)
                {
                    SizeF sz = gm.MeasureString(line.Text, _font, 0, StringFormat.GenericTypographic);
                    int right = line.X + (int)Math.Ceiling(sz.Width);
                    if (right > width) width = right;
                }
            }

            width += Padding;
            if (width > MaxPanelWidth) width = MaxPanelWidth;
            return width;
        }

        int ComputeHeight(int contentCount, int lineHeight)
        {
            int ySep1 = Padding;
            int yHeader = ySep1 + Separator + SeparatorGap;
            int ySep2 = yHeader + lineHeight + SeparatorGap;
            int yTitle = ySep2 + Separator + SeparatorGap;
            int ySep3 = yTitle + lineHeight + SeparatorGap;

            int bottomSepY;
            if (contentCount > 0)
            {
                int yContent0 = ySep3 + Separator + SeparatorGap;
                int lastTop = yContent0 + (contentCount - 1) * LinePitch(lineHeight);
                bottomSepY = lastTop + lineHeight + SeparatorGap;
            }
            else
            {
                bottomSepY = ySep3;
            }

            return bottomSepY + Separator + Padding;
        }

        /// <summary>
        /// Marca la fila del cursor dentro del contenido. La fuente de verdad es
        /// el color de resaltado que ya pone PrompterContent (0xB0,0xFF,0x00);
        /// cursorRow solo se usa como respaldo si no aparece ninguna.
        /// </summary>
        static bool[] MarkHighlight(List<PromptLine> content, int cursorRow)
        {
            bool[] marks = new bool[content.Count];
            int found = -1;

            for (int k = 0; k < content.Count; k++)
            {
                PromptLine line = content[k];
                if (line.R == 0xB0 && line.G == 0xFF && line.B == 0x00)
                {
                    found = k;
                    break;
                }
            }

            if (found < 0 && cursorRow >= 0 && cursorRow < content.Count)
            {
                found = cursorRow;
            }

            if (found >= 0)
            {
                marks[found] = true;
            }

            return marks;
        }

        static void DrawSeparator(Graphics g, int width, int y)
        {
            using (SolidBrush b = new SolidBrush(SeparatorColor))
            {
                g.FillRectangle(b, 0, y, width, Separator);
            }
        }

        void DrawText(Graphics g, PromptLine line, int y)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(line.R, line.G, line.B)))
            {
                g.DrawString(line.Text, _font, brush, line.X, y, StringFormat.GenericTypographic);
            }
        }
    }
}
