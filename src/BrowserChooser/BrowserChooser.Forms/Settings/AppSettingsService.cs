using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using BrowserChooser.Forms.Models;

namespace BrowserChooser.Forms.Settings
{
    public class AppSettingsService
    {
        public const string BrowserChooserConfigFileName = "BrowserChooserConfig.xml";
        public const int DaysBetweenUpdateCheck = 3;

        public static bool PortableMode;
        public static string DefaultMessage = "Choose a Browser";
        public static string UrlToOpen;
        public static BrowserConfig BrowserConfig;
        public static List<Browser> Browsers { get; set; } = new List<Browser>();

        public static void Load()
        {
            var settingsFile = GetSettingsFile();
            if (File.Exists(settingsFile))
            {
                using (Stream writer = new FileStream(settingsFile, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(BrowserConfig));
                    BrowserConfig = (BrowserConfig)serializer.Deserialize(writer);
                    writer.Close();
                }
            }
        }

        public static bool Save()
        {
            try
            {
                var settingsFile = GetSettingsFile();
                using (Stream writer = new FileStream(settingsFile, FileMode.Create))
                {
                    var xmlSerializer = new XmlSerializer(typeof(BrowserConfig));
                    xmlSerializer.Serialize(writer, BrowserConfig);
                    writer.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void CheckPortable()
        {
            // set the portable mode flag if we detect a local config file
            if (File.Exists(Path.Combine(Application.StartupPath, BrowserChooserConfigFileName)))
            {
                PortableMode = true;
            }
        }

        public static bool Exists()
        {
            var settingsFile = GetSettingsFile();
            return File.Exists(settingsFile);
        }

        private static string GetSettingsFile()
        {
            var settingsDirectory = EnsureSettingsDirectory();

            return Path.Combine(settingsDirectory, BrowserChooserConfigFileName);
        }

        private static string EnsureSettingsDirectory()
        {
            var settingsDirectory = PortableMode
                ? Application.StartupPath
                : Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BrowserChooser\\";

            var directoryInfo = new DirectoryInfo(settingsDirectory);
            if (!directoryInfo.Exists)
            {
                Directory.CreateDirectory(settingsDirectory);
            }

            return settingsDirectory;
        }
    }
}
