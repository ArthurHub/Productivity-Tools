// "Therefore those skilled at the unorthodox
// are infinite as heaven and earth,
// inexhaustible as the great rivers.
// When they come to an end,
// they begin again,
// like the days and months;
// they die and are reborn,
// like the four seasons."
// 
// - Sun Tsu,
// "The Art of War"

using System.Windows.Forms;

namespace OnenoteMarkdownConverter
{
    internal class HtmlTextboxcs : TextBox
    {
        private const string StartFragment = "<!--StartFragment-->";
        private const string EndFragment = "<!--EndFragment-->";

        protected override void WndProc(ref Message m)
        {
            // Trap WM_PASTE:
            if( m.Msg == 0x302 && Clipboard.ContainsText() )
            {
                if( SetHtmlTextFromClipboard() )
                    return;
            }
            base.WndProc(ref m);
        }

        public bool SetHtmlTextFromClipboard()
        {
            var htmlData = Clipboard.GetData(DataFormats.Html);
            if( htmlData != null )
            {
                var htmlStr = htmlData.ToString();

                int start = htmlStr.IndexOf(StartFragment, System.StringComparison.Ordinal);
                if( start > -1 )
                {
                    int end = htmlStr.IndexOf(EndFragment, start);
                    if( end > -1 )
                    {
                        SelectedText = htmlStr.Substring(start + StartFragment.Length, end - start - StartFragment.Length).Trim();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}