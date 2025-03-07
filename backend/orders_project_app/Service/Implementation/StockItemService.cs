using orders_project_app.CustomException;
using orders_project_app.Model;
using orders_project_app.Model.Dto;
using orders_project_app.Repository.Interface;
using orders_project_app.Service.Interface;

namespace orders_project_app.Service.Implementation
{
    public class StockItemService(IStockItemRepository stockItemRepository) : IStockItemService
    {
        public async Task<List<StockItemDto>> GetStockItems()
        {
            List<StockItem> stockItems = await stockItemRepository.GetStockItems();
            List<StockItemDto> stockItemDtos = [];
            stockItems.ForEach(stockItem =>
            {
                StockItemDto stockItemDto = new StockItemDto
                {
                    Id = stockItem.Id,
                    Name = stockItem.Name,
                    UnitPrice = stockItem.UnitPrice,
                    Quantity = stockItem.Quantity
                };
                stockItemDtos.Add(stockItemDto);
            });
            return stockItemDtos;
        }

        public async Task<StockItemDto> GetStockItemById(int id)
        {
            StockItem stockItemEntity = await stockItemRepository.GetStockItemById(id);
            StockItemDto stockItemDto = new StockItemDto
            {
                Id = stockItemEntity.Id,
                Name = stockItemEntity.Name,
                UnitPrice = stockItemEntity.UnitPrice,
                Quantity = stockItemEntity.Quantity
            };
            return stockItemDto;
        }

        public async Task AddStockItem(StockItemCreateDto stockItem)
        {
            StockItem stockItemEntity = new StockItem
            {
                Name = stockItem.Name,
                UnitPrice = stockItem.UnitPrice,
                Quantity = stockItem.Quantity
            };
            await stockItemRepository.AddStockItem(stockItemEntity);
        }

        public async Task UpdateStockItem(StockItemCreateDto stockItem)
        {
            StockItem stockItemEntity = new StockItem
            {
                Name = stockItem.Name,
                UnitPrice = stockItem.UnitPrice,
                Quantity = stockItem.Quantity
            };
            await stockItemRepository.UpdateStockItem(stockItemEntity);
        }

        public async Task DeleteStockItem(int id)
        {
            await stockItemRepository.DeleteStockItem(id);
        }
    }
}
