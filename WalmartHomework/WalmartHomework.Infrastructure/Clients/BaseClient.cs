using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WalmartHomework.Core.Models;

namespace WalmartHomework.Infrastructure.Clients
{
    public class BaseClient
    {
        protected readonly HttpClient Client = new HttpClient();
        protected readonly AppSettings AppSettings;
        protected readonly ILogger<BaseClient> Logger;

        public BaseClient(IOptions<AppSettings> appSettings, ILogger<BaseClient> logger)
        {
            AppSettings = appSettings.Value;
            Logger = logger;
        }

        protected static HttpRequestMessage GetRequest(HttpMethod httpMethod, string requestUri)
        {
            var httpRequestMessage = new HttpRequestMessage(httpMethod, requestUri);
            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpRequestMessage;
        }

        protected async Task<T> GetResponse<T>(HttpRequestMessage request) where T : WalmartOpenApiBaseResponse, new()
        {
            var response = await Client.SendAsync(request);
            var responseStr = await response.Content.ReadAsStringAsync();

            try
            {
                var responseObj = Deserialize<T>(responseStr);
                return responseObj;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Exception attempting to deserialize response for request URI {RequestUri}. Response: {responseStr}", request.RequestUri, responseStr);
                return new T
                {
                    StatusCode = response.StatusCode,
                    Errors = new List<WalmartOpenApiError> { new WalmartOpenApiError { Message = e.Message } }
                };
            }
        }

        protected static T Deserialize<T>(string responseStr)
        {
            return JsonConvert.DeserializeObject<T>(responseStr);
        }
    }
}
