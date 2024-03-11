// CartController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;


namespace CartService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly Dictionary<string, (string, int)> cart = new Dictionary<string, (string, int)>();

        [HttpPost]
        public IActionResult AddToCart([FromBody] CartItemRequest request)
        {
            if (request != null && !string.IsNullOrWhiteSpace(request.ProductId) && request.Quantity > 0)
            {
                cart[Guid.NewGuid().ToString()] = (request.ProductId, request.Quantity);
                return Ok("Item added to cart");
            }
            else
            {
                return BadRequest("Invalid request");
            }
        }

        [HttpGet]
        public IActionResult GetCart()
        {
            return Ok(cart);
        }
    }

    public class CartItemRequest
    {
        // Declaring ProductId as nullable
        public string? ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
