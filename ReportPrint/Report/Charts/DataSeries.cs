using System;
using System.Collections.Generic;
using System.Drawing;

namespace ReportPrint.Report.Charts
{
    /// <summary>
    /// Class <c>DataSeries</c> models series of chart.
    /// </summary>
    internal class DataSeries
    {
        public LineStyle LineStyle { get; set; } = new LineStyle();
        public SymbolStyle Symbol { get; set; } = new SymbolStyle();
        public string SeriesName { get; set; } = String.Empty;
        public List<PointF> PointList { get; set; } = new List<PointF>();
    }
}
