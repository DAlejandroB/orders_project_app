using orders_project_app.Model;
using orders_project_app.Repository.Interface;
using orders_project_app.Service.Interface;

namespace orders_project_app.Service.Implementation
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        public async Task<List<Order>> GetOrders()
        {
            return await orderRepository.GetOrders();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await orderRepository.GetOrderById(id);
        }

        public async Task AddOrder(Order order)
        {
            await orderRepository.AddOrder(order);
        }

        public async Task UpdateOrder(Order order)
        {
            await orderRepository.UpdateOrder(order);
        }

        public async Task DeleteOrder(int id)
        {
            await orderRepository.DeleteOrder(id);
        }
    }
}
