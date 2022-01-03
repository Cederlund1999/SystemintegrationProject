using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.OrderService.Models.Domain
{
    public class Orders
    {
        
        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        [Key]
        public int OrderId { get; set; }
    }
}
