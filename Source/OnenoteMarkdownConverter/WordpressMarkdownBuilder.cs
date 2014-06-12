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

namespace OnenoteMarkdownConverter
{
    /// <summary>
    /// Builder for creating markdown text.
    /// </summary>
    internal sealed class WordpressMarkdownBuilder : MarkdownBuilderBase
    {
        /// <summary>
        /// If to encode the text using HTML encoding.
        /// </summary>
        public override bool HtmlEncode
        {
            get { return true; }
        }

        /// <summary>
        /// Append text decoration tags for given style.
        /// </summary>
        public override MarkdownBuilderBase AppendDecoration(bool bold, bool italic, bool underline)
        {
            if (italic && bold)
                _builder.Append("***");
            else if (bold)
                _builder.Append("**");
            else if (italic)
                _builder.Append("*");
            return this;
        }
    }
}