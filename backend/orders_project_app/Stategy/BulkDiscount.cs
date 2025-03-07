using orders_project_app.Model;

namespace orders_project_app.Stategy
{
    public class BulkDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(Order order)
        {
            return order.TotalPrice * 0.95m;
        }
    }
}
