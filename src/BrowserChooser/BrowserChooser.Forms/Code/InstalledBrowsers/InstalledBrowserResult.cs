using System.Collections.Generic;
using BrowserChooser.Forms.Models;

namespace BrowserChooser.Forms.Code.InstalledBrowsers
{
    public class InstalledBrowserResult
    {
        public InstalledBrowserResult()
        {
            Browsers = new List<Browser>();
        }

        public bool IsSuccessful { get; set; }
        public IList<Browser> Browsers { get; set; }
    }
}