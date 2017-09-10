using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading;

namespace BrowserChooser.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            AppDomain ad = Thread.GetDomain();
            ad.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal user = (WindowsPrincipal) Thread.CurrentPrincipal;
            // Decorate Activate Browser button with the BCM_SETSHIELD method if the user Is an non admin
            var ElevationRequired = false;
            if (!user.IsInRole(WindowsBuiltInRole.Administrator))
            {
                ElevationRequired = true;
                new OptionsForm().ElevateIcon_BCM_SETSHIELD(btnYes, true);
            }
            else
            {
                new OptionsForm().ElevateIcon_BCM_SETSHIELD(btnYes, false);
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
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
                MessageBox.Show(OptionsForm.SetDefaultBrowserPath());
            }
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
