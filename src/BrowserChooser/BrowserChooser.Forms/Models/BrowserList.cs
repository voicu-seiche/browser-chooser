using System;
using System.Collections.Generic;
using System.Linq;

namespace BrowserChooser.Forms.Models
{
    public class BrowserList
    {
        public BrowserList()
        {
            Browsers = new List<Browser>();
        }

        public bool DefaultBrowser { get; set; }
        public bool RevealUrl { get; set; }
        public bool AutoUpdateCheck { get; set; }
        public DateTime LastUpdateCheck { get; set; }

        public List<Browser> Browsers { get; set; }
    }
}