using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace BrowserChooser.Forms
{
    public class BrowserList
    {
        public BrowserList()
        {
            Browsers = new List<Browser>();

        }

        public bool IamDefaultBrowser { get; set; }

        public bool ShowUrl { get; set; }

        public bool RevealUrl { get; set; }

        public bool AutoUpdateCheck { get; set; }

        public DateTime LastUpdateCheck { get; set; }

        public Browser IntranetBrowser { get; set; }

        public Browser DefaultBrowser { get; set; }

        public List<Browser> Browsers { get; set; }

        public Browser GetBrowser(int browserNumber)
        {
            Browser browser = null;
            if (!ReferenceEquals(this.Browsers, null))
            {
                browser = this.Browsers.FirstOrDefault(t => t.BrowserNumber == browserNumber);
            }
            if (ReferenceEquals(browser, null))
            {
                browser = new Browser();
            }
            return browser;
        }

        public int GetBrowserByUrl(string url)
        {
            var rez = 0;

            if (this.IntranetBrowser != null)
            {
                if (Program.IsIntranetUrl(url))
                {
                    rez = Convert.ToInt32(Program.BrowserConfig.IntranetBrowser.BrowserNumber);
                }
            }

            if (this.DefaultBrowser != null)
            {
                if (DefaultBrowser.BrowserNumber != 0)
                {
                    rez = Convert.ToInt32(Program.BrowserConfig.DefaultBrowser.BrowserNumber);
                }
            }

            Browser b = this.Browsers.FirstOrDefault(c => c.Urls.Any(w => url.ToUpper().Contains(Convert.ToString(w.Trim().ToUpper()))));
            if (b != null)
            {
                rez = Convert.ToInt32(b.BrowserNumber);
            }

            return rez;
        }

        public void Save(string browserChooserConfigDirectory)
        {
            DirectoryInfo f = new DirectoryInfo(browserChooserConfigDirectory);
            if (!f.Exists)
            {
                Directory.CreateDirectory(browserChooserConfigDirectory);
            }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BrowserList));

            using (Stream writer = new FileStream(Path.Combine(browserChooserConfigDirectory, Convert.ToString(Program.BrowserChooserConfigFileName)), FileMode.Create))
            {
                this.Browsers.Sort();
                xmlSerializer.Serialize(writer, this);
                writer.Close();
            }

        }

        public static BrowserList Load(string browserChooserConfigDirectory)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BrowserList));

            BrowserList blist;

            string configPath = Path.Combine(browserChooserConfigDirectory, Convert.ToString(Program.BrowserChooserConfigFileName));
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
    }
}