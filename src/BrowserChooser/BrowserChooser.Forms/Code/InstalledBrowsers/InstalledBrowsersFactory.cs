using System.Collections.Generic;

namespace BrowserChooser.Forms.Code.InstalledBrowsers
{
    public class InstalledBrowsersFactory
    {
        public static IEnumerable<IInstalledBrowserBuilder> GetBuilders()
        {
            return new List<IInstalledBrowserBuilder>
            {
                new ChromeInstalledBrowserBuilder(),
                new FirefoxInstalledBrowserBuilder(),
                new FlockInstalledBrowserBuilder(),
                new InternetExplorerInstalledBrowserBuilder(),
                new MicrosoftEdgeInstalledBrowserBuilder(),
                new OperaInstalledBrowserBuilder(),
                new SafariInstalledBrowserBuilder(),
            };
        }
    }
}
