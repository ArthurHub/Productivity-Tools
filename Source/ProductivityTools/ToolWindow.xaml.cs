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

namespace ProductivityTools
{
    /// <summary>
    /// Interaction logic for ToolWindow.xaml
    /// </summary>
    public partial class ToolWindow
    {
        public ToolWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set the given control to be shown in the tool window.
        /// </summary>
        public void SetControl(string name, UserControl control)
        {
            Title += name;
            Grid.SetColumn(control, 1);
            _grid.Children.Add(control);
        }

        /// <summary>
        /// Close the tool windows and open main windows.
        /// </summary>
        private void OnBack_click(object sender, RoutedEventArgs e)
        {
            var mainWindows = new MainWindow();
            mainWindows.Show();
            Close();
        }
    }
}
