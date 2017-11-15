﻿using System;
using System.IO;
using BrowserChooser.Forms.Models;

namespace BrowserChooser.Forms.Code.InstalledBrowsers
{
    public class SafariInstalledBrowserBuilder : IInstalledBrowserBuilder
    {
        private const string BrowserName = "Safari";
        private const string BrowserFolderPath = "Safari\\Safari.exe";

        public InstalledBrowserResult GetInstalledBrowser()
        {
            var result = new InstalledBrowserResult();

            var installedBrowserPath = CheckInstalledBrowser(Environment.SpecialFolder.ProgramFiles) ?? CheckInstalledBrowser(Environment.SpecialFolder.ProgramFilesX86);
            if (string.IsNullOrEmpty(installedBrowserPath))
            {
                return result;
            }

            result.IsSuccessful = true;
            result.Browsers.Add(new Browser
            {
                Name = BrowserName,
                Target = installedBrowserPath
            });

            return result;
        }

        private static string CheckInstalledBrowser(Environment.SpecialFolder programFilesSpecialFolder)
        {
            var programFilesPath = Environment.GetFolderPath(programFilesSpecialFolder);
            var browserPath = Path.Combine(programFilesPath, BrowserFolderPath);

            return File.Exists(browserPath) ? browserPath : null;
        }
    }
}