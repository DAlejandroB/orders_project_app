using orders_project_app.Model;
using orders_project_app.Model.Enum;

namespace orders_project_app.Stategy
{
    public class DiscountStrategyFactory
    {
        public static IDiscountStrategy GetDiscountStrategy(Order order)
        {
            switch (order.Type)
            {
                case OrderType.BULK:
                    return new BulkDiscount();
                case OrderType.SUBSCRIPTION:
                    return new SubscriptionDiscount();
                default:
                    return new NoDiscount();
            }
        }
    }
}
