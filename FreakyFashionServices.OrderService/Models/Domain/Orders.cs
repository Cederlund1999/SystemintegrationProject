using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.OrderService.Models.Domain
{
    public class Orders
    {
        public Orders(int orderId, string customerId, string customerName)
        {
            OrderId = orderId;
            CustomerId = customerId;
            CustomerName = customerName;
        }

        [Key]
        public int OrderId { get; set; }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
