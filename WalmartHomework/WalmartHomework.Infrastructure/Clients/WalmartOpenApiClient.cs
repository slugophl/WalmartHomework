using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WalmartHomework.Core.Interfaces;
using WalmartHomework.Core.Models;

namespace WalmartHomework.Infrastructure.Clients
{
    public class WalmartOpenApiClient : BaseClient, IWalmartOpenApiClient
    {
        public WalmartOpenApiClient(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        public async Task<Search> Search(string query)
        {
            var request = GetRequest(HttpMethod.Get, $"{AppSettings.WalmartApiBaseUrl}/{AppSettings.WalmartApiSearchUrlPart}?apiKey={AppSettings.WalmartApiKey}&query={query}");

            var search = await GetResponse<Search>(request);

            return search;
        }

        public async Task<Item> LookupProduct(long id)
        {
            var request = GetRequest(HttpMethod.Get, $"{AppSettings.WalmartApiBaseUrl}/{AppSettings.WalmartApiLookupUrlPart.Replace("{id}", id.ToString())}?apiKey={AppSettings.WalmartApiKey}&format=json");

            var item = await GetResponse<Item>(request);

            return item;
        }

        public async Task<List<Item>> GetRecommendations(long id)
        {
            var request = GetRequest(HttpMethod.Get, $"{AppSettings.WalmartApiBaseUrl}/{AppSettings.WalmartApiRecommendationsUrlPart}?apiKey={AppSettings.WalmartApiKey}&itemId={id}");

            var items = await GetResponse<List<Item>>(request);

            return items;
        }
    }
}
