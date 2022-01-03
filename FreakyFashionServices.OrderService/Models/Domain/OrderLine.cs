using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.OrderService.Models.Domain
{
    public class OrderLine
    {
        [Key]
        public string CustomerId { get; set; }

        public IEnumerable<Items> Items { get; set; } = new List<Items>();
    }
}
