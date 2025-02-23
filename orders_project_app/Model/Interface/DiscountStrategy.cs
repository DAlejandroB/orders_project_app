namespace orders_project_app.Model.Interface
{
    public interface DiscountStrategy
    {
        public decimal ApplyDiscount(Order order);
    }
}
