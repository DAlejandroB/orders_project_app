using orders_project_app.Model;
using orders_project_app.Model.Dto;

namespace orders_project_app.Service.Interface
{
    public interface IOrderService
    {
        public Task<List<OrderDto>> GetOrders();
        public Task<OrderDto> GetOrderById(int id);
        public Task AddOrder(OrderCreateDto order);
        public Task UpdateOrder(OrderCreateDto order);
        public Task DeleteOrder(int id);
    }
}
