using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace BrowserChooser.Forms
{
    public partial class Options : Form
    {
        public List<Browser> InstalledBrowsers;

        public Options()
        {
            InitializeComponent();
        }

        private void LoadBrowsers()
        {
            InstalledBrowsers = new List<Browser>();

            InstalledBrowsers.Add(new Browser {Name = "Custom", Target = ""});

            string programFiles = "";
            //programFiles = (new Microsoft.VisualBasic.Devices.ServerComputer()).FileSystem.SpecialDirectories.ProgramFiles;

            // If we are running on a 64 bit system, replace the programFiles string with a path to the x86
            if (Program.Is64Bit)
            {
                programFiles = Convert.ToString(Environment.GetEnvironmentVariable("ProgramFiles(x86)"));
            }

            string appData;
            //appData = Directory.GetParent((new Microsoft.VisualBasic.Devices.ServerComputer()).FileSystem.SpecialDirectories.Temp).FullName;
            string system = Directory.GetParent(Convert.ToString(Environment.GetFolderPath(Environment.SpecialFolder.System))).FullName;

            // Add Firefox
            string firefox = Path.Combine(programFiles, "Mozilla Firefox\\firefox.exe");

            if (File.Exists(firefox))
            {
                InstalledBrowsers.Add(new Browser {Name = "Firefox", Target = firefox});
            }

            // Add Flock
            string flock = Path.Combine(programFiles, "Flock\\flock.exe");

            if (File.Exists(flock))
            {
                InstalledBrowsers.Add(new Browser {Name = "Flock", Target = flock});
            }

            // Add Google Chrome
            string chrome = Path.Combine(programFiles, "Google\\Chrome\\Application\\chrome.exe");
            if (File.Exists(chrome))
            {
                InstalledBrowsers.Add(new Browser {Name = "Google Chrome", Target = chrome});
                InstalledBrowsers.Add(new Browser {Name = "Google Chrome Incognito", Target = chrome + " -incognito"});
            }

            // Add Internet Explorer
            string internetExplorer = Path.Combine(programFiles, "Internet Explorer\\iexplore.exe");
            if (File.Exists(internetExplorer))
            {
                InstalledBrowsers.Add(new Browser {Name = "Internet Explorer", Target = internetExplorer});
                InstalledBrowsers.Add(new Browser {Name = "Internet Explorer InPrivate", Target = internetExplorer + " -private"});
            }

            // Add Edge
            string edge = Path.Combine(system, "SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdge.exe");
            if (File.Exists(edge))
            {
                InstalledBrowsers.Add(new Browser {Name = "Edge", Target = edge});
            }

            // Add Opera
            string opera = Path.Combine(programFiles, "Opera\\opera.exe");
            if (File.Exists(opera))
            {
                InstalledBrowsers.Add(new Browser {Name = "Opera", Target = opera});
            }

            // Add Safari
            string safari = Path.Combine(programFiles, "Safari\\Safari.exe");
            if (File.Exists(safari))
            {
                InstalledBrowsers.Add(new Browser {Name = "Safari", Target = safari});
            }

        }

        private void btnBrowse1_Click(System.Object sender, System.EventArgs e)
        {
            Browser1FileDialog.Filter = "Application | *.exe";
            Browser1FileDialog.ShowDialog();
            //if a file is not picked, don't clear the options textbox
            if (!string.IsNullOrEmpty(Convert.ToString(Browser1FileDialog.FileName)))
            {
                Browser1Target.Text = Browser1FileDialog.FileName.ToString();
            }
            Browser1FileDialog.Reset();
        }

        private void btnBrowse2_Click(System.Object sender, System.EventArgs e)
        {
            Browser2FileDialog.Filter = "Application | *.exe";
            Browser2FileDialog.ShowDialog();
            //if a file is not picked, don't clear the options textbox
            if (!string.IsNullOrEmpty(Convert.ToString(Browser2FileDialog.FileName)))
            {
                Browser2Target.Text = Browser2FileDialog.FileName.ToString();
            }
        }

        private void btnBrowse3_Click(System.Object sender, System.EventArgs e)
        {
            Browser3FileDialog.Filter = "Application | *.exe";
            Browser3FileDialog.ShowDialog();
            //if a file is not picked, don't clear the options textbox
            if (!string.IsNullOrEmpty(Convert.ToString(Browser3FileDialog.FileName)))
            {
                Browser3Target.Text = Browser3FileDialog.FileName.ToString();
            }
        }

        private void btnBrowse4_Click(System.Object sender, System.EventArgs e)
        {
            Browser4FileDialog.Filter = "Application | *.exe";
            Browser4FileDialog.ShowDialog();
            //if a file is not picked, don't clear the options textbox
            if (!string.IsNullOrEmpty(Convert.ToString(Browser4FileDialog.FileName)))
            {
                Browser4Target.Text = Browser4FileDialog.FileName.ToString();
            }
        }

        private void btnBrowse5_Click(System.Object sender, System.EventArgs e)
        {
            Browser5FileDialog.Filter = "Application | *.exe";
            Browser5FileDialog.ShowDialog();
            //if a file is not picked, don't clear the options textbox
            if (!string.IsNullOrEmpty(Convert.ToString(Browser5FileDialog.FileName)))
            {
                Browser5Target.Text = Browser5FileDialog.FileName.ToString();
            }
        }

        private void btnSave_Click(System.Object sender, System.EventArgs e)
        {
            //Save settings from textboxes
            //Offer to make default browser if not already

            //reset the in memory list of browsers object
            Program.BrowserConfig.Browsers.Clear();

            if (!Program.BrowserConfig.IamDefaultBrowser)
            {
                //MsgBoxResult Answer = Interaction.MsgBox("Browser Chooser is not currently set as your default browser. Would you like to make it so now?" + "\r\n" + "(Without being the default browser, Browser Chooser's usefullness rapidly declines...)", MsgBoxStyle.YesNo, null);
                //if (Answer == MsgBoxResult.Yes)
                //{
                //    Program.BrowserConfig.IamDefaultBrowser = true;
                //    SetDefaultBrowserPath();
                //}
                //else
                //{
                //    Program.BrowserConfig.IamDefaultBrowser = false;
                //}
            }

            Program.BrowserConfig.ShowUrl = cbURL.Checked;
            Program.BrowserConfig.AutoUpdateCheck = cbAutoCheck.Checked;
            Program.BrowserConfig.RevealUrl = cbRevealURL.Checked;

            if (cbIntranet.SelectedIndex == 0)
            {
                Program.BrowserConfig.IntranetBrowser = null;
            }
            else if (cbIntranet.SelectedItem != null)
            {
                Program.BrowserConfig.IntranetBrowser = (Browser) cbIntranet.SelectedItem;
            }

            if (cbDefault.SelectedIndex == 0)
            {
                Program.BrowserConfig.DefaultBrowser = null;
            }
            else if (cbDefault.SelectedItem != null)
            {
                Program.BrowserConfig.DefaultBrowser = (Browser) cbDefault.SelectedItem;
            }

            if (!string.IsNullOrEmpty(Convert.ToString(Browser1Name.Text)))
            {
                Program.BrowserConfig.Browsers.Add(new Browser {Name = Browser1Name.Text, Target = Browser1Target.Text, Image = Browser1Image.Text, BrowserNumber = 1, IsActive = true, Urls = Browser.StringToUrls(Browser1Urls.Text), CustomImagePath = Browser1ImagePath.Text});
            }

            if (!string.IsNullOrEmpty(Convert.ToString(Browser2Name.Text)))
            {
                Program.BrowserConfig.Browsers.Add(new Browser {Name = Browser2Name.Text, Target = Browser2Target.Text, Image = Browser2Image.Text, BrowserNumber = 2, IsActive = true, Urls = Browser.StringToUrls(Browser2Urls.Text), CustomImagePath = Browser2ImagePath.Text});
            }

            if (!string.IsNullOrEmpty(Convert.ToString(Browser3Name.Text)))
            {
                Program.BrowserConfig.Browsers.Add(new Browser {Name = Browser3Name.Text, Target = Browser3Target.Text, Image = Browser3Image.Text, BrowserNumber = 3, IsActive = true, Urls = Browser.StringToUrls(Browser3Urls.Text), CustomImagePath = Browser3ImagePath.Text});
            }

            if (!string.IsNullOrEmpty(Convert.ToString(Browser4Name.Text)))
            {
                Program.BrowserConfig.Browsers.Add(new Browser {Name = Browser4Name.Text, Target = Browser4Target.Text, Image = Browser4Image.Text, BrowserNumber = 4, IsActive = true, Urls = Browser.StringToUrls(Browser4Urls.Text), CustomImagePath = Browser4ImagePath.Text});
            }

            if (!string.IsNullOrEmpty(Convert.ToString(Browser5Name.Text)))
            {
                Program.BrowserConfig.Browsers.Add(new Browser {Name = Browser5Name.Text, Target = Browser5Target.Text, Image = Browser5Image.Text, BrowserNumber = 5, IsActive = true, Urls = Browser.StringToUrls(Browser5Urls.Text), CustomImagePath = Browser5ImagePath.Text});
            }

            if (cbPortable.Checked)
            {
                Program.PortableMode = true;
            }

            SaveConfig();

            //Me.Close()
            Process.Start(Application.ExecutablePath);
            Environment.Exit(-1);
            //frmMain.InitializeMain()

            //MsgBox("Please restart the application for the settings to take effect.")
        }

        public void SaveConfig()
        {
            //try
            //{
            //    //Switch to make portable version
            //    if (PortableMode)
            //    {
            //        Program.BrowserConfig.Save(Application.StartupPath);
            //    }
            //    else
            //    {
            //        Program.BrowserConfig.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BrowserChooser");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Interaction.MsgBox("There was an error saving to the configuration file." + "\r\n" + ex.Message, MsgBoxStyle.Critical, null);
            //}
        }

        private void Options_Load(System.Object sender, System.EventArgs e)
        {
            //Autodetect all present browsers
            LoadBrowsers();

            Browser1.DataSource = InstalledBrowsers.ToList();
            Browser1.DisplayMember = "Name";
            Browser1.ValueMember = "Target";
            Browser2.DataSource = InstalledBrowsers.ToList();
            Browser2.DisplayMember = "Name";
            Browser2.ValueMember = "Target";
            Browser3.DataSource = InstalledBrowsers.ToList();
            Browser3.DisplayMember = "Name";
            Browser3.ValueMember = "Target";
            Browser4.DataSource = InstalledBrowsers.ToList();
            Browser4.DisplayMember = "Name";
            Browser4.ValueMember = "Target";
            Browser5.DataSource = InstalledBrowsers.ToList();
            Browser5.DisplayMember = "Name";
            Browser5.ValueMember = "Target";

            //Load settings into textboxes
            Browser1Name.Text = Program.BrowserConfig.GetBrowser(1).Name;
            Browser2Name.Text = Program.BrowserConfig.GetBrowser(2).Name;
            Browser3Name.Text = Program.BrowserConfig.GetBrowser(3).Name;
            Browser4Name.Text = Program.BrowserConfig.GetBrowser(4).Name;
            Browser5Name.Text = Program.BrowserConfig.GetBrowser(5).Name;

            Browser1Target.Text = Program.BrowserConfig.GetBrowser(1).Target;
            Browser2Target.Text = Program.BrowserConfig.GetBrowser(2).Target;
            Browser3Target.Text = Program.BrowserConfig.GetBrowser(3).Target;
            Browser4Target.Text = Program.BrowserConfig.GetBrowser(4).Target;
            Browser5Target.Text = Program.BrowserConfig.GetBrowser(5).Target;

            Browser1Image.SelectedItem = Program.BrowserConfig.GetBrowser(1).Image;
            Browser2Image.SelectedItem = Program.BrowserConfig.GetBrowser(2).Image;
            Browser3Image.SelectedItem = Program.BrowserConfig.GetBrowser(3).Image;
            Browser4Image.SelectedItem = Program.BrowserConfig.GetBrowser(4).Image;
            Browser5Image.SelectedItem = Program.BrowserConfig.GetBrowser(5).Image;

            Browser1Urls.Text = Program.BrowserConfig.GetBrowser(1).UrlsToString();
            Browser2Urls.Text = Program.BrowserConfig.GetBrowser(2).UrlsToString();
            Browser3Urls.Text = Program.BrowserConfig.GetBrowser(3).UrlsToString();
            Browser4Urls.Text = Program.BrowserConfig.GetBrowser(4).UrlsToString();
            Browser5Urls.Text = Program.BrowserConfig.GetBrowser(5).UrlsToString();

            Browser1ImagePath.Text = Program.BrowserConfig.GetBrowser(1).CustomImagePath;
            Browser2ImagePath.Text = Program.BrowserConfig.GetBrowser(2).CustomImagePath;
            Browser3ImagePath.Text = Program.BrowserConfig.GetBrowser(3).CustomImagePath;
            Browser4ImagePath.Text = Program.BrowserConfig.GetBrowser(4).CustomImagePath;
            Browser5ImagePath.Text = Program.BrowserConfig.GetBrowser(5).CustomImagePath;

            //Select the correct items in the Browser dropdown
            try
            {
                SelectBrowser(Convert.ToString(Program.BrowserConfig.GetBrowser(1).Target), Convert.ToString(Program.BrowserConfig.GetBrowser(1).Image), Browser1);
                SelectBrowser(Convert.ToString(Program.BrowserConfig.GetBrowser(2).Target), Convert.ToString(Program.BrowserConfig.GetBrowser(2).Image), Browser2);
                SelectBrowser(Convert.ToString(Program.BrowserConfig.GetBrowser(3).Target), Convert.ToString(Program.BrowserConfig.GetBrowser(3).Image), Browser3);
                SelectBrowser(Convert.ToString(Program.BrowserConfig.GetBrowser(4).Target), Convert.ToString(Program.BrowserConfig.GetBrowser(4).Image), Browser4);
                SelectBrowser(Convert.ToString(Program.BrowserConfig.GetBrowser(5).Target), Convert.ToString(Program.BrowserConfig.GetBrowser(5).Image), Browser5);
            }
            catch (Exception)
            {

            }

            cbURL.Checked = Program.BrowserConfig.ShowUrl;
            cbAutoCheck.Checked = Program.BrowserConfig.AutoUpdateCheck;
            cbRevealURL.Checked = Program.BrowserConfig.RevealUrl;

            string target = "";
            if (Program.BrowserConfig.IntranetBrowser != null)
            {
                target = Convert.ToString(Program.BrowserConfig.IntranetBrowser.Target);
            }

            cbIntranet.Items.Add("None");
            cbIntranet.SelectedIndex = 0;
            foreach (var browser in Program.BrowserConfig.Browsers)
            {
                if (browser.IsActive)
                {
                    cbIntranet.Items.Add(browser);
                    if (target == browser.Target)
                    {
                        cbIntranet.SelectedItem = browser;
                    }
                }
            }

            target = "";
            if (Program.BrowserConfig.DefaultBrowser != null)
            {
                target = Convert.ToString(Program.BrowserConfig.DefaultBrowser.Target);
            }

            cbDefault.Items.Add("None");
            cbDefault.SelectedIndex = 0;
            foreach (var browser in Program.BrowserConfig.Browsers)
            {
                if (browser.IsActive)
                {
                    cbDefault.Items.Add(browser);
                    if (target == browser.Target)
                    {
                        cbDefault.SelectedItem = browser;
                    }
                }
            }

            //Switch for portable version
            string ConfigFile = "";
            if (Program.PortableMode)
            {
                cbPortable.Checked = true;
                ConfigFile = Path.Combine(Application.StartupPath, Convert.ToString(Program.BrowserChooserConfigFileName));
            }
            else
            {
                ConfigFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BrowserChooser", Convert.ToString(Program.BrowserChooserConfigFileName));
            }

            if (!File.Exists(ConfigFile))
            {
                //if (Interaction.MsgBox("Would you like to automatically check for updates?", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
                //{
                //    cbAutoCheck.Checked = true;
                //    Program.BrowserConfig.AutoUpdateCheck = true;
                //}
            }

            AppDomain ad = Thread.GetDomain();
            ad.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal user = (WindowsPrincipal) Thread.CurrentPrincipal;
            // Decorate Activate Browser button with the BCM_SETSHIELD method if the user Is an non admin
            var elevationRequired = false;
            if (!user.IsInRole(WindowsBuiltInRole.Administrator))
            {
                elevationRequired = true;
                ElevateIcon_BCM_SETSHIELD(btnSetDefault, true);
            }
            else
            {
                ElevateIcon_BCM_SETSHIELD(btnSetDefault, false);
            }
        }

        //    P/Invoke setup for user32.dll!SendMessage
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public void ElevateIcon_BCM_SETSHIELD(Button ThisButton, bool Enable)
        {
            //Input validation, validate that ThisControl Is Not null
            if (ReferenceEquals(ThisButton, null))
            {
                return;
            }
            // Define BCM_SETSHIELD locally, declared originally in Commctrl.h
            uint BCM_SETSHIELD = (uint) 5644;
            //   Set button style to the system style
            ThisButton.FlatStyle = FlatStyle.System;
            //Send the BCM_SETSHIELD message to the button control
            if (Enable)
            {
                SendMessage(new HandleRef(ThisButton, ThisButton.Handle), BCM_SETSHIELD, new IntPtr(0), new IntPtr(1));
            }
            else
            {
                SendMessage(new HandleRef(ThisButton, ThisButton.Handle), BCM_SETSHIELD, new IntPtr(0), new IntPtr(0));
            }
            return;
        }

        private void SelectBrowser(string BrowserPath, string BrowserName, ComboBox currentComboBox)
        {
            string path = BrowserPath;
            BrowserPredicate comparer = new BrowserPredicate(path);
            Browser browser = InstalledBrowsers.Find(comparer.ComparePaths);
            if (browser != null)
            {
                currentComboBox.SelectedIndex = currentComboBox.FindString(BrowserName);
            }
        }

        private class BrowserPredicate
        {
            private string _path;
            private string _name;

            public BrowserPredicate(string path)
            {
                _path = path;
            }

            public bool ComparePaths(Browser obj)
            {
                return _path == obj.Target;
            }

            public bool CompareNames(Browser obj)
            {
                return _path == obj.Name;
            }
        }

        private void Browser1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            ComboBox selectedComboBox = (ComboBox) sender;

            if (selectedComboBox.SelectedIndex > 0)
            {
                Browser selectedBrowser = default(Browser);
                selectedBrowser = (Browser) selectedComboBox.SelectedItem;

                if (selectedComboBox.Name == "Browser1")
                {
                    Browser1Name.Text = selectedBrowser.Name;
                    Browser1Target.Text = selectedBrowser.Target;
                    Browser1Image.SelectedIndex = Browser1Image.FindString(selectedBrowser.Name);
                }
                else if (selectedComboBox.Name == "Browser2")
                {
                    Browser2Name.Text = selectedBrowser.Name;
                    Browser2Target.Text = selectedBrowser.Target;
                    Browser2Image.SelectedIndex = Browser2Image.FindString(selectedBrowser.Name);
                }
                else if (selectedComboBox.Name == "Browser3")
                {
                    Browser3Name.Text = selectedBrowser.Name;
                    Browser3Target.Text = selectedBrowser.Target;
                    Browser3Image.SelectedIndex = Browser3Image.FindString(selectedBrowser.Name);
                }
                else if (selectedComboBox.Name == "Browser4")
                {
                    Browser4Name.Text = selectedBrowser.Name;
                    Browser4Target.Text = selectedBrowser.Target;
                    Browser4Image.SelectedIndex = Browser4Image.FindString(selectedBrowser.Name);
                }
                else if (selectedComboBox.Name == "Browser5")
                {
                    Browser5Name.Text = selectedBrowser.Name;
                    Browser5Target.Text = selectedBrowser.Target;
                    Browser5Image.SelectedIndex = Browser5Image.FindString(selectedBrowser.Name);
                }
                else
                {
                }
            }
            else
            {
                var selectedBrowser = (Browser) selectedComboBox.SelectedItem;

                if (selectedComboBox.Name == "Browser1")
                {
                    Browser1Name.Text = "";
                    Browser1Target.Text = "";
                    Browser1Image.SelectedItem = "Custom";
                }
                else if (selectedComboBox.Name == "Browser2")
                {
                    Browser2Name.Text = "";
                    Browser2Target.Text = "";
                    Browser2Image.SelectedItem = "Custom";
                }
                else if (selectedComboBox.Name == "Browser3")
                {
                    Browser3Name.Text = "";
                    Browser3Target.Text = "";
                    Browser3Image.SelectedItem = "Custom";
                }
                else if (selectedComboBox.Name == "Browser4")
                {
                    Browser4Name.Text = "";
                    Browser4Target.Text = "";
                    Browser4Image.SelectedItem = "Custom";
                }
                else if (selectedComboBox.Name == "Browser5")
                {
                    Browser5Name.Text = "";
                    Browser5Target.Text = "";
                    Browser5Image.SelectedItem = "Custom";
                }
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            if (File.Exists(Convert.ToString(Program.BrowserChooserConfigFileName)) || Program.ConfigFile.Exists)
            {
                this.Close();
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnSetDefault_Click(System.Object sender, System.EventArgs e)
        {
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
            if (!hasAdministrativeRight)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                startInfo.Arguments = "registerbrowser";
                startInfo.Verb = "runas";
                startInfo.CreateNoWindow = true;
                Process p = Process.Start(startInfo);
                p.WaitForExit();
            }
            else
            {
                MessageBox.Show(SetDefaultBrowserPath());
            }
        }

        public static string SetDefaultBrowserPath()
        {
            if (OS_Version() == "Windows XP")
            {
                try
                {
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes").SetValue(".shtml", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes").SetValue(".xht", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes").SetValue(".xhtm", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes").SetValue(".xhtml", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes").SetValue(".htm", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes").SetValue(".html", "BrowserChooserHTML", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.shtml").SetValue("", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.xht").SetValue("", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.xhtm").SetValue("", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.xhtml").SetValue("", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.htm").SetValue("", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.html").SetValue("", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.url").SetValue("", "BrowserChooserHTML", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\BrowserChooserHTML\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\BrowserChooserHTML\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\MyInternetShortcut\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\MyInternetShortcut\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\http\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\http\\shell\\BrowserChooserHTML\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\https\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\https\\shell\\BrowserChooserHTML\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ftp\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ftp\\shell\\BrowserChooserHTML\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\BrowserChooserHTML\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\BrowserChooserHTML\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\ftp\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\ftp\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\gopher\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\gopher\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\http\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\http\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\https\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\https\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\CHROME\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\CHROME\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\BrowserChooserHTML\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\BrowserChooserHTML\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ftp\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ftp\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\gopher\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\gopher\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\http\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\http\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\https\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\https\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\CHROME\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\CHROME\\shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main").SetValue("Check_Associations", "No", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main").SetValue("IgnoreDefCheck", "Yes", RegistryValueKind.String);

                }
                catch (Exception ex)
                {
                    Program.BrowserConfig.IamDefaultBrowser = false;
                    return "Problem writing or reading Registry: " + "\r\n" + "\r\n" + ex.Message;
                }

            }
            else if (OS_Version() == "Windows 7" || OS_Version() == "Windows Vista" || OS_Version() == "Windows 8" || OS_Version() == "Windows 10")
            {
                try
                {
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\RegisteredApplications").SetValue("Browser Chooser", "Software\\\\Browser Chooser\\\\Capabilities", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities").SetValue("ApplicationName", "Browser Chooser", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities").SetValue("ApplicationIcon", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities").SetValue("ApplicationDescription", "Small app that let's you choose what browser to open a url in. Visit my website for more information. www.janolepeek.com", RegistryValueKind.String);

                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\FileAssociations").SetValue(".xhtml", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\FileAssociations").SetValue(".xht", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\FileAssociations").SetValue(".shtml", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\FileAssociations").SetValue(".html", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\FileAssociations").SetValue(".htm", "BrowserChooserHTML", RegistryValueKind.String);

                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\StartMenu").SetValue("StartMenuInternet", "Browser Chooser.exe", RegistryValueKind.String);

                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\URLAssociations").SetValue("https", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\URLAssociations").SetValue("http", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\URLAssociations").SetValue("ftp", "BrowserChooserHTML", RegistryValueKind.String);

                    Registry.ClassesRoot.CreateSubKey("BrowserChooserHTML").SetValue("", "Browser Chooser HTML", RegistryValueKind.String);
                    Registry.ClassesRoot.CreateSubKey("BrowserChooserHTML").SetValue("URL Protocol", "", RegistryValueKind.String);

                    Registry.ClassesRoot.CreateSubKey("BrowserChooserHTML\\DefaultIcon").SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);

                    Registry.ClassesRoot.CreateSubKey("BrowserChooserHTML\\shell\\open\\command").SetValue("", Application.ExecutablePath + " %1", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\Shell\\Associations\\UrlAssociations\\http\\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\Shell\\Associations\\UrlAssociations\\https\\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\Shell\\Associations\\UrlAssociations\\ftp\\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String);

                    try
                    {
                        if (OS_Version() == "Windows 10" || OS_Version() == "Windows 8")
                        {
                            // Win 8 and above no longer support setting the default apps - must show the dialog to the end user
                            var result = Process.Start("ms-settings:defaultapps");
                            MessageBox.Show("Please select Browser Chooser as the default Web Browser");
                            return "";
                        }
                        else
                        {
                            Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.htm\\UserChoice");
                            Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.html\\UserChoice");
                            Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.shtml\\UserChoice");
                            Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.xht\\UserChoice");
                            Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.xhtml\\UserChoice");

                            Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.htm\\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String);
                            Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.html\\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String);
                            Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.shtml\\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String);
                            Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.xht\\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String);
                            Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.xhtml\\UserChoice").SetValue("Progid", "BrowserChooserHTML", Microsoft.Win32.RegistryValueKind.String);
                        }
                    }
                    catch (Exception ex)
                    {
                        //Interaction.MsgBox("An error may have occured registering the file extensions. You may want to check in the 'Default Programs' option in your start menu to confirm this worked." + "\r\n" + "\r\n" + ex.Message, MsgBoxStyle.Exclamation, null);
                    }
                }
                catch (Exception ex)
                {
                    Program.BrowserConfig.IamDefaultBrowser = false;
                    return "Problem writing or reading Registry: " + "\r\n" + "\r\n" + ex.Message;
                }
            }
            else
            {
                return "Unable to determine what version of Windows you are running, so we can't set Browser Chooser as the default. Sorry.";
            }

            Program.BrowserConfig.IamDefaultBrowser = true;
            return "Default browser has been set to Browser Chooser.";
        }

        private void Browser1Target_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (Browser1Target.Text != "")
            {
                Panel2.Enabled = true;
            }
            else
            {
                Panel2.Enabled = false;
            }
        }

        private void Browser2Target_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (Browser2Target.Text != "")
            {
                Panel3.Enabled = true;
            }
            else
            {
                Panel3.Enabled = false;
            }
        }

        private void Browser3Target_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (Browser3Target.Text != "")
            {
                Panel4.Enabled = true;
            }
            else
            {
                Panel4.Enabled = false;
            }
        }

        private void Browser4Target_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (Browser4Target.Text != "")
            {
                Panel5.Enabled = true;
            }
            else
            {
                Panel5.Enabled = false;
            }
        }


        private void btnUpdateCheck_Click(System.Object sender, System.EventArgs e)
        {
            //MainForm.CheckforUpdate("verbose");
        }

        private void btnHelp_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\Browser Chooser Help.chm");
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox("Help file not found!" + "\r\n" + "\r\n" + ex.Message, MsgBoxStyle.Critical, null);
            }
        }

        private void BrowseCustomImageClick(OpenFileDialog fileDialog, TextBox filePathTextBox, ComboBox imageComboBox)
        {
            //try to open the file dialog to the image's path (even if the image doesn't exist)
            //otherwise open to the application startup path
            if (!string.IsNullOrEmpty(filePathTextBox.Text))
            {
                FileInfo cImage = new FileInfo(Path.Combine(Application.StartupPath, filePathTextBox.Text));
                if (cImage.Directory.Exists)
                {
                    fileDialog.InitialDirectory = cImage.DirectoryName;
                    if (cImage.Exists)
                    {
                        fileDialog.FileName = cImage.FullName;
                    }
                }
                else
                {
                    fileDialog.InitialDirectory = Application.StartupPath;
                }
            }
            else
            {
                fileDialog.InitialDirectory = Application.StartupPath;
            }

            fileDialog.Filter = "Image (png, ico)|*.png;*.ico";
            fileDialog.ShowDialog();
            //if a file is not picked, don't clear the options textbox
            if (!string.IsNullOrEmpty(fileDialog.FileName))
            {
                imageComboBox.SelectedItem = "Custom";
                if (fileDialog.FileName.StartsWith(Application.StartupPath))
                {
                    //remove application path to support relative paths / particularly for portable mode
                    filePathTextBox.Text = fileDialog.FileName.Substring(Application.StartupPath.Length + 1);
                }
                else
                {
                    filePathTextBox.Text = fileDialog.FileName;
                }
            }
            fileDialog.Reset();
        }

        private void btnBrowseCustomImage1_Click(System.Object sender, System.EventArgs e)
        {
            BrowseCustomImageClick(Browser1FileDialog, Browser1ImagePath, Browser1Image);
        }

        private void btnBrowseCustomImage2_Click(System.Object sender, System.EventArgs e)
        {
            BrowseCustomImageClick(Browser2FileDialog, Browser2ImagePath, Browser2Image);
        }

        private void btnBrowseCustomImage3_Click(System.Object sender, System.EventArgs e)
        {
            BrowseCustomImageClick(Browser3FileDialog, Browser3ImagePath, Browser3Image);
        }

        private void btnBrowseCustomImage4_Click(System.Object sender, System.EventArgs e)
        {
            BrowseCustomImageClick(Browser4FileDialog, Browser4ImagePath, Browser4Image);
        }

        private void btnBrowseCustomImage5_Click(System.Object sender, System.EventArgs e)
        {
            BrowseCustomImageClick(Browser5FileDialog, Browser5ImagePath, Browser5Image);
        }

        public static string OS_Version()
        {
            OperatingSystem osInfo = default(OperatingSystem);
            string sAns = "Unknown";

            osInfo = Environment.OSVersion;

            if (osInfo.Platform == PlatformID.Win32Windows)
            {
                if ((int) (osInfo.Version.Minor) == 0)
                {
                    sAns = "Windows 95";
                }
                else if ((int) (osInfo.Version.Minor) == 10)
                {
                    if (osInfo.Version.Revision.ToString() == "2222A")
                    {
                        sAns = "Windows 98 Second Edition";
                    }
                    else
                    {
                        sAns = "Windows 98";
                    }
                }
                else if ((int) (osInfo.Version.Minor) == 90)
                {
                    sAns = "Windows Me";
                }
            }
            else if (osInfo.Platform == PlatformID.Win32NT)
            {
                if ((int) (osInfo.Version.Major) == 3)
                {
                    sAns = "Windows NT 3.51";
                }
                else if ((int) (osInfo.Version.Major) == 4)
                {
                    sAns = "Windows NT 4.0";
                }
                else if ((int) (osInfo.Version.Major) == 5)
                {
                    if (osInfo.Version.Minor == 0)
                    {
                        sAns = "Windows 2000";
                    }
                    else if (osInfo.Version.Minor == 1)
                    {
                        sAns = "Windows XP";
                    }
                    else if (osInfo.Version.Minor == 2)
                    {
                        sAns = "Windows Server 2003";
                    }
                    else //Future version maybe update
                    {
                        //as needed
                        sAns = "Unknown Windows Version";
                    }
                }
                else if ((int) (osInfo.Version.Major) == 6)
                {
                    if (osInfo.Version.Minor == 0)
                    {
                        sAns = "Windows Vista";
                    }
                    else if (osInfo.Version.Minor == 1)
                    {
                        sAns = "Windows 7";
                    }
                    else if (osInfo.Version.Minor == 2)
                    {
                        Version vs = Environment.OSVersion.Version;
                        bool w10 = IsWindows10();
                        if (w10)
                        {
                            sAns = "Windows 10";
                        }
                        else
                        {
                            sAns = "Windows 8";
                        }
                    }
                    else //Future version maybe update
                    {
                        //as needed
                        sAns = "Unknown Windows Version";
                    }
                }
            }
            else
            {
                sAns = "Unknown";
            }

            return sAns;
        }

        public static bool IsWindows10()
        {
            // Not a great way, but the only reliable way I was able to find
            var reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
            var productName = reg.GetValue("ProductName").ToString();
            return productName.StartsWith("Windows 10");
        }
    }
}