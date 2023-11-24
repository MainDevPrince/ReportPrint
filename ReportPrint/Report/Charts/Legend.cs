using System;
using System.Drawing;

namespace ReportPrint.Report.Charts
{
    /// <summary>
    /// Class <c>Legend</c> models Legend of chart.
    /// </summary>
    internal class Legend
    {
        //Specify whether legend is visible.
        public bool IsLegendVisible { get; set; } = false;
        //Text color of legend.
        public Color TextColor { get; set; } = Color.Black;
        //Font  color of legend.
        public Font LegendFont { get; set; } = new Font("", 8, FontStyle.Regular);
        //width of displaying data series mark.
        float LegendMarkWidth { get; set; } = 60f;
        //Gap between data sereis mark.
        float GapBetweenItems { get; set; } = 15f;
        //gap between data sereis mark and mark text.
        float GapsBetweenLineAndText { get; set; } = 4f;

        /// <summary>
        /// Draw legend to chart.
        /// </summary>
        /// <param name="g"Graphics></param>
        /// <param name="dc">DataCollection</param>
        /// <param name="chart">LineChart</param>
        public void AddLegend(Graphics g, DataCollection dc, LineChart chart)
        {
            if (dc.DataSeriesList.Count == 0)
            {
                return;
            }
            if (!IsLegendVisible)
            {
                return;
            }

            float totalWidth = 0;
            float legendHeight = 0;

            foreach (DataSeries ds in dc.DataSeriesList)
            {
                if (totalWidth > 0)
                {
                    totalWidth += GapBetweenItems;
                }

                totalWidth += LegendMarkWidth;

                SizeF size = g.MeasureString(ds.SeriesName, LegendFont);

                totalWidth += size.Width;
                legendHeight = Math.Max(legendHeight, size.Height);
            }

            DrawLegend(g,
                chart.ChartArea.Left + chart.ChartArea.Width / 2 - totalWidth / 2, chart.PlotArea.Bottom + 60,
                legendHeight, dc, chart);
        }

        void DrawLegend(Graphics g, float x, float y, float height, DataCollection dc, LineChart chart)
        {
            Brush br = new SolidBrush(TextColor);

            float yLine = y + height / 2;

            foreach (DataSeries ds in dc.DataSeriesList)
            {
                using (Pen aPen = new Pen(ds.LineStyle.LineColor, ds.LineStyle.LineThickness))
                {
                    aPen.DashStyle = ds.LineStyle.LinePattern;

                    g.DrawLine(aPen, x, yLine, x + LegendMarkWidth, yLine);
                    ds.Symbol.DrawSymbol(g, new PointF(x + LegendMarkWidth / 2, yLine));

                    x += LegendMarkWidth + GapsBetweenLineAndText;

                    SizeF size = g.MeasureString(ds.SeriesName, LegendFont);
                    g.DrawString(ds.SeriesName, LegendFont, br, x, y);

                    x += size.Width;
                    x += GapBetweenItems;
                }
            }

            br.Dispose();
        }
    }
}
