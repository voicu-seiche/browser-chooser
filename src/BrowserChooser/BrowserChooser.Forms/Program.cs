using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using BrowserChooser.Forms.Code;
using BrowserChooser.Forms.Settings;
using SimpleInjector;

namespace BrowserChooser.Forms
{
    internal static class Program
    {
        private static Container _container;

        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _container = new Container();
            _container.RegisterPackages(AppDomain.CurrentDomain.GetAssemblies());

            AppSettingsService.CheckPortable();
            AppSettingsService.Load();

            Form formToOpen = null;

            if (args.Length > 0)
            {
                var cmdLineOption = args[0];
                if (cmdLineOption == "gooptions")
                {
                    Application.Run(new OptionsForm());
                }
                else if (cmdLineOption == "registerbrowser")
                {
                    Console.WriteLine(RegistryService.SetDefaultBrowserPath());
                }
                else
                {
                    AppSettingsService.UrlToOpen = cmdLineOption;

                    var browserNumber = AppSettingsService.BrowserConfig.GetBrowserByUrl(AppSettingsService.UrlToOpen);
                    if (browserNumber != 0)
                    {
                        LaunchBrowser(browserNumber);
                    }
                    else
                    {
                        formToOpen = new MainForm();
                    }
                }
            }
            else
            {
                formToOpen = new MainForm();
            }

            if (formToOpen != null)
            {
                Application.Run(formToOpen);
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
            // microsoft-edge:
            // microsoft-edge:http://www.google.com

            string target = NormalizeTarget(AppSettingsService.BrowserConfig.GetBrowser(browserNumber).Target);

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
