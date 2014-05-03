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
using System.Text;
using HtmlAgilityPack;

namespace HtmlObfuscator
{
    /// <summary>
    /// Obfuscates HTML:<br/>
    /// - change all text in the html to random sequence of characters.<br/>
    /// - sequence of numbers replaced by random sequence of numbers.<br/>
    /// </summary>
    internal static class Obfuscator
    {
        /// <summary>
        /// Random number generator
        /// </summary>
        private static readonly Random _rand = new Random();

        /// <summary>
        /// Obfuscate the given HTML.
        /// </summary>
        /// <param name="html">the html to obfuscate</param>
        /// <returns>obfuscated html</returns>
        public static string Obfuscate(string html)
        {
            if (!string.IsNullOrWhiteSpace(html))
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                if (doc.DocumentNode != null)
                {
                    ObfuscateNode(doc.DocumentNode);

                    return doc.DocumentNode.OuterHtml;
                }
            }
            return html;
        }

        /// <summary>
        /// Obfuscate html node:<br/>
        /// - replace text in text and comment nodes.<br/>
        /// - recursively traverse elements.<br/>
        /// </summary>
        /// <param name="node"></param>
        private static void ObfuscateNode(HtmlNode node)
        {
            switch (node.NodeType)
            {
                case HtmlNodeType.Document:
                case HtmlNodeType.Element:
                    foreach (var childNode in node.ChildNodes)
                        ObfuscateNode(childNode);
                    break;
                case HtmlNodeType.Comment:
                case HtmlNodeType.Text:
                    node.InnerHtml = ObfuscateText(node.InnerHtml);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unexpected html node type: " + node.NodeType);
            }
        }

        /// <summary>
        /// Obfuscate text string:<br/>
        /// Replace letters with random letters and numbers with random numbers.<br/>
        /// Ignore HTML encoded text (&lt;).
        /// </summary>
        /// <param name="text">the text to obfuscate</param>
        /// <returns>obfuscated text</returns>
        private static string ObfuscateText(string text)
        {
            var sb = new StringBuilder(text);

            bool ignore = false;
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                if (c == '&')
                {
                    ignore = true;
                }
                else if (c == ';')
                {
                    ignore = false;
                }
                else if (!ignore)
                {
                    if (Char.IsLetter(c))
                    {
                        sb[i] = (char)_rand.Next('a', 'z' + 1);
                    }
                    else if (char.IsDigit(c))
                    {
                        sb[i] = (char)_rand.Next('0', '9' + 1);
                    }
                }
            }

            return sb.ToString();
        }
    }
}