using Customer.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly HttpClient catalogClient;
        private readonly HttpClient cartClient;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            catalogClient = httpClientFactory.CreateClient();
            catalogClient.BaseAddress = new Uri("http://localhost:5001/catalog");

            cartClient = httpClientFactory.CreateClient();
            cartClient.BaseAddress = new Uri("http://localhost:5002/cart");
        }

        [HttpPost("buy")]
        public async Task<IActionResult> BuyItemsFromCart([FromBody] List<viewModel> cartItems)
        {
            if (cartItems == null || cartItems.Count == 0)
            {
                return BadRequest("Cart items not provided");
            }

            var orderDetails = new List<(string productId, int quantity)>();

            foreach (var cartItem in cartItems)
            {
                var response = await cartClient.GetAsync($"cart/{cartItem.ProductId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var retrievedCartItem = JsonConvert.DeserializeObject<(string productId, int quantity)>(content);
                    orderDetails.Add(retrievedCartItem);
                }
            }

            
            var orderId = Guid.NewGuid().ToString();

            
            return Ok(orderId);
        }
    }
}
