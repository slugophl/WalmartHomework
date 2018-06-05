using System;
using System.Collections.Generic;
using System.Text;

namespace WalmartHomework.Core.Models
{
    public class AppSettings
    {
        public string WalmartApiKey { get; set; }
        public string WalmartApiBaseUrl { get; set; }
        public string WalmartApiSearchUrlPart { get; set; }
        public string WalmartApiLookupUrlPart { get; set; }
        public string WalmartApiRecommendationsUrlPart { get; set; }
    }
}
