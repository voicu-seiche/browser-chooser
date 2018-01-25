using System;
using System.Windows.Forms;
using BrowserChooser.Forms.Code;

namespace BrowserChooser.Forms.Views
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            MainService.ElevateButton(btnYes);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            var result = MainService.SetDefaultBrowser();
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result);
            }

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
