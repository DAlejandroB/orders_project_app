using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using orders_project_app.Model.Enum;

namespace orders_project_app.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDateTime { get; set; }
        public required List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }
        public int ClientId { get; set; }
        public required Client Client { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.PENDING;
        public OrderType Type { get; set; }

    }
}
