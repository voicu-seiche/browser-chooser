using System;
using System.IO;
using BrowserChooser.Forms.Models;

namespace BrowserChooser.Forms.Code.InstalledBrowsers
{
    public class InternetExplorerInstalledBrowserBuilder : IInstalledBrowserBuilder
    {
        private const string BrowserName = "Internet Explorer";
        private const string BrowserFolderPath = "Internet Explorer\\iexplore.exe";

        public InstalledBrowserResult GetInstalledBrowser()
        {
            var result = new InstalledBrowserResult();

            var installedBrowserPath = CheckInstalledBrowser(Environment.SpecialFolder.ProgramFiles) ?? CheckInstalledBrowser(Environment.SpecialFolder.ProgramFilesX86);
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
            result.Browsers.Add(new Browser
            {
                Name = $"{BrowserName} InPrivate",
                Target = $"{installedBrowserPath} -private"
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
