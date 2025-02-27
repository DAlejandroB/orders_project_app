using orders_project_app.Model;

namespace orders_project_app.Repository.Interface
{
    public interface IOrderItemRepository
    {
        public Task<List<OrderItem>> GetOrderItems();
        public Task<OrderItem> GetOrderItemById(int id);
        public void AddOrderItem(OrderItem orderItem);
        public void UpdateOrderItem(OrderItem orderItem);
        public void DeleteOrderItem(int id);
    }
}
