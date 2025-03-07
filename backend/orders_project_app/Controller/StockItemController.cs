using Microsoft.AspNetCore.Mvc;
using orders_project_app.Model.Dto;
using orders_project_app.Service.Interface;

namespace orders_project_app.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockItemController(IStockItemService stockItemService) : ControllerBase
    {
        [HttpGet]
        public async Task<List<StockItemDto>> GetStockItems()
        {
            return await stockItemService.GetStockItems();
        }

        [HttpGet("{id}")]
        public async Task<StockItemDto> GetStockItemById(int id)
        {
            return await stockItemService.GetStockItemById(id);
        }

        [HttpPost]
        public async Task AddStockItem(StockItemCreateDto stockItem)
        {
            await stockItemService.AddStockItem(stockItem);
        }

        [HttpPut]
        public async Task UpdateStockItem(StockItemCreateDto stockItem)
        {
            await stockItemService.UpdateStockItem(stockItem);
        }

        [HttpDelete("{id}")]
        public async Task DeleteStockItem(int id)
        {
            await stockItemService.DeleteStockItem(id);
        }
    }
}
