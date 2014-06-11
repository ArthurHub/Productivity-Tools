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
using HtmlObfuscator;
using OnenoteMarkdownConverter;

namespace ProductivityTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnOneNoteButton_Click(object sender, RoutedEventArgs e)
        {
            OpenToolWindow(new ConverterControl());
        }

        private void OnHtmlObfuscatorButton_Click(object sender, RoutedEventArgs e)
        {
            OpenToolWindow(new HtmlObfuscatorControl());
        }

        private void OnRegExEditorButton_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Open tool window with the given tool control.
        /// </summary>
        private void OpenToolWindow(UserControl control)
        {
            var toolWindow = new ToolWindow();
            toolWindow.SetControl(control);
            toolWindow.Show();
            Close();
        }
    }
}
