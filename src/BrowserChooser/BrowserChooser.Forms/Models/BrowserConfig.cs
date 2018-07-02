using System;

namespace BrowserChooser.Forms.Models
{
    public class BrowserConfig
    {
        public bool DefaultBrowser { get; set; }
        public bool RevealUrl { get; set; }
        public bool AutoUpdateCheck { get; set; }
        public DateTime LastUpdateCheck { get; set; }
    }
}