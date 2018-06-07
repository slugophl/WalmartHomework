using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WalmartHomework.Core.Dtos;
using WalmartHomework.Core.Interfaces;
using WalmartHomework.Core.Models;

namespace WalmartHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IWalmartOpenApiClient _walmartOpenApiClient;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IWalmartOpenApiClient walmartOpenApiClient, ILogger<ProductsController> logger)
        {
            _walmartOpenApiClient = walmartOpenApiClient;
            _logger = logger;
        }

        // GET: api/Products/Search?query=ipod
        [HttpGet(Name = "Search")]
        [Route("Search")]
        public async Task<IActionResult> Search(string query)
        {
            _logger.LogInformation("Searching for {query}", query);

            if (string.IsNullOrEmpty(query))
            {
                _logger.LogWarning("Empty search query received. Returning bad reqeust.");
                return BadRequest();
            }

            var searchResponse = await _walmartOpenApiClient.Search(query);

            if (searchResponse.Errors != null && searchResponse.Errors.Any())
                return Ok(Mapper.Map<ErrorsDto>(searchResponse));

            return Ok(searchResponse);
        }

        // GET: api/Products/12417832
        [HttpGet("{id}", Name = "LookupProduct")]
        [Route("{id}/Lookup")]
        public async Task<IActionResult> LookupProduct(long id)
        {
            _logger.LogInformation("Looking up product ID {ID}", id);
            var item = await _walmartOpenApiClient.LookupProduct(id);

            if (item.Errors != null && item.Errors.Any())
                return Ok(Mapper.Map<ErrorsDto>(item));

            if (item.ItemId == 0)
            {
                _logger.LogWarning("Product ID {ID} not found", id);
                return NotFound();
            }

            return Ok(item);
        }

        // GET: api/Products/12417832
        [HttpGet("{id}", Name = "Recommendations")]
        [Route("{id}/Recommendations")]
        public async Task<IActionResult> GetRecommendations(long id)
        {
            _logger.LogWarning("Getting recommendations for product ID {ID}", id);
            var recommendations = await _walmartOpenApiClient.GetRecommendations(id);

            if (recommendations.Errors != null && recommendations.Errors.Any())
            {
                var errorsDto = Mapper.Map<ErrorsDto>(recommendations);
                return Ok(errorsDto);
            }

            return Ok(recommendations.Recommendations.Take(10).ToList());
        }
    }
}
