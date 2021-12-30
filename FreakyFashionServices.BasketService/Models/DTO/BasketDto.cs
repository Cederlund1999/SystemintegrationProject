using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.BasketService.Models.DTO
{
    public class BasketDto
    {

        public string CustomerId { get; set; }

        public IEnumerable<Items> Items { get; set; } = new List<Items>();

    }
}
