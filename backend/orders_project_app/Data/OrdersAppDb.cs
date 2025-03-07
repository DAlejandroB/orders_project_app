using Microsoft.EntityFrameworkCore;
using orders_project_app.Model;

namespace orders_project_app.Data
{
    public class OrdersAppDb : DbContext
    {
        public OrdersAppDb(DbContextOptions<OrdersAppDb> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<StockItem> StockItems { get; set; }

    }
}
