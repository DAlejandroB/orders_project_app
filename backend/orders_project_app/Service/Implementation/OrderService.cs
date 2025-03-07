using orders_project_app.CustomException;
using orders_project_app.Model;
using orders_project_app.Model.Dto;
using orders_project_app.Repository.Interface;
using orders_project_app.Service.Interface;

namespace orders_project_app.Service.Implementation
{
    public class OrderService(
        IOrderRepository orderRepository,
        IClientRepository clientRepository,
        IStockItemRepository stockItemRepository) : IOrderService
    {
        public async Task<List<OrderDto>> GetOrders()
        {
            List<Order> orders = await orderRepository.GetOrders();
            return orders.Select(order =>
            {
                return new OrderDto
                {
                    Id = order.Id,
                    OrderDateTime = order.OrderDateTime,
                    OrderItems = order.OrderItems.Select(oi => oi.Id).ToList(),
                    TotalPrice = order.TotalPrice,
                    ClientId = order.ClientId,
                    Status = order.Status,
                    Type = order.Type
                };
            }).ToList();
        }

        public async Task<OrderDto> GetOrderById(int id)
        {
            Order orderEntity = await orderRepository.GetOrderById(id) ?? throw new EntityNotFoundException($"Order with ID='{id}' not found");
            return new OrderDto
            {
                Id = orderEntity.Id,
                OrderDateTime = orderEntity.OrderDateTime,
                OrderItems = orderEntity.OrderItems.Select(orderItem => orderItem.Id).ToList(),
                TotalPrice = orderEntity.TotalPrice,
                ClientId = orderEntity.ClientId,
                Status = orderEntity.Status,
                Type = orderEntity.Type
            };
        }

        public async Task AddOrder(OrderCreateDto order)
        {
            Client orderClient = await GetClient(order.ClientId);
            Order orderEntity = new Order
            {
                OrderDateTime = DateTime.Now,
                ClientId = order.ClientId,
                Client = orderClient,
                Status = order.Status,
                Type = order.Type
            };

            List<OrderItem> orderItems = await GetOrderItems(order, orderEntity);
            decimal totalPrice = orderItems.Sum(orderItem => orderItem.TotalPrice);

            // Set order reference to orderItems
            foreach (OrderItem orderItem in orderItems)
            {
                orderItem.Order = orderEntity;
            }

            orderEntity.OrderItems = orderItems;
            orderEntity.TotalPrice = totalPrice;
            //Persist order
            await orderRepository.AddOrder(orderEntity);
        }

        public async Task UpdateOrder(int orderId, OrderCreateDto order)
        {
            var existingOrder = await orderRepository.GetOrderById(orderId)
                                ?? throw new EntityNotFoundException($"Order with ID='{orderId}' not found");

            existingOrder.Status = order.Status;
            existingOrder.Type = order.Type;
            var orderItems = await GetOrderItems(order, existingOrder);
            existingOrder.TotalPrice = orderItems.Sum(o => o.TotalPrice);
            existingOrder.OrderItems = orderItems;

            foreach (var orderItem in orderItems)
            {
                orderItem.Order = existingOrder;
            }

            await orderRepository.UpdateOrder(existingOrder);
        }

        public async Task DeleteOrder(int id)
        {
            var existingOrder = await orderRepository.GetOrderById(id);
            if (existingOrder == null)
            {
                throw new EntityNotFoundException($"Order with ID='{id}' not found");
            }
            await orderRepository.DeleteOrder(id);
        }

        private async Task<List<OrderItem>> GetOrderItems(OrderCreateDto orderCreateDto, Order orderEntity)
        {
            List<OrderItem> orderItems = [];

            foreach (OrderItemDto orderItemDto in orderCreateDto.OrderItems)
            {
                StockItem stockItem = await stockItemRepository.GetStockItemById(orderItemDto.ItemId);
                if (stockItem == null)
                {
                    throw new EntityNotFoundException($"{typeof(StockItem)} with ID='{orderItemDto.ItemId}' not found");
                }
                OrderItem orderItem = new OrderItem
                {
                    Order = orderEntity,
                    Name = stockItem.Name,
                    TotalPrice = stockItem.UnitPrice * orderItemDto.Quantity,
                    Quantity = orderItemDto.Quantity
                };
                if(stockItem.Quantity < orderItemDto.Quantity)
                {
                    throw new InsufficientStockException($"Insufficient stock for item '{stockItem.Name}'");
                }
                stockItem.Quantity -= orderItemDto.Quantity;
                orderItems.Add(orderItem);
            }
            return orderItems;
        }

        private async Task<Client> GetClient(int clientId)
        {
            Client result = await clientRepository.GetClientById(clientId);
            if (result == null)
            {
                throw new EntityNotFoundException($"{typeof(Client)} with ID='{clientId}' not found");
            }
            return result;
        }
    }
}
