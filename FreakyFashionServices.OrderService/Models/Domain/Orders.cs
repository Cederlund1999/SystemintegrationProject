using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.OrderService.Models.Domain
{
    public class Orders
    {

        public int Id { get; set; }

        public string CustomerName { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
