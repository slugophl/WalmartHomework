using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WalmartHomework.Core.Interfaces;
using WalmartHomework.Core.Models;

namespace WalmartHomework.Infrastructure.Clients
{
    public class WalmartOpenApiClient : BaseClient, IWalmartOpenApiClient
    {
        public WalmartOpenApiClient(IOptions<AppSettings> appSettings, ILogger<BaseClient> logger) : base(appSettings, logger)
        {
        }

        public async Task<SearchResponse> Search(string query)
        {
            var request = GetRequest(HttpMethod.Get, $"{AppSettings.WalmartApiBaseUrl}/{AppSettings.WalmartApiSearchUrlPart}?apiKey={AppSettings.WalmartApiKey}&query={query}");

            var search = await GetResponse<SearchResponse>(request);

            return search;
        }

        public async Task<ItemResponse> LookupProduct(long id)
        {
            var request = GetRequest(HttpMethod.Get, $"{AppSettings.WalmartApiBaseUrl}/{AppSettings.WalmartApiLookupUrlPart.Replace("{id}", id.ToString())}?apiKey={AppSettings.WalmartApiKey}&format=json");

            var item = await GetResponse<ItemResponse>(request);

            return item;
        }

        public async Task<RecommendationsResponse> GetRecommendations(long id)
        {
            var request = GetRequest(HttpMethod.Get, $"{AppSettings.WalmartApiBaseUrl}/{AppSettings.WalmartApiRecommendationsUrlPart}?apiKey={AppSettings.WalmartApiKey}&itemId={id}");

            var response = await Client.SendAsync(request);
            var responseStr = await response.Content.ReadAsStringAsync();

            try
            {
                if (responseStr.Contains("errors"))
                {
                    var responseObj = JsonConvert.DeserializeObject<RecommendationsResponse>(responseStr);
                    return responseObj;
                }
                else
                {
                    var recommendationsResponse = new RecommendationsResponse
                    {
                        Recommendations = JsonConvert.DeserializeObject<List<ItemResponse>>(responseStr)
                    };
                    return recommendationsResponse;
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Exception attempting to deserialize response for request URI {RequestUri}. Response: {responseStr}", request.RequestUri, responseStr);
                return new RecommendationsResponse
                {
                    StatusCode = (int)response.StatusCode,
                    Errors = new List<WalmartOpenApiError> { new WalmartOpenApiError { Message = $"Response: {responseStr}. Exception {e.Message}" } }
                };
            }
        }
    }
}
