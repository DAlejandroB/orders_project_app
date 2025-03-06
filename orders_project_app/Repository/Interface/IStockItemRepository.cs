using orders_project_app.Model;

namespace orders_project_app.Repository.Interface
{
    public interface IStockItemRepository
    {
        public Task<List<StockItem>> GetStockItems();
        public Task<StockItem> GetStockItemById(int id);
        public Task AddStockItem(StockItem stockItem);
        public Task UpdateStockItem(StockItem stockItem);
        public Task DeleteStockItem(int id);
    }
}
