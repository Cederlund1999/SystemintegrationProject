using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.OrderService.Models.Domain
{
    public class OrderLine
    {
        public OrderLine(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        
        
    }
}
