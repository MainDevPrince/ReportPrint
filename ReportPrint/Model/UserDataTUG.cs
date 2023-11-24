using System;

namespace ReportPrint.Model
{
    /// <summary>
    /// Class <c>UserDataCarePitLog</c> models user data in TUG.csv.
    /// </summary>
    internal class UserDataTUG : IUserData
    {
        /// <summary>
        /// UserID in TUG.csv
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// GameType.TUG
        /// </summary>
        public GameType GameType { get; set; } = GameType.TUG;
        /// <summary>
        /// Line no of data in TUG.csv
        /// </summary>
        public int LineNo { get; set; }
        /// <summary>
        /// DATE in TUG.csv
        /// </summary>
        public DateTime MeasureTime { get; set; }
        /// <summary>
        /// Score in TUG.csv
        /// </summary>
        public float GameScore { get; set; }

        /// <summary>
        /// "Timed up & go"
        /// </summary>
        public string GameTitle => Config.TitleOfTUG;
    }
}
