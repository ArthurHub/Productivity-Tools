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
using HtmlObfuscator;

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

        }

        private void OnHtmlObfuscatorButton_Click(object sender, RoutedEventArgs e)
        {
            var toolWindow = new ToolWindow();
            toolWindow.SetControl(new HtmlObfuscatorControl());
            toolWindow.Show();
            Close();
        }

        private void OnRegExEditorButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
