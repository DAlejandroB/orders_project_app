using orders_project_app.Model;

namespace orders_project_app.Repository.Interface
{
    public interface IOrderItemRepository
    {
        public Task<List<OrderItem>> GetOrderItems();
        public Task<OrderItem> GetOrderItemById(int id);
        public Task AddOrderItem(OrderItem orderItem);
        public Task UpdateOrderItem(OrderItem orderItem);
        public Task DeleteOrderItem(int id);
    }
}
