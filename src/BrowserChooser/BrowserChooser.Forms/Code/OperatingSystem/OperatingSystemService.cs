using System;
using Microsoft.Win32;

namespace BrowserChooser.Forms.Code.OperatingSystem
{
    public static class OperatingSystemService
    {
        public static OSVersion GetVersion()
        {
            var osInfo = Environment.OSVersion;

            if (osInfo.Platform == PlatformID.Win32Windows)
            {
                if (osInfo.Version.Minor == 0)
                {
                    return OSVersion.Windows95;
                }
                if (osInfo.Version.Minor == 10)
                {
                    if (osInfo.Version.Revision.ToString() == "2222A")
                    {
                        return OSVersion.Windows98SecondEdition;
                    }
                    return OSVersion.Windows98;
                }
                if (osInfo.Version.Minor == 90)
                {
                    return OSVersion.WindowsMe;
                }
            }
            else if (osInfo.Platform == PlatformID.Win32NT)
            {
                if (osInfo.Version.Major == 3)
                {
                    return OSVersion.WindowsNT351;
                }
                if (osInfo.Version.Major == 4)
                {
                    return OSVersion.WindowsNT40;
                }
                if (osInfo.Version.Major == 5)
                {
                    if (osInfo.Version.Minor == 0)
                    {
                        return OSVersion.Windows2000;
                    }
                    if (osInfo.Version.Minor == 1)
                    {
                        return OSVersion.WindowsXP;
                    }
                    if (osInfo.Version.Minor == 2)
                    {
                        return OSVersion.WindowsServer2003;
                    }
                    return OSVersion.Unknown;
                }
                if (osInfo.Version.Major == 6)
                {
                    if (osInfo.Version.Minor == 0)
                    {
                        return OSVersion.WindowsVista;
                    }
                    if (osInfo.Version.Minor == 1)
                    {
                        return OSVersion.Windows7;
                    }
                    if (osInfo.Version.Minor == 2)
                    {
                        return IsWindows10() ? OSVersion.Windows10 : OSVersion.Windows8;
                    }
                    return OSVersion.Unknown;
                }
            }
            return OSVersion.Unknown;
        }

        private static bool IsWindows10()
        {
            // Not a great way, but the only reliable way I was able to find
            var reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
            if (reg == null)
            {
                return false;
            }
            var productName = reg.GetValue("ProductName").ToString();
            return productName.StartsWith("Windows 10");
        }
    }
}
