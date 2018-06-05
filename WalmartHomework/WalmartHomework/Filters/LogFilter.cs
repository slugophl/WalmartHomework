﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartHomework.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public LogFilter(ILogger logger)
        {
            _logger = logger;
        }


    }
}
