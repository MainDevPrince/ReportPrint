using System.Collections.Generic;
using System.Linq;

namespace ReportPrint.Model
{
    /// <summary>
    /// Class <c>ModelManager</c> models the model management.
    /// It is used to replresent user's data.
    /// </summary>
    internal static class ModelManager
    {
        /// <summary>
        /// Get users information from excel file(Userdata.xlsx).
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<User> Users
        {
            get
            {
                return ExcelReader.GetUsersFromExcel();
            }
        }

        /// <summary>
        /// Get user data from user id.
        /// </summary>
        /// <param name="UserID">User id to retrieve data.</param>
        /// <returns>
        /// List of UserDatas in IUserData
        /// </returns>
        public static IEnumerable<IUserData> GetUserDatas(int UserID)
        {
            List<IUserData> userDatas = new List<IUserData>();

            //get data of ALL.csv
            userDatas.AddRange(UserDataFileManager.GetUserDataFromAllCSV(UserID));
            //get data of TUG.csv
            userDatas.AddRange(UserDataFileManager.GetUserDataFromTUGCSV(UserID));
            //get data of CarePitLog2020.txt
            userDatas.AddRange(UserDataFileManager.GetUserDataFromLogCSV(UserID));

            //Sort in reverse with respect to measure time.
            return userDatas.OrderByDescending(d => d.MeasureTime);
        }
    }
}
