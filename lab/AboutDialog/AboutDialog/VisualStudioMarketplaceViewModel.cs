using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;

namespace Sharpen
{
    internal class VisualStudioMarketplaceViewModel : ConfigurationBaseViewModel
    {
        private int? numberOfInstalls;
        private double? rating;
        private int? numberOfReviews;

        public int? NumberOfInstalls { get => numberOfInstalls; set => SetProperty(ref numberOfInstalls, value); }
        public double? Rating { get => rating; set => SetProperty(ref rating, value); }
        public int? NumberOfReviews { get => numberOfReviews; set => SetProperty(ref numberOfReviews, value); }

        internal async Task SetVisualStudioMarketplaceInfoAsync()
        {
            IRestResponse response;
            try
            {
                response = await GetVisualStudioMarketplaceDataAsync();
                if (!response.IsSuccessful)
                    return;

                var json = JObject.Parse(response.Content);

#pragma warning disable CS8602
#pragma warning disable CS8604
                // Fugly. This *is* a full sentence comment.
                // This whole block could cause exception if response structure changes.
                // It is expected to fail into catch block, hence warning disables.
                var statistics = json["results"][0]["extensions"][0]["statistics"];
                NumberOfInstalls = (int)statistics[0]["value"];
                Rating = (double)statistics[1]["value"];
                NumberOfReviews = (int)statistics[2]["value"];
#pragma warning restore CS8604
#pragma warning restore CS8602
            }
            catch
            {
                // Ignore all exceptions retrieving VisualStudioMarketplace data.
                // Ignore all exceptions that are result of changed response structure.
            }
        }

        internal async Task<IRestResponse> GetVisualStudioMarketplaceDataAsync()
        {
            var client = new RestClient("https://marketplace.visualstudio.com/");

            var request = new RestRequest("_apis/public/gallery/extensionquery", Method.POST, DataFormat.Json);
            request.AddHeader("Accept", "application/json; api-version=3.2-preview.1");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            // Fiddler4 + Manage Extensions was source for this request.
            request.AddJsonBody($@"{{
                        ""flags"":""256"",
                        ""filters"":[{{
                            ""criteria"":[{{
                                ""filterType"":""10"",
                                ""value"":""{configuration.VisualStudioMarketplaceId}""
                            }}]
                        }}]
                    }}");

            return await client.ExecuteAsync(request);
        }
    }
}
