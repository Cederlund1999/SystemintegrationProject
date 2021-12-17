using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.BasketService.Models.DTO
{
    public class BasketDto
    {
        
        public string CustomerId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        
    }
}
