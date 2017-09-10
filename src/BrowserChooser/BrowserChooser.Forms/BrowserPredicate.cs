namespace BrowserChooser.Forms
{
    public partial class OptionsForm
    {
        public class BrowserPredicate
        {
            private string _path;
            private string _name;

            public BrowserPredicate(string path)
            {
                _path = path;
            }

            public bool ComparePaths(Browser obj)
            {
                return _path == obj.Target;
            }

            public bool CompareNames(Browser obj)
            {
                return _path == obj.Name;
            }
        }
    }
}