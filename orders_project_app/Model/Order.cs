using Microsoft.EntityFrameworkCore;
using orders_project_app.Model.Enum;

namespace orders_project_app.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDateTime { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.PENDING;
        public OrderType Type { get; set; }

    }
}
