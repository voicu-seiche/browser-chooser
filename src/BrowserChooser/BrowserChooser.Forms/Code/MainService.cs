using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace BrowserChooser.Forms.Code
{
    public static class MainService
    {
        public static string SetDefaultBrowser()
        {
            var pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            var hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
            if (!hasAdministrativeRight)
            {
                var startInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Application.ExecutablePath,
                    Arguments = "registerbrowser",
                    Verb = "runas",
                    CreateNoWindow = true
                };
                var p = Process.Start(startInfo);
                p?.WaitForExit();
            }
            else
            {
                return RegistryService.SetDefaultBrowserPath();
            }
            return String.Empty;
        }

        public static bool IsSetAsDefaultBrowser()
        {
            var data = Registry.GetValue("HKEY_CLASSES_ROOT\\BrowserChooserHTML\\DefaultIcon", string.Empty, string.Empty);
            return data != null;
        }

        // P/Invoke setup for user32.dll!SendMessage
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static void ElevateButton(Button button)
        {
            // Input validation, validate that button is not null
            if (button is null)
            {
                return;
            }
            
            // Define BCM_SETSHIELD locally, declared originally in Commctrl.h
            const uint BCM_SETSHIELD = (uint)5644;
            
            // Set button style to the system style
            button.FlatStyle = FlatStyle.System;

            // Decorate Activate Browser button with the BCM_SETSHIELD method if the user Is an non admin
            var appDomain = Thread.GetDomain();
            appDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            var user = (WindowsPrincipal)Thread.CurrentPrincipal;

            // Send the BCM_SETSHIELD message to the button control
            if (!user.IsInRole(WindowsBuiltInRole.Administrator))
            {
                SendMessage(new HandleRef(button, button.Handle), BCM_SETSHIELD, new IntPtr(0), new IntPtr(1));
            }
            else
            {
                SendMessage(new HandleRef(button, button.Handle), BCM_SETSHIELD, new IntPtr(0), new IntPtr(0));
            }
        }
    }
}
