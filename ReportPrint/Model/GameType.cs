namespace ReportPrint.Model
{
    /// <summary>
    /// Class <c>GameType</c> models the type of user data.
    /// It is used in statistics data index.
    /// Also enum <c>GameType</c> is used in Chart and Table's data.
    /// </summary>
    enum GameType : int
    {
        /// <summary>
        /// 片足立ち
        /// </summary>
        All_ashiage = 0,
        /// <summary>
        /// 片足立ち_右
        /// </summary>
        All_ashiage_right = 0,
        /// <summary>
        /// 片足立ち_左
        /// </summary>
        All_ashiage_left = 1,
        /// <summary>
        /// 立ち座り
        /// </summary>
        All_ssfive = 2,
        /// <summary>
        /// Timed up & go
        /// </summary>
        TUG = 3,
        /// <summary>
        /// 姿勢
        /// </summary>
        CarePitLog = 4,
    }
}
