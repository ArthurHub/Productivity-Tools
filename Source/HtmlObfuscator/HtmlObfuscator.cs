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

namespace HtmlObfuscator
{
    public partial class HtmlObfuscator : Form
    {
        public HtmlObfuscator()
        {
            InitializeComponent();
        }

        private void OnPasteHtmlButton_Click(object sender, EventArgs e)
        {
            _sourceHtmlTB.Text = Clipboard.GetText();
        }

        private void OnCopyHtmlButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_obfuscatedHtmlTB.Text))
                Clipboard.SetText(_obfuscatedHtmlTB.Text);
        }

        private void OnSourceHtml_TextChanged(object sender, EventArgs e)
        {
            _obfuscatedHtmlTB.Text = Obfuscator.Obfuscate(_sourceHtmlTB.Text);
        }
    }
}
