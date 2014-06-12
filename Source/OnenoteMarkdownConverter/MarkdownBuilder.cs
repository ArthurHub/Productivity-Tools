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
    internal abstract class MarkdownBuilderBase
    {
        #region Fields and Consts

        /// <summary>
        /// The inner string builder used to create the markdown text
        /// </summary>
        protected readonly StringBuilder _builder = new StringBuilder();

        #endregion


        /// <summary>
        /// If to encode the text using HTML encoding.
        /// </summary>
        public abstract bool HtmlEncode { get; }

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
        public MarkdownBuilderBase Append(string value)
        {
            _builder.Append(value);
            return this;
        }

        /// <summary>
        /// Append newline to the markdown
        /// </summary>
        public MarkdownBuilderBase AppendLine()
        {
            _builder.AppendLine();
            return this;
        }

        /// <summary>
        /// Append newline to the markdown that will not be removed later.
        /// </summary>
        public MarkdownBuilderBase AppendStrongLine()
        {
            _builder.Append("&nbsp;").AppendLine();
            return this;
        }

        /// <summary>
        /// Append text decoration tags for given style.
        /// </summary>
        public virtual MarkdownBuilderBase AppendDecoration(bool bold, bool italic, bool underline)
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
        public virtual MarkdownBuilderBase AppendImage(int reference, string alt)
        {
            _builder.Append("![").Append(alt).Append("][").Append(reference.ToString(CultureInfo.InvariantCulture)).Append("]");
            return this;
        }

        /// <summary>
        /// Append link reference to the markdown that will not be removed later.
        /// </summary>
        public virtual MarkdownBuilderBase AppendLinkReference(Link link)
        {
            _builder.Append("[").Append(link.Index.ToString(CultureInfo.InvariantCulture)).Append("]: ").Append(link.Source);
            if (!string.IsNullOrWhiteSpace(link.Title))
                _builder.Append(" \"").Append(link.Title).Append("\"");
            _builder.AppendLine();
            return this;
        }
    }
}