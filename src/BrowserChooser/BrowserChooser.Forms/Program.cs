using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using BrowserChooser.Forms.Settings;
using SimpleInjector;

namespace BrowserChooser.Forms
{
    static class Program
    {
        private static Container _container;

        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _container = new Container();
            _container.RegisterPackages(AppDomain.CurrentDomain.GetAssemblies());

            // set the portable mode flag if we detect a local config file
            if (File.Exists(Path.Combine(Application.StartupPath, AppSettingsService.BrowserChooserConfigFileName)))
            {
                AppSettingsService.PortableMode = true;
            }

            //Switch to make portable
            if (AppSettingsService.PortableMode)
            {
                AppSettingsService.BrowserConfig = AppSettingsService.Load(Application.StartupPath);
            }
            else
            {
                AppSettingsService.BrowserConfig = AppSettingsService.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BrowserChooser\\");
            }

            if (args.Length > 0)
            {
                var cmdLineOption = args[0];
                if (cmdLineOption == "gooptions")
                {
                    Application.Run(new OptionsForm());
                }
                else if (cmdLineOption == "registerbrowser")
                {
                    Console.WriteLine(OptionsForm.SetDefaultBrowserPath());
                }
                else
                {
                    AppSettingsService.StrUrl = cmdLineOption;

                    var browserNumber = AppSettingsService.BrowserConfig.GetBrowserByUrl(AppSettingsService.StrUrl);
                    if (browserNumber != 0)
                    {
                        LaunchBrowser(browserNumber);
                    }
                    else
                    {
                        Application.Run(new MainForm());
                    }
                }
            }
            else
            {
                Application.Run(new MainForm());
            }
        }

        public static string NormalizeTarget(string target)
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

        public static bool LaunchBrowser(int browserNumber)
        {
            string target = NormalizeTarget(AppSettingsService.BrowserConfig.GetBrowser(browserNumber).Target);

            //check to see if the file exists
            if (File.Exists(target) || target.Contains(".exe "))
            {
                if (target.Contains(".exe "))
                {
                    var indexOfExe = target.IndexOf(".exe", StringComparison.Ordinal);
                    var strBrowser = target.Substring(0, indexOfExe + 5);
                    var strParameters = target.Substring(indexOfExe + 5, target.Length - (indexOfExe + 5)) + " ";

                    if (!string.IsNullOrEmpty(AppSettingsService.StrUrl))
                    {
                        Process.Start(strBrowser, strParameters + "\"" + AppSettingsService.StrUrl + "\"");
                    }
                    else
                    {
                        Process.Start(strBrowser, strParameters);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(AppSettingsService.StrUrl))
                    {
                        Process.Start(target, "\"" + AppSettingsService.StrUrl + "\"");
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

        public static bool IsIntranetUrl(string url)
        {
            Uri targetUri = new Uri(url);
            string domain = targetUri.Authority;

            if (domain.Contains("."))
            {
                return false;
            }

            return true;
        }
    }
}
