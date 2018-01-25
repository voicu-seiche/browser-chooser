using System;
using System.Diagnostics;
using System.Windows.Forms;
using BrowserChooser.Forms.Code.OperatingSystem;
using BrowserChooser.Forms.Settings;
using Microsoft.Win32;

namespace BrowserChooser.Forms.Code
{
    public class RegistryService
    {
        public static string SetDefaultBrowserPath()
        {
            var osVersion = OperatingSystemService.GetVersion();
            if (osVersion == OSVersion.WindowsXP)
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
                    AppSettingsService.BrowserConfig.DefaultBrowser = false;
                    return "Problem writing or reading Registry: " + "\r\n" + "\r\n" + ex.Message;
                }

            }
            else if (osVersion == OSVersion.Windows7 || osVersion == OSVersion.WindowsVista || osVersion == OSVersion.Windows8 || osVersion == OSVersion.Windows10)
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
                        if (osVersion == OSVersion.Windows8 || osVersion == OSVersion.Windows10)
                        {
                            // Win 8 and above no longer support setting the default apps - must show the dialog to the end user
                            var result = Process.Start("ms-settings:defaultapps");
                            MessageBox.Show("Please select Browser Chooser as the default Web Browser");
                            return "";
                        }
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
                    catch (Exception)
                    {
                        //Interaction.MsgBox("An error may have occured registering the file extensions. You may want to check in the 'Default Programs' option in your start menu to confirm this worked." + "\r\n" + "\r\n" + ex.Message, MsgBoxStyle.Exclamation, null);
                    }
                }
                catch (Exception ex)
                {
                    AppSettingsService.BrowserConfig.DefaultBrowser = false;
                    return "Problem writing or reading Registry: " + "\r\n" + "\r\n" + ex.Message;
                }
            }
            else
            {
                return "Unable to determine what version of Windows you are running, so we can't set Browser Chooser as the default. Sorry.";
            }

            AppSettingsService.BrowserConfig.DefaultBrowser = true;
            return "Default browser has been set to Browser Chooser.";
        }
    }
}
