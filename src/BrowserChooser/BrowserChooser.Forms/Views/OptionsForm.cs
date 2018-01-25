using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using BrowserChooser.Forms.Code;
using BrowserChooser.Forms.Models;
using BrowserChooser.Forms.Settings;

namespace BrowserChooser.Forms.Views
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            cbAutoCheck.Checked = AppSettingsService.BrowserConfig.AutoUpdateCheck;
            cbRevealURL.Checked = AppSettingsService.BrowserConfig.RevealUrl;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!AppSettingsService.BrowserConfig.DefaultBrowser)
            {
                var answer = MessageBox.Show("Browser Chooser is not currently set as your default browser. Would you like to make it so now?" + "\r\n" + "(Without being the default browser, Browser Chooser's usefullness rapidly declines...)", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    AppSettingsService.BrowserConfig.DefaultBrowser = true;
                    RegistryService.SetDefaultBrowserPath();
                }
                else
                {
                    AppSettingsService.BrowserConfig.DefaultBrowser = false;
                }
            }

            AppSettingsService.BrowserConfig.AutoUpdateCheck = cbAutoCheck.Checked;
            AppSettingsService.BrowserConfig.RevealUrl = cbRevealURL.Checked;
            AppSettingsService.PortableMode = cbPortable.Checked;

            if (!AppSettingsService.Save())
            {
                MessageBox.Show($"There was an error saving to the configuration file", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            var result = MainService.SetDefaultBrowser();
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result);
            }
        }

        private void btnUpdateCheck_Click(object sender, EventArgs e)
        {
            //MainForm.CheckForUpdate("verbose");
        }
    }
}