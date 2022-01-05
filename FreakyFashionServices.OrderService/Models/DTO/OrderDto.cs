using FreakyFashionServices.OrderService.Models.Domain;

namespace FreakyFashionServices.OrderService.Models.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public IEnumerable<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
