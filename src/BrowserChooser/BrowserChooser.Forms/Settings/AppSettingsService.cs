using System.IO;
using System.Xml.Serialization;

namespace BrowserChooser.Forms.Settings
{
    public class AppSettingsService
    {
        public static bool Is64Bit;
        public static bool PortableMode;
        public static string DefaultMessage = "Choose a Browser";
        public static string StrUrl;
        public static BrowserList BrowserConfig = new BrowserList();
        public const string BrowserChooserConfigFileName = "BrowserChooserConfig.xml";
        public const int DaysBetweenUpdateCheck = 3;
        public static bool AutoUpdateCheck = false;

        public static BrowserList Load(string browserChooserConfigDirectory)
        {
            var serializer = new XmlSerializer(typeof(BrowserList));

            BrowserList blist;

            var configPath = Path.Combine(browserChooserConfigDirectory, BrowserChooserConfigFileName);
            if (File.Exists(configPath))
            {
                using (Stream writer = new FileStream(configPath, FileMode.Open))
                {
                    blist = (BrowserList)serializer.Deserialize(writer);
                    writer.Close();
                }
            }
            else
            {
                blist = new BrowserList();
            }
            return blist;
        }

        public static void Save(string browserChooserConfigDirectory, BrowserList browserList)
        {
            var f = new DirectoryInfo(browserChooserConfigDirectory);
            if (!f.Exists)
            {
                Directory.CreateDirectory(browserChooserConfigDirectory);
            }
            var xmlSerializer = new XmlSerializer(typeof(BrowserList));

            using (Stream writer = new FileStream(Path.Combine(browserChooserConfigDirectory, BrowserChooserConfigFileName), FileMode.Create))
            {
                browserList.Browsers.Sort();
                xmlSerializer.Serialize(writer, browserList);
                writer.Close();
            }
        }
    }
}
