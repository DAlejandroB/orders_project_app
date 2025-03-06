using Microsoft.EntityFrameworkCore;
using orders_project_app.CustomException;
using orders_project_app.Data;
using orders_project_app.Model;
using orders_project_app.Repository.Interface;

namespace orders_project_app.Repository.Implementation
{
    public class OrderItemRepository(OrdersAppDb appDb) : IOrderItemRepository
    {
        public async Task AddOrderItem(OrderItem orderItem)
        {
            await appDb.OrderItems.AddAsync(orderItem);
            await appDb.SaveChangesAsync();
        }

        public async Task DeleteOrderItem(int id)
        {
            OrderItem? orderItem = await appDb.OrderItems.FindAsync(id) ?? throw new EntityNotFoundException("OrderItem not found");
            appDb.OrderItems.Remove(orderItem);
            await appDb.SaveChangesAsync();
        }

        public async Task<OrderItem> GetOrderItemById(int id)
        {
            OrderItem? orderItem = await appDb.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                throw new EntityNotFoundException("OrderItem not found");
            }
            return orderItem;
        }

        public async Task<List<OrderItem>> GetOrderItems()
        {
            return await appDb.OrderItems.ToListAsync();
        }

        public async Task UpdateOrderItem(OrderItem orderItem)
        {
            OrderItem? existingOrderItem = await appDb.OrderItems.FindAsync(orderItem.Id);
            if (existingOrderItem == null)
            {
                throw new EntityNotFoundException($"OrderItem with ID='{orderItem.Id}' not found");
            }
            appDb.Entry(existingOrderItem).CurrentValues.SetValues(orderItem);
            await appDb.SaveChangesAsync();
        }
    }
}
