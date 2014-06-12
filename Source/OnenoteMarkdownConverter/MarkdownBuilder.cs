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
using System.Globalization;
using System.Text;

namespace OnenoteMarkdownConverter
{
    /// <summary>
    /// Builder for creating markdown text.
    /// </summary>
    internal class MarkdownBuilder
    {
        #region Fields and Consts

        /// <summary>
        /// The inner string builder used to create the markdown text
        /// </summary>
        private readonly StringBuilder _builder = new StringBuilder();

        /// <summary>
        /// If to encode the text using HTML encoding.
        /// </summary>
        private readonly bool _htmlEncode;

        #endregion


        public MarkdownBuilder(bool htmlEncode)
        {
            _htmlEncode = htmlEncode;
        }

        /// <summary>
        /// If to encode the text using HTML encoding.
        /// </summary>
        public bool HtmlEncode
        {
            get { return _htmlEncode; }
        }

        public string GetMarkdown()
        {
            return _builder.ToString().Trim();
        }

        /// <summary>
        /// Check if the current build markdown ends with newline, ignore whitespaces.
        /// </summary>
        public bool IsEndsNewLine()
        {
            int i = _builder.Length - 1;
            while (i > 0)
            {
                if (!Char.IsWhiteSpace(_builder[i]))
                {
                    return _builder[i] == '\n';
                }
                i--;
            }
            return false;
        }

        /// <summary>
        /// Remove all whitespaces from the end of the builder.
        /// </summary>
        public void TrimEndWhitespaces()
        {
            int i = _builder.Length;
            while (i > 1 && Char.IsWhiteSpace(_builder[i - 1]))
                i--;

            if (i < _builder.Length)
                _builder.Remove(i, _builder.Length - i);
        }

        /// <summary>
        /// Append the given string to the markdown
        /// </summary>
        public MarkdownBuilder Append(string value)
        {
            _builder.Append(value);
            return this;
        }

        /// <summary>
        /// Append newline to the markdown
        /// </summary>
        public MarkdownBuilder AppendLine()
        {
            _builder.Append("  ").AppendLine();
            return this;
        }

        /// <summary>
        /// Append newline to the markdown that will not be removed later.
        /// </summary>
        public MarkdownBuilder AppendStrongLine()
        {
            _builder.Append("&nbsp;").AppendLine();
            return this;
        }

        /// <summary>
        /// Append text decoration tags for given style.
        /// </summary>
        public virtual MarkdownBuilder AppendHeader(int size)
        {
            AppendStrongLine();
            if (size == 1)
                _builder.Append("#");
            else if (size == 2)
                _builder.Append("##");
            else if (size == 3)
                _builder.Append("###");
            else if (size == 4)
                _builder.Append("####");
            else if (size == 5)
                _builder.Append("#####");
            _builder.Append(" ");
            return this;
        }

        /// <summary>
        /// Append text decoration tags for given style.
        /// </summary>
        public virtual MarkdownBuilder AppendDecoration(bool bold, bool italic, bool underline)
        {
            if (italic && bold)
                _builder.Append("***");
            else if (bold)
                _builder.Append("**");
            else if (italic)
                _builder.Append("*");
            return this;
        }

        /// <summary>
        /// Append link reference to the markdown that will not be removed later.
        /// </summary>
        public virtual MarkdownBuilder AppendImage(int reference, string alt)
        {
            _builder.Append("![").Append(alt).Append("][").Append(reference.ToString(CultureInfo.InvariantCulture)).Append("]");
            return this;
        }

        /// <summary>
        /// Append link reference to the markdown that will not be removed later.
        /// </summary>
        public virtual MarkdownBuilder AppendLinkReference(Link link)
        {
            _builder.Append("[").Append(link.Index.ToString(CultureInfo.InvariantCulture)).Append("]: ").Append(link.Source);
            if (!string.IsNullOrWhiteSpace(link.Title))
                _builder.Append(" \"").Append(link.Title).Append("\"");
            _builder.AppendLine();
            return this;
        }
    }
}