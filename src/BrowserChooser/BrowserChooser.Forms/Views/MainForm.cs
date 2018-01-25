using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using BrowserChooser.Forms.Code;
using BrowserChooser.Forms.Code.Events;
using BrowserChooser.Forms.Models;
using BrowserChooser.Forms.Settings;

namespace BrowserChooser.Forms.Views
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

            urlLabel.Text = AppSettingsService.UrlToOpen;

            foreach (var browser in AppSettingsService.BrowserConfig.Browsers)
            {
                if (browser.IsActive)
                {
                    var browserButtonUserControl = new BrowserButtonUserControl();
                    browserButtonUserControl.Browser = browser;
                    browserButtonUserControl.Width = flowLayoutPanel.Width;

                    browserButtonUserControl.BrowserButtonClicked += BrowserButtonUserControl_BrowserButtonClicked;
                    browserButtonUserControl.BrowserButtonHovered += BrowserButtonUserControl_BrowserButtonHovered;

                    flowLayoutPanel.Controls.Add(browserButtonUserControl);
                }
            }

            if (AppSettingsService.BrowserConfig.AutoUpdateCheck)
            {
                var ts = new TimeSpan(DateTime.Now.Ticks - AppSettingsService.BrowserConfig.LastUpdateCheck.Ticks);
                if (ts.Days >= AppSettingsService.DaysBetweenUpdateCheck)
                {
                    CheckForUpdate(string.Empty);
                }
            }

            strShownUrl = AppSettingsService.UrlToOpen;

            UnshortenUrl();

            SetTitle();

            Refresh();
            CenterToScreen();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.O)
            {
                ShowOptionsForm();
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                Close();
                return;
            }

            var firstChar = e.KeyData.ToString();

            if (AppSettingsService.BrowserConfig.GetBrowser(1).IsActive && e.KeyCode == Keys.D1 | AppSettingsService.BrowserConfig.GetBrowser(1).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase))
            {
                LaunchBrowserAndClose(1, !ModifierKeys.HasFlag(Keys.Control));
            }
            else if (AppSettingsService.BrowserConfig.GetBrowser(2).IsActive && e.KeyCode == Keys.D2 | AppSettingsService.BrowserConfig.GetBrowser(2).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase))
            {
                LaunchBrowserAndClose(2, !ModifierKeys.HasFlag(Keys.Control));
            }
            else if (AppSettingsService.BrowserConfig.GetBrowser(3).IsActive && e.KeyCode == Keys.D3 | AppSettingsService.BrowserConfig.GetBrowser(3).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase))
            {
                LaunchBrowserAndClose(3, !ModifierKeys.HasFlag(Keys.Control));
            }
            else if (AppSettingsService.BrowserConfig.GetBrowser(4).IsActive && e.KeyCode == Keys.D4 | AppSettingsService.BrowserConfig.GetBrowser(4).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase))
            {
                LaunchBrowserAndClose(4, !ModifierKeys.HasFlag(Keys.Control));
            }
            else if (AppSettingsService.BrowserConfig.GetBrowser(5).IsActive && e.KeyCode == Keys.D5 | AppSettingsService.BrowserConfig.GetBrowser(5).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase))
            {
                LaunchBrowserAndClose(5, !ModifierKeys.HasFlag(Keys.Control));
            }
        }

        private void BrowserButtonUserControl_BrowserButtonHovered(object sender, Browser e)
        {
            if (e is null)
            {
                SetTitle();
            }
            else
            {
                UpdateTitleWithBrowserName(e.BrowserNumber);
            }
        }

        private void BrowserButtonUserControl_BrowserButtonClicked(object sender, BrowserButtonClickedEventArgs e)
        {
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
                    e.Browser.Urls.Add(uri.Host);
                }
                if (!AppSettingsService.Save())
                {
                    MessageBox.Show($"There was an error saving to the configuration file", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LaunchBrowserAndClose(e.Browser.BrowserNumber, e.Close);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptionsForm();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AppSettingsService.UrlToOpen))
            {
                //Clipboard.SetText(AppSettingsService.UrlToOpen);
            }
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdate(string.Empty);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //About.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UnshortenUrl()
        {
            // http://bit.ly/2CBfw0x
            // https://tinyurl.com/5q65j

            if (AppSettingsService.BrowserConfig.RevealUrl && !string.IsNullOrEmpty(AppSettingsService.UrlToOpen))
            {
                var uri = new UriBuilder(AppSettingsService.UrlToOpen);
                if (UrlService.ShortenedHosts.Contains(uri.Host))
                {
                    strShownUrl = $"Unshortening {AppSettingsService.UrlToOpen} ...";
                    toolStripStatusLabel.Text = $"{AppSettingsService.DefaultMessage} - {strShownUrl}";
                    var backgroundWorker = new BackgroundWorker();
                    backgroundWorker.DoWork += BackgroundWorkerDoWork;
                    backgroundWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerCompleted;
                    backgroundWorker.RunWorkerAsync();
                }
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
            toolStripStatusLabel.Text = $"{AppSettingsService.DefaultMessage} - {urlTitle}";
            urlLabel.Text = urlTitle.ToString();
        }

        private void CheckForUpdate(string mode)
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
            //        if (mode == "verbose")
            //        {
            //            Interaction.MsgBox("You are running the current version of Browser Chooser!", MsgBoxStyle.Information, null);
            //        }
            //    }
            //    BrowserConfig.LastUpdateCheck = DateTime.Now;
            //    Options.SaveConfig();
            //}
            //catch (Exception ex)
            //{
            //    if (mode == "verbose")
            //    {
            //        Interaction.MsgBox("There was an error checking for the latest version." + "\r\n" + "\r\n" + ex.Message, MsgBoxStyle.Critical, null);
            //    }
            //}
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
            toolStripStatusLabel.Text = $"Open {AppSettingsService.DefaultMessage}{urlTitle}";
        }

        private void UpdateTitleWithBrowserName(int browserNumber)
        {
            var urlTitle = AppSettingsService.BrowserConfig.ShowUrl && !string.IsNullOrEmpty(strShownUrl) ? $" - {strShownUrl}" : string.Empty;
            toolStripStatusLabel.Text = $"Open {AppSettingsService.BrowserConfig.GetBrowser(browserNumber).Name}{urlTitle}";
        }

        private void LaunchBrowserAndClose(int browserNumber, bool close = true)
        {
            if (!Program.LaunchBrowser(browserNumber))
            {
                MessageBox.Show("The target browser does not exist in the target location.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (close)
                {
                    Close();
                }
            }
        }
    }
}
