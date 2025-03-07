using Microsoft.EntityFrameworkCore;
using orders_project_app.CustomException;
using orders_project_app.Data;
using orders_project_app.Model;
using orders_project_app.Repository.Interface;

namespace orders_project_app.Repository.Implementation
{
    public class StockItemRepository(OrdersAppDb appDb) : IStockItemRepository
    {
        public async Task AddStockItem(StockItem stockItem)
        {
            await appDb.StockItems.AddAsync(stockItem);
            await appDb.SaveChangesAsync();
        }

        public async Task DeleteStockItem(int id)
        {
            StockItem? stockItem = await appDb.StockItems.FindAsync(id) ?? throw new EntityNotFoundException("StockItem not found");
            appDb.StockItems.Remove(stockItem);
            await appDb.SaveChangesAsync();
        }

        public async Task<StockItem> GetStockItemById(int id)
        {
            StockItem? stockItem = await appDb.StockItems.FindAsync(id);
            if (stockItem == null)
            {
                throw new EntityNotFoundException("StockItem not found");
            }
            return stockItem;
        }

        public async Task<List<StockItem>> GetStockItems()
        {
            return await appDb.StockItems.ToListAsync();
        }

        public async Task UpdateStockItem(StockItem stockItem)
        {
            StockItem? existingStockItem = await appDb.StockItems.FindAsync(stockItem.Id);
            if (existingStockItem == null)
            {
                throw new EntityNotFoundException($"StockItem with ID='{stockItem.Id}' not found");
            }
            appDb.Entry(existingStockItem).CurrentValues.SetValues(stockItem);
            await appDb.SaveChangesAsync();
        }
    }
}
