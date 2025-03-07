using orders_project_app.Model;

namespace orders_project_app.Stategy
{
    public interface IDiscountStrategy
    {
        public decimal ApplyDiscount(Order order);
    }
}
