using System;
using System.Collections.Generic;
using System.Linq;
using BrowserChooser.Forms.Settings;

namespace BrowserChooser.Forms.Models
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
            var browser = Browsers.FirstOrDefault(t => t.BrowserNumber == browserNumber) ?? new Browser();
            return browser;
        }

        public int GetBrowserByUrl(string url)
        {
            var result = 0;

            if (IntranetBrowser != null)
            {
                if (Program.IsIntranetUrl(url))
                {
                    result = AppSettingsService.BrowserConfig.IntranetBrowser.BrowserNumber;
                }
            }

            if (DefaultBrowser != null)
            {
                if (DefaultBrowser.BrowserNumber != 0)
                {
                    result = AppSettingsService.BrowserConfig.DefaultBrowser.BrowserNumber;
                }
            }

            var browser = Browsers.FirstOrDefault(c => c.Urls.Any(w => url.ToUpper().Contains(w.Trim().ToUpper())));
            if (browser != null)
            {
                result = browser.BrowserNumber;
            }

            return result;
        }
    }
}