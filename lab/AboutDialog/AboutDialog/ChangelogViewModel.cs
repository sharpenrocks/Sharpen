using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Sharpen
{
    internal class ChangelogViewModel : BindableBase
    {
        internal class ChangelogVersion
        {
            public string Version { get; private set; }
            public DateTime Date { get; private set; }
            public FlowDocument Document { get; private set; }

            internal ChangelogVersion(string version, DateTime date, FlowDocument document)
            {
                Version = version;
                Date = date;
                Document = document;
            }
        }

        private readonly Regex versionExtruder = new Regex(@"^ \[(?<version>.*)] - (?<date>\d{4}-\d{2}-\d{2})$");
        private ChangelogVersion? selectedVersion;

        public ObservableCollection<ChangelogVersion> Versions { get; } = new ObservableCollection<ChangelogVersion>();
        public ChangelogVersion? SelectedVersion { get => selectedVersion; set => SetProperty(ref selectedVersion, value); }

        internal async Task SetChangelogAsync()
        {
            string? changelogText;

            using (var reader = File.OpenText("CHANGELOG.md"))
                changelogText = await reader.ReadToEndAsync();

            var markdown = new MarkdownDocument();
            markdown.Parse(changelogText);

            foreach (var header in markdown.Blocks.OfType<HeaderBlock>().Where(h => h.HeaderLevel == 2))
            {
                var versionInfo = versionExtruder.Match(header.ToString());
                var version = new ChangelogVersion(versionInfo.Groups["version"].Value, DateTime.Parse(versionInfo.Groups["date"].Value), CreateFlowDocument(markdown, markdown.Blocks.IndexOf(header) + 1));
                Versions.Add(version); // Stores reference to created document.
            }
            if (Versions.Any())
                SelectedVersion = Versions.First();
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
    }
}
