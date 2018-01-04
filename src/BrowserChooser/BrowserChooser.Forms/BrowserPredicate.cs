using BrowserChooser.Forms.Models;

namespace BrowserChooser.Forms
{
    public partial class OptionsForm
    {
        public class BrowserPredicate
        {
            private readonly string path;

            public BrowserPredicate(string path)
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
}