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

using System;
using System.Windows;
using System.Windows.Controls;

namespace OnenoteMarkdownConverter
{
    /// <summary>
    /// Interaction logic for ConverterControl.xaml
    /// </summary>
    public partial class ConverterControl
    {
        private const string StartFragment = "<!--StartFragment-->";
        private const string EndFragment = "<!--EndFragment-->";

        public ConverterControl()
        {
            InitializeComponent();

            DataObject.AddPastingHandler(_sourceHtmlTB, OnPaste);
        }

        private void OnPasteSourceHtml_click(object sender, RoutedEventArgs e)
        {
            _markdownTB.Text = String.Empty;
            SetHtmlTextFromClipboard();
        }

        private void OnHtmlEncodeChecked(object sender, RoutedEventArgs e)
        {
            if (_markdownTB != null)
            {
                RunConvert();
                SetMarkdownToClipboard();
            }
        }

        private void OnCopyMarkdown_click(object sender, RoutedEventArgs e)
        {
            SetMarkdownToClipboard();
            _copyMarkDownButton.Content = "Copied to Clipboard!";
        }

        private void OnSourceHtml_TextChanged(object sender, TextChangedEventArgs e)
        {
            RunConvert();
            SetMarkdownToClipboard();
        }

        /// <summary>
        /// Run convert from HTML to markdown and set the result to clipboard.
        /// </summary>
        private void RunConvert()
        {
            var converter = new Converter();

            _copyMarkDownButton.Content = "Copy Markdown";
            var markdownBuilder = new MarkdownBuilder(_htmlEncode.IsChecked, _persistEmptyLines.IsChecked);
            _markdownTB.Text = converter.ConvertHtmlToMarkdown(_sourceHtmlTB.Text, markdownBuilder);
        }

        /// <summary>
        /// Set the obfuscated HTML in text box to clipboard.
        /// </summary>
        private void SetMarkdownToClipboard()
        {
            var data = new DataObject();
            string text = _markdownTB.Text;
            data.SetText(text, TextDataFormat.Text);
            data.SetText(text, TextDataFormat.UnicodeText);
            Clipboard.SetDataObject(data);
        }

        /// <summary>
        /// On paste to source html text box do html text paste.
        /// </summary>
        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (SetHtmlTextFromClipboard())
            {
                SetMarkdownToClipboard();
                e.Handled = true;
                e.CancelCommand();
            }
        }

        /// <summary>
        /// Set HTML from clipboard if exists.
        /// </summary>
        /// <returns>true - html was set from clipboard, false - otherwise</returns>
        private bool SetHtmlTextFromClipboard()
        {
            var htmlData = Clipboard.GetData(DataFormats.Html);
            if (htmlData != null)
            {
                var htmlStr = htmlData.ToString();

                int start = htmlStr.IndexOf(StartFragment, StringComparison.Ordinal);
                if (start > -1)
                {
                    int end = htmlStr.IndexOf(EndFragment, start, StringComparison.Ordinal);
                    if (end > -1)
                    {
                        _sourceHtmlTB.SelectedText = htmlStr.Substring(start + StartFragment.Length, end - start - StartFragment.Length).Trim();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
