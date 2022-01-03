using FreakyFashionServices.OrderService.Data;
using FreakyFashionServices.OrderService.Models.Domain;
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
      
        private OrderServiceContext Context { get; }

        private readonly IHttpClientFactory httpClientFactory;

        public OrdersController(OrderServiceContext context, IHttpClientFactory httpClientFactory)
        {
            Context = context;
            this.httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Orders orders)
        {
            var orderJson = new StringContent(
                JsonSerializer.Serialize(orders),
                Encoding.UTF8,
                Application.Json);
            var httpClient = httpClientFactory.CreateClient();

            using var httpResponseMessage =
                await httpClient.PostAsync("http://localhost:5000/api/baskets", orderJson);
            
            return Created("", null);
        }
    }
}
