using OfficeOpenXml;
using System;
using System.Windows.Forms;

namespace ReportPrint
{
    /// <summary>
    /// This is the main entry point for the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Setting EPPPlus license.
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            Application.Run(new MainForm());
        }
    }
}
