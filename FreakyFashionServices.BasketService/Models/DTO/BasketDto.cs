using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.BasketService.Models.DTO
{
    public class BasketDto
    {

        public string CustomerId { get; set; }

        public ICollection<Items> Items { get; set; }

    }
}
