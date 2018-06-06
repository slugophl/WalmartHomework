using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WalmartHomework.Core.Models
{
    public class WalmartOpenApiBaseResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public IEnumerable<WalmartOpenApiError> Errors { get; set; }
    }

    public class WalmartOpenApiError
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
