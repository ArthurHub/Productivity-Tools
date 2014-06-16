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
    /// Holds link reference data.
    /// </summary>
    internal sealed class Link
    {
        /// <summary>
        /// The index of the reference
        /// </summary>
        private readonly int _index;

        /// <summary>
        /// The link source reference
        /// </summary>
        private readonly string _source;

        /// <summary>
        /// the link text title
        /// </summary>
        private readonly string _title;

        public Link(int index, string source, string title)
        {
            _index = index;
            _source = source;
            _title = title;
        }

        /// <summary>
        /// The index of the reference
        /// </summary>
        public int Index
        {
            get { return _index; }
        }

        /// <summary>
        /// The link source reference
        /// </summary>
        public string Source
        {
            get { return _source; }
        }

        /// <summary>
        /// the link text title
        /// </summary>
        public string Title
        {
            get { return _title; }
        }

        private bool Equals(Link other)
        {
            return string.Equals(_source, other._source);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is Link && Equals((Link)obj);
        }

        public override int GetHashCode()
        {
            return (_source != null ? _source.GetHashCode() : 0);
        }
    }
}
