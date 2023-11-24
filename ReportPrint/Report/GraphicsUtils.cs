using System.Drawing;
using System.Drawing.Drawing2D;

namespace ReportPrint.Report
{
    /// <summary>
    /// Class <c>GraphicsUtils</c> implements the functions widly used in making Report.
    /// </summary>
    internal static class GraphicsUtils
    {
        /// <summary>
        /// Draw first title rectangle region in Report section.
        /// </summary>
        /// <param name="graphics">Graphics</param>
        /// <param name="x">X coordinate of rectangle</param>
        /// <param name="y">Y coordinate of rectangle</param>
        /// <param name="width">Width of rectangle</param>
        /// <param name="height">Height of rectangle</param>
        /// <param name="radius">Rudius of rectangle</param>
        /// <param name="brush">Brush filling rectangle</param>
        public static void DrawHalfRoundedRectangle(this Graphics graphics, int x, int y, int width, int height, int radius, Brush brush)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = 2 * radius;
            Rectangle arcRect = new Rectangle(x, y, diameter, diameter);

            // Top left arc
            path.AddArc(arcRect, 180, 90);
            path.AddLine(x + radius, y, x + width - radius, y);
            arcRect.X += width - diameter;

            // Top right arc
            path.AddArc(arcRect, 270, 90);
            path.AddLine(x + width, y + radius, x + width, y + height);

            path.AddLine(x + width, y + height, x, y + height);
            path.AddLine(x, y + height, x, y + radius);


            // Close the path
            path.CloseFigure();

            // Fill the rounded rectangle path
            graphics.FillPath(brush, path);
        }

        /// <summary>
        /// Draw thick round rectangle.
        /// </summary>
        /// <param name="graphics">Graphics</param>
        /// <param name="brush">Brush filling frame</param>
        /// <param name="x">X coordinate of outer rectangle</param>
        /// <param name="y">Y coordinate of outer rectangle</param>
        /// <param name="width">Width of outer rectangle</param>
        /// <param name="height">Height of outer rectangle</param>
        /// <param name="xThick">Frame Width Thickness</param>
        /// <param name="yThick">Frame Height Thickness</param>
        /// <param name="outerCornerRadius">Rudius of outer rectangle</param>
        /// <param name="innerConnerRadius">Rudius of inner rectangle</param>
        public static void FillRoundRect(this Graphics graphics, Brush brush, int x, int y, int width, int height, int xThick, int yThick, int outerCornerRadius, int innerConnerRadius)
        {
            GraphicsPath path = new GraphicsPath();

            FillRoundRect(path, x, y, width, height, outerCornerRadius);
            FillRoundRect(path, x + xThick, y + yThick, width - 2 * xThick, height - 2 * yThick, innerConnerRadius);

            // Close the path
            path.CloseFigure();

            // Fill the rounded rectangle path
            graphics.FillPath(brush, path);
        }

        /// <summary>
        /// Draw round rectangle.
        /// </summary>
        /// <param name="path">GraphicsPath</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="width">Width of rectangle</param>
        /// <param name="height">Height of rectangle</param>
        /// <param name="cornerRadius"></param>
        private static void FillRoundRect(this GraphicsPath path, int x, int y, int width, int height, int cornerRadius)
        {
            int diameter = 2 * cornerRadius;
            Rectangle arcRect = new Rectangle(x, y, diameter, diameter);

            // Top left arc
            path.AddArc(arcRect, 180, 90);
            path.AddLine(x + cornerRadius, y, x + width - cornerRadius, y);
            arcRect.X += width - diameter;

            // Top right arc
            path.AddArc(arcRect, 270, 90);
            path.AddLine(x + width, y + cornerRadius, x + width, y + height - cornerRadius);
            arcRect.Y += height - diameter;

            // Bottom right arc
            path.AddArc(arcRect, 0, 90);
            arcRect.X -= width - diameter;
            path.AddLine(x + width - cornerRadius, y + height, x + cornerRadius, y + height);

            // Bottom left arc
            path.AddArc(arcRect, 90, 90);
            path.AddLine(x, y + height - cornerRadius, x, y + cornerRadius);
        }
    }
}
