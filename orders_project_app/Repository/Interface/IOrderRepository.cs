using orders_project_app.Model;

namespace orders_project_app.Repository.Interface
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetOrders();
        public Task<Order> GetOrderById(int id);
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);
        public void DeleteOrder(int id);
    }
}
