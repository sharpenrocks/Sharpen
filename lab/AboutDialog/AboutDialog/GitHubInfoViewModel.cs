using GraphQL.Client;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
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
            Stars = (int)repository.stargazers.totalCount;
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
    }
}
