using DotSpatial.Positioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PinPoint
{
    public static class PinPointConfig
    {
        public static string UnitID { get; set; }
        public static string UnitType { get; set; }

        /// <summary>
        /// Post Interval in milliseconds.
        /// </summary>
        public static int PostInterval { get; set; }

        /// <summary>
        /// Post Interval in seconds.  Config file stores interval in seconds
        /// </summary>
        public static int PostIntervalSeconds
        {
            get
            {
                return PostInterval / 1000;
            }

            set
            {
                PostInterval = value * 1000;
            }
        }

        public static bool AutoEnable { get; set; }
        public static string PostURL { get; set; }

        public static bool DebugMode { get; set; }

        public static void LoadSettings()
        {
            bool bootmp;
            UnitID = Properties.Settings.Default.UnitID;
            UnitType = Properties.Settings.Default.UnitType;
            PostIntervalSeconds = Properties.Settings.Default.PostInterval;

            Boolean.TryParse(ConfigurationManager.AppSettings["AutoEnable"], out bootmp);
            AutoEnable = bootmp;
            PostURL = ConfigurationManager.AppSettings["PostURL"];
            Boolean.TryParse(ConfigurationManager.AppSettings["DebugMode"], out bootmp);
            DebugMode = bootmp;   
        }

        /// <summary>
        /// Checks if there are any settings missing that the user is responsible for
        /// </summary>
        /// <returns>true if settings must be set, false otherwise</returns>
        public static bool isInitSettingRequired()
        {
            if (String.IsNullOrWhiteSpace(UnitID) || String.IsNullOrWhiteSpace(UnitType)
                    || PostInterval <= 0)
            {
                return true;
            }

            return false;
        }

        public static void SaveSettings()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            settings["AutoEnable"].Value = AutoEnable.ToString();
            settings["PostURL"].Value = PostURL;
            settings["DebugMode"].Value = DebugMode.ToString();

            Properties.Settings.Default.UnitID = UnitID;
            Properties.Settings.Default.UnitType = UnitType;
            Properties.Settings.Default.PostInterval = PostIntervalSeconds;

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

            Properties.Settings.Default.Save();
        }

    }
}
