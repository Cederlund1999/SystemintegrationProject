using AutoMapper;
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
        private readonly OrderServiceContext Context;
        


        public OrdersController(IHttpClientFactory httpClientFactory, OrderServiceContext context)
        {
            this.httpClientFactory = httpClientFactory;
            Context = context;
            
        }


        [HttpPost]
        public async Task<ActionResult<OrderCreatedDto>> CreateOrder(CreateOrderDto orders)
        {

            var httpClient = httpClientFactory.CreateClient();

            var httpResponse = await httpClient.GetAsync($"http://localhost:9500/api/baskets/{orders.CustomerId}");

            var response = await httpResponse.Content.ReadAsStringAsync();

            var basketResponse = JsonSerializer.Deserialize<OrderDto>(
                response,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (basketResponse.CustomerId == null)
                return NotFound(new { message = "no basket found on this id" });


            var SuccessfullOrder = await Context.Orders.AddAsync(new Orders()
            {
                CustomerName = orders.CustomerName,
                OrderLines = basketResponse.Items
                .Select(x => new OrderLine(
                   x.ProductId,
                   x.Quantity
                   )).ToList()
               
            });

            await Context.SaveChangesAsync();

            return Created("", new OrderCreatedDto { OrderId = SuccessfullOrder.Entity.Id});

        }
    }
}
