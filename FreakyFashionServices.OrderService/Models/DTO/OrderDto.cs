using FreakyFashionServices.OrderService.Models.Domain;

namespace FreakyFashionServices.OrderService.Models.DTO
{
    public class OrderDto
    {
        public string CustomerId { get; set; }

        public ICollection<OrderLineDto> Items { get; set; }
    }
}
