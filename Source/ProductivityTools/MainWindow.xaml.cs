
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
            var obfuscatorWindow = new HtmlObfuscatorWindow();
            obfuscatorWindow.Show();
            Close();
        }

        private void OnRegExEditorButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
