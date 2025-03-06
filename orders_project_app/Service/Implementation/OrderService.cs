using orders_project_app.CustomException;
using orders_project_app.Model;
using orders_project_app.Model.Dto;
using orders_project_app.Repository.Interface;
using orders_project_app.Service.Interface;

namespace orders_project_app.Service.Implementation
{
    public class OrderService(IOrderRepository orderRepository, IClientRepository clientRepository) : IOrderService
    {
        public async Task<List<OrderDto>> GetOrders()
        {
            List<Order> orders = await orderRepository.GetOrders();
            List<OrderDto> orderDtos = [];
            orders.ForEach(order =>
            {
                OrderDto orderDto = new OrderDto
                {
                    Id = order.Id,
                    OrderDateTime = order.OrderDateTime,
                    OrderItems = order.OrderItems.Select(orderItem => orderItem.Id).ToList(),
                    TotalPrice = order.TotalPrice,
                    ClientId = order.ClientId,
                    Status = order.Status,
                    Type = order.Type
                };
                orderDtos.Add(orderDto);
            });
            return orderDtos;
        }

        public async Task<OrderDto> GetOrderById(int id)
        {
            Order orderEntity = await orderRepository.GetOrderById(id);
            OrderDto orderDto = new OrderDto
            {
                Id = orderEntity.Id,
                OrderDateTime = orderEntity.OrderDateTime,
                OrderItems = orderEntity.OrderItems.Select(orderItem => orderItem.Id).ToList(),
                TotalPrice = orderEntity.TotalPrice,
                ClientId = orderEntity.ClientId,
                Status = orderEntity.Status,
                Type = orderEntity.Type
            };
            return orderDto;
        }

        public async Task AddOrder(OrderCreateDto order)
        {
            Client orderClient = await clientRepository.GetClientById(order.ClientId);
            if (orderClient == null)
            {
                throw new EntityNotFoundException($"{typeof(Client)} with ID='{order.ClientId}' not found");
            }
            Order orderEntity = new Order
            {
                OrderDateTime = DateTime.Now,
                OrderItems = order.OrderItems.Select(orderItemId => new OrderItem { Id = orderItemId }).ToList(), // This line is incorrect
                TotalPrice = order.TotalPrice,
                ClientId = order.ClientId,
                Client = orderClient,
                Status = order.Status,
                Type = order.Type
            };
            await orderRepository.AddOrder(orderEntity);
        }

        public async Task UpdateOrder(OrderCreateDto order)
        {
            Client orderClient = await clientRepository.GetClientById(order.ClientId);
            if (orderClient == null)
            {
                throw new EntityNotFoundException($"{typeof(Client)} with ID='{order.ClientId}' not found");
            }
            Order orderEntity = new Order
            {
                OrderItems = order.OrderItems.Select(orderItemId => new OrderItem { Id = orderItemId }).ToList(),
                TotalPrice = order.TotalPrice,
                ClientId = order.ClientId,
                Client = orderClient,
                Status = order.Status,
                Type = order.Type
            };
            await orderRepository.UpdateOrder(orderEntity);
        }

        public async Task DeleteOrder(int id)
        {
            await orderRepository.DeleteOrder(id);
        }
    }
}
