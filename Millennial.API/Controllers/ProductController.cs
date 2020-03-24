using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Millennial.Core;
using Millennial.Core.Repository.Interface;
using Millennial.DB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Millennial.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get(int page, int take, string sortBy, string sortDirection, string search)
        {
            try
            {
                var products = _productService.GetList(page, take, sortBy, sortDirection, search);
                return Ok(products);
            }  
            catch (Exception ex) 
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, new { Page = page , Take = take });
            }

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            _productService.Add(product);
            try
            {
                _productService.Save();
                var url = $"{Request.Scheme}://{Request.Host.Value}{Request.Path.Value}/{product.ProductId}";
                return Created(url, product.ProductId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, product);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
