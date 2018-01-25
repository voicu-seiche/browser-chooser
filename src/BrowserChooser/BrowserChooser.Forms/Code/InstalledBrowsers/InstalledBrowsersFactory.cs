using System.Collections.Generic;

namespace BrowserChooser.Forms.Code.InstalledBrowsers
{
    public class InstalledBrowsersFactory
    {
        private static List<IInstalledBrowserBuilder> _installedBrowserBuilders;

        public static IEnumerable<IInstalledBrowserBuilder> GetBuilders()
        {
            return _installedBrowserBuilders ?? (_installedBrowserBuilders = new List<IInstalledBrowserBuilder>
            {
                new MicrosoftEdgeInstalledBrowserBuilder(),
                new InternetExplorerInstalledBrowserBuilder(),
                new FirefoxInstalledBrowserBuilder(),
                new ChromeInstalledBrowserBuilder(),
                new OperaInstalledBrowserBuilder(),
                new SafariInstalledBrowserBuilder(),
                new FlockInstalledBrowserBuilder(),
            });
        }
    }
}
