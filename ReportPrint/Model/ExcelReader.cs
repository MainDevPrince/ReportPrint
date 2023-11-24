using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReportPrint.Model
{
    /// <summary>
    /// Class <c>ExcelReader</c> models reading data from Excel file.
    /// It uses EPPPlus open source  solution.
    /// </summary>
    internal static class ExcelReader
    {
        //Read User data from file, Config.ExcelUserFilePath.
        public static IEnumerable<User> GetUsersFromExcel()
        {
            List<User> users = new List<User>();

            //Check whether file exist.
            if (!File.Exists(Config.ExcelUserFilePath))
            {
                return users;
            }

            FileInfo file = new FileInfo(Config.ExcelUserFilePath);

            using (ExcelPackage package = new ExcelPackage(file))
            {
                // Get the first worksheet from the Excel package
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                // Iterate over the rows in the worksheet
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (!int.TryParse(worksheet.Cells[row, 1].Value?.ToString(), out int id))
                    {
                        continue;
                    }

                    User user = new User()
                    {
                        ID = id,
                        Name = (string)worksheet.Cells[row, 2].Value,
                        Birth = (DateTime)worksheet.Cells[row, 3].Value,
                        Sex = (string)worksheet.Cells[row, 4].Value
                    };

                    users.Add(user);
                }
            }

            return users;
        }

    }
}
