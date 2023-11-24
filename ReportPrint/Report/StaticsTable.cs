using ReportPrint.Model.Statistics;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReportPrint.Report
{
    /// <summary>
    /// Class <c>StaticsTable</c> implements StaticsTable used in ReportSection.
    /// </summary>
    internal class StaticsTable
    {
        readonly int CellWidth = 118;
        readonly int CellHheight = 80;
        readonly int OuterThickness = 9;
        readonly int InnerThickness = 6;

        readonly int Rows = 6;
        readonly int Cols = 16;

        readonly Font fontCell = new Font(Config.PrintFontName, 11, FontStyle.Regular);
        readonly Brush BrushInner = Brushes.DarkGray;
        readonly Brush brushOdd = new SolidBrush(Color.LightGray);

        int TotalWidth => CellWidth * Cols + InnerThickness * (Cols - 1);
        int TotalHeight => CellHheight * Rows + InnerThickness * (Rows - 1);

        int XPos(int Col) => (CellWidth + InnerThickness) * Col;
        int YPos(int Row) => (CellHheight + InnerThickness) * Row;
        int ColWidth(int Cols = 1) => CellWidth * Cols + InnerThickness * (Cols - 1);
        int RowHeight(int Rows = 1) => CellHheight * Rows + InnerThickness * (Rows - 1);

        readonly StatisticItem s_item;

        internal StaticsTable(StatisticItem s_item)
        {
            this.s_item = s_item;
        }

        internal StaticsTable(int Rows, int Cols)
        {
            this.Rows = Rows;
            this.Cols = Cols;
        }

        /// <summary>
        /// Draw Table used in report section.
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            DrawFrameOfTable(graphics);
            DrawMergedCell(graphics);
            DrawTitle(graphics);
        }

        /// <summary>
        /// Draw Frame of table.
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawFrameOfTable(Graphics graphics)
        {
            int x = 0, y = 0;

            Pen blackPen = new Pen(Color.Black, OuterThickness)
            {
                Alignment = PenAlignment.Inset
            };

            graphics.DrawRectangle(blackPen, -OuterThickness, -OuterThickness, TotalWidth + 2 * OuterThickness, TotalHeight + 2 * OuterThickness);

            for (int row = 1; row < 6; row++)
            {
                y += CellHheight;

                graphics.FillRectangle(BrushInner, 0, y, TotalWidth, InnerThickness);

                y += InnerThickness;

                if (row % 2 == 1)
                {
                    graphics.FillRectangle(brushOdd, 0, y, TotalWidth, CellHheight);
                }
            }

            for (int col = 1; col < 16; col++)
            {
                x += CellWidth;

                graphics.FillRectangle(BrushInner, x, 0, InnerThickness, TotalHeight);

                x += InnerThickness;
            }
        }

        /// <summary>
        /// Draw merged cells of this table.
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawMergedCell(Graphics graphics)
        {
            Brush brushMerge = new SolidBrush(Color.Gray);

            MergeCell(graphics, Brushes.White, 0, 0, 1, 4);
            MergeCell(graphics, brushMerge, 1, 0, 2, 2);
            MergeCell(graphics, brushOdd, 3, 0, 1, 3);
            MergeCell(graphics, brushMerge, 4, 0, 1, 3);
            MergeCell(graphics, brushOdd, 5, 0, 1, 3);
        }

        /// <summary>
        /// Draw title of Table.
        /// </summary>
        /// <param name="graphics">Graphics</param>
        private void DrawTitle(Graphics graphics)
        {
            StringFormat stringFormatCell = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            DrawText(graphics, "測定月", 0, 0, stringFormatCell, 1, 4);

            //Draw Month
            int month = this.s_item.CalcMonth;

            int cnt = 0;

            while (cnt < 12)
            {
                if (month > 12)
                    month = 1;

                DrawText(graphics, month.ToString() + "月", 0, 4 + cnt, stringFormatCell);

                month++;
                cnt++;
            }

            DrawText(graphics, Config.TitleOfAll_ashiage, 1, 0, stringFormatCell, 2, 2);
            DrawText(graphics, Config.TitleOfAll_ashiage_right, 1, 2, stringFormatCell);
            DrawText(graphics, $"({Config.TitleOfAll_ashiage_unit})", 1, 3, stringFormatCell);
            DrawText(graphics, Config.TitleOfAll_ashiage_left, 2, 2, stringFormatCell);
            DrawText(graphics, $"({Config.TitleOfAll_ashiage_unit})", 2, 3, stringFormatCell);
            DrawText(graphics, Config.TitleOfAll_ssfive, 3, 0, stringFormatCell, 1, 3);
            DrawText(graphics, $"({Config.TitleOfAll_ssfive_unit})", 3, 3, stringFormatCell);
            DrawText(graphics, Config.TitleOfTUG, 4, 0, stringFormatCell, 1, 3);
            DrawText(graphics, $"({Config.TitleOfTUG_unit})", 4, 3, stringFormatCell);
            DrawText(graphics, Config.TitleOfCarePitLog, 5, 0, stringFormatCell, 1, 3);
            DrawText(graphics, $"({Config.TitleOfCarePitLog_unit})", 5, 3, stringFormatCell);

            DrawTextOfCells(graphics);
        }

        private void DrawText(Graphics graphics, string Text, int Row, int Col, StringFormat sf, int RowsSpan = 1, int ColsSpan = 1)
        {
            Font fitFont = FindBestFitFont(graphics, Text, this.fontCell, new Size(ColWidth(ColsSpan), RowHeight(RowsSpan)));

            graphics.DrawString(
                Text,
                fitFont,
                Brushes.Black,
                new Rectangle(XPos(Col), YPos(Row), ColWidth(ColsSpan), RowHeight(RowsSpan)),
                sf);
        }

        /// <summary>
        /// Draw merged cell.
        /// </summary>
        /// <param name="graphics">Graphics</param>
        /// <param name="brushMerge">Brush</param>
        /// <param name="Row">Start Row</param>
        /// <param name="Col">Start Col</param>
        /// <param name="RowsSpan">Merged Row Count</param>
        /// <param name="ColsSpan">Merged Col Count</param>
        private void MergeCell(Graphics graphics, Brush brushMerge, int Row, int Col, int RowsSpan, int ColsSpan)
        {
            graphics.FillRectangle(brushMerge,
                XPos(Col),
                YPos(Row),
                ColWidth(ColsSpan),
                RowHeight(RowsSpan));
        }

        /// <summary>
        /// Find font size which fits with specifed size.
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="text">Text String</param>
        /// <param name="font">First font</param>
        /// <param name="proposedSize">Size to be drawn</param>
        /// <returns></returns>
        private Font FindBestFitFont(Graphics g, String text, Font font, Size proposedSize)
        {
            Font fitFont = font;

            // Compute actual size, shrink if needed
            while (true)
            {
                SizeF size = g.MeasureString(text, fitFont);

                // It fits, back out
                if (size.Height <= proposedSize.Height &&
                     size.Width <= proposedSize.Width) 
                { 
                    return fitFont; 
                }

                // Try a smaller font (90% of old size)
                Font oldFont = fitFont;
                fitFont = new Font(font.Name, (float)(fitFont.Size * .9), fitFont.Style);

                if (font != oldFont)
                {
                    oldFont.Dispose();
                }
            }
        }

        /// <summary>
        /// Draw statistic value to Table.
        /// </summary>
        /// <param name="graphics">Graphics</param>
        private void DrawTextOfCells(Graphics graphics)
        {
            //algin is right.
            StringFormat stringFormatCell = new StringFormat()
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };

            //draw statistic value from "片足立ち" to "姿勢".
            for (int kind = 0; kind < 5; kind++)
            {
                for (int month = 0; month < 12; month++)
                {
                    if (Single.IsNaN(this.s_item.Values[kind, month]))
                    {
                        continue;
                    }

                    DrawText(graphics, this.s_item.Values[kind, month].ToString(), 1 + kind, 4 + month, stringFormatCell);
                }
            }
        }
    }
}
