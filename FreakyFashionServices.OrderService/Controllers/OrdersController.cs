using FreakyFashionServices.OrderService.Data;
using FreakyFashionServices.OrderService.Models.Domain;
using FreakyFashionServices.OrderService.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace FreakyFashionServices.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {


        private readonly IHttpClientFactory httpClientFactory;

        public OrdersController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /*
         {
             "identifier": "someidentifier",
              "customer": "John Doe"
        }

        NewOrderDto
         */
        [HttpPost("{customerId}")]
        public async Task<IActionResult> CreateOrder(string customerId, OrderDto orders)
        {
            var orderJson = new StringContent(
                JsonSerializer.Serialize(orders),
                Encoding.UTF8,
                Application.Json);

            var httpClient = httpClientFactory.CreateClient();

            // GET basket (baserat å identifier) 
            using var httpResponseMessage =
                await httpClient.PostAsync($"http://localhost:9500/api/baskets/{customerId}", orderJson);
            
            // deserializera basket

            // skapa order (Order), samt orderrader (OrderLine) - orderrader genereras baserat på 
            // antal items i din basket

            // spara nere i db

            return Created("", orders); 
        }
    }
}
