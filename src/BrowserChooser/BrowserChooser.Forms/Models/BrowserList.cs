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
                    rez = AppSettingsService.BrowserConfig.IntranetBrowser.BrowserNumber;
                }
            }

            if (this.DefaultBrowser != null)
            {
                if (DefaultBrowser.BrowserNumber != 0)
                {
                    rez = AppSettingsService.BrowserConfig.DefaultBrowser.BrowserNumber;
                }
            }

            var b = this.Browsers
                .FirstOrDefault(c => c.Urls.Any(w => url.ToUpper()
                .Contains(w.Trim().ToUpper())));
            if (b != null)
            {
                rez = b.BrowserNumber;
            }

            return rez;
        }
    }
}