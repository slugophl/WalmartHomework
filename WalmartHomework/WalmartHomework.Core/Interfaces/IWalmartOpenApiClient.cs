using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalmartHomework.Core.Models;

namespace WalmartHomework.Core.Interfaces
{
    public interface IWalmartOpenApiClient
    {
        Task<SearchResponse> Search(string query);
        Task<ItemResponse> LookupProduct(long id);
        Task<RecommendationsResponse> GetRecommendations(long id);
    }
}
