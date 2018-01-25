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
