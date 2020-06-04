using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Sharpen
{
    public partial class AboutDialog : Window
    {
        private AboutDialogConfigurationSection configuration = ConfigurationManager.GetSection("aboutDialogConfigurationSection") as AboutDialogConfigurationSection;

        private AboutDialogLoader loader = new AboutDialogLoader();
        public AboutDialog()
        {
            InitializeComponent();
            DataContext = loader;
        }

        private void HyperlinkRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
        }

        private void BtnCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void WindowLoaded(object sender, RoutedEventArgs e)
        {            
            await Task.WhenAll(loader.LoadAsync(), SetChangelogDataAsync());
        }

        #region Changelog
        private readonly Regex versionExtruder = new Regex(@"^ \[(?<version>.*)] - (?<date>\d{4}-\d{2}-\d{2})$");
        private readonly Dictionary<ListViewItem, FlowDocument> changelog = new Dictionary<ListViewItem, FlowDocument>();

        private async Task SetChangelogDataAsync()
        {
            string changelogText;
            
            using (var reader = File.OpenText("CHANGELOG.md"))
                changelogText = await reader.ReadToEndAsync();

            var markdown = new MarkdownDocument();
            markdown.Parse(changelogText);

            foreach (var header in markdown.Blocks.OfType<HeaderBlock>().Where(h => h.HeaderLevel == 2))
            {
                var versionInfo = versionExtruder.Match(header.ToString());
                var version = new ListViewItem()
                {
                    Content = versionInfo.Groups["version"],
                    ToolTip = DateTime.Parse(versionInfo.Groups["date"].Value),
                    Padding = new Thickness(10, 1, 10, 1)
                };
                changelog.Add(version, CreateFlowDocument(markdown, markdown.Blocks.IndexOf(header) + 1)); // Stores reference to created document.
                lvVersions.Items.Add(version);
            }

            lvVersions.SelectedItem = lvVersions.Items[0];
        }
        private FlowDocument CreateFlowDocument(MarkdownDocument markdown, int headerIndex)
        {
            var document = new FlowDocument()
            {
                FontSize = 12,
                FontFamily = new System.Windows.Media.FontFamily("Segoe UI")
            };

            for (int i = headerIndex; i < markdown.Blocks.Count; i++)
            {
                var block = markdown.Blocks[i];
                var header = block as HeaderBlock;
                if (header?.HeaderLevel == 2)
                    break;

                document.Blocks.Add(MarkdownToFlowDocumentConverter.CreateBlock(block));

                if (header?.HeaderLevel == 3)
                    document.Blocks.Add(new BlockUIContainer(new Separator()));
            }

            return document;
        }
        private void LvVersionsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var version = (ListViewItem)lvVersions.SelectedItem;
            fdsvVersionChangelog.Document = changelog[version];
        }
        #endregion
    }
}
