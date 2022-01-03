using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.OrderService.Models.Domain
{
    public class Items
    {
        [Key]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
