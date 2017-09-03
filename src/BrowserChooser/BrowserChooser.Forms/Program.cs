using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace BrowserChooser.Forms
{
    static class Program
    {
        internal static bool Is64Bit = false;
        internal static bool PortableMode = false;
        internal static string DefaultMessage = "Choose a Browser";
        internal static string strUrl;
        internal static string strShownUrl;
        internal static BrowserList BrowserConfig = new BrowserList();

        internal static FileInfo ConfigFile = new FileInfo(Application.StartupPath + "\\config.ini");
        internal const string BrowserChooserConfigFileName = "BrowserChooserConfig.xml";
        internal const int DaysBetweenUpdateCheck = 3;
        internal static bool AutoUpdateCheck = false;

        public static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly parentAssembly = Assembly.GetExecutingAssembly();

            var name = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";

            if (name == "Microsoft.WindowsAPICodePack.dll" || name == "Microsoft.WindowsAPICodePack.Shell.dll")
            {
                var resourceName = parentAssembly.GetManifestResourceNames().First(s => s.EndsWith(name));

                using (Stream stream = parentAssembly.GetManifestResourceStream(System.Convert.ToString(resourceName)))
                {
                    byte[] block = new byte[System.Convert.ToInt32(stream.Length - 1) + 1];
                    stream.Read(block, 0, block.Length);
                    return Assembly.Load(block);
                }

            }

            return typeof(Program).Assembly;
        }

        public static void Main(string[] args)
        {
            // load the WindowsAPICodePack DLLs from the embedded resource allowing us to keep one tidy .exe and no dlls.
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += MyResolveEventHandler;

            Application.EnableVisualStyles();

            // set the 64bit flag if we are runnong on a 64 bit OS
            if (IntPtr.Size == 8 || !string.IsNullOrEmpty(Convert.ToString(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                Is64Bit = true;
            }

            // set the portable mode flag if we detect a local config file
            if (File.Exists(Path.Combine(Convert.ToString(Application.StartupPath), BrowserChooserConfigFileName)))
            {
                PortableMode = true;
            }

            if (ConfigFile.Exists)
            {
                ConfigSetup importConfig = new ConfigSetup();
                BrowserConfig = importConfig.ReadConfig();
                PortableMode = true;
            }
            else
            {
                //Switch to make portable
                if (PortableMode)
                {
                    BrowserConfig = BrowserList.Load(Application.StartupPath);
                }
                else
                {
                    BrowserConfig = BrowserList.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BrowserChooser\\");
                }
            }

            string cmdLineOption = "";
            if (args.Length > 0)
            {
                cmdLineOption = args[0];
                if (cmdLineOption == "gooptions")
                {
                    Application.Run(new Options());
                }
                else if (cmdLineOption == "registerbrowser")
                {
                    Console.WriteLine(Options.SetDefaultBrowserPath());
                }
                else
                {
                    strUrl = cmdLineOption;

                    int browserNumber = System.Convert.ToInt32(BrowserConfig.GetBrowserByUrl(strUrl));

                    if (!(browserNumber == 0))
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

        private static void openOptions()
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.Verb = "runas";
            myProcess.StartInfo.FileName = Application.ExecutablePath;
            myProcess.StartInfo.Arguments = "gooptions";
            myProcess.Start();
            System.Environment.Exit(-1);
        }
        public static string NormalizeTarget(string target)
        {
            // it's possible that in portable mode you have a path to an x86 folder and are running on a 32 bit system
            // so the strBrowser will point to an invalid browser
            if (Is64Bit)
            {
                string programFiles = "";
                //programFiles = (new Microsoft.VisualBasic.Devices.ServerComputer()).FileSystem.SpecialDirectories.ProgramFiles;

                if (target.StartsWith(programFiles))
                {
                    if (target.StartsWith(System.Convert.ToString(Environment.GetEnvironmentVariable("ProgramFiles(x86)"))) == false)
                    {
                        target = target.Replace(programFiles, System.Convert.ToString(Environment.GetEnvironmentVariable("ProgramFiles(x86)")));
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
            string target = NormalizeTarget(System.Convert.ToString(BrowserConfig.GetBrowser(browserNumber).Target));

            string strParameters = "";
            string strBrowser = "";
            //check to see if the file exists
            if ((File.Exists(target)) || target.Contains(".exe "))
            {
                if (target.Contains(".exe "))
                {
                    strBrowser = target.Substring(0, target.IndexOf(".exe") + 5);
                    strParameters = target.Substring(target.IndexOf(".exe") + 5, target.Length - (target.IndexOf(".exe") + 5)) + " ";

                    if (!string.IsNullOrEmpty(strUrl))
                    {
                        Process.Start(strBrowser, strParameters + "\"" + strUrl + "\"");
                    }
                    else
                    {
                        Process.Start(strBrowser, strParameters);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(strUrl))
                    {
                        Process.Start(target, "\"" + strUrl + "\"");
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
            string domain = System.Convert.ToString(targetUri.Authority);

            if (domain.Contains("."))
            {
                return false;
            }

            return true;
        }
    }
}
