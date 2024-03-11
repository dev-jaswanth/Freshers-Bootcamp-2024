// CatalogController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;


namespace CatalogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        // Sample product information
        private readonly Dictionary<string, Product> products = new Dictionary<string, Product>
        {
            { "1", new Product("1", "Product 1") },
            { "2", new Product("2", "Product 2") },
            { "3", new Product("3", "Product 3") }
        };

        [HttpGet("{productId}")]
        public IActionResult GetProductInfo(string productId)
        {
            if (products.ContainsKey(productId))
            {
                return Ok(products[productId]);
            }
            else
            {
                return NotFound("Product not found");
            }
        }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Product(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
