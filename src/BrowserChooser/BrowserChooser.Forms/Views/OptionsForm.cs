using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BrowserChooser.Forms.Code;
using BrowserChooser.Forms.Code.InstalledBrowsers;
using BrowserChooser.Forms.Models;
using BrowserChooser.Forms.Settings;

namespace BrowserChooser.Forms.Views
{
    public partial class OptionsForm : Form
    {
        private const string FileDialogFilter = "Application | *.exe";
        public List<Browser> InstalledBrowsers;

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void LoadBrowsers()
        {
            InstalledBrowsers = new List<Browser>
            {
                new Browser
                {
                    Name = "Custom",
                    Target = ""
                }
            };

            foreach (var builder in InstalledBrowsersFactory.GetBuilders())
            {
                var result = builder.GetInstalledBrowser();
                if (result.IsSuccessful)
                {
                    InstalledBrowsers.AddRange(result.Browsers);
                }
            }
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            Browser1FileDialog.Filter = FileDialogFilter;
            Browser1FileDialog.ShowDialog();
            //if a file is not picked, don't clear the options textbox
            if (!string.IsNullOrEmpty(Browser1FileDialog.FileName))
            {
                Browser1Target.Text = Browser1FileDialog.FileName;
            }
            Browser1FileDialog.Reset();
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            Browser2FileDialog.Filter = FileDialogFilter;
            Browser2FileDialog.ShowDialog();
            //if a file is not picked, don't clear the options textbox
            if (!string.IsNullOrEmpty(Browser2FileDialog.FileName))
            {
                Browser2Target.Text = Browser2FileDialog.FileName;
            }
        }

        private void btnBrowse3_Click(object sender, EventArgs e)
        {
            Browser3FileDialog.Filter = FileDialogFilter;
            Browser3FileDialog.ShowDialog();
            //if a file is not picked, don't clear the options textbox
            if (!string.IsNullOrEmpty(Browser3FileDialog.FileName))
            {
                Browser3Target.Text = Browser3FileDialog.FileName;
            }
        }

        private void btnBrowse4_Click(object sender, EventArgs e)
        {
            Browser4FileDialog.Filter = FileDialogFilter;
            Browser4FileDialog.ShowDialog();
            //if a file is not picked, don't clear the options textbox
            if (!string.IsNullOrEmpty(Browser4FileDialog.FileName))
            {
                Browser4Target.Text = Browser4FileDialog.FileName;
            }
        }

        private void btnBrowse5_Click(object sender, EventArgs e)
        {
            Browser5FileDialog.Filter = FileDialogFilter;
            Browser5FileDialog.ShowDialog();
            //if a file is not picked, don't clear the options textbox
            if (!string.IsNullOrEmpty(Browser5FileDialog.FileName))
            {
                Browser5Target.Text = Browser5FileDialog.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Save settings from textboxes
            //Offer to make default browser if not already

            //reset the in memory list of browsers object
            AppSettingsService.BrowserConfig.Browsers.Clear();

            if (!AppSettingsService.BrowserConfig.IamDefaultBrowser)
            {
                var answer = MessageBox.Show("Browser Chooser is not currently set as your default browser. Would you like to make it so now?" + "\r\n" + "(Without being the default browser, Browser Chooser's usefullness rapidly declines...)", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    AppSettingsService.BrowserConfig.IamDefaultBrowser = true;
                    RegistryService.SetDefaultBrowserPath();
                }
                else
                {
                    AppSettingsService.BrowserConfig.IamDefaultBrowser = false;
                }
            }


            AppSettingsService.BrowserConfig.ShowUrl = cbURL.Checked;
            AppSettingsService.BrowserConfig.AutoUpdateCheck = cbAutoCheck.Checked;
            AppSettingsService.BrowserConfig.RevealUrl = cbRevealURL.Checked;

            if (cbIntranet.SelectedIndex == 0)
            {
                AppSettingsService.BrowserConfig.IntranetBrowser = null;
            }
            else if (cbIntranet.SelectedItem != null)
            {
                AppSettingsService.BrowserConfig.IntranetBrowser = (Browser)cbIntranet.SelectedItem;
            }

            if (cbDefault.SelectedIndex == 0)
            {
                AppSettingsService.BrowserConfig.DefaultBrowser = null;
            }
            else if (cbDefault.SelectedItem != null)
            {
                AppSettingsService.BrowserConfig.DefaultBrowser = (Browser)cbDefault.SelectedItem;
            }

            if (!string.IsNullOrEmpty(Browser1Name.Text))
            {
                AppSettingsService.BrowserConfig.Browsers.Add(new Browser
                {
                    Name = Browser1Name.Text,
                    Target = Browser1Target.Text,
                    Image = Browser1Image.Text,
                    BrowserNumber = 1,
                    IsActive = true,
                    Urls = Browser.StringToUrls(Browser1Urls.Text),
                    CustomImagePath = Browser1ImagePath.Text
                });
            }

            if (!string.IsNullOrEmpty(Browser2Name.Text))
            {
                AppSettingsService.BrowserConfig.Browsers.Add(new Browser
                {
                    Name = Browser2Name.Text,
                    Target = Browser2Target.Text,
                    Image = Browser2Image.Text,
                    BrowserNumber = 2,
                    IsActive = true,
                    Urls = Browser.StringToUrls(Browser2Urls.Text),
                    CustomImagePath = Browser2ImagePath.Text
                });
            }

            if (!string.IsNullOrEmpty(Browser3Name.Text))
            {
                AppSettingsService.BrowserConfig.Browsers.Add(new Browser
                {
                    Name = Browser3Name.Text,
                    Target = Browser3Target.Text,
                    Image = Browser3Image.Text,
                    BrowserNumber = 3,
                    IsActive = true,
                    Urls = Browser.StringToUrls(Browser3Urls.Text),
                    CustomImagePath = Browser3ImagePath.Text
                });
            }

            if (!string.IsNullOrEmpty(Browser4Name.Text))
            {
                AppSettingsService.BrowserConfig.Browsers.Add(new Browser
                {
                    Name = Browser4Name.Text,
                    Target = Browser4Target.Text,
                    Image = Browser4Image.Text,
                    BrowserNumber = 4,
                    IsActive = true,
                    Urls = Browser.StringToUrls(Browser4Urls.Text),
                    CustomImagePath = Browser4ImagePath.Text
                });
            }

            if (!string.IsNullOrEmpty(Browser5Name.Text))
            {
                AppSettingsService.BrowserConfig.Browsers.Add(new Browser
                {
                    Name = Browser5Name.Text,
                    Target = Browser5Target.Text,
                    Image = Browser5Image.Text,
                    BrowserNumber = 5,
                    IsActive = true,
                    Urls = Browser.StringToUrls(Browser5Urls.Text),
                    CustomImagePath = Browser5ImagePath.Text
                });
            }

            if (cbPortable.Checked)
            {
                AppSettingsService.PortableMode = true;
            }

            if (!AppSettingsService.Save())
            {
                MessageBox.Show($"There was an error saving to the configuration file", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
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
            Browser1Name.Text = AppSettingsService.BrowserConfig.GetBrowser(1).Name;
            Browser2Name.Text = AppSettingsService.BrowserConfig.GetBrowser(2).Name;
            Browser3Name.Text = AppSettingsService.BrowserConfig.GetBrowser(3).Name;
            Browser4Name.Text = AppSettingsService.BrowserConfig.GetBrowser(4).Name;
            Browser5Name.Text = AppSettingsService.BrowserConfig.GetBrowser(5).Name;

            Browser1Target.Text = AppSettingsService.BrowserConfig.GetBrowser(1).Target;
            Browser2Target.Text = AppSettingsService.BrowserConfig.GetBrowser(2).Target;
            Browser3Target.Text = AppSettingsService.BrowserConfig.GetBrowser(3).Target;
            Browser4Target.Text = AppSettingsService.BrowserConfig.GetBrowser(4).Target;
            Browser5Target.Text = AppSettingsService.BrowserConfig.GetBrowser(5).Target;

            //Browser1.SelectedItem = AppSettingsService.BrowserConfig.GetBrowser(1);
            //Browser2.SelectedItem = AppSettingsService.BrowserConfig.GetBrowser(2);
            //Browser3.SelectedItem = AppSettingsService.BrowserConfig.GetBrowser(3);
            //Browser4.SelectedItem = AppSettingsService.BrowserConfig.GetBrowser(4);
            //Browser5.SelectedItem = AppSettingsService.BrowserConfig.GetBrowser(5);

            Browser1Image.SelectedItem = AppSettingsService.BrowserConfig.GetBrowser(1).Image;
            Browser2Image.SelectedItem = AppSettingsService.BrowserConfig.GetBrowser(2).Image;
            Browser3Image.SelectedItem = AppSettingsService.BrowserConfig.GetBrowser(3).Image;
            Browser4Image.SelectedItem = AppSettingsService.BrowserConfig.GetBrowser(4).Image;
            Browser5Image.SelectedItem = AppSettingsService.BrowserConfig.GetBrowser(5).Image;

            Browser1Urls.Text = AppSettingsService.BrowserConfig.GetBrowser(1).UrlsToString();
            Browser2Urls.Text = AppSettingsService.BrowserConfig.GetBrowser(2).UrlsToString();
            Browser3Urls.Text = AppSettingsService.BrowserConfig.GetBrowser(3).UrlsToString();
            Browser4Urls.Text = AppSettingsService.BrowserConfig.GetBrowser(4).UrlsToString();
            Browser5Urls.Text = AppSettingsService.BrowserConfig.GetBrowser(5).UrlsToString();

            Browser1ImagePath.Text = AppSettingsService.BrowserConfig.GetBrowser(1).CustomImagePath;
            Browser2ImagePath.Text = AppSettingsService.BrowserConfig.GetBrowser(2).CustomImagePath;
            Browser3ImagePath.Text = AppSettingsService.BrowserConfig.GetBrowser(3).CustomImagePath;
            Browser4ImagePath.Text = AppSettingsService.BrowserConfig.GetBrowser(4).CustomImagePath;
            Browser5ImagePath.Text = AppSettingsService.BrowserConfig.GetBrowser(5).CustomImagePath;

            //Select the correct items in the Browser dropdown
            try
            {
                SelectBrowser(AppSettingsService.BrowserConfig.GetBrowser(1).Target, AppSettingsService.BrowserConfig.GetBrowser(1).Image, Browser1);
                SelectBrowser(AppSettingsService.BrowserConfig.GetBrowser(2).Target, AppSettingsService.BrowserConfig.GetBrowser(2).Image, Browser2);
                SelectBrowser(AppSettingsService.BrowserConfig.GetBrowser(3).Target, AppSettingsService.BrowserConfig.GetBrowser(3).Image, Browser3);
                SelectBrowser(AppSettingsService.BrowserConfig.GetBrowser(4).Target, AppSettingsService.BrowserConfig.GetBrowser(4).Image, Browser4);
                SelectBrowser(AppSettingsService.BrowserConfig.GetBrowser(5).Target, AppSettingsService.BrowserConfig.GetBrowser(5).Image, Browser5);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            cbURL.Checked = AppSettingsService.BrowserConfig.ShowUrl;
            cbAutoCheck.Checked = AppSettingsService.BrowserConfig.AutoUpdateCheck;
            cbRevealURL.Checked = AppSettingsService.BrowserConfig.RevealUrl;

            string target = "";
            if (AppSettingsService.BrowserConfig.IntranetBrowser != null)
            {
                target = AppSettingsService.BrowserConfig.IntranetBrowser.Target;
            }

            cbIntranet.Items.Add("None");
            cbIntranet.SelectedIndex = 0;
            foreach (var browser in AppSettingsService.BrowserConfig.Browsers)
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
            if (AppSettingsService.BrowserConfig.DefaultBrowser != null)
            {
                target = AppSettingsService.BrowserConfig.DefaultBrowser.Target;
            }

            cbDefault.Items.Add("None");
            cbDefault.SelectedIndex = 0;
            foreach (var browser in AppSettingsService.BrowserConfig.Browsers)
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

            if (!AppSettingsService.Exists())
            {
                //if (Interaction.MsgBox("Would you like to automatically check for updates?", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
                //{
                //    cbAutoCheck.Checked = true;
                //    Program.BrowserConfig.AutoUpdateCheck = true;
                //}
            }

            MainService.ElevateButton(btnSetDefault);
        }

        private void SelectBrowser(string browserPath, string browserName, ComboBox currentComboBox)
        {
            string path = browserPath;
            var comparer = new BrowserInfoPredicate(path);
            var browser = InstalledBrowsers.Find(comparer.ComparePaths);
            if (browser != null)
            {
                currentComboBox.SelectedIndex = currentComboBox.FindString(browserName);
            }
        }

        private void Browser1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedComboBox = (ComboBox)sender;

            if (selectedComboBox.SelectedIndex > 0)
            {
                var selectedBrowser = (Browser)selectedComboBox.SelectedItem;

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
            }
            else
            {
                var selectedBrowser = (Browser)selectedComboBox.SelectedItem;

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            var result = MainService.SetDefaultBrowser();
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result);
            }
        }

        private void Browser1Target_TextChanged(object sender, EventArgs e)
        {
            Panel2.Enabled = Browser1Target.Text != "";
        }

        private void Browser2Target_TextChanged(object sender, EventArgs e)
        {
            Panel3.Enabled = Browser2Target.Text != "";
        }

        private void Browser3Target_TextChanged(object sender, EventArgs e)
        {
            Panel4.Enabled = Browser3Target.Text != "";
        }

        private void Browser4Target_TextChanged(object sender, EventArgs e)
        {
            Panel5.Enabled = Browser4Target.Text != "";
        }

        private void btnUpdateCheck_Click(object sender, EventArgs e)
        {
            //MainForm.CheckForUpdate("verbose");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\Browser Chooser Help.chm");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                //Interaction.MsgBox("Help file not found!" + "\r\n" + "\r\n" + ex.Message, MsgBoxStyle.Critical, null);
            }
        }

        private void BrowseCustomImageClick(OpenFileDialog fileDialog, TextBox filePathTextBox, ComboBox imageComboBox)
        {
            //try to open the file dialog to the image's path (even if the image doesn't exist)
            //otherwise open to the application startup path
            if (!string.IsNullOrEmpty(filePathTextBox.Text))
            {
                var cImage = new FileInfo(Path.Combine(Application.StartupPath, filePathTextBox.Text));
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

        private void btnBrowseCustomImage1_Click(object sender, EventArgs e)
        {
            BrowseCustomImageClick(Browser1FileDialog, Browser1ImagePath, Browser1Image);
        }

        private void btnBrowseCustomImage2_Click(object sender, EventArgs e)
        {
            BrowseCustomImageClick(Browser2FileDialog, Browser2ImagePath, Browser2Image);
        }

        private void btnBrowseCustomImage3_Click(object sender, EventArgs e)
        {
            BrowseCustomImageClick(Browser3FileDialog, Browser3ImagePath, Browser3Image);
        }

        private void btnBrowseCustomImage4_Click(object sender, EventArgs e)
        {
            BrowseCustomImageClick(Browser4FileDialog, Browser4ImagePath, Browser4Image);
        }

        private void btnBrowseCustomImage5_Click(object sender, EventArgs e)
        {
            BrowseCustomImageClick(Browser5FileDialog, Browser5ImagePath, Browser5Image);
        }
    }
}