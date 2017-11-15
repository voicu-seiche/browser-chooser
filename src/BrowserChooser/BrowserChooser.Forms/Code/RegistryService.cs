using System;
using System.Diagnostics;
using System.Windows.Forms;
using BrowserChooser.Forms.Settings;
using Microsoft.Win32;

namespace BrowserChooser.Forms.Code
{
    public class RegistryService
    {
        public static string SetDefaultBrowserPath()
        {
            if (OS_Version() == "Windows XP")
            {
                try
                {
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes")?.SetValue(".shtml", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes")?.SetValue(".xht", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes")?.SetValue(".xhtm", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes")?.SetValue(".xhtml", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes")?.SetValue(".htm", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes")?.SetValue(".html", "BrowserChooserHTML", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.shtml")?.SetValue("", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.xht")?.SetValue("", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.xhtm")?.SetValue("", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.xhtml")?.SetValue("", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.htm")?.SetValue("", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.html")?.SetValue("", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.url")?.SetValue("", "BrowserChooserHTML", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\BrowserChooserHTML\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\BrowserChooserHTML\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\MyInternetShortcut\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\MyInternetShortcut\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\http\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\http\\shell\\BrowserChooserHTML\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\https\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\https\\shell\\BrowserChooserHTML\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ftp\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ftp\\shell\\BrowserChooserHTML\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\BrowserChooserHTML\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\BrowserChooserHTML\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\ftp\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\ftp\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\gopher\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\gopher\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\http\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\http\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\https\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\https\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\CHROME\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\CHROME\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\BrowserChooserHTML\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\BrowserChooserHTML\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ftp\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ftp\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\gopher\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\gopher\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\http\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\http\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\https\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\https\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\CHROME\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\CHROME\\shell\\open\\command")?.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main")?.SetValue("Check_Associations", "No", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main")?.SetValue("IgnoreDefCheck", "Yes", RegistryValueKind.String);

                }
                catch (Exception ex)
                {
                    AppSettingsService.BrowserConfig.IamDefaultBrowser = false;
                    return "Problem writing or reading Registry: " + "\r\n" + "\r\n" + ex.Message;
                }

            }
            else if (OS_Version() == "Windows 7" || OS_Version() == "Windows Vista" || OS_Version() == "Windows 8" || OS_Version() == "Windows 10")
            {
                try
                {
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\RegisteredApplications")?.SetValue("Browser Chooser", "Software\\\\Browser Chooser\\\\Capabilities", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities")?.SetValue("ApplicationName", "Browser Chooser", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities")?.SetValue("ApplicationIcon", Application.ExecutablePath + ",0", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities")?.SetValue("ApplicationDescription", "Small app that let's you choose what browser to open a url in. Visit my website for more information. www.janolepeek.com", RegistryValueKind.String);

                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\FileAssociations")?.SetValue(".xhtml", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\FileAssociations")?.SetValue(".xht", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\FileAssociations")?.SetValue(".shtml", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\FileAssociations")?.SetValue(".html", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\FileAssociations")?.SetValue(".htm", "BrowserChooserHTML", RegistryValueKind.String);

                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\StartMenu")?.SetValue("StartMenuInternet", "Browser Chooser.exe", RegistryValueKind.String);

                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\URLAssociations")?.SetValue("https", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\URLAssociations")?.SetValue("http", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Browser Chooser\\Capabilities\\URLAssociations")?.SetValue("ftp", "BrowserChooserHTML", RegistryValueKind.String);

                    Registry.ClassesRoot.CreateSubKey("BrowserChooserHTML")?.SetValue("", "Browser Chooser HTML", RegistryValueKind.String);
                    Registry.ClassesRoot.CreateSubKey("BrowserChooserHTML")?.SetValue("URL Protocol", "", RegistryValueKind.String);

                    Registry.ClassesRoot.CreateSubKey("BrowserChooserHTML\\DefaultIcon")?.SetValue("", Application.ExecutablePath + ",0", RegistryValueKind.String);

                    Registry.ClassesRoot.CreateSubKey("BrowserChooserHTML\\shell\\open\\command")?.SetValue("", Application.ExecutablePath + " %1", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\Shell\\Associations\\UrlAssociations\\http\\UserChoice")?.SetValue("Progid", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\Shell\\Associations\\UrlAssociations\\https\\UserChoice")?.SetValue("Progid", "BrowserChooserHTML", RegistryValueKind.String);
                    Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\Shell\\Associations\\UrlAssociations\\ftp\\UserChoice")?.SetValue("Progid", "BrowserChooserHTML", RegistryValueKind.String);

                    try
                    {
                        if (OS_Version() == "Windows 10" || OS_Version() == "Windows 8")
                        {
                            // Win 8 and above no longer support setting the default apps - must show the dialog to the end user
                            var result = Process.Start("ms-settings:defaultapps");
                            MessageBox.Show("Please select Browser Chooser as the default Web Browser");
                            return "";
                        }
                        else
                        {
                            Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.htm\\UserChoice");
                            Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.html\\UserChoice");
                            Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.shtml\\UserChoice");
                            Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.xht\\UserChoice");
                            Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.xhtml\\UserChoice");

                            Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.htm\\UserChoice")?.SetValue("Progid", "BrowserChooserHTML", RegistryValueKind.String);
                            Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.html\\UserChoice")?.SetValue("Progid", "BrowserChooserHTML", RegistryValueKind.String);
                            Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.shtml\\UserChoice")?.SetValue("Progid", "BrowserChooserHTML", RegistryValueKind.String);
                            Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.xht\\UserChoice")?.SetValue("Progid", "BrowserChooserHTML", RegistryValueKind.String);
                            Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.xhtml\\UserChoice")?.SetValue("Progid", "BrowserChooserHTML", RegistryValueKind.String);
                        }
                    }
                    catch (Exception ex)
                    {
                        //Interaction.MsgBox("An error may have occured registering the file extensions. You may want to check in the 'Default Programs' option in your start menu to confirm this worked." + "\r\n" + "\r\n" + ex.Message, MsgBoxStyle.Exclamation, null);
                    }
                }
                catch (Exception ex)
                {
                    AppSettingsService.BrowserConfig.IamDefaultBrowser = false;
                    return "Problem writing or reading Registry: " + "\r\n" + "\r\n" + ex.Message;
                }
            }
            else
            {
                return "Unable to determine what version of Windows you are running, so we can't set Browser Chooser as the default. Sorry.";
            }

            AppSettingsService.BrowserConfig.IamDefaultBrowser = true;
            return "Default browser has been set to Browser Chooser.";
        }

        public static string OS_Version()
        {
            var sAns = "Unknown";

            var osInfo = Environment.OSVersion;

            if (osInfo.Platform == PlatformID.Win32Windows)
            {
                if (osInfo.Version.Minor == 0)
                {
                    sAns = "Windows 95";
                }
                else if (osInfo.Version.Minor == 10)
                {
                    if (osInfo.Version.Revision.ToString() == "2222A")
                    {
                        sAns = "Windows 98 Second Edition";
                    }
                    else
                    {
                        sAns = "Windows 98";
                    }
                }
                else if (osInfo.Version.Minor == 90)
                {
                    sAns = "Windows Me";
                }
            }
            else if (osInfo.Platform == PlatformID.Win32NT)
            {
                if (osInfo.Version.Major == 3)
                {
                    sAns = "Windows NT 3.51";
                }
                else if (osInfo.Version.Major == 4)
                {
                    sAns = "Windows NT 4.0";
                }
                else if (osInfo.Version.Major == 5)
                {
                    if (osInfo.Version.Minor == 0)
                    {
                        sAns = "Windows 2000";
                    }
                    else if (osInfo.Version.Minor == 1)
                    {
                        sAns = "Windows XP";
                    }
                    else if (osInfo.Version.Minor == 2)
                    {
                        sAns = "Windows Server 2003";
                    }
                    else //Future version maybe update
                    {
                        //as needed
                        sAns = "Unknown Windows Version";
                    }
                }
                else if (osInfo.Version.Major == 6)
                {
                    if (osInfo.Version.Minor == 0)
                    {
                        sAns = "Windows Vista";
                    }
                    else if (osInfo.Version.Minor == 1)
                    {
                        sAns = "Windows 7";
                    }
                    else if (osInfo.Version.Minor == 2)
                    {
                        var vs = Environment.OSVersion.Version;
                        var w10 = IsWindows10();
                        sAns = w10 ? "Windows 10" : "Windows 8";
                    }
                    else //Future version maybe update
                    {
                        //as needed
                        sAns = "Unknown Windows Version";
                    }
                }
            }
            else
            {
                sAns = "Unknown";
            }

            return sAns;
        }

        public static bool IsWindows10()
        {
            // Not a great way, but the only reliable way I was able to find
            var reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
            var productName = reg.GetValue("ProductName").ToString();
            return productName.StartsWith("Windows 10");
        }
    }
}
