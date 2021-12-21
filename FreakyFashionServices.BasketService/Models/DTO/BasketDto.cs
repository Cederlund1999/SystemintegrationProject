using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.BasketService.Models.DTO
{
    public class BasketDto
    {
        public BasketDto(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public string CustomerId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        
    }
}
