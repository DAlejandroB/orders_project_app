using orders_project_app.Model;
using orders_project_app.Model.Dto;

namespace orders_project_app.Service.Interface
{
    public interface IStockItemService
    {
        public Task<List<StockItemDto>> GetStockItems();
        public Task<StockItemDto> GetStockItemById(int id);
        public Task AddStockItem(StockItemCreateDto order);
        public Task UpdateStockItem(StockItemCreateDto order);
        public Task DeleteStockItem(int id);
    }
}
