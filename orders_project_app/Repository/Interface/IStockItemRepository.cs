using orders_project_app.Model;

namespace orders_project_app.Repository.Interface
{
    public interface IStockItemRepository
    {
        public Task<List<StockItem>> GetStockItems();
        public Task<StockItem> GetStockItemById(int id);
        public StockItem AddStockItem(StockItem stockItem);
        public StockItem UpdateStockItem(StockItem stockItem);
        public StockItem DeleteStockItem(int id);
    }
}
