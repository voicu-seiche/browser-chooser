using BrowserChooser.Forms.Models;

namespace BrowserChooser.Forms.Code
{
    public class BrowserInfoPredicate
    {
        private readonly string path;

        public BrowserInfoPredicate(string path)
        {
            this.path = path;
        }

        public bool ComparePaths(Browser obj)
        {
            return path == obj.Target;
        }

        public bool CompareNames(Browser obj)
        {
            return path == obj.Name;
        }
    }

}