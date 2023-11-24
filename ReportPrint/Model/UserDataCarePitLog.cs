using System;

namespace ReportPrint.Model
{
    /// <summary>
    /// Class <c>UserDataCarePitLog</c> models user data in CarePitLog2020.txt.
    /// </summary>
    internal class UserDataCarePitLog : IUserData
    {
        /// <summary>
        /// UserID in CarePitLog2020.txt
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// GameType.CarePitLog
        /// </summary>
        public GameType GameType { get; set; } = GameType.CarePitLog;
        /// <summary>
        /// Line no of data in CarePitLog2020.txt
        /// </summary>
        public int LineNo { get; set; }
        /// <summary>
        /// DATE in CarePitLog2020.txt
        /// </summary>
        public DateTime MeasureTime { get; set; }
        /// <summary>
        /// SCORE in CarePitLog2020.txt
        /// </summary>
        public float GameScore { get; set; }

        /// <summary>
        /// "姿勢"
        /// </summary>
        public string GameTitle => Config.TitleOfCarePitLog;
    }
}
