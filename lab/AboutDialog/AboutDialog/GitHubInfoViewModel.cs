using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Linq;
using System.Threading.Tasks;

namespace Sharpen
{
    internal class GitHubInfoViewModel : ConfigurationBaseViewModel
    {
        private int? stars;

        public int? Stars { get => stars; set => SetProperty(ref stars, value); }

        internal async Task SetGitHubInfoAsync()
        {
            GraphQLResponse<dynamic> response;
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
            Stars = (int)repository.stargazers.totalCount;
        }

        private async Task<GraphQLResponse<dynamic>> GetGitHubDataAsync()
        {
            using (var client = new GraphQLHttpClient("https://api.github.com/graphql", new NewtonsoftJsonSerializer()))
            {
                client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {configuration.GitHubAuthToken}");
                client.HttpClient.DefaultRequestHeaders.Add("User-Agent", "SharpenAboutBox");
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
                return await client.SendQueryAsync<dynamic>(request);
            }
        }
    }
}
