using System;
using System.Diagnostics;
using System.IO;
using BrowserChooser.Forms.Models;
using BrowserChooser.Forms.Settings;

namespace BrowserChooser.Forms.Code
{
    public class LaunchService
    {
        public static bool LaunchBrowser(Browser browser)
        {
            // microsoft-edge:
            // microsoft-edge:http://www.google.com

            string target = NormalizeTarget(browser.Target);

            //check to see if the file exists
            if (File.Exists(target) || target.Contains(".exe "))
            {
                if (target.Contains(".exe "))
                {
                    var indexOfExe = target.IndexOf(".exe", StringComparison.Ordinal);
                    var strBrowser = target.Substring(0, indexOfExe + 5);
                    var strParameters = target.Substring(indexOfExe + 5, target.Length - (indexOfExe + 5)) + " ";

                    if (!string.IsNullOrEmpty(AppSettingsService.UrlToOpen))
                    {
                        Process.Start(strBrowser, strParameters + "\"" + AppSettingsService.UrlToOpen + "\"");
                    }
                    else
                    {
                        Process.Start(strBrowser, strParameters);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(AppSettingsService.UrlToOpen))
                    {
                        Process.Start(target, "\"" + AppSettingsService.UrlToOpen + "\"");
                    }
                    else
                    {
                        Process.Start(target);
                    }
                }
                return true;
            }
            //file doesn't exist so return false
            return false;
        }

        private static string NormalizeTarget(string target)
        {
            if (Environment.Is64BitOperatingSystem)
            {
                var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

                if (target.StartsWith(programFiles))
                {
                    var environmentVariable = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                    if (target.StartsWith(environmentVariable) == false)
                    {
                        target = target.Replace(programFiles, environmentVariable);
                    }
                }
            }
            else
            {
                if (target.Contains("x86"))
                {
                    target = target.Replace(" (x86)", "");
                }
            }

            return target;
        }
    }
}
