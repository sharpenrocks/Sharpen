using GraphQL.Client;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace AboutLayoutTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string flags = "256";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LblTitleLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void BtnCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private async void BtnRunClick(object sender, RoutedEventArgs e)
        //{
        //    var regex = new Regex(@".*""install"".*""averagerating"".*");
        //    var results = new List<Tuple<string, long, string>>();
        //    for (int i = 0; i <= 999; i++)
        //    {
        //        flags = i.ToString("000");
        //        var marketplaceResponse = await GetMarketplaceDataAsync();
        //        if (regex.IsMatch(marketplaceResponse.Content))
        //            results.Add(new Tuple<string, long, string>(flags, marketplaceResponse.ContentLength, marketplaceResponse.Content));
        //    }

        //    using (var s = new System.IO.StreamWriter(@"c:\test\flags.txt"))
        //    {
        //        foreach (var tuple in results.OrderBy(r => r.Item2).ThenBy(r => r.Item1))
        //        {
        //            s.WriteLine($"**** {tuple.Item1} ****");
        //            s.WriteLine(tuple.Item3);
        //            s.WriteLine($"**** {tuple.Item1} ****");
        //            s.WriteLine();
        //        }
        //    }
        //}

        private async void WindowLoaded(object sender, RoutedEventArgs e)
        {
            //SetLocalData();
            await SetGitDataAsync();
            await SetVSMarketplaceDataAsync();

        }
        private async Task SetGitDataAsync()
        {
            var response = await GetGitDataAsync();
            var repository = response.Data.repositoryOwner.repository;
            lblDescription.Content = new TextBlock() { Text = repository.description, TextWrapping = TextWrapping.Wrap };
            txtGithub.Inlines.Add($" ({repository.stargazers.totalCount } stars)");
        }
        private async Task SetVSMarketplaceDataAsync()
        {
            var response = await GetMarketplaceDataAsync();
            var json = (JsonObject)SimpleJson.DeserializeObject(response.Content);
            var numberOfInstalls = 5;
            var numberOfReviews = 12;
            double rating = 2.74;
            var span = new System.Windows.Documents.Span()
            {
                ToolTip = $"{rating}/5"
            };

            for (int i = 1; i <= 5; i++)
            {
                if ((int)rating >= i)
                    span.Inlines.Add(new Image() { Source = ((Image)FindResource("FullStar")).Source });
                else if ((int)rating + 1 == i)
                    if ((rating % 1) * 100 >= 75)
                        span.Inlines.Add(new Image() { Source = ((Image)FindResource("FullStar")).Source });
                    else if ((rating % 1) * 100 >= 25)
                        span.Inlines.Add(new Image() { Source = ((Image)FindResource("HalfStar")).Source });
                    else
                        span.Inlines.Add(new Image() { Source = ((Image)FindResource("NoStar")).Source });
                else
                    span.Inlines.Add(new Image() { Source = ((Image)FindResource("NoStar")).Source });
            }
            txtVSMarketplace.Inlines.Add($" ({numberOfInstalls} installs) ");
            txtVSMarketplace.Inlines.Add(span);
            txtVSMarketplace.Inlines.Add($" ({numberOfReviews})");
        }

        private void SetLocalData()
        {
            var name = Assembly.GetEntryAssembly().GetName();
            lblTitle.Content = $"{name.Name} v{name.Version}";
            lblCopyright.Content = $"Copyright © Igor Rončević 2017 - {DateTime.Now.Year}";
        }

        private async Task<GraphQLResponse> GetGitDataAsync()
        {
            var client = new GraphQLClient("https://api.github.com/graphql");
            client.DefaultRequestHeaders.Add("Authorization", $"bearer {ConfigurationManager.AppSettings["GitAuthToken"]}");
            client.DefaultRequestHeaders.Add("User-Agent", "SharpenAboutBox");
            var request = new GraphQLRequest()
            {
                Query = @"query {
                    repositoryOwner (login: ""sharpenrocks"") {
                        repository(name: ""sharpen"") {
                            description
                            stargazers {
                                totalCount
                            }
                        }
                    }
                }"
            };
            return await client.PostAsync(request);
        }

        private async Task<IRestResponse> GetMarketplaceDataAsync()
        {
            var client = new RestClient("https://marketplace.visualstudio.com/");

            var request = new RestRequest("_apis/public/gallery/extensionquery", Method.POST, RestSharp.DataFormat.Json);
            request.AddHeader("Accept", "application/json; api-version=3.2-preview.1");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            // Fiddler4 + Manage Extensions was source for this request
            //request.AddJsonBody(@"{""flags"":""262"",""filters"":[{""criteria"":[{""filterType"":""10"",""value"":""ironcev.sharpen""}]}]}");
            request.AddJsonBody($@"{{""flags"":""{flags}"",""filters"":[{{""criteria"":[{{""filterType"":""10"",""value"":""ironcev.sharpen""}}]}}]}}");

            return await client.ExecuteTaskAsync(request);
        }

        private void HyperlinkRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
        }
    }
}
