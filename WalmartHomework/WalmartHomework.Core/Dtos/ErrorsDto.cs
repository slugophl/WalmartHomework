using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WalmartHomework.Core.Models;

namespace WalmartHomework.Core.Dtos
{
    public class ErrorsDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public IEnumerable<WalmartOpenApiError> Errors { get; set; }
    }
}
