using System;

namespace ReportPrint.Model
{
    /// <summary>
    /// Class <c>UserDataAll</c> models user data in ALL.csv.
    /// </summary>
    internal class UserDataAll : IUserData
    {
        /// <summary>
        /// UserID in ALL.csv
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// If GameName in ALL.csv is "ssfive" then GameType.All_ssfive, 
        /// Else if "ashiage" then GameType.All_ashiage
        /// </summary>
        public GameType GameType { get; set; }
        /// <summary>
        /// Line no of data in ALL.csv
        /// </summary>
        public int LineNo { get; set; }
        /// <summary>
        /// Start in ALL.csv
        /// </summary>
        public DateTime MeasureTime { get; set; }
        /// <summary>
        /// Score in ALL.csv
        /// </summary>
        public float GameScore { get; set; }
        /// <summary>
        /// If GameOption in ALL.csv is "左" then tue,
        /// ELse false
        /// </summary>
        public bool? IsLeft { get; set; }
        /// <summary>
        /// If GameName in ALL.csv is "ssfive" then "立ち座り", 
        /// Else if "ashiage" then "片足立ち"
        /// </summary>
        public string GameTitle => GameType == GameType.All_ssfive ? Config.TitleOfAll_ssfive : Config.TitleOfAll_ashiage;
    }
}
