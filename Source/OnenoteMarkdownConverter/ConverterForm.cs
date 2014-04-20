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
using System.Windows.Forms;
using OnenoteMarkdownConverter.Properties;

namespace OnenoteMarkdownConverter
{
    public partial class ConverterForm : Form
    {
        private readonly Timer _timer = new Timer();

        public ConverterForm()
        {
            InitializeComponent();

            Icon = Resources.icon;

            _timer = new Timer();
            _timer.Interval = 500;
            _timer.Tick += OnTimerTick;
        }


        #region Private methods

        private void OnConvertButton_Click(object sender, EventArgs e)
        {
            _markdownTextBox.Text = String.Empty;
            _htmlTextBox.Text = String.Empty;
            _htmlTextBox.SetHtmlTextFromClipboard();
            RunConvert();
            if( !string.IsNullOrWhiteSpace(_markdownTextBox.Text) )
                Clipboard.SetText(_markdownTextBox.Text);
            _timer.Stop();
        }

        private void OnCopyButton_Click(object sender, EventArgs e)
        {
            if( !string.IsNullOrWhiteSpace(_markdownTextBox.Text) )
                Clipboard.SetText(_markdownTextBox.Text);
        }

        private void OnHtmlTextBox_TextChanged(object sender, EventArgs e)
        {
            _timer.Stop();
            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs eventArgs)
        {
            _timer.Stop();

            RunConvert();
        }

        private void RunConvert()
        {
            var converter = new Converter();
            _markdownTextBox.Text = converter.ConvertHtmlToMarkdown(_htmlTextBox.Text);
        }

        private void OnTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( e.KeyChar == '\x1' )
            {
                ( (TextBox)sender ).SelectAll();
                e.Handled = true;
            }
        }

        #endregion
    }
}
