using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportPrint
{
    /// <summary>
    /// Class <c>Config</c> models the configuration.
    /// </summary>
    internal static class Config
    {
        const string ApplicationRegPath = "Software\\ReportApp";
        
        const string RegDataPath = "data-path";

        static internal string ExcelUserFilePath => $"{DataPath}\\TANO-USERDATA\\Userdata.xlsx";
        static internal string CSVUserDataAllFilePath => $"{DataPath}\\TANO-USERDATA\\ALL.csv";
        static internal string CSVUserDataCarePitLogFilePath => $"{DataPath}\\TANO-CarePit\\CarePitLog2020.txt";
        static internal string CSVUserDataTUGFilePath => $"{DataPath}\\TANO-TUG\\TUG.csv";
        static internal string CSVUserDataTUGDirectoryPath => $"{DataPath}\\TANO-TUG";

        internal const string TitleOfAll_ashiage = "片足立ち";
        internal const string TitleOfAll_ashiage_left = "左";
        internal const string TitleOfAll_ashiage_right = "右";
        internal const string TitleOfAll_ashiage_unit = "秒";
        internal const string TitleOfAll_ssfive = "立ち座り";
        internal const string TitleOfAll_ssfive_unit = "数";
        internal const string TitleOfTUG = "Timed up & go";
        internal const string TitleOfTUG_unit = "秒";
        internal const string TitleOfCarePitLog = "姿勢";
        internal const string TitleOfCarePitLog_unit = "点";

        internal const int IndexOfAll_GameOption = 5;
        internal const int IndexOfAll_GameScore = 7;
        internal const int IndexOfTUG_GameScore = 2;
        internal const int IndexOfCarePitLog_GameScore = 4;

        internal const string PrintFontName = "Meiryo UI";

        static string GetConfigValue(string Name)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(ApplicationRegPath))
            {
                if (key != null)
                {
                    object value = key.GetValue(Name);
                    
                    if (value != null)
                    {
                        // Process the retrieved value
                        return value.ToString();
                    }
                    else
                    {
                        // Handle case when the value doesn't exist
                        Console.WriteLine("The specified value doesn't exist in the registry.");
                        return string.Empty;
                    }
                }
                else
                {
                    // Handle case when the registry key doesn't exist
                    Console.WriteLine("The specified registry key doesn't exist.");
                    return string.Empty;
                }
            }
        }

        static float GetConfigFloatValue(string Name)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(ApplicationRegPath))
            {
                if (key != null)
                {
                    object value = key.GetValue(Name);

                    if (value != null)
                    {
                        // Process the retrieved value
                        return float.Parse(value.ToString());
                    }
                    else
                    {
                        // Handle case when the value doesn't exist
                        Console.WriteLine("The specified value doesn't exist in the registry.");
                        return Single.NaN;
                    }
                }
                else
                {
                    // Handle case when the registry key doesn't exist
                    Console.WriteLine("The specified registry key doesn't exist.");
                    return Single.NaN;
                }
            }
        }

        static void SetConfigValue(string Name, string Value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(ApplicationRegPath))
            {
                key.SetValue(Name, Value);
            }
        }

        static void SetConfigValue(string Name, float Value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(ApplicationRegPath))
            {
                key.SetValue(Name, Value.ToString());
            }
        }

        static internal string DataPath
        {
            get
            {
                string path = GetConfigValue(RegDataPath);

                if (path == string.Empty)
                {
                    //Get default datapath and set
                    string myDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    SetConfigValue(RegDataPath, myDocumentPath);

                    return myDocumentPath;
                }
                else
                {
                    return path;
                }
            }

            set
            {
                SetConfigValue(RegDataPath, value);
            }
        }

        #region Axis
        const string Reg_ashiag_min = "ax_ashiag_min";
        const string Reg_ashiag_max = "ax_ashiag_max";
        const string Reg_ashiag_intv = "ax_ashiag_intv";
        const string Reg_ssfive_min = "ax_ssfive_min";
        const string Reg_ssfive_max = "ax_ssfive_max";
        const string Reg_ssfive_intv = "ax_ssfive_intv";
        const string Reg_tug_min = "ax_tug_min";
        const string Reg_tug_max = "ax_tug_max";
        const string Reg_tug_intv = "ax_tug_intv";
        const string Reg_log_min = "ax_log_min";
        const string Reg_log_max = "ax_log_max";
        const string Reg_log_intv = "ax_log_intv";

        static float GetAxisReg(string RegName, float default_value)
        {
            float value = GetConfigFloatValue(RegName);

            if (Single.IsNaN(value))
            {
                SetConfigValue(RegName, default_value);

                return default_value;
            }
            else
            {
                return value;
            }
        }

        internal static float Axis_ashiag_y_min
        {
            get { return GetAxisReg(Config.Reg_ashiag_min, 0); }
            set { SetConfigValue(Config.Reg_ashiag_min, value); }
        }
        internal static float Axis_ashiag_y_max
        {
            get { return GetAxisReg(Config.Reg_ashiag_max, 80); }
            set { SetConfigValue(Config.Reg_ashiag_max, value); }
        }
        internal static float Axis_ashiag_y_intv
        {
            get { return GetAxisReg(Config.Reg_ashiag_intv, 20); }
            set { SetConfigValue(Config.Reg_ashiag_intv, value); }
        }

        internal static float Axis_ssfive_y_min
        {
            get { return GetAxisReg(Config.Reg_ssfive_min, 0); }
            set { SetConfigValue(Config.Reg_ssfive_min, value); }
        }
        internal static float Axis_ssfive_y_max
        {
            get { return GetAxisReg(Config.Reg_ssfive_max, 25); }
            set { SetConfigValue(Config.Reg_ssfive_max, value); }
        }
        internal static float Axis_ssfive_y_intv
        {
            get { return GetAxisReg(Config.Reg_ssfive_intv, 5); }
            set { SetConfigValue(Config.Reg_ssfive_intv, value); }
        }
        internal static float Axis_tug_y_min
        {
            get { return GetAxisReg(Config.Reg_tug_min, 0); }
            set { SetConfigValue(Config.Reg_tug_min, value); }
        }
        internal static float Axis_tug_y_max
        {
            get { return GetAxisReg(Config.Reg_tug_max, 30); }
            set { SetConfigValue(Config.Reg_tug_max, value); }
        }
        internal static float Axis_tug_y_intv
        {
            get { return GetAxisReg(Config.Reg_tug_intv, 5); }
            set { SetConfigValue(Config.Reg_tug_intv, value); }
        }
        internal static float Axis_log_y_min
        {
            get { return GetAxisReg(Config.Reg_log_min, 0); }
            set { SetConfigValue(Config.Reg_log_min, value); }
        }
        internal static float Axis_log_y_max
        {
            get { return GetAxisReg(Config.Reg_log_max, 100); }
            set { SetConfigValue(Config.Reg_log_max, value); }
        }
        internal static float Axis_log_y_intv
        {
            get { return GetAxisReg(Config.Reg_log_intv, 20); }
            set { SetConfigValue(Config.Reg_log_intv, value); }
        }
        #endregion
    }
}
