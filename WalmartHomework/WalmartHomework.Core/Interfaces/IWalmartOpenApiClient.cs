using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalmartHomework.Core.Models;

namespace WalmartHomework.Core.Interfaces
{
    public interface IWalmartOpenApiClient
    {
        Task<Search> Search(string query);
        Task<Item> LookupProduct(long id);
        Task<List<Item>> GetRecommendations(long id);
    }
}
