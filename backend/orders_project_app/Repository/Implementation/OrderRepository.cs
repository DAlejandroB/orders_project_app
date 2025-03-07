using Microsoft.EntityFrameworkCore;
using orders_project_app.CustomException;
using orders_project_app.Data;
using orders_project_app.Model;
using orders_project_app.Repository.Interface;

namespace orders_project_app.Repository.Implementation
{
    public class OrderRepository(OrdersAppDb appDb) : IOrderRepository
    {
        public async Task AddOrder(Order order)
        {
            await appDb.Orders.AddAsync(order);
            await appDb.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id)
        {
            Order? order = await appDb.Orders.FindAsync(id) ?? throw new EntityNotFoundException("Order not found");
            appDb.Orders.Remove(order);
            await appDb.SaveChangesAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            Order? order = await appDb.Orders.FindAsync(id);
            if (order == null)
            {
                throw new EntityNotFoundException("Order not found");
            }
            return order;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await appDb.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            Order? existingOrder = await appDb.Orders.FindAsync(order.Id);
            if (existingOrder == null)
            {
                throw new EntityNotFoundException("Order not found");
            }
            appDb.Entry(existingOrder).CurrentValues.SetValues(order);
            await appDb.SaveChangesAsync();
        }
    }
}
