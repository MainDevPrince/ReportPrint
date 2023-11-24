using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReportPrint.Report.Charts
{
    /// <summary>
    /// Class <c>LineStyle</c> models line style of data series.
    /// </summary>
    internal class LineStyle
    {
        public bool IsVisible { get; set; } = true;
        public float LineThickness { get; set; } = 1.0f;
        public DashStyle LinePattern { get; set; } = DashStyle.Solid;
        public Color LineColor { get; set; } = Color.Black;
    }
}
