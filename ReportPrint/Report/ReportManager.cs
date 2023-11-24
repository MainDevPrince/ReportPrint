using ReportPrint.Model.Statistics;
using ReportPrinting;

namespace ReportPrint.Report
{
    /// <summary>
    /// Class <c>ReportManager</c> implements AddPrintReportSection of ReportBuilder.
    /// </summary>
    internal static class ReportManager
    {
        /// <summary>
        /// Make Report Section to append on ReportBuilder.
        /// </summary>
        /// <param name="reportBuilder">Report Builder</param>
        /// <param name="s_item">Statistic Item</param>
        internal static void AddPrintReportSection(this ReportBuilder reportBuilder, StatisticItem s_item)
        {
            PrintReportSection section = new PrintReportSection(s_item);

            section.HorizontalAlignment = HorizontalAlignment.Center;

            reportBuilder.AddSection(section);
        }
    }
}
