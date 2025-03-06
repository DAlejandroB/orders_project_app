using Microsoft.EntityFrameworkCore;

namespace orders_project_app.Model
{
    public class OrderItem : Item
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }
    }
}
