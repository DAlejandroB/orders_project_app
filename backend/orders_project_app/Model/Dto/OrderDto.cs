using Microsoft.EntityFrameworkCore;
using orders_project_app.Model.Enum;

namespace orders_project_app.Model.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDateTime { get; set; }
        public List<int> OrderItems { get; set; } = [];
        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }
        public int ClientId { get; set; }
        public OrderStatus Status { get; set; }
        public OrderType Type { get; set; }
    }
}
