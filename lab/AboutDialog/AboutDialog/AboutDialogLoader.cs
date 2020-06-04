using GraphQL.Client;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sharpen
{
    /// <summary>
    /// Loader for databindable fileds.
    /// </summary>
    internal class AboutDialogLoader : BindableBase
    {
        private AboutDialogConfigurationSection configuration = ConfigurationManager.GetSection("aboutDialogConfigurationSection") as AboutDialogConfigurationSection;

        #region Assembly data
        private string title;
        private string description;
        private string copyright;

        public string Title { get => title; set => SetProperty(ref title, value); }
        public string Description { get => description; set => SetProperty(ref description, value); }
        public string Copyright { get => copyright; set => SetProperty(ref copyright, value); }

        private Task SetAssemblyDataAsync()
        {
            var assembly = Assembly.GetEntryAssembly();

            // Set Title.
            var name = assembly.GetName();
            Title = $"{name.Name} v{name.Version}";

            // Set Description.
            var descriptionAttribute = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>();
            if (descriptionAttribute != null)
                Description = descriptionAttribute.Description;

            // Set Copyright.
            var copyrightAttribute = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>();
            if (copyrightAttribute != null)
                Copyright = copyrightAttribute.Copyright;

            return Task.CompletedTask;
        }
        #endregion

        #region GitHub data
        private int? gitHubStars;

        public int? GitHubStars { get => gitHubStars; set => SetProperty(ref gitHubStars, value); }

        private async Task SetGitHubDataAsync()
        {
            GraphQLResponse response;
            try
            {
                response = await GetGitHubDataAsync();
                // Ignore response if it contains any errors.
                if (response.Errors != null && response.Errors.Any())
                    return;
            }
            catch
            {
                // Ignore all exceptions retrieving GitHub data.
                return;
            }

            var repository = response.Data.repositoryOwner.repository;
            GitHubStars = (int)repository.stargazers.totalCount;
        }
        private async Task<GraphQLResponse> GetGitHubDataAsync()
        {
            using (var client = new GraphQLClient("https://api.github.com/graphql"))
            {
                client.DefaultRequestHeaders.Add("Authorization", $"bearer {configuration.GitHubAuthToken}");
                client.DefaultRequestHeaders.Add("User-Agent", "SharpenAboutBox");
                var request = new GraphQLRequest()
                {
                    Query = $@"query {{
                    repositoryOwner (login: ""{configuration.GitHubLogin}"") {{
                        repository(name: ""{configuration.GitHubRepository}"") {{
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
        private int? vSMarketplaceNumberOfInstalls;
        private double? vSMarketplaceRating;
        private int? vsMarketplaceNumberOfReviews;

        public int? VSMarketplaceNumberOfInstalls { get => vSMarketplaceNumberOfInstalls; set => SetProperty(ref vSMarketplaceNumberOfInstalls, value); }
        public double? VSMarketplaceRating { get => vSMarketplaceRating; set => SetProperty(ref vSMarketplaceRating, value); }
        public int? VsMarketplaceNumberOfReviews { get => vsMarketplaceNumberOfReviews; set => SetProperty(ref vsMarketplaceNumberOfReviews, value); }

        private async Task SetVSMarketplaceDataAsync()
        {
            IRestResponse response;
            try
            {
                response = await GetVSMarketplaceDataAsync();
                if (!response.IsSuccessful)
                    return;

                var json = JObject.Parse(response.Content);

                // Fugly. This *is* a full sentence comment.
                // This whole block could cause exception if response structure changes.
                var statistics = json["results"][0]["extensions"][0]["statistics"];
                VSMarketplaceNumberOfInstalls = (int)statistics[0]["value"];
                VSMarketplaceRating = (double)statistics[1]["value"];
                VsMarketplaceNumberOfReviews = (int)statistics[2]["value"];
            }
            catch
            {
                // Ignore all exceptions retrieving VSMarketplace data.
                // Ignore all exceptions that are result of changed response structure.
            }
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
                        ""value"":""{configuration.VSMarketplaceId}""
                    }}]
                }}]
            }}");

            return await client.ExecuteTaskAsync(request);
        }
        #endregion

        public async Task LoadAsync()
        {
            await Task.WhenAll(SetAssemblyDataAsync(), SetGitHubDataAsync(), SetVSMarketplaceDataAsync());
        }
    }
}
