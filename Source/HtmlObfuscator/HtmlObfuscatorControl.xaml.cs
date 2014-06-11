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

using System.Windows;
using System.Windows.Controls;

namespace HtmlObfuscator
{
    /// <summary>
    /// Interaction logic for HtmlObfuscatorWindow.xaml
    /// </summary>
    public partial class HtmlObfuscatorControl
    {
        public HtmlObfuscatorControl()
        {
            InitializeComponent();
        }

        private void OnSourceHtml_TextChanged(object sender, TextChangedEventArgs e)
        {
            _obfuscatedHtmlTB.Text = Obfuscator.Obfuscate(_sourceHtmlTB.Text);
            SetObfuscatedHtmlToClipboard();
        }

        /// <summary>
        /// Set source HTML text from clipboard.
        /// </summary>
        private void OnPasteSourceHtml_click(object sender, RoutedEventArgs e)
        {
            var text = Clipboard.GetText(TextDataFormat.UnicodeText);
            if (string.IsNullOrEmpty(text))
                text = Clipboard.GetText(TextDataFormat.Text);

            _sourceHtmlTB.Text = text;
        }

        /// <summary>
        /// Set obfuscated HTML to cliboard.
        /// </summary>
        private void OnCopyOvfuscatedHtml_click(object sender, RoutedEventArgs e)
        {
            SetObfuscatedHtmlToClipboard();
        }

        /// <summary>
        /// Set the obfuscated HTML in text box to clipboard.
        /// </summary>
        private void SetObfuscatedHtmlToClipboard()
        {
            var data = new DataObject();
            string text = _obfuscatedHtmlTB.Text;
            data.SetText(text, TextDataFormat.Text);
            data.SetText(text, TextDataFormat.UnicodeText);
            Clipboard.SetDataObject(data);
        }
    }
}