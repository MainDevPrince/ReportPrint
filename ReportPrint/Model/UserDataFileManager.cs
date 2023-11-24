using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ReportPrint.Model
{
    /// <summary>
    /// Class <c>UserDataFileManager</c> read, modify and remove user data file item.
    /// And Add TUG data item.
    /// </summary>
    internal class UserDataFileManager
    {
        /// <summary>
        /// Read user data from ALL.csv.
        /// delimiter is ','.
        /// </summary>
        /// <param name="UserID">User id</param>
        /// <returns>List of UserDataAll</returns>
        internal static IEnumerable<IUserData> GetUserDataFromAllCSV(int UserID)
        {
            List<IUserData> userDatas = new List<IUserData>();
            int csvLineNo = 0; //Line no in CSV
            DateTime? measureTime;
            float? score;

            if (!File.Exists(Config.CSVUserDataAllFilePath))
            {
                return userDatas;
            }

            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true
            };

            using (var streamReader = File.OpenText(Config.CSVUserDataAllFilePath))
            using (var csvReader = new CsvReader(streamReader, csvConfig))
            {
                while (csvReader.Read())
                {
                    csvReader.TryGetField<string>(0, out string value);
                    csvLineNo++;

                    if (!int.TryParse(value, out int userID))
                    {
                        continue;
                    }

                    if (userID != UserID)
                    {
                        continue;
                    }

                    if (csvReader.TryGetField<string>(1, out string Date))
                    {
                        measureTime = ParseDate(Date);

                        if (measureTime == null)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    if (csvReader.TryGetField<string>(4, out string GameName))
                    {
                        if (GameName != "ssfive" &&
                            GameName != "ashiage")
                        {
                            continue;
                        }
                    }
                    else 
                    { 
                        continue; 
                    }

                    if (csvReader.TryGetField<string>(5, out string GameOption))
                    {
                        GameOption = GameOption.Trim();
                    }
                    else
                    { 
                        continue; 
                    }

                    if (csvReader.TryGetField<string>(7, out string Score))
                    {
                        score = ParseScore(Score);
                        if (score == null)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    UserDataAll userData = new UserDataAll()
                    {
                        UserId = userID,
                        GameType = GameName == "ssfive" ? GameType.All_ssfive : GameType.All_ashiage,
                        LineNo = csvLineNo - 1,
                        MeasureTime = measureTime.Value,
                        GameScore = score.Value,
                        IsLeft = GameOption == string.Empty ? (bool?)null  : (GameOption == Config.TitleOfAll_ashiage_left)
                    };

                    userDatas.Add(userData);
                }
            }

            return userDatas;
        }

        /// <summary>
        /// Read user data from CarePitLog2020.txt.
        /// delimiter is '\t'.
        /// </summary>
        /// <param name="UserID">User id</param>
        /// <returns>List of UserDataCarePitLog</returns>
        internal static IEnumerable<IUserData> GetUserDataFromLogCSV(int UserID)
        {
            List<IUserData> userDatas = new List<IUserData>();
            int csvLineNo = 0; //Line no in CSV
            DateTime? measureTime;
            float? score;

            if (!File.Exists(Config.CSVUserDataCarePitLogFilePath))
            {
                return userDatas;
            }

            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                Delimiter = "\t",
                HasHeaderRecord = true
            };

            using (var streamReader = File.OpenText(Config.CSVUserDataCarePitLogFilePath))
            using (var csvReader = new CsvReader(streamReader, csvConfig))
            {
                while (csvReader.Read())
                {
                    csvLineNo++;
                    csvReader.TryGetField<string>(2, out string value);

                    if (!int.TryParse(value, out int userID))
                    {
                        continue;
                    }

                    if (userID != UserID)
                    {
                        continue;
                    }

                    if (csvReader.TryGetField<string>(1, out string Date))
                    {
                        measureTime = ParseDate(Date);

                        if (measureTime == null)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    if (csvReader.TryGetField<string>(4, out string Score))
                    {
                        score = ParseScore(Score);
                        if (score == null)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    UserDataCarePitLog userData = new UserDataCarePitLog()
                    {
                        UserId = userID,
                        LineNo = csvLineNo - 1,
                        MeasureTime = measureTime.Value,
                        GameScore = score.Value
                    };

                    userDatas.Add(userData);
                }
            }

            return userDatas;
        }

        /// <summary>
        /// Read user data from TUG.csv.
        /// delimiter is ','.
        /// </summary>
        /// <param name="UserID">User id</param>
        /// <returns>List of UserDataTUG</returns>
        public static IEnumerable<IUserData> GetUserDataFromTUGCSV(int UserID)
        {
            List<IUserData> userDatas = new List<IUserData>();
            int csvLineNo = 0; //Line no in CSV
            DateTime? measureTime;
            float? score;

            if (!File.Exists(Config.CSVUserDataTUGFilePath))
            {
                return userDatas;
            }

            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true
            };

            using (var streamReader = File.OpenText(Config.CSVUserDataTUGFilePath))
            using (var csvReader = new CsvReader(streamReader, csvConfig))
            {
                while (csvReader.Read())
                {
                    csvLineNo++;
                    csvReader.TryGetField<string>(0, out string value);

                    if (!int.TryParse(value, out int userID))
                    {
                        continue;
                    }

                    if (userID != UserID)
                    {
                        continue;
                    }

                    if (csvReader.TryGetField<string>(1, out string Date))
                    {
                        measureTime = ParseDate(Date);

                        if (measureTime == null)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    if (csvReader.TryGetField<string>(2, out string Score))
                    {
                        score = ParseScore(Score);
                        if (score == null)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    UserDataTUG userData = new UserDataTUG()
                    {
                        UserId = userID,
                        LineNo = csvLineNo - 1,
                        MeasureTime = measureTime.Value,
                        GameScore = score.Value
                    };

                    userDatas.Add(userData);
                }
            }

            return userDatas;
        }

        /// <summary>
        /// Get File name by GameType.
        /// delimiter is '\t'.
        /// </summary>
        /// <param name="gameType">Game Type</param>
        /// <returns>Data File Name</returns>
        private static string GetFileNameByGameType(GameType gameType)
        {
            switch(gameType)
            {
                case GameType.All_ashiage_left:
                case GameType.All_ashiage_right:
                case GameType.All_ssfive:
                    return Config.CSVUserDataAllFilePath;
                case GameType.TUG:
                    return Config.CSVUserDataTUGFilePath;
                case GameType.CarePitLog:
                    return Config.CSVUserDataCarePitLogFilePath;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Delete user data from user data file.
        /// delimiter is '\t'.
        /// </summary>
        /// <param name="userData">User data item</param>
        /// <returns>true if succeed, false when fails</returns>
        public static bool DeleteUserData(IUserData userData)
        {
            string pathName = GetFileNameByGameType(userData.GameType);

            if (!File.Exists(pathName))
            {
                return false;
            }

            List<String> lines = new List<String>();
            int lineNo = 0;

            using (StreamReader reader = new StreamReader(pathName))
            {
                String line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNo != userData.LineNo)
                        lines.Add(line);
                    lineNo++;
                }
            }

            //Set file size 0
            File.WriteAllBytes(pathName, new byte[0]);
            using (StreamWriter writer = new StreamWriter(pathName, true))
            {
                foreach (String line in lines)
                {
                    writer.WriteLine(line);
                }
            }

            return true;
        }

        /// <summary>
        /// Modify user game score to value.
        /// </summary>
        /// <param name="userData">User data item</param>
        /// <param name="gameScore">Modified Game Score</param>
        /// <param name="isLeft">Modified Left/Right</param>
        /// <returns>true if succeed, false when fails</returns>
        public static bool ModifyGameScore(IUserData userData, float gameScore, bool? isLeft)
        {
            switch (userData.GameType)
            {
                case GameType.All_ashiage_left:
                case GameType.All_ashiage_right:
                case GameType.All_ssfive:
                    return ModifyGameScoreFromAllCSV(userData, gameScore, isLeft);
                case GameType.TUG:
                    return ModifyGameScoreFromTUGCSV(userData, gameScore);
                case GameType.CarePitLog:
                    return ModifyGameScoreFromLogCSV(userData, gameScore);
                default: return false;
            }
        }

        /// <summary>
        /// Modify user game score to value in All.csv.
        /// </summary>
        /// <param name="userData">User data item</param>
        /// <param name="value">Modified value</param>
        /// <returns>true if succeed, false when fails</returns>
        static bool ModifyGameScoreFromAllCSV(IUserData userData, float value, bool? isLeft)
        {
            string pathName = Config.CSVUserDataAllFilePath;

            if (!File.Exists(pathName))
            {
                return false;
            }

            string[] lines = File.ReadAllLines(pathName);

            string line = lines[userData.LineNo];

            var split = line.Split(',');

            if (split.Length <= Config.IndexOfAll_GameScore)
            {
                return false;
            }

            split[Config.IndexOfAll_GameScore] = value.ToString();
            split[Config.IndexOfAll_GameOption] = isLeft == null ? "" : (isLeft.Value ? Config.TitleOfAll_ashiage_left:Config.TitleOfAll_ashiage_right);

            lines[userData.LineNo] = string.Join(",", split);

            File.WriteAllLines(pathName, lines);

            return true;
        }

        /// <summary>
        /// Modify user game score to value in CarePitLog2020.txt.
        /// </summary>
        /// <param name="userData">User data item</param>
        /// <param name="value">Modified value</param>
        /// <returns>true if succeed, false when fails</returns>
        static bool ModifyGameScoreFromLogCSV(IUserData userData, float value)
        {
            string pathName = Config.CSVUserDataCarePitLogFilePath;

            if (!File.Exists(pathName))
            {
                return false;
            }

            string[] lines = File.ReadAllLines(pathName);

            string line = lines[userData.LineNo];

            var split = line.Split('\t');

            if (split.Length <= Config.IndexOfCarePitLog_GameScore)
            {
                return false;
            }

            split[Config.IndexOfCarePitLog_GameScore] = value.ToString();
            lines[userData.LineNo] = string.Join("\t", split);

            File.WriteAllLines(pathName, lines);

            return true;
        }

        /// <summary>
        /// Modify user game score to value in TUG.csv.
        /// </summary>
        /// <param name="userData">User data item</param>
        /// <param name="value">Modified value</param>
        /// <returns>true if succeed, false when fails</returns>
        static bool ModifyGameScoreFromTUGCSV(IUserData userData, float value)
        {
            string pathName = Config.CSVUserDataTUGFilePath;

            if (!File.Exists(pathName))
            {
                return false;
            }

            string[] lines = File.ReadAllLines(pathName);

            string line = lines[userData.LineNo];

            var split = line.Split(',');

            if (split.Length <= Config.IndexOfTUG_GameScore)
            {
                return false;
            }

            split[Config.IndexOfTUG_GameScore] = value.ToString();
            lines[userData.LineNo] = string.Join(",", split);

            File.WriteAllLines(pathName, lines);

            return true;
        }

        /// <summary>
        /// Make "Timed up & go" skelton file when it does not exist.
        /// </summary>
        /// <returns>true if succeed, false when fails</returns>
        static bool MakeTUGSkelton()
        {
            if (!Directory.Exists(Config.CSVUserDataTUGDirectoryPath))
            {
                Directory.CreateDirectory(Config.CSVUserDataTUGDirectoryPath);
            }

            File.WriteAllLines(Config.CSVUserDataTUGFilePath, new string[] { "UserID,DATE,Score" });

            return true;
        }

        /// <summary>
        /// Append TUG data to TUG.csv.
        /// </summary>
        /// <param name="UserID">User ID</param>
        /// <param name="MeasureTime">Measure Time</param>
        /// <param name="GameScore">Game Score</param>
        /// <returns></returns>
        internal static bool AppendTUGData(int UserID, DateTime MeasureTime, float GameScore)
        {
            string pathName = Config.CSVUserDataTUGFilePath;

            if (!File.Exists(pathName))
            {
                MakeTUGSkelton();
            }

            if (!File.Exists(pathName))
                return false;

            using (StreamWriter writer = new StreamWriter(pathName, true))
            {
                writer.WriteLine($"{UserID},{MeasureTime:yyyy/M/d},{GameScore}");
            }

            return true;
        }

        /// <summary>
        /// Convert string to DateTime.
        /// </summary>
        /// <param name="MeasureDateTime"></param>
        /// <returns></returns>
        static DateTime? ParseDate(string MeasureDateTime)
        {
            string[] formats = {
                "yyyy/M/d",
                "yyyy/M/d HH:mm",
                "yyyy/M/d h:mm",
                "yyyy/M/d HH:mm:s",
                "yyyy/M/d HH:mm:ss",
                "yyyy/M/d HH:mm:ss",
            };

            if (DateTime.TryParseExact(MeasureDateTime, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
            {
                return dateValue;
            }

            return null;
        }

        /// <summary>
        /// Convert Game Score in string to float.
        /// </summary>
        /// <param name="GameScore"></param>
        /// <returns></returns>
        static float? ParseScore(string GameScore)
        {
            if (!float.TryParse(GameScore, out float score))
            {
                return null;
            }

            return score;
        }
    }
}
