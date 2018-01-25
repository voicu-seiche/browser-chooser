using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BrowserChooser.Forms.Code.Events;
using BrowserChooser.Forms.Models;
using BrowserChooser.Forms.Settings;

namespace BrowserChooser.Forms.Views
{
    public partial class BrowserButtonUserControl : UserControl
    {
        public event EventHandler<BrowserButtonClickedEventArgs> BrowserButtonClicked;
        public event EventHandler<Browser> BrowserButtonHovered;

        public BrowserButtonUserControl()
        {
            InitializeComponent();
        }

        public Browser Browser { get; set; }

        private void BrowserButtonUserControl_Load(object sender, EventArgs e)
        {
            browserIconPictureBox.Image = Icon.ExtractAssociatedIcon(Browser.Target)?.ToBitmap();
            browserTitleLabel.Text = Browser.Name;

            var browserToolTipString = new StringBuilder();
            browserToolTipString.Append("Open ");
            if (AppSettingsService.BrowserConfig.ShowUrl && !string.IsNullOrEmpty(AppSettingsService.UrlToOpen))
            {
                browserToolTipString.Append($"{AppSettingsService.UrlToOpen} in ");
            }
            browserToolTipString.Append($"{Browser.Name}.\r\nHotkeys: ({Browser.BrowserNumber}) or ({Browser.Name.Substring(0, 1)}).");

            var browserToolTip = new ToolTip();
            browserToolTip.SetToolTip(browserIconPictureBox, browserToolTipString.ToString());
            browserToolTip.SetToolTip(browserTitleLabel, browserToolTipString.ToString());
        }

        private void BrowserButtonUserControl_Click(object sender, EventArgs e)
        {
            if (!(e is MouseEventArgs mouseEventArgs))
            {
                return;
            }
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                OnBrowserButtonClicked(new BrowserButtonClickedEventArgs
                {
                    Browser = Browser,
                    Close = !ModifierKeys.HasFlag(Keys.Control),
                });
            }
        }

        private void BrowserButtonUserControl_MouseHover(object sender, EventArgs e)
        {
            OnBrowserButtonHovered(Browser);
        }

        private void BrowserButtonUserControl_MouseLeave(object sender, EventArgs e)
        {
            OnBrowserButtonHovered(null);
        }

        protected virtual void OnBrowserButtonClicked(BrowserButtonClickedEventArgs e)
        {
            BrowserButtonClicked?.Invoke(this, e);
        }

        protected virtual void OnBrowserButtonHovered(Browser e)
        {
            BrowserButtonHovered?.Invoke(this, e);
        }
    }
}
