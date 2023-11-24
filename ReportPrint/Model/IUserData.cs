using System;

namespace ReportPrint.Model
{
    /// <summary>
    /// Interface <c>IUserData</c> models the user data.
    /// It is used to replresent user's data.
    /// </summary>
    internal interface IUserData
    {
        /// <summary>
        /// User's Id in Userdata.xlsx
        /// </summary>
        int UserId { get; set; }
        /// <summary>
        /// Game type in EnumGameType.
        /// </summary>
        GameType GameType { get; set; }
        /// <summary>
        /// Measure Time
        /// </summary>
        DateTime MeasureTime { get; set; }
        /// <summary>
        /// Game Score
        /// </summary>
        float GameScore { get; set; }
        /// <summary>
        /// Game Title.(片足立ち,立ち座り,Timed up & go,姿勢)
        /// </summary>
        string GameTitle { get; }
        /// <summary>
        /// Line no in CSV data file
        /// </summary>
        int LineNo { get; set; }

    }
}
