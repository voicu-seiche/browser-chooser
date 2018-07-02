using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BrowserChooser.Forms.Models;
using BrowserChooser.Forms.Settings;

namespace BrowserChooser.Forms.Code
{
    public class LaunchService
    {
        public static bool LaunchBrowser(Browser browser, bool privateMode = false)
        {
            // microsoft-edge:
            // microsoft-edge:http://www.google.com

            if (!File.Exists(browser.Target))
            {
                return false;
            }

            var processArguments = new List<string>();

            if (privateMode)
            {
                processArguments.Add(browser.IncognitoFlag);
            }

            if (!string.IsNullOrEmpty(AppSettingsService.UrlToOpen))
            {
                processArguments.Add(AppSettingsService.UrlToOpen);
            }

            var processStartInfo = new ProcessStartInfo
            {
                FileName = browser.Target,
                Arguments = string.Join(" ", processArguments.ToArray())
            };

            Process.Start(processStartInfo);

            return true;
        }
    }
}
