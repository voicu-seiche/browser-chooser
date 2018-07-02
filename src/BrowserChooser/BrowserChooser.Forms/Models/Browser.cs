﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BrowserChooser.Forms.Models
{
    public class Browser : IComparable<Browser>
    {
        public int BrowserNumber { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
        public string Image { get; set; }
        public string CustomImagePath { get; set; }
        public List<string> Urls { get; set; } = new List<string>();
        public string IncognitoFlag { get; set; }
        public Icon Icon { get; set; }

        public string UrlsToString()
        {
            if (ReferenceEquals(Urls, null) || Urls.Count == 0)
            {
                return string.Empty;
            }
            return string.Join(",", Urls.ToArray());
        }

        public static List<string> StringToUrls(string urlList)
        {
            if (string.IsNullOrEmpty(urlList))
            {
                return new List<string>();
            }
            return urlList.Split(",".ToCharArray()).ToList();
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Browser other)
        {
            return BrowserNumber.CompareTo(other.BrowserNumber);
        }
    }
}
