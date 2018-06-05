using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalmartHomework.Core.Interfaces;

namespace WalmartHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IWalmartOpenApiClient _walmartOpenApiClient;

        public ProductsController(IWalmartOpenApiClient walmartOpenApiClient)
        {
            _walmartOpenApiClient = walmartOpenApiClient;
        }

        // GET: api/Products
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(new string[] { "value1", "value2" });
        //}

        // GET: api/Products/Search?query=ipod
        [HttpGet(Name = "Search")]
        [Route("Search")]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
                return BadRequest();

            var searchResponse = await _walmartOpenApiClient.Search(query);

            return Ok(searchResponse);
        }

        // GET: api/Products/12417832
        [HttpGet("{id}", Name = "LookupProduct")]
        [Route("{id}/Lookup")]
        public async Task<IActionResult> LookupProduct(long id)
        {
            var item = await _walmartOpenApiClient.LookupProduct(id);

            if (item.ItemId == 0)
                return BadRequest();

            return Ok(item);
        }

        // GET: api/Products/12417832
        [HttpGet("{id}", Name = "Recommendations")]
        [Route("{id}/Recommendations")]
        public async Task<IActionResult> GetRecommendations(long id)
        {
            var recommendations = await _walmartOpenApiClient.GetRecommendations(id);

            if (recommendations == null || recommendations.Count == 0)
                return BadRequest();

            return Ok(recommendations.Take(10).ToList());
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Created("", "value");
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
