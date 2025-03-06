using Microsoft.EntityFrameworkCore;
using orders_project_app.Model.Enum;

namespace orders_project_app.Model.Dto
{
    public class OrderCreateDto
    {
        public List<OrderItemDto> OrderItems { get; set; } = [];
        [Precision(18, 2)]
        public int ClientId { get; set; }
        public OrderStatus Status { get; set; }
        public OrderType Type { get; set; }
    }
}
