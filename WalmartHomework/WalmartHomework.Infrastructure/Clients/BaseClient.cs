using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WalmartHomework.Core.Models;

namespace WalmartHomework.Infrastructure.Clients
{
    public class BaseClient
    {
        protected readonly HttpClient _client = new HttpClient();
        protected readonly AppSettings AppSettings;

        public BaseClient(IOptions<AppSettings> appSettings)
        {
            AppSettings = appSettings.Value;
        }

        protected static HttpRequestMessage GetRequest(HttpMethod httpMethod, string requestUri)
        {
            var httpRequestMessage = new HttpRequestMessage(httpMethod, requestUri);
            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpRequestMessage;
        }

        protected async Task<T> GetResponse<T>(HttpRequestMessage request)
        {
            var response = await _client.SendAsync(request);
            var responseStr = await response.Content.ReadAsStringAsync();
            var responseObj = Deserialize<T>(responseStr);
            return responseObj;
        }

        protected static T Deserialize<T>(string responseStr)
        {
            return JsonConvert.DeserializeObject<T>(responseStr);
        }
    }
}
