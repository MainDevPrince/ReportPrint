using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReportPrint.Report.Charts
{
    /// <summary>
    /// Class <c>LineStyle</c> implements LineChart.
    /// </summary>
    internal class LineChart
    {
        public int FirstMonth { get; set; } = 1;
        public string Caption { get; set; } = string.Empty;
        public Font CaptionFont { get; set; } = new Font(Config.PrintFontName, 10, FontStyle.Bold);
        public Color CaptionColor { get; set; } = Color.Black;
        public Color PlotBorderColor { get; set; } = Color.DimGray;
        public float PlotBorderWidth { get; set; } = 4f;

        public float XLimitMin { get; set; } = 0f;
        public float XLimitMax { get; set; } = 13f;
        public float YLimitMin { get; set; } = 0f;
        public float YLimitMax { get; set; } = 10f;
        private float XTick { get; set; } = 1f;
        public float YTick { get; set; } = 2f;
        public Font XTickFont { get; set; } = new Font(Config.PrintFontName, 6, FontStyle.Regular);
        public Font YTickFont { get; set; } = new Font(Config.PrintFontName, 8, FontStyle.Regular);
        public Color TickFontColor { get; set; } = Color.DimGray;
        public bool IsXGrid { get; set; } = true;
        public bool IsYGrid { get; set; } = false;
        public Color GridColor { get; set; } = Color.DimGray;
        public float GridWidth { get; set; } = 4f;
        public string XLabel { get; set; } = string.Empty;
        public string YLabel { get; set; } = string.Empty;
        public Font YLabelFont { get; set; } = new Font(Config.PrintFontName, 8, FontStyle.Regular);
        public Color LabelColor { get; set; } = Color.DimGray;
        public string VerticalUnit { get; set; } = string.Empty;
        public int CharHorizThickness { get; set; } = 10;
        public int CartVertThickness { get; set; } = 10;
        public int ChartOuterRudius { get; set; } = 32;
        public int ChartInnerRudius { get; set; } = 24;

        public Rectangle ChartArea { get; set; }
        public Rectangle PlotArea { get; private set; }

        public LineChart()
        {
        }

        public LineChart(int Left, int Top, int Width, int Height)
        {
            ChartArea = new Rectangle(Left, Top, Width, Height);
        }

        public void AddChartStyle(Graphics g)
        {
            float fX, fY;

            SetPlotArea();

            //Draw Chart Area
            Brush aBrush = new SolidBrush(Color.FromArgb(152, 148, 140));
            Pen aPen = new Pen(PlotBorderColor, PlotBorderWidth)
            {
                Alignment = PenAlignment.Center
            };

            g.FillRoundRect(aBrush, this.ChartArea.Left, this.ChartArea.Top, this.ChartArea.Width, this.ChartArea.Height, CharHorizThickness, CartVertThickness, ChartOuterRudius, ChartInnerRudius);

            aBrush.Dispose();

            //Draw Plot Area
            g.DrawRectangle(aPen, this.PlotArea);

            //Create horizontal gridlines:
            if (this.IsXGrid)
            {
                aPen.Dispose();
                aPen = new Pen(this.GridColor, GridWidth);

                for (fY = this.YLimitMin + this.YTick; fY < this.YLimitMax; fY += YTick)
                {
                    g.DrawLine(aPen, Point2D(XLimitMin, fY), Point2D(XLimitMax, fY));
                }
            }

            //Create the X-Axis tick marks.
            aBrush.Dispose();
            aBrush = new SolidBrush(this.TickFontColor);
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Far
            };

            //draw x-axis(month)
            int month = this.FirstMonth;

            for (fX = 1; fX < XLimitMax; fX += XTick)
            {
                PointF xAxisPoint = Point2D(fX, YLimitMin);
                g.FillRectangle(Brushes.Black, new RectangleF(xAxisPoint.X - 3f, xAxisPoint.Y - 3f, 6f, 6f));

                if (month > 12)
                {
                    month = 1;
                }

                SizeF sizeXTick = g.MeasureString(fX.ToString(), XTickFont);
                g.DrawString(
                    month.ToString(),
                    XTickFont,
                    aBrush,
                    new PointF(xAxisPoint.X + sizeXTick.Width / 2, xAxisPoint.Y + 15f),
                    sf);

                month++;
            }

            SizeF tickFontSize = g.MeasureString("A", YTickFont);
            //Create Y-Axis tick marks.
            for (fY = YLimitMin; fY <= YLimitMax; fY += YTick)
            {
                PointF YAxisPoint = Point2D(XLimitMin, fY);

                g.DrawLine(aPen, YAxisPoint, new PointF(YAxisPoint.X - 6f, YAxisPoint.Y));
                g.DrawString(fY.ToString(),
                    YTickFont,
                    aBrush,
                    new PointF(YAxisPoint.X - 4f, YAxisPoint.Y - tickFontSize.Height / 2),
                    sf);
            }

            aPen.Dispose();
            aBrush.Dispose();

            AddLabels(g);
        }

        void AddLabels(Graphics g)
        {
            //Draw caption
            SizeF size = g.MeasureString(Caption, CaptionFont);
            StringFormat sf = new StringFormat() { Alignment = StringAlignment.Near };
            Brush aBrush = new SolidBrush(CaptionColor);

            g.DrawString(Caption, CaptionFont, aBrush, ChartArea.X + ChartArea.Width / 2 - size.Width / 2, ChartArea.Top + 25f, sf);

            //Draw Y caption
            GraphicsState prev = g.Save();

            aBrush.Dispose();
            aBrush = new SolidBrush(LabelColor);
            size = g.MeasureString(YLabel, YLabelFont);
            g.TranslateTransform(ChartArea.X + 60, PlotArea.Y + PlotArea.Height / 2);
            g.RotateTransform(270);
            g.DrawString(YLabel, YLabelFont, aBrush, -size.Width / 2, -size.Height / 2);

            g.Restore(prev);

            aBrush.Dispose();
        }

        void SetPlotArea()
        {
            int plotX = this.ChartArea.Left + 140;
            int plotY = this.ChartArea.Top + 85;
            int plotWidth = this.ChartArea.Width - 140 - 20;
            int plotHeight = this.ChartArea.Height - 85 - 120;

            this.PlotArea = new Rectangle(plotX, plotY, plotWidth, plotHeight);
        }

        public PointF Point2D(PointF pt)
        {
            return Point2D(pt.X, pt.Y);
        }

        public PointF Point2D(float X, float Y)
        {
            PointF aPoint = new PointF();

            if (X < XLimitMin || X > XLimitMax || Y < YLimitMin || Y > YLimitMax)
            {
                X = Single.NaN;
                Y = Single.NaN;
            }

            aPoint.X = PlotArea.X + (X - XLimitMin) * PlotArea.Width / (XLimitMax - XLimitMin);
            aPoint.Y = PlotArea.Bottom - (Y - YLimitMin) * PlotArea.Height / (YLimitMax - YLimitMin);

            return aPoint;
        }
    }
}
