using FreakyFashionServices.BasketService.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace FreakyFashionServices.BasketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        public BasketsController(IDistributedCache cache)
        {
            Cache = cache;
        }

        public IDistributedCache Cache { get; }


        [HttpPut("{customerId}")]
        public IActionResult CreateBasket(BasketDto basketDto)
        {
            var serializedBasket = JsonSerializer.Serialize(basketDto);

            Cache.SetString(basketDto.CustomerId, serializedBasket);

            return NoContent();
        }
        [HttpGet("{customerId}")]
        public ActionResult<BasketDto> GetBasket(string customerId)
        {
            var serializedBasket = Cache.GetString(customerId);
            if(serializedBasket == null)
            {
                return NotFound();
            }
            var basketDto = JsonSerializer.Deserialize<BasketDto>(serializedBasket);
            return Ok(basketDto);
        }
    }
}
