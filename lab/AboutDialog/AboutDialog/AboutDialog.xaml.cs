using GraphQL.Client;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Sharpen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AboutDialog : Window
    {
        public AboutDialog()
        {
            InitializeComponent();
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
            await SetAssemblyDataAsync();
            await SetGitHubDataAsync();
            await SetVSMarketplaceDataAsync();
            await SetChangelogDataAsync();
        }

        #region Assembly data
        private async Task SetAssemblyDataAsync()
        {
            Assembly assembly = null;
            await Task.Run(() => assembly = Assembly.GetEntryAssembly());

            // Set Title.
            var name = assembly.GetName();
            lblTitle.Content = $"{name.Name} v{name.Version}";

            // Set Description.
            var descriptionAttribute = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false).OfType<AssemblyDescriptionAttribute>().FirstOrDefault();
            if (descriptionAttribute != null)
                lblDescription.Content = new TextBlock() { Text = descriptionAttribute.Description, TextWrapping = TextWrapping.Wrap };

            // Set Copyright.
            lblCopyright.Content = $"Copyright © Igor Rončević 2017 - {DateTime.Now.Year}";
        }
        #endregion

        #region GitHub data
        private async Task SetGitHubDataAsync()
        {
            GraphQLResponse response;
            try
            {
                response = await GetGitHubDataAsync();
            }
            catch
            {
                // Ignore all errors retrieving GitHub data.
                return;
            }
            var repository = response.Data.repositoryOwner.repository;
            txtGitHub.Inlines.Add($" ({repository.stargazers.totalCount } stars)");
        }
        private async Task<GraphQLResponse> GetGitHubDataAsync()
        {
            using (var client = new GraphQLClient("https://api.github.com/graphql"))
            {
                client.DefaultRequestHeaders.Add("Authorization", $"bearer {ConfigurationManager.AppSettings["GitHubAuthToken"]}");
                client.DefaultRequestHeaders.Add("User-Agent", "SharpenAboutBox");
                var request = new GraphQLRequest()
                {
                    Query = $@"query {{
                    repositoryOwner (login: ""{ConfigurationManager.AppSettings["GitHubLogin"]}"") {{
                        repository(name: ""{ConfigurationManager.AppSettings["GitHubRepository"]}"") {{
                            stargazers {{
                                totalCount
                            }}
                        }}
                    }}
                }}"
                };
                return await client.PostAsync(request);
            }
        }
        #endregion

        #region VSMarketplace data
        private async Task SetVSMarketplaceDataAsync()
        {
            IRestResponse response;
            try
            {
                response = await GetVSMarketplaceDataAsync();
            }
            catch
            {
                // Ignore all errors retrieving VSMarketplace data.
                return;
            }
            var json = Newtonsoft.Json.Linq.JObject.Parse(response.Content);

            // Fugly. This *is* a full sentence comment.
            var statistics = json["results"][0]["extensions"][0]["statistics"];
            var numberOfInstalls = (int)statistics[0]["value"];
            double rating = (double)statistics[1]["value"];
            var numberOfReviews = (int)statistics[2]["value"];

            double roundedRating = Math.Round(rating * 2, MidpointRounding.AwayFromZero) / 2;
            var span = new Span()
            {
                ToolTip = $"{rating:0.0}/5"
            };

            for (int i = 1; i <= 5; i++)
            {
                if ((int)roundedRating >= i)
                    span.Inlines.Add(new Image() { Source = ((Image)FindResource("FullStar")).Source });
                else if ((int)roundedRating + 1 == i && (roundedRating % 1) == 0.5)
                    span.Inlines.Add(new Image() { Source = ((Image)FindResource("HalfStar")).Source });
                else
                    span.Inlines.Add(new Image() { Source = ((Image)FindResource("NoStar")).Source });
            }
            txtVSMarketplace.Inlines.Add($" ({numberOfInstalls} installs) ");
            txtVSMarketplace.Inlines.Add(span);
            txtVSMarketplace.Inlines.Add($" ({numberOfReviews})");
        }
        private async Task<IRestResponse> GetVSMarketplaceDataAsync()
        {
            var client = new RestClient("https://marketplace.visualstudio.com/");

            var request = new RestRequest("_apis/public/gallery/extensionquery", Method.POST, RestSharp.DataFormat.Json);
            request.AddHeader("Accept", "application/json; api-version=3.2-preview.1");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            // Fiddler4 + Manage Extensions was source for this request.
            request.AddJsonBody($@"{{
                ""flags"":""256"",
                ""filters"":[{{
                    ""criteria"":[{{
                        ""filterType"":""10"",
                        ""value"":""{ConfigurationManager.AppSettings["VSMarketplaceID"]}""
                    }}]
                }}]
            }}");

            return await client.ExecuteTaskAsync(request);
        }
        #endregion

        #region Changelog
        private readonly Regex versionExtruder = new Regex(@"^ \[(?<version>.*)] - (?<date>\d{4}-\d{2}-\d{2})$");
        private readonly Dictionary<ListViewItem, FlowDocument> changelog = new Dictionary<ListViewItem, FlowDocument>();

        private async Task SetChangelogDataAsync()
        {
            var markdown = new MarkdownDocument();

            await Task.Run(() => markdown.Parse(File.ReadAllText("CHANGELOG.md")));
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
                FontFamily = new FontFamily("Segoe UI")
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
            fdsvVersionChangeLog.Document = changelog[version];
        }
        #endregion
    }
}
