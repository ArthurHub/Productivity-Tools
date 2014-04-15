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
    /// <summary>
    /// Extend textbox to extract pasted HTML snipped from the clipboard.<br/>
    /// Standard textbox uses plain text.
    /// </summary>
    internal class HtmlTextBox : TextBox
    {
        private const string StartFragment = "<!--StartFragment-->";
        private const string EndFragment = "<!--EndFragment-->";

        /// <summary>
        /// Set HTML from clipboard if exists.
        /// </summary>
        /// <returns>true - html was set from clipboard, false - otherwise</returns>
        public bool SetHtmlTextFromClipboard()
        {
            var htmlData = Clipboard.GetData(DataFormats.Html);
            if (htmlData != null)
            {
                var htmlStr = htmlData.ToString();

                int start = htmlStr.IndexOf(StartFragment, System.StringComparison.Ordinal);
                if (start > -1)
                {
                    int end = htmlStr.IndexOf(EndFragment, start);
                    if (end > -1)
                    {
                        SelectedText = htmlStr.Substring(start + StartFragment.Length, end - start - StartFragment.Length).Trim();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Override control proc handling to change the handling of PASTE event.
        /// </summary>
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

        
    }
}