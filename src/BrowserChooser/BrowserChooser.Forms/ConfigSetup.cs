using System;
using System.IO;
using System.Windows.Forms;

namespace BrowserChooser.Forms
{
    public class ConfigSetup
    {
        private string GetRowValue(string sLine)
        {
            string returnValue = "";
            int i = sLine.IndexOf("=");
            if (i != -1)
            {
                returnValue = sLine.Substring(0, i);
            }
            else
            {
                returnValue = "";
            }
            return returnValue;
        }

        //import config.ini file into new object/xml based format
        public BrowserList ReadConfig()
        {
            BrowserList importedConfig = new BrowserList();
            try
            {
                Browser browser1 = new Browser { BrowserNumber = 1, IsActive = true };
                Browser browser2 = new Browser { BrowserNumber = 2, IsActive = true };
                Browser browser3 = new Browser { BrowserNumber = 3, IsActive = true };
                Browser browser4 = new Browser { BrowserNumber = 4, IsActive = true };
                Browser browser5 = new Browser { BrowserNumber = 5, IsActive = true };

                using (StreamReader sr = new StreamReader(Program.ConfigFile.ToString()))
                {
                    string sLine = sr.ReadLine();

                    while (!ReferenceEquals(sLine, null))
                    {
                        switch (GetRowValue(sLine))
                        {
                            case "DefaultBrowser":
                                importedConfig.IamDefaultBrowser = sLine.Substring(15, sLine.Length - 15) == "IamDefaultBrowser";
                                break;
                            case "ShowURL":
                                importedConfig.ShowUrl = sLine.Substring(8, sLine.Length - 8) == "ShowUrl";
                                break;
                            case "AutoUpdateCheck":
                                importedConfig.AutoUpdateCheck = sLine.Substring(16, sLine.Length - 16) == "AutoUpdateCheck";
                                break;
                            case "Browser1Name":
                                browser1.Name = sLine.Substring(13, sLine.Length - 13);
                                break;
                            case "Browser2Name":
                                browser2.Name = sLine.Substring(13, sLine.Length - 13);
                                break;
                            case "Browser3Name":
                                browser3.Name = sLine.Substring(13, sLine.Length - 13);
                                break;
                            case "Browser4Name":
                                browser4.Name = sLine.Substring(13, sLine.Length - 13);
                                break;
                            case "Browser5Name":
                                browser5.Name = sLine.Substring(13, sLine.Length - 13);
                                break;

                            case "Browser1Target":
                                browser1.Target = sLine.Substring(15, sLine.Length - 15);
                                break;
                            case "Browser2Target":
                                browser2.Target = sLine.Substring(15, sLine.Length - 15);
                                break;
                            case "Browser3Target":
                                browser3.Target = sLine.Substring(15, sLine.Length - 15);
                                break;
                            case "Browser4Target":
                                browser4.Target = sLine.Substring(15, sLine.Length - 15);
                                break;
                            case "Browser5Target":
                                browser5.Target = sLine.Substring(15, sLine.Length - 15);
                                break;

                            case "Browser1Image":
                                browser1.Image = sLine.Substring(14, sLine.Length - 14);
                                break;
                            case "Browser2Image":
                                browser2.Image = sLine.Substring(14, sLine.Length - 14);
                                break;
                            case "Browser3Image":
                                browser3.Image = sLine.Substring(14, sLine.Length - 14);
                                break;
                            case "Browser4Image":
                                browser4.Image = sLine.Substring(14, sLine.Length - 14);
                                break;
                            case "Browser5Image":
                                browser5.Image = sLine.Substring(14, sLine.Length - 14);
                                break;

                        }
                        sLine = sr.ReadLine();
                    }
                    sr.Close();
                }

                if (!string.IsNullOrEmpty(Convert.ToString(browser1.Name)))
                {
                    importedConfig.Browsers.Add(browser1);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(browser2.Name)))
                {
                    importedConfig.Browsers.Add(browser2);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(browser3.Name)))
                {
                    importedConfig.Browsers.Add(browser3);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(browser4.Name)))
                {
                    importedConfig.Browsers.Add(browser4);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(browser5.Name)))
                {
                    importedConfig.Browsers.Add(browser5);
                }

                importedConfig.Save(Application.StartupPath);

                //Remove existing config.ini
                if (Program.ConfigFile.Exists)
                {
                    Program.ConfigFile.Delete();
                }
            }
            catch (Exception)
            {

            }
            return importedConfig;
        }
    }
}
