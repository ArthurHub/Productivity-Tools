// "Therefore those skilled at the unorthodox
// are infinite as heaven and earth,
// inexhaustible as the great rivers.
// When they come to an end,
// they bagin again,
// like the days and months;
// they die and are reborn,
// like the four seasons."
// 
// - Sun Tsu,
// "The Art of War"

using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RegExEditor
{
    /// <summary>
    /// Interaction logic for RegExControl.xaml
    /// </summary>
    public partial class RegExControl
    {
        public RegExControl()
        {
            InitializeComponent();
        }
        private void OnRegexTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ProcessRegex();
            }
            catch
            {}
        }

        private void OnRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProcessRegex();
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex.ToString(), "Regex failed", MessageBoxButton.OK, MessageBoxImage.Error );
            }
        }

        private void OnReplaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_regexTB.Text) && !string.IsNullOrEmpty(_textTB.Text) )
            {
                try
                {
                    ProcessReplace();
                    ProcessRegex();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Regex replace failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if( e.Key == Key.Enter )
            {
                OnReplaceButton_Click( sender, e );
            }
        }

        private void ProcessRegex()
        {
            if (!string.IsNullOrEmpty(_regexTB.Text) && !string.IsNullOrEmpty(_textTB.Text))
            {
                var regex = FixRegexString( _regexTB.Text );
                var matchCollection = Regex.Matches( _textTB.Text, regex, RegexOptions.Multiline | RegexOptions.IgnoreCase );
                _matchesLV.ItemsSource = matchCollection;
            }
        }

        private void ProcessReplace()
        {
            if (!string.IsNullOrEmpty(_regexTB.Text) && !string.IsNullOrEmpty(_textTB.Text))
            {
                var text = _textTB.Text;
                var regex = FixRegexString( _regexTB.Text );
                var replace = FixRegexString( _replaceRegexTB.Text );
                text = Regex.Replace( text, regex, replace, RegexOptions.Multiline | RegexOptions.IgnoreCase );
                _textTB.Text = text;
            }
        }

        private static string FixRegexString( string regex )
        {
            regex = regex.Replace( "\\n", "\n" );
            regex = regex.Replace( "\\r", "\r" );
            regex = regex.Replace( "\\t", "\t" );
            return regex;
        }
    }
}
