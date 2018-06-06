using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalmartHomework.Core.Interfaces;
using WalmartHomework.Core.Models;
using WalmartHomework.Infrastructure.Clients;
using Xunit;

namespace WalmartHomework.Tests
{
    public class WalmartOpenApiClientTests
    {
        private readonly IWalmartOpenApiClient _walmartOpenApiClient;
        private readonly IOptions<AppSettings> _appSettings = Options.Create(new AppSettings
        {
            WalmartApiKey = "ndprdgtexca3twqvnfumgmce",
            WalmartApiBaseUrl = "http://api.walmartlabs.com",
            WalmartApiSearchUrlPart = "v1/search",
            WalmartApiLookupUrlPart = "v1/items/{id}",
            WalmartApiRecommendationsUrlPart = "v1/nbp"
        });

        public WalmartOpenApiClientTests()
        {
            _walmartOpenApiClient = new WalmartOpenApiClient(_appSettings, new NullLogger<BaseClient>());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Search_Valid_Query_Return_Ok_With_Results()
        {
            var response = await _walmartOpenApiClient.Search("ipod");

            Assert.IsType<SearchResponse>(response);
            Assert.Equal("ipod", response.Query);
            Assert.True(response.TotalResults > 0);
            Assert.NotEmpty(response.Items);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Search_Invalid_Query_Return_Ok_With_Results_Not_Found()
        {
            var response = await _walmartOpenApiClient.Search("aslkjsdfoiuwe");

            Assert.IsType<SearchResponse>(response);
            Assert.Equal("Results not found!", response.Message);
            Assert.Equal(0, response.TotalResults);
            Assert.Null(response.Items);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task LookupProduct_Valid_Id_Return_Ok_With_Result()
        {
            var response = await _walmartOpenApiClient.LookupProduct(12417832);

            Assert.IsType<ItemResponse>(response);
            Assert.Equal(12417832, response.ItemId);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task LookupProduct_Invalid_Id_Return_Item_Id_Zero()
        {
            var response = await _walmartOpenApiClient.LookupProduct(98765432123456789);

            Assert.IsType<ItemResponse>(response);
            Assert.Equal(0, response.ItemId);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Get_Recommendations_Valid_Id_Return_Ok_With_Results()
        {
            var response = await _walmartOpenApiClient.GetRecommendations(44569327);

            Assert.IsType<RecommendationsResponse>(response);
            Assert.NotEmpty(response.Recommendations);
        }
    }
}
