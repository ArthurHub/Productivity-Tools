using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OnenoteMarkdownConverter
{
    /// <summary>
    /// Builder for creating markdown text.
    /// </summary>
    internal sealed class MarkdownBuilder
    {
        #region Fields and Consts

        /// <summary>
        /// The inner string builder used to create the markdown text
        /// </summary>
        private readonly StringBuilder _builder = new StringBuilder();

        /// <summary>
        /// Used to 
        /// </summary>
        private readonly List<Tuple<int, string, string>> _references = new List<Tuple<int, string, string>>();

        #endregion


        /// <summary>
        /// Is the conversion is currently on table
        /// </summary>
        public bool InTable { get; set; }

        /// <summary>
        /// Is the table header has been created from the first row of the table
        /// </summary>
        public bool TableHeaderDone { get; set; }

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
            _builder.AppendLine();
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

        public int AddReference(string value, string title)
        {
            var tuple = Tuple.Create(_references.Count + 1, value, CleanString(title));
            _references.Add(tuple);
            return tuple.Item1;
        }

        public Tuple<int, string, string>[] GetAllReferences()
        {
            return _references.ToArray();
        }

        public string CleanString(string str)
        {
            if (str != null)
            {
                str = str.Replace("Machine generated alternative", "");
                str = Regex.Replace(str, "&#\\d+;", "");
            }
            return str;
        }

        public string GetMarkdown()
        {
            return _builder.ToString().Trim();
        }
    }
}