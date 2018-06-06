using System;
using System.Collections.Generic;
using System.Text;

namespace WalmartHomework.Core.Models
{
    public class SearchResponse : WalmartOpenApiBaseResponse
    {
        public string Query { get; set; }
        public string Sort { get; set; }
        public string ResponseGroup { get; set; }
        public int TotalResults { get; set; }
        public int Start { get; set; }
        public int NumItems { get; set; }
        public IEnumerable<ItemResponse> Items { get; set; }
        public string Message { get; set; }
        public IEnumerable<object> Facets { get; set; }
    }
}
