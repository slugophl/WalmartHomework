using System;
using System.Collections.Generic;
using System.Text;

namespace WalmartHomework.Core.Models
{
    public class RecommendationsResponse : WalmartOpenApiBaseResponse
    {
        public List<ItemResponse> Recommendations { get; set; }
    }
}
