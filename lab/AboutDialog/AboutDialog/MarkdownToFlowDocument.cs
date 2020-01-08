using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;
using Microsoft.Toolkit.Parsers.Markdown.Inlines;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace AboutDialog
{
    public static class MarkdownToFlowDocument
    {
        public static Block CreateBlock(MarkdownBlock block)
        {
            switch (block.Type)
            {
                case MarkdownBlockType.Header:
                    return CreateHeader(block as HeaderBlock);
                case MarkdownBlockType.Paragraph:
                    return CreateParagraph(block as ParagraphBlock);
                case MarkdownBlockType.List:
                    return CreateList(block as ListBlock);
                default:
                    return new Paragraph();
            }
        }

        private static Block CreateHeader(HeaderBlock headerBlock)
        {
            var paragraph = new Paragraph()
            {
                FontSize = Math.Max(19 - headerBlock.HeaderLevel, 12),
                Margin = new Thickness(0, 5, 0, 5)
            };
            paragraph.Inlines.AddRange(CreateInlines(headerBlock.Inlines));
            return paragraph;
        }

        private static Block CreateParagraph(ParagraphBlock paragraphBlock)
        {
            var paragraph = new Paragraph();
            paragraph.Inlines.AddRange(CreateInlines(paragraphBlock.Inlines));
            return paragraph;
        }

        private static List CreateList(ListBlock listBlock)
        {
            var list = new List()
            {
                Margin = new Thickness(0, 10, 0, 10)
            };
            foreach (var item in listBlock.Items)
            {
                var listItem = new ListItem();
                foreach (var block in item.Blocks)
                    listItem.Blocks.Add(CreateBlock(block));
                list.ListItems.Add(listItem);
            }
            return list;
        }

        private static IEnumerable<Inline> CreateInlines(IList<MarkdownInline> inlines)
        {
            foreach (var inline in inlines)
                switch (inline.Type)
                {
                    case MarkdownInlineType.TextRun:
                        yield return new Run((inline as TextRunInline).Text);
                        break;
                    case MarkdownInlineType.Bold:
                        foreach (var bold in CreateInlines((inline as BoldTextInline).Inlines))
                            yield return new Bold(bold);
                        break;
                    case MarkdownInlineType.Italic:
                        foreach (var italic in CreateInlines((inline as ItalicTextInline).Inlines))
                            yield return new Italic(italic);
                        break;
                    case MarkdownInlineType.MarkdownLink:
                        yield return CreateHyperlink(inline as MarkdownLinkInline);
                        break;
                    case MarkdownInlineType.Image:
                        yield return new InlineUIContainer(CreateImage(inline as ImageInline));
                        break;
                }
        }

        private static Image CreateImage(ImageInline imageInline)
        {
            // TODO: Add animated gif support.
            var bitmapImage = new BitmapImage();
            if (imageInline.RenderUrl.Contains(".svg"))
            {
                using (var bitmap = (new Svg.SvgImage().GetImage(imageInline.RenderUrl) as Svg.SvgDocument).Draw())
                using (var memory = new MemoryStream())
                {
                    bitmap.Save(memory, ImageFormat.Png);
                    memory.Position = 0;
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                }
            }
            else
            {
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(imageInline.RenderUrl, UriKind.Absolute);
                bitmapImage.EndInit();
            }

            return new Image()
            {
                Source = bitmapImage,
                Stretch = System.Windows.Media.Stretch.Uniform,
                StretchDirection = StretchDirection.DownOnly
            };
        }

        private static Hyperlink CreateHyperlink(MarkdownLinkInline markdownLinkInline)
        {
            var hyperlink = new Hyperlink() { NavigateUri = new Uri(markdownLinkInline.Url, UriKind.Absolute) };
            hyperlink.Inlines.AddRange(CreateInlines(markdownLinkInline.Inlines));
            hyperlink.RequestNavigate += NavigateFromHyperlink;
            return hyperlink;
        }

        private static void NavigateFromHyperlink(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
        }
    }
}
