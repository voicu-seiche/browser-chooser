using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using BrowserChooser.Forms.Code;
using BrowserChooser.Forms.Models;
using BrowserChooser.Forms.Settings;
using BrowserChooser.Forms.Views;
using SimpleInjector;

namespace BrowserChooser.Forms
{
    internal static class Program
    {
        private static Container container;

        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            container = new Container();
            container.RegisterPackages(AppDomain.CurrentDomain.GetAssemblies());

            AppSettingsService.CheckPortable();
            AppSettingsService.Load();

            Form formToOpen = null;

            if (args.Length > 0)
            {
                var cmdLineOption = args[0];
                if (cmdLineOption == "options")
                {
                    formToOpen = new OptionsForm();
                }
                else if (cmdLineOption == "register")
                {
                    Console.WriteLine(RegistryService.SetDefaultBrowserPath());
                }
                else
                {
                    AppSettingsService.UrlToOpen = args[0];

                    formToOpen = new MainForm();
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
    }
}
