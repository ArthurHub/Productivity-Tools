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
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace OnenoteMarkdownConverter
{
    internal sealed class Converter
    {
        private MarkdownBuilder _builder;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html">the html string to convert</param>
        /// <returns>the markdown</returns>
        public string ConvertHtmlToMarkdown(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            if (doc.DocumentNode != null)
            {
                _builder = new MarkdownBuilder();
                foreach (var childNode in doc.DocumentNode.ChildNodes)
                {
                    TraverseNode(childNode);
                }

                _builder.AppendStrongLine();
                foreach (var reference in _builder.GetAllReferences())
                {
                    _builder.Append("[").Append(reference.Item1.ToString()).Append("]: ").Append(reference.Item2);
                    if (!string.IsNullOrWhiteSpace(reference.Item3))
                        _builder.Append(" \"").Append(reference.Item3).Append("\"");
                    _builder.AppendLine();
                }

                var mardown = _builder.GetMarkdown();
                mardown = Regex.Replace(mardown, "^\\s+", "", RegexOptions.Multiline);
                mardown = Regex.Replace(mardown, "(&nbsp;\\s*&nbsp;){1,}", "&nbsp;^^^nl^^^");
                mardown = mardown.Replace("&nbsp;", "");
                mardown = mardown.Replace("^^^nl^^^", "&nbsp;" + Environment.NewLine);
                return mardown;
            }
            else
            {
                return string.Empty;
            }
        }

        private void TraverseNode(HtmlNode node)
        {
            switch (node.NodeType)
            {
                case HtmlNodeType.Element:
                    HandleElement(node, true);
                    foreach (var childNode in node.ChildNodes)
                    {
                        TraverseNode(childNode);
                    }
                    HandleElement(node, false);
                    break;
                case HtmlNodeType.Text:
                    var text = node.InnerText.Replace("\r", " ").Replace("\n", " ");
                    text = Regex.Replace(text, "\\s{2,}", " ");
                    _builder.Append(text);
                    break;
            }
        }

        private void HandleElement(HtmlNode node, bool before)
        {
            HandleParagraph(node, before);
            
            HandleLink(node, before);
            
            HandleImage(node, before);
            
            HandleSpan(node);

            HandleList(node, before);
                
            HandleTable(node, before);
        }

        private void HandleParagraph(HtmlNode node, bool before)
        {
            if( node.Name == "p" )
            {
                var header = GetHeader(node);
                if( header != null )
                {
                    if( before )
                    {
                        if( !_builder.InTable )
                            _builder.AppendLine();
                        _builder.Append(header).Append(" ");
                    }
                }
                else
                {
                    if( !_builder.InTable && !_builder.IsEndsNewLine() )
                        _builder.AppendLine();
                }
            }
        }

        private void HandleLink(HtmlNode node, bool before)
        {
            if( node.Name == "a" )
            {
                var href = node.GetAttributeValue("href", null);
                if( href != null )
                {
                    if( before )
                    {
                        _builder.Append("[");
                    }
                    else
                    {
                        int reference = _builder.AddReference(href, null);
                        _builder.Append("][").Append(reference.ToString()).Append("]");
                    }
                }
            }
        }

        private void HandleImage(HtmlNode node, bool before)
        {
            if( node.Name == "img" )
            {
                var src = node.GetAttributeValue("src", null);
                if( src != null )
                {
                    if( before )
                    {
                        var uri = new Uri(src);
                        var name = uri.Segments[uri.Segments.Length - 1];
                        var alt = _builder.CleanString(node.GetAttributeValue("alt", name)) ?? "image";
                        int reference = _builder.AddReference(src, alt);
                        _builder.Append("![").Append(alt).Append("][").Append(reference.ToString()).Append("]");
                    }
                }
            }
        }

        private void HandleSpan(HtmlNode node)
        {
            if( node.Name == "span" )
            {
                bool bold = CheckStylesContains(node, "font-weigh", "bold");
                bool italic = CheckStylesContains(node, "font-style", "italic");
                if( italic && bold )
                    _builder.Append("***");
                else if( bold )
                    _builder.Append("**");
                else if( italic )
                    _builder.Append("*");
            }
        }

        private void HandleList(HtmlNode node, bool before)
        {
            if( before && ( node.Name == "ul" || node.Name == "ol" ) )
            {
                _builder.AppendStrongLine();
            }

            if( node.Name == "li" )
            {
                int number = 0;
                if( node.ParentNode != null && node.ParentNode.Name == "ol" )
                {
                    foreach(var childNode in node.ParentNode.ChildNodes)
                    {
                        if( childNode.Name == "li" )
                        {
                            number = childNode.GetAttributeValue("value", 1);
                            break;
                        }
                    }

                    for(int i = 0; i < node.ParentNode.ChildNodes.Count && node.ParentNode.ChildNodes[i] != node; i++)
                        if( node.ParentNode.ChildNodes[i].Name == "li" )
                            number++;
                }

                if( before )
                {
                    _builder.AppendLine().Append(number > 0 ? number + "." : "*").Append(" ");
                }
            }
        }

        private void HandleTable(HtmlNode node, bool before)
        {
            if( node.Name == "table" )
            {
                _builder.InTable = before;
                _builder.TableHeaderDone = false;
            }
            else if( node.Name == "td" )
            {
                if( before )
                {
                    _builder.Append("| ");
                }
                else
                {
                    _builder.Append(" ");
                }
            }
            else if( node.Name == "tr" )
            {
                if( !before )
                {
                    _builder.Append("|").AppendLine();
                    if( !_builder.TableHeaderDone )
                    {
                        _builder.TableHeaderDone = true;
                        _builder.Append("| ");
                        foreach(var childNode in node.ChildNodes)
                        {
                            if( childNode.Name == "td" )
                            {
                                var align = GetAlign(childNode);
                                if( align == 0 )
                                    _builder.Append(":");
                                _builder.Append("---");
                                if( align >= 0 )
                                    _builder.Append(":");
                                _builder.Append(" | ");
                            }
                        }
                        _builder.AppendLine();
                    }
                }
            }
        }

        private static int GetAlign(HtmlNode node)
        {
            if (CheckStylesContains(node, "text-align", "center"))
            {
                return 0;
            }
            else if (CheckStylesContains(node, "text-align", "right"))
            {
                return 1;
            }
            else
            {
                foreach (var childNode in node.ChildNodes)
                {
                    if (CheckStylesContains(childNode, "text-align", "center"))
                    {
                        return 0;
                    }
                    else if (CheckStylesContains(childNode, "text-align", "right"))
                    {
                        return 1;
                    }
                }
            }
            return -1;
        }

        private static string GetHeader(HtmlNode node)
        {
            var style = node.GetAttributeValue("style", null);
            if (style != null)
            {
                int size = 0;
                var styleValues = style.Split(';');
                foreach (var styleValue in styleValues)
                {
                    if (styleValue.Contains("size"))
                    {
                        var str = Regex.Match(styleValue, @"\d+").Value;
                        size = int.Parse(str);
                    }
                }

                if (size == 16)
                    return "#";
                else if (size == 14)
                    return "##";
                else if (size == 12)
                    return "###";
            }
            return null;
        }

        private static string[] GetStyles(HtmlNode node)
        {
            var style = node.GetAttributeValue("style", null);
            return style != null ? style.Split(';') : new string[0];
        }

        private static string GetStyle(HtmlNode node, string style)
        {
            foreach (var styleValue in GetStyles(node))
            {
                if (styleValue.Contains(style))
                    return styleValue;
            }
            return null;
        }

        private static bool CheckStylesContains(HtmlNode node, string style, string data)
        {
            var styleValue = GetStyle(node, style);
            return styleValue != null && styleValue.Contains(data);
        }
    }
}
