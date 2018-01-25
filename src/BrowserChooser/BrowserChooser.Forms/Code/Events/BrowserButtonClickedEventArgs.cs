using BrowserChooser.Forms.Models;

namespace BrowserChooser.Forms.Code.Events
{
    public class BrowserButtonClickedEventArgs
    {
        public Browser Browser { get; set; }
        public bool Close { get; set; }
    }
}
