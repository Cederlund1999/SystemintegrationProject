using FreakyFashionServices.OrderService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.OrderService.Data
{
    public class OrderServiceContext : DbContext
    {
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }

        public OrderServiceContext(DbContextOptions<OrderServiceContext> options)
            : base(options)
        {

        }
    }
}
