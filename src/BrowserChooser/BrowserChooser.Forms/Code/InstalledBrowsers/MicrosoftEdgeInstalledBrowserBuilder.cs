using System;
using System.IO;
using BrowserChooser.Forms.Models;

namespace BrowserChooser.Forms.Code.InstalledBrowsers
{
    public class MicrosoftEdgeInstalledBrowserBuilder : IInstalledBrowserBuilder
    {
        private const string BrowserName = "Microsoft Edge";
        private const string BrowserFolderPath = "SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdge.exe";

        public InstalledBrowserResult GetInstalledBrowser()
        {
            var result = new InstalledBrowserResult();

            var installedBrowserPath = CheckInstalledBrowser(Environment.SpecialFolder.Windows);
            if (string.IsNullOrEmpty(installedBrowserPath))
            {
                return result;
            }

            result.IsSuccessful = true;
            result.Browsers.Add(new Browser
            {
                Name = BrowserName,
                Target = installedBrowserPath
            });

            return result;
        }

        private static string CheckInstalledBrowser(Environment.SpecialFolder programFilesSpecialFolder)
        {
            var programFilesPath = Environment.GetFolderPath(programFilesSpecialFolder);
            var browserPath = Path.Combine(programFilesPath, BrowserFolderPath);

            return File.Exists(browserPath) ? browserPath : null;
        }
    }
}
