using orders_project_app.Model;

namespace orders_project_app.Repository.Interface
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetOrders();
        public Task<Order> GetOrderById(int id);
        public Task AddOrder(Order order);
        public Task UpdateOrder(Order order);
        public Task DeleteOrder(int id);
    }
}
