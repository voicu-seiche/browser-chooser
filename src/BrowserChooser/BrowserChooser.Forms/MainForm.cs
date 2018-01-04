using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.WindowsAPICodePack.Shell;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BrowserChooser.Forms.Code;
using BrowserChooser.Forms.Models;
using BrowserChooser.Forms.Settings;

namespace BrowserChooser.Forms
{
    public partial class MainForm : Form
    {
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
                ShowOptionsForm();
            }

            InitializeMain();
        }

        private void InitializeMain()
        {
            urlLabel.Text = AppSettingsService.UrlToOpen;

            foreach (var browser in AppSettingsService.BrowserConfig.Browsers)
            {
                if (browser.IsActive)
                {
                    var browserButton = new PictureBox();
                    browserButton.BackColor = Color.Transparent;
                    browserButton.ContextMenuStrip = !string.IsNullOrEmpty(AppSettingsService.UrlToOpen) ? browserButtonContextMenu : null;
                    browserButton.Image = Icon.ExtractAssociatedIcon(browser.Target)?.ToBitmap();
                    browserButton.Name = $"browserButton{browser.BrowserNumber}";
                    browserButton.Size = new Size(48, 48);
                    browserButton.SizeMode = PictureBoxSizeMode.CenterImage;
                    browserButton.TabIndex = 10 + browser.BrowserNumber;
                    browserButton.TabStop = false;
                    browserButton.Tag = browser;
                    browserButton.Visible = true;
                    browserButton.Click += btnApp_Click;
                    browserButton.MouseEnter += btnApp_MouseHover;
                    browserButton.MouseLeave += btnApp_MouseLeave;
                    browserButton.MouseHover += btnApp_MouseHover;

                    var browserToolTipString = new StringBuilder();
                    browserToolTipString.Append("Open ");
                    if (AppSettingsService.BrowserConfig.ShowUrl && !string.IsNullOrEmpty(AppSettingsService.UrlToOpen))
                    {
                        browserToolTipString.Append($"{AppSettingsService.UrlToOpen} in ");
                    }
                    browserToolTipString.Append($"{browser.Name}.\r\nHotkeys: ({browser.BrowserNumber}) or ({browser.Name.Substring(0, 1)}).");

                    var browserToolTip = new ToolTip();
                    browserToolTip.SetToolTip(browserButton, browserToolTipString.ToString());

                    flowLayoutPanel.Controls.Add(browserButton);
                }
            }

            CenterToScreen();

            if (AppSettingsService.BrowserConfig.AutoUpdateCheck)
            {
                var ts = new TimeSpan(DateTime.Now.Ticks - AppSettingsService.BrowserConfig.LastUpdateCheck.Ticks);
                if (ts.Days >= AppSettingsService.DaysBetweenUpdateCheck)
                {
                    CheckforUpdate(string.Empty);
                }
            }

            strShownUrl = AppSettingsService.UrlToOpen;

            UnshortenUrl();

            SetTitle();
        }

        private void UnshortenUrl()
        {
            // http://bit.ly/2CBfw0x
            // https://tinyurl.com/5q65j

            if (AppSettingsService.BrowserConfig.RevealUrl && !string.IsNullOrEmpty(AppSettingsService.UrlToOpen))
            {
                var shortenedHosts = new List<string>
                {
                    "301url.com",
                    "6url.com",
                    "bit.ly",
                    "budurl.com",
                    "canurl.com",
                    "c-o.in",
                    "cli.gs",
                    "co.nr",
                    "cuttr.info",
                    "decenturl.com",
                    "dn.vc",
                    "doiop.com",
                    "dwarfurl.com",
                    "easyurl.net",
                    "elfurl.com",
                    "ff.im",
                    "fire.to",
                    "flq.us",
                    "freak.to",
                    "fype.com",
                    "gamerdna.com",
                    "gonext.org",
                    "is.gd",
                    "ix.lt",
                    "jive.to",
                    "kurl.us",
                    "lilurl.us",
                    "lnkurl.com",
                    "memurl.com",
                    "miklos.dk",
                    "miny.info",
                    "myurl.in",
                    "nanoref.com",
                    "notlong.com",
                    "ow.ly",
                    "pic.gd",
                    "piurl.com",
                    "plexp.com",
                    "qicute.com",
                    "qurlyq.com",
                    "readthisurl.com",
                    "redir.fr",
                    "redirx.com",
                    "shorl.com",
                    "shorterlink.com",
                    "shortlinks.co.uk",
                    "shorturl.com",
                    "shout.to",
                    "shrinkurl.us",
                    "shurl.net",
                    "simurl.com",
                    "smarturl.eu",
                    "snipurl.com",
                    "snurl.com",
                    "starturl.com",
                    "surl.co.uk",
                    "thurly.net",
                    "tighturl.com",
                    "tinylink.com",
                    "tinypic.com",
                    "tinyurl.com",
                    "traceurl.com",
                    "tr.im",
                    "tumblr.com",
                    "twurl.nl",
                    "url9.com",
                    "urlcut.com",
                    "urlcutter.com",
                    "urlhawk.com",
                    "urlpass.com",
                    "url-press.com",
                    "urlsmash.com",
                    "urlsn.com",
                    "urltea.com",
                    "url.ly",
                    "urly.local",
                    "yuarel.com",
                    "x.se",
                    "xaddr.com",
                    "xil.in",
                    "xrl.us",
                    "yatuc.com",
                    "yep.it",
                    "yweb.com"
                };
                var uri = new UriBuilder(AppSettingsService.UrlToOpen);
                if (shortenedHosts.Contains(uri.Host))
                {
                    strShownUrl = $"Unshortening {AppSettingsService.UrlToOpen} ...";
                    Text = $"{AppSettingsService.DefaultMessage} - {strShownUrl}";
                    var backgroundWorker = new BackgroundWorker();
                    backgroundWorker.DoWork += BackgroundWorkerDoWork;
                    backgroundWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerCompleted;
                    backgroundWorker.RunWorkerAsync();
                }
            }
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
            if (string.IsNullOrEmpty(AppSettingsService.UrlToOpen))
            {
                return;
            }
            //create a new URI object in order to parse out the server portion
            //given a url like: http://www.google.com/test/browser.aspx?a=3&c=6, uri.Host should equal www.google.com
            UriBuilder uri = null;
            try
            {
                uri = new UriBuilder(AppSettingsService.UrlToOpen);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading {AppSettingsService.UrlToOpen} as a valid URL.{"\r\n"}{ex.Message}");
            }

            //get the browser button/picture box that triggered the context menu
            PictureBox browserButton = null;
            try
            {
                var cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
                browserButton = (PictureBox)cms.SourceControl;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Context Menu Error!{"\r\n"}{ex.Message}");
            }

            if (uri == null || browserButton == null)
            {
                return;
            }

            if (browserButton.Tag is Browser browser)
            {
                AppSettingsService.BrowserConfig.GetBrowser(browser.BrowserNumber).Urls.Add(uri.Host);
            }

            //save additions to the url list
            if (!AppSettingsService.Save())
            {
                MessageBox.Show($"There was an error saving to the configuration file", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //not sure if this UAC approach is needed here but added it for consistency
            //Process.Start(Application.ExecutablePath, AppSettingsService.UrlToOpen);
            //Environment.Exit(-1);
        }

        private void btnApp_MouseHover(object sender, EventArgs e)
        {
            if (!(sender is PictureBox browserButton))
            {
                return;
            }
            if (browserButton.Tag is Browser browser)
            {
                UpdateTitleWithBrowserName(browser.BrowserNumber);
            }
        }

        private void btnApp_MouseLeave(object sender, EventArgs e)
        {
            SetTitle();
        }

        private void btnApp_Click(object sender, EventArgs e)
        {
            if (!(sender is PictureBox browserButton))
            {
                return;
            }
            if (!(browserButton.Tag is Browser browser))
            {
                return;
            }
            if (rememberUrlCheckBox.Checked)
            {
                UriBuilder uri = null;
                try
                {
                    uri = new UriBuilder(AppSettingsService.UrlToOpen);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading {AppSettingsService.UrlToOpen} as a valid URL.{"\r\n"}{ex.Message}");
                }
                if (uri != null)
                {
                    uri.Path = "";
                    browser.Urls.Add(uri.Host);
                }
                if (!AppSettingsService.Save())
                {
                    MessageBox.Show($"There was an error saving to the configuration file", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!(e is MouseEventArgs mouseEventArgs))
            {
                return;
            }
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                LaunchBrowserAndClose(browser.BrowserNumber, !ModifierKeys.HasFlag(Keys.Control));
            }
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
            WebResponse response = null;
            try
            {
                var request = WebRequest.Create(AppSettingsService.UrlToOpen);
                request.Method = WebRequestMethods.Http.Get;
                response = request.GetResponse();
            }
            catch (WebException)
            {
                //request = WebRequest.Create(AppSettingsService.UrlToOpen);
                //request.Method = WebRequestMethods.Http.Get;
                //response = request.GetResponse();
            }

            e.Result = response?.ResponseUri.ToString();
            AppSettingsService.UrlToOpen = response?.ResponseUri.ToString();
            strShownUrl = response?.ResponseUri.ToString();
        }

        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            var urlTitle = e.Error != null ? AppSettingsService.UrlToOpen : e.Result;
            Text = $"{AppSettingsService.DefaultMessage} - {urlTitle}";
        }

        private void CopyUrlToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AppSettingsService.UrlToOpen))
            {
                //Clipboard.SetText(AppSettingsService.UrlToOpen);
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

        private void optionsToolStripButton_Click(object sender, EventArgs e)
        {
            ShowOptionsForm();
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            //About.ShowDialog();
        }

        private static void ShowOptionsForm()
        {
            var dialogResult = new OptionsForm().ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                AppSettingsService.Load();
            }
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
                MessageBox.Show("The target browser does not exist in the target location.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (bClose)
                {
                    Close();
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
    }
}
