using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.WindowsAPICodePack.Shell;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BrowserChooser.Forms.Code;
using BrowserChooser.Forms.Models;
using BrowserChooser.Forms.Settings;

namespace BrowserChooser.Forms
{
    public partial class MainForm : Form
    {
        private List<PictureBox> browserButtons;
        private List<ToolTip> browserTooltips;
        private string strShownUrl;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!MainService.IsSetAsDefaultBrowser())
            {
                new RegisterForm().ShowDialog();
            }

            if (AppSettingsService.BrowserConfig is null || AppSettingsService.BrowserConfig.Browsers.Count == 0)
            {
                var dialogResult = new OptionsForm().ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    AppSettingsService.Load();
                }
            }

            InitializeMain();
        }

        private void SetTitle()
        {
            var urlTitle = AppSettingsService.BrowserConfig.ShowUrl && !string.IsNullOrEmpty(strShownUrl) ? $" - {strShownUrl}" : string.Empty;
            Text = $"Open {AppSettingsService.DefaultMessage}{urlTitle}";
        }

        private void UpdateTitleWithBrowserName(int browserNumber)
        {
            var urlTitle = AppSettingsService.BrowserConfig.ShowUrl && !string.IsNullOrEmpty(strShownUrl) ? $" - {strShownUrl}" : string.Empty;
            Text = $"Open {AppSettingsService.BrowserConfig.GetBrowser(browserNumber).Name}{urlTitle}";
        }

        private void LaunchBrowserAndClose(int browserNumber, bool bClose = true)
        {
            if (!Program.LaunchBrowser(browserNumber))
            {
                //Interaction.MsgBox("The target browser does not exist in the target location.", MsgBoxStyle.Critical, null);
            }
            else
            {
                if (bClose)
                {
                    this.Close();
                }
            }
        }

        private Image SetImage(Browser browserChoice)
        {
            Image returnValue;
            if (browserChoice.Image == "Firefox")
            {
                returnValue = Properties.Resources.Firefox;
            }
            else if (browserChoice.Image == "Flock")
            {
                returnValue = Properties.Resources.Flock;
            }
            else if (browserChoice.Image == "Internet Explorer")
            {
                returnValue = Properties.Resources.InternetExplorer;
            }
            else if (browserChoice.Image == "Internet Explorer InPrivate")
            {
                returnValue = Properties.Resources.InternetExplorerInPrivate;
            }
            else if (browserChoice.Image == "Edge")
            {
                returnValue = Properties.Resources.Edge;
            }
            else if (browserChoice.Image == "Google Chrome")
            {
                returnValue = Properties.Resources.GoogleChrome;
            }
            else if (browserChoice.Image == "Opera")
            {
                returnValue = Properties.Resources.Opera;
            }
            else if (browserChoice.Image == "Safari")
            {
                returnValue = Properties.Resources.Safari;
            }
            else
            {
                if (!string.IsNullOrEmpty(browserChoice.CustomImagePath))
                {
                    //handles absolute or relative paths,
                    //Path.Combine(path1, path2): If path2 contains an absolute path, this method returns path2
                    FileInfo cImage = new FileInfo(Path.Combine(Application.StartupPath, browserChoice.CustomImagePath));
                    if (cImage.Exists)
                    {
                        try
                        {
                            switch (cImage.Extension.ToUpper())
                            {
                                case ".PNG":
                                    returnValue = Image.FromFile(cImage.FullName);
                                    break;
                                case ".ICO":
                                    returnValue = new Icon(cImage.FullName, new Size(75, 80)).ToBitmap();
                                    break;
                                default:
                                    //unexpected file format - set icon to error
                                    returnValue = Properties.Resources._53;
                                    break;
                            }
                        }
                        catch (Exception)
                        {
                            //file specified not a valid image format - set icon to error
                            returnValue = Properties.Resources._53;
                        }
                    }
                    else
                    {
                        //file doesn't exist - set icon to error
                        returnValue = Properties.Resources._53;
                    }
                }
                else
                {
                    //custom option chosen but no file specified - set icon to error
                    returnValue = Properties.Resources._53;
                }
            }
            return returnValue;
        }

        private void InitializeMain()
        {
            browserButtons = new List<PictureBox>();
            browserButtons.Add(null);
            browserButtons.Add(btnApp1);
            browserButtons.Add(btnApp2);
            browserButtons.Add(btnApp3);
            browserButtons.Add(btnApp4);
            browserButtons.Add(btnApp5);

            browserTooltips = new List<ToolTip>();
            browserTooltips.Add(null);
            browserTooltips.Add(btn1TT);
            browserTooltips.Add(btn2TT);
            browserTooltips.Add(btn3TT);
            browserTooltips.Add(btn4TT);
            browserTooltips.Add(btn5TT);

            for (int index = 1; index <= 5; index++)
            {
                if (AppSettingsService.BrowserConfig.GetBrowser(index).IsActive)
                {
                    this.Width = index * 81 + 112;
                    browserButtons[index].Visible = true;
                    browserButtons[index].Image = SetImage(AppSettingsService.BrowserConfig.GetBrowser(index));
                }
                else
                {
                    browserButtons[index].Visible = false;
                }
            }

            if (AppSettingsService.BrowserConfig.AutoUpdateCheck)
            {
                var ts = new TimeSpan(DateTime.Now.Ticks - AppSettingsService.BrowserConfig.LastUpdateCheck.Ticks);
                if (ts.Days >= AppSettingsService.DaysBetweenUpdateCheck)
                {
                    CheckforUpdate(string.Empty);
                }
            }

            btnOptions.Location = new Point(this.Width - 33, 12);

            //Load url from parameter
            //for (var i = 0; i <= (new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase()).CommandLineArgs.Count - 1; i++)
            //{
            //    strUrl = (new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase()).CommandLineArgs.Item[i].ToString();
            //}

            strShownUrl = AppSettingsService.StrUrl;

            if (AppSettingsService.BrowserConfig.RevealUrl && !string.IsNullOrEmpty(AppSettingsService.StrUrl))
            {
                var shortenedHosts = new List<string> { "301url.com", "6url.com", "bit.ly", "budurl.com", "canurl.com", "c-o.in", "cli.gs", "co.nr", "cuttr.info", "decenturl.com", "dn.vc", "doiop.com", "dwarfurl.com", "easyurl.net", "elfurl.com", "ff.im", "fire.to", "flq.us", "freak.to", "fype.com", "gamerdna.com", "gonext.org", "is.gd", "ix.lt", "jive.to", "kurl.us", "lilurl.us", "lnkurl.com", "memurl.com", "miklos.dk", "miny.info", "myurl.in", "nanoref.com", "notlong.com", "ow.ly", "pic.gd", "piurl.com", "plexp.com", "qicute.com", "qurlyq.com", "readthisurl.com", "redir.fr", "redirx.com", "shorl.com", "shorterlink.com", "shortlinks.co.uk", "shorturl.com", "shout.to", "shrinkurl.us", "shurl.net", "simurl.com", "smarturl.eu", "snipurl.com", "snurl.com", "starturl.com", "surl.co.uk", "thurly.net", "tighturl.com", "tinylink.com", "tinypic.com", "tinyurl.com", "traceurl.com", "tr.im", "tumblr.com", "twurl.nl", "url9.com", "urlcut.com", "urlcutter.com", "urlhawk.com", "urlpass.com", "url-press.com", "urlsmash.com", "urlsn.com", "urltea.com", "url.ly", "urly.local", "yuarel.com", "x.se", "xaddr.com", "xil.in", "xrl.us", "yatuc.com", "yep.it", "yweb.com" };
                var uri = new UriBuilder(AppSettingsService.StrUrl);
                if (shortenedHosts.Contains(uri.Host))
                {
                    strShownUrl = $"Unshortening {AppSettingsService.StrUrl} ...";
                    Text = $"{AppSettingsService.DefaultMessage} - {strShownUrl}";
                    var backgroundWorker = new BackgroundWorker();
                    backgroundWorker.DoWork += BackgroundWorkerDoWork;
                    backgroundWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerCompleted;
                    backgroundWorker.RunWorkerAsync();
                }
            }

            SetTitle();

            //If no URL is passed in, don't display context menu
            if (string.IsNullOrEmpty(AppSettingsService.StrUrl))
            {
                for (var index = 1; index <= 5; index++)
                {
                    browserButtons[index].ContextMenuStrip = null;
                }
            }

            //Set up Tooltips
            for (var index = 1; index <= 5; index++)
            {
                if (AppSettingsService.BrowserConfig.GetBrowser(index).IsActive)
                {
                    string strToolTip;

                    if (AppSettingsService.BrowserConfig.ShowUrl && !string.IsNullOrEmpty(AppSettingsService.StrUrl))
                    {
                        strToolTip = $"Open {AppSettingsService.StrUrl} in {AppSettingsService.BrowserConfig.GetBrowser(index).Name}.\r\nHotkeys: ({index}) or ({AppSettingsService.BrowserConfig.GetBrowser(index).Name.Substring(0, 1)}).";
                    }
                    else
                    {
                        strToolTip = $"Open {AppSettingsService.BrowserConfig.GetBrowser(index).Name}.\r\nHotkeys: ({index}) or ({AppSettingsService.BrowserConfig.GetBrowser(index).Name.Substring(0, 1)}).";
                    }
                    browserTooltips[index].SetToolTip(browserButtons[index], strToolTip);
                }
            }
        }

        private void btnInfo_MouseEnter(object sender, EventArgs e)
        {
            this.Text = "About";
        }

        private void btnInfo_MouseLeave(object sender, EventArgs e)
        {
            if (AppSettingsService.BrowserConfig.ShowUrl && !string.IsNullOrEmpty(AppSettingsService.StrUrl))
            {
                this.Text = AppSettingsService.DefaultMessage + " - " + strShownUrl;
            }
            else
            {
                this.Text = AppSettingsService.DefaultMessage;
            }
        }

        private void btnOptions_MouseEnter(object sender, EventArgs e)
        {
            this.Text = "Options";
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            new OptionsForm().Show();
        }

        public void CheckforUpdate(string strMode)
        {
            //try
            //{
            //    WebClient client = new WebClient();
            //    string strWebVersion = "";
            //    //Switch for Portable
            //    //If (PortableMode) Then
            //    //    strWebVersion = client.DownloadString("http://www.janolepeek.com/bcport.txt")
            //    //Else
            //    strWebVersion = client.DownloadString("http://www.janolepeek.com/bclatest.txt");
            //    //End If
            //    var version = new Version(strWebVersion);
            //    if (version.CompareTo((new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase()).Info.Version) > -1)
            //    {
            //        if (Interaction.MsgBox("A new version of Browser Chooser is available. Would you like to download it now?", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
            //        {
            //            Download.ShowDialog();
            //        }
            //    }
            //    else
            //    {
            //        if (strMode == "verbose")
            //        {
            //            Interaction.MsgBox("You are running the current version of Browser Chooser!", MsgBoxStyle.Information, null);
            //        }
            //    }
            //    BrowserConfig.LastUpdateCheck = DateTime.Now;
            //    Options.SaveConfig();
            //}
            //catch (Exception ex)
            //{
            //    if (strMode == "verbose")
            //    {
            //        Interaction.MsgBox("There was an error checking for the latest version." + "\r\n" + "\r\n" + ex.Message, MsgBoxStyle.Critical, null);
            //    }
            //}
        }

        private void AddUrlToAutoOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AppSettingsService.StrUrl))
            {
                //create a new URI object in order to parse out the server portion
                //given a url like: http://www.google.com/test/browser.aspx?a=3&c=6, uri.Host should equal www.google.com
                UriBuilder uri = null;
                try
                {
                    uri = new UriBuilder(AppSettingsService.StrUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading {AppSettingsService.StrUrl} as a valid URL.{"\r\n"}{ex.Message}");
                }

                //get the browser button/picture box that triggered the context menu
                ContextMenuStrip cms = null;
                PictureBox browserButton = null;
                try
                {
                    cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
                    browserButton = (PictureBox)cms.SourceControl;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected Context Menu Error!{"\r\n"}{ex.Message}");
                }

                if (uri != null && browserButton != null)
                {
                    if (browserButton.Name == "btnApp1")
                    {
                        AppSettingsService.BrowserConfig.GetBrowser(1).Urls.Add(uri.Host);
                    }
                    else if (browserButton.Name == "btnApp2")
                    {
                        AppSettingsService.BrowserConfig.GetBrowser(2).Urls.Add(uri.Host);
                    }
                    else if (browserButton.Name == "btnApp3")
                    {
                        AppSettingsService.BrowserConfig.GetBrowser(3).Urls.Add(uri.Host);
                    }
                    else if (browserButton.Name == "btnApp4")
                    {
                        AppSettingsService.BrowserConfig.GetBrowser(4).Urls.Add(uri.Host);
                    }
                    else if (browserButton.Name == "btnApp5")
                    {
                        AppSettingsService.BrowserConfig.GetBrowser(5).Urls.Add(uri.Host);
                    }
                    else
                    {
                        MessageBox.Show($"Browser Not Configured For Auto Add Url.{"\r\n"}Name={browserButton.Name}");
                    }

                    //save additions to the url list
                    new OptionsForm().SaveConfig();

                    //not sure if this UAC approach is needed here but added it for consistency
                    Process.Start(Application.ExecutablePath, AppSettingsService.StrUrl);
                    System.Environment.Exit(-1);

                }
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            //About.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApp_MouseHover(object sender, EventArgs e)
        {
            int browserIndex = browserButtons.IndexOf((PictureBox)sender);
            UpdateTitleWithBrowserName(browserIndex);
        }

        private void btnApp_MouseLeave(object sender, EventArgs e)
        {
            if (AppSettingsService.BrowserConfig.ShowUrl == true && strShownUrl != "")
            {
                this.Text = AppSettingsService.DefaultMessage + " - " + strShownUrl;
            }
            else
            {
                this.Text = AppSettingsService.DefaultMessage;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApp_Click(object sender, EventArgs e)
        {
            int browserIndex = browserButtons.IndexOf((PictureBox)sender);

            if (RememberForThisURL.Checked)
            {
                var browser = AppSettingsService.BrowserConfig.Browsers[browserIndex - 1];
                UriBuilder uri = null;
                try
                {
                    uri = new UriBuilder(AppSettingsService.StrUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading {AppSettingsService.StrUrl} as a valid URL.{"\r\n"}{ex.Message}");
                }
                uri.Path = "";
                browser.Urls.Add(uri.Host);
                new OptionsForm().SaveConfig();
            }

            //if (((new Microsoft.VisualBasic.Devices.Computer()).Keyboard.CtrlKeyDown) && (e.Button == MouseButtons.Left))
            //{
            //    LaunchBrowserAndClose(browserIndex, false);
            //}
            //else if (e.Button == MouseButtons.Left)
            //{
            LaunchBrowserAndClose(browserIndex);
            //}
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            var firstChar = e.KeyData.ToString();

            //if ((new Microsoft.VisualBasic.Devices.Computer()).Keyboard.CtrlKeyDown)
            //{
            //    bClose = false;
            //}

            if (e.KeyCode == Keys.O)
            {
                new OptionsForm().Show();
            }

            if (AppSettingsService.BrowserConfig.GetBrowser(1).IsActive && e.KeyCode == Keys.D1 | AppSettingsService.BrowserConfig.GetBrowser(1).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase))
            {
                LaunchBrowserAndClose(1);
            }
            else if (AppSettingsService.BrowserConfig.GetBrowser(2).IsActive && e.KeyCode == Keys.D2 | AppSettingsService.BrowserConfig.GetBrowser(2).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase))
            {
                LaunchBrowserAndClose(2);
            }
            else if (AppSettingsService.BrowserConfig.GetBrowser(3).IsActive && e.KeyCode == Keys.D3 | AppSettingsService.BrowserConfig.GetBrowser(3).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase))
            {
                LaunchBrowserAndClose(3);
            }
            else if (AppSettingsService.BrowserConfig.GetBrowser(4).IsActive && e.KeyCode == Keys.D4 | AppSettingsService.BrowserConfig.GetBrowser(4).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase))
            {
                LaunchBrowserAndClose(4);
            }
            else if (AppSettingsService.BrowserConfig.GetBrowser(5).IsActive && e.KeyCode == Keys.D5 | AppSettingsService.BrowserConfig.GetBrowser(5).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase))
            {
                LaunchBrowserAndClose(5);
            }
        }

        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var request = WebRequest.Create(AppSettingsService.StrUrl);
            WebResponse response;
            try
            {
                request.Method = WebRequestMethods.Http.Head;
                response = request.GetResponse();
            }
            catch (WebException)
            {
                request = WebRequest.Create(AppSettingsService.StrUrl);
                request.Method = WebRequestMethods.Http.Get;
                response = request.GetResponse();
            }

            e.Result = response.ResponseUri.ToString();
            AppSettingsService.StrUrl = response.ResponseUri.ToString();
            strShownUrl = response.ResponseUri.ToString();
        }

        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            var urlTitle = e.Error != null ? AppSettingsService.StrUrl : e.Result;
            this.Text = $"{AppSettingsService.DefaultMessage} - {urlTitle}";
        }

        private void CopyUrlToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AppSettingsService.StrUrl))
            {
                Clipboard.SetText(AppSettingsService.StrUrl);
            }
        }

        private static void AddJumpLists()
        {
            // create the jump lists
            if (TaskbarManager.IsPlatformSupported)
            {
                var jumpList = JumpList.CreateJumpList();

                foreach (var browser in AppSettingsService.BrowserConfig.Browsers)
                {
                    if (browser.IsActive)
                    {
                        string target = Program.NormalizeTarget(browser.Target);

                        string strParameters = "";

                        if (target.Contains(".exe "))
                        {
                            var indexOfExe = target.IndexOf(".exe", StringComparison.Ordinal);
                            strParameters = target.Substring(indexOfExe + 5, target.Length - (indexOfExe + 5)) + " ";
                        }

                        jumpList.AddUserTasks(new JumpListLink(target, "Open " + browser.Name)
                        {
                            IconReference = new IconReference(target, 0),
                            Arguments = strParameters
                        });
                    }
                }
                jumpList.Refresh();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            AddJumpLists();
        }
    }
}
