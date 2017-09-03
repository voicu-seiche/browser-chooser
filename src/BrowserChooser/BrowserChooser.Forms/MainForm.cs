using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;
using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.WindowsAPICodePack.Shell;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace BrowserChooser.Forms
{
    public partial class MainForm : Form
    {
        private List<PictureBox> browserButtons;
        private List<ToolTip> browserTooltips;
        private BackgroundWorker backgroundWorker1;
        private string strShownUrl;
        private string strUrl;

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckIfRegistered();

            InitializeMain();
        }

        private static void CheckIfRegistered()
        {
            var data = Registry.GetValue("HKEY_CLASSES_ROOT\\BrowserChooserHTML\\DefaultIcon", string.Empty, string.Empty);
            if (string.IsNullOrEmpty(Convert.ToString(data)))
            {
                new RegisterNow().ShowDialog();
            }
        }

        private void LaunchBrowserInfo(int browserNumber)
        {
            //if (BrowserConfig.ShowUrl == true && strShownUrl != "")
            //{
            //    this.Text = "Open " + BrowserConfig.GetBrowser(browserNumber).Name + " - " + strShownUrl;
            //}
            //else
            //{
            //    this.Text = "Open " + BrowserConfig.GetBrowser(browserNumber).Name;
            //}
        }

        private void LaunchBrowserAndClose(int browserNumber, bool bClose = true)
        {
            //if (!LaunchBrowser(browserNumber))
            //{
            //    Interaction.MsgBox("The target browser does not exist in the target location.", MsgBoxStyle.Critical, null);
            //}
            //else
            //{
            //    if (bClose)
            //    {
            //        this.Close();
            //    }
            //}
        }

        private Image SetImage(Browser browserChoice)
        {
            Image returnValue = default(Image);
            //if ((string)browserChoice.Image == "Firefox")
            //{
            //    returnValue = (Image)(global::My.Resources.Firefox);
            //}
            //else if ((string)browserChoice.Image == "Flock")
            //{
            //    returnValue = (Image)(global::My.Resources.Flock);
            //}
            //else if ((string)browserChoice.Image == "Internet Explorer")
            //{
            //    returnValue = (Image)(global::My.Resources.InternetExplorer);
            //}
            //else if ((string)browserChoice.Image == "Internet Explorer InPrivate")
            //{
            //    returnValue = (Image)(global::My.Resources.InternetExplorerInPrivate);
            //}
            //else if ((string)browserChoice.Image == "Edge")
            //{
            //    returnValue = (Image)(global::My.Resources.Edge);
            //}
            //else if ((string)browserChoice.Image == "Google Chrome")
            //{
            //    returnValue = (Image)(global::My.Resources.GoogleChrome);
            //}
            //else if ((string)browserChoice.Image == "Opera")
            //{
            //    returnValue = (Image)(global::My.Resources.Opera);
            //}
            //else if ((string)browserChoice.Image == "Safari")
            //{
            //    returnValue = (Image)(global::My.Resources.Safari);
            //}
            //else
            //{
            //    if (!string.IsNullOrEmpty(Convert.ToString(browserChoice.CustomImagePath)))
            //    {
            //        //handles absolute or relative paths,
            //        //Path.Combine(path1, path2): If path2 contains an absolute path, this method returns path2
            //        FileInfo cImage = new FileInfo(Path.Combine(Application.StartupPath, Convert.ToString(browserChoice.CustomImagePath)));
            //        if (cImage.Exists)
            //        {
            //            try
            //            {
            //                switch (cImage.Extension.ToUpper())
            //                {
            //                    case ".PNG":
            //                        returnValue = (Image)(Bitmap.FromFile(cImage.FullName));
            //                        break;
            //                    case ".ICO":
            //                        returnValue = new Icon(cImage.FullName, new Size(75, 80)).ToBitmap();
            //                        break;
            //                    default:
            //                        //unexpected file format - set icon to error
            //                        returnValue = (Image)(global::My.Resources._53);
            //                        break;
            //                }
            //            }
            //            catch (Exception)
            //            {
            //                //file specified not a valid image format - set icon to error
            //                returnValue = (Image)(global::My.Resources._53);
            //            }
            //        }
            //        else
            //        {
            //            //file doesn't exist - set icon to error
            //            returnValue = (Image)(global::My.Resources._53);
            //        }
            //    }
            //    else
            //    {
            //        //custom option chosen but no file specified - set icon to error
            //        returnValue = (Image)(global::My.Resources._53);
            //    }
            //}
            return returnValue;
        }

        public void InitializeMain()
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

            if (ReferenceEquals(Program.BrowserConfig, null) || Program.BrowserConfig.Browsers.Count == 0)
            {
                //Force open Options screen
                new Options().ShowDialog();
            }
            else
            {
                for (int index = 1; index <= 5; index++)
                {
                    if (Program.BrowserConfig.GetBrowser(index).IsActive)
                    {
                        this.Width = (index * 81) + 112;
                        browserButtons[index].Visible = true;
                        browserButtons[index].Image = SetImage(Program.BrowserConfig.GetBrowser(index));
                    }
                    else
                    {
                        browserButtons[index].Visible = false;
                    }
                }
            }

            if (Program.BrowserConfig.AutoUpdateCheck == true)
            {
                TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - Program.BrowserConfig.LastUpdateCheck.Ticks);
                if (ts.Days >= Program.DaysBetweenUpdateCheck)
                {
                    CheckforUpdate("");
                }
            }

            btnOptions.Location = new Point(this.Width - 33, 12);

            //Load url from parameter
            //for (var i = 0; i <= (new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase()).CommandLineArgs.Count - 1; i++)
            //{
            //    strUrl = (new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase()).CommandLineArgs.Item[Convert.ToInt32(i)].ToString();
            //}

            strShownUrl = strUrl;

            if (Program.BrowserConfig.RevealUrl && !string.IsNullOrEmpty(Convert.ToString(strUrl)))
            {
                string ShortenedHosts = "301url.com,6url.com,bit.ly,budurl.com,canurl.com,c-o.in,cli.gs,co.nr,cuttr.info,decenturl.com,dn.vc,doiop.com,dwarfurl.com,easyurl.net,elfurl.com,ff.im,fire.to,flq.us,freak.to,fype.com,gamerdna.com,gonext.org,is.gd,ix.lt,jive.to,kurl.us,lilurl.us,lnkurl.com,memurl.com,miklos.dk,miny.info,myurl.in,nanoref.com,notlong.com,ow.ly,pic.gd,piurl.com,plexp.com,qicute.com,qurlyq.com,readthisurl.com,redir.fr,redirx.com,shorl.com,shorterlink.com,shortlinks.co.uk,shorturl.com,shout.to,shrinkurl.us,shurl.net,simurl.com,smarturl.eu,snipurl.com,snurl.com,starturl.com,surl.co.uk,thurly.net,tighturl.com,tinylink.com,tinypic.com,tinyurl.com,traceurl.com,tr.im,tumblr.com,twurl.nl,url9.com,urlcut.com,urlcutter.com,urlhawk.com,urlpass.com,url-press.com,urlsmash.com,urlsn.com,urltea.com,url.ly,urly.local,yuarel.com,x.se,xaddr.com,xil.in,xrl.us,yatuc.com,yep.it,yweb.com";
                UriBuilder uri = new UriBuilder(strUrl);
                ShortenedHosts.Split(",".ToCharArray()).ToList();
                if (ShortenedHosts.Contains(Convert.ToString(uri.Host.ToString())))
                {
                    strShownUrl = "Unshortening " + strUrl + " ....";
                    this.Text = Program.DefaultMessage + " - " + strShownUrl;
                    backgroundWorker1 = new BackgroundWorker();
                    backgroundWorker1.DoWork += this.backgroundWorker1_DoWork;
                    backgroundWorker1.RunWorkerCompleted += this.backgroundWorker1_RunWorkerCompleted;
                    backgroundWorker1.RunWorkerAsync();
                }
            }

            if (Program.BrowserConfig.ShowUrl == true && !string.IsNullOrEmpty(Convert.ToString(strUrl)))
            {
                this.Text = Program.DefaultMessage + " - " + strShownUrl;
            }
            else
            {
                this.Text = Program.DefaultMessage;
            }

            //If no URL is passed in, don't display context menu
            if (string.IsNullOrEmpty(Convert.ToString(strUrl)))
            {
                for (int index = 1; index <= 5; index++)
                {
                    browserButtons[index].ContextMenuStrip = null;
                }
            }

            //Set up Tooltips
            for (int index = 1; index <= 5; index++)
            {
                if (Program.BrowserConfig.GetBrowser(index).IsActive)
                {
                    string strToolTip = "";

                    if (Program.BrowserConfig.ShowUrl == true && !string.IsNullOrEmpty(Convert.ToString(strUrl)))
                    {
                        strToolTip = string.Format("Open {0} in {1}.{2}Hotkeys: ({3}) or ({4}).", strUrl, Program.BrowserConfig.GetBrowser(index).Name, "\r\n", index, Program.BrowserConfig.GetBrowser(index).Name.Substring(0, 1));
                    }
                    else
                    {
                        strToolTip = string.Format("Open {0}.{1}Hotkeys: ({2}) or ({3}).", Program.BrowserConfig.GetBrowser(index).Name, "\r\n", index, Program.BrowserConfig.GetBrowser(index).Name.Substring(0, 1));
                    }
                    browserTooltips[index].SetToolTip(browserButtons[index], strToolTip);
                }
            }
        }

        private void btnInfo_MouseEnter(System.Object sender, System.EventArgs e)
        {
            this.Text = "About";
        }

        private void btnInfo_MouseLeave(System.Object sender, System.EventArgs e)
        {
            if (Program.BrowserConfig.ShowUrl == true && !string.IsNullOrEmpty(Convert.ToString(strUrl)))
            {
                this.Text = Program.DefaultMessage + " - " + strShownUrl;
            }
            else
            {
                this.Text = Program.DefaultMessage;
            }
        }

        private void btnOptions_MouseEnter(System.Object sender, System.EventArgs e)
        {
            this.Text = "Options";
        }

        private void btnOptions_Click(System.Object sender, System.EventArgs e)
        {
            new Options().Show();
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
            //    strWebVersion = Convert.ToString(client.DownloadString("http://www.janolepeek.com/bclatest.txt"));
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

        private void AddUrlToAutoOpenToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(strUrl)))
            {
                //create a new URI object in order to parse out the server portion
                //given a url like: http://www.google.com/test/browser.aspx?a=3&c=6, uri.Host should equal www.google.com
                UriBuilder uri = null;
                try
                {
                    uri = new UriBuilder(strUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading {strUrl} as a valid URL.{"\r\n"}{ex.Message}");
                }

                //get the browser button/picture box that triggered the context menu
                ContextMenuStrip cms = null;
                PictureBox browserButton = null;
                try
                {
                    cms = (ContextMenuStrip) ((ToolStripMenuItem)sender).Owner;
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
                        Program.BrowserConfig.GetBrowser(1).Urls.Add(uri.Host);
                    }
                    else if (browserButton.Name == "btnApp2")
                    {
                        Program.BrowserConfig.GetBrowser(2).Urls.Add(uri.Host);
                    }
                    else if (browserButton.Name == "btnApp3")
                    {
                        Program.BrowserConfig.GetBrowser(3).Urls.Add(uri.Host);
                    }
                    else if (browserButton.Name == "btnApp4")
                    {
                        Program.BrowserConfig.GetBrowser(4).Urls.Add(uri.Host);
                    }
                    else if (browserButton.Name == "btnApp5")
                    {
                        Program.BrowserConfig.GetBrowser(5).Urls.Add(uri.Host);
                    }
                    else
                    {
                        MessageBox.Show($"Browser Not Configured For Auto Add Url.{"\r\n"}Name={browserButton.Name}");
                    }

                    //save additions to the url list
                    new Options().SaveConfig();

                    //not sure if this UAC approach is needed here but added it for consistency
                    Process.Start(Application.ExecutablePath, strUrl);
                    System.Environment.Exit(-1);

                }
            }
        }

        private void btnInfo_Click(System.Object sender, System.EventArgs e)
        {
            //About.ShowDialog();
        }

        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnApp_MouseHover(System.Object sender, System.EventArgs e)
        {
            int browserIndex = Convert.ToInt32(browserButtons.IndexOf((PictureBox) sender));
            LaunchBrowserInfo(browserIndex);
        }

        private void btnApp_MouseLeave(System.Object sender, System.EventArgs e)
        {
            if (Program.BrowserConfig.ShowUrl == true && strShownUrl != "")
            {
                this.Text = Program.DefaultMessage + " - " + strShownUrl;
            }
            else
            {
                this.Text = Program.DefaultMessage;
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnApp_Click(System.Object sender, MouseEventArgs e)
        {
            int browserIndex = Convert.ToInt32(browserButtons.IndexOf((PictureBox) sender));

            if (RememberForThisURL.Checked)
            {
                var browser = Program.BrowserConfig.Browsers[browserIndex - 1];
                UriBuilder uri = null;
                try
                {
                    uri = new UriBuilder(strUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading {strUrl} as a valid URL.{"\r\n"}{ex.Message}");
                }
                uri.Path = "";
                browser.Urls.Add(uri.Host);
                new Options().SaveConfig();
            }

            //if (((new Microsoft.VisualBasic.Devices.Computer()).Keyboard.CtrlKeyDown) && (e.Button == MouseButtons.Left))
            //{
            //    LaunchBrowserAndClose(browserIndex, false);
            //}
            //else if (e.Button == MouseButtons.Left)
            //{
            //    LaunchBrowserAndClose(browserIndex);
            //}
        }

        private void frmMain_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string firstChar = Convert.ToString(e.KeyData.ToString());
            bool bClose = true;

            //if ((new Microsoft.VisualBasic.Devices.Computer()).Keyboard.CtrlKeyDown)
            //{
            //    bClose = false;
            //}

            if (e.KeyCode == Keys.O)
            {
                new Options().Show();
            }

            if (Program.BrowserConfig.GetBrowser(1).IsActive == true && (e.KeyCode == Keys.D1 | Program.BrowserConfig.GetBrowser(1).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase)))
            {
                LaunchBrowserAndClose(1, bClose);
            }
            else if (Program.BrowserConfig.GetBrowser(2).IsActive == true && (e.KeyCode == Keys.D2 | Program.BrowserConfig.GetBrowser(2).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase)))
            {
                LaunchBrowserAndClose(2, bClose);
            }
            else if (Program.BrowserConfig.GetBrowser(3).IsActive == true && (e.KeyCode == Keys.D3 | Program.BrowserConfig.GetBrowser(3).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase)))
            {
                LaunchBrowserAndClose(3, bClose);
            }
            else if (Program.BrowserConfig.GetBrowser(4).IsActive == true && (e.KeyCode == Keys.D4 | Program.BrowserConfig.GetBrowser(4).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase)))
            {
                LaunchBrowserAndClose(4, bClose);
            }
            else if (Program.BrowserConfig.GetBrowser(5).IsActive == true && (e.KeyCode == Keys.D5 | Program.BrowserConfig.GetBrowser(5).Name.StartsWith(firstChar, StringComparison.InvariantCultureIgnoreCase)))
            {
                LaunchBrowserAndClose(5, bClose);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            WebRequest request = WebRequest.Create(strUrl);
            WebResponse response = null;
            try
            {
                request.Method = WebRequestMethods.Http.Head;
                response = request.GetResponse();
            }
            catch (WebException)
            {
                request = WebRequest.Create(strUrl);
                request.Method = WebRequestMethods.Http.Get;
                response = request.GetResponse();
            }

            e.Result = response.ResponseUri.ToString();
            strUrl = response.ResponseUri.ToString();
            strShownUrl = response.ResponseUri.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                this.Text = Program.DefaultMessage + " - " + strUrl;
            }
            else
            {
                this.Text = Program.DefaultMessage + " - " + e.Result.ToString();
            }
        }

        private void CopyUrlToClipboardToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            //if (!string.IsNullOrEmpty(Convert.ToString(strUrl)))
            //{
            //    (new Microsoft.VisualBasic.Devices.Computer()).Clipboard.SetText(Convert.ToString(strUrl));
            //}
        }

        private void AddJumpLists()
        {
            // create the jump lists
            if (TaskbarManager.IsPlatformSupported)
            {

                JumpList jumpList = JumpList.CreateJumpList();

                foreach (var Browser in Program.BrowserConfig.Browsers)
                {
                    if (Browser.IsActive)
                    {
                        string target = Convert.ToString(Program.NormalizeTarget(Browser.Target));

                        string strBrowser = target;
                        string strParameters = "";

                        if (target.Contains(".exe "))
                        {
                            strBrowser = target.Substring(0, target.IndexOf(".exe") + 5);
                            strParameters = target.Substring(target.IndexOf(".exe") + 5, target.Length - (target.IndexOf(".exe") + 5)) + " ";

                        }

                        jumpList.AddUserTasks(new JumpListLink(Program.NormalizeTarget(strBrowser), "Open " + Browser.Name) { IconReference = new IconReference(Program.NormalizeTarget(strBrowser), 0), Arguments = strParameters });
                    }
                }

                // Add our user tasks
                jumpList.Refresh();
            }
        }

        private void frmMain_Shown(System.Object sender, System.EventArgs e)
        {
            AddJumpLists();
        }
    }
}
