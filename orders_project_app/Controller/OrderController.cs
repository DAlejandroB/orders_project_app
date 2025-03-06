using Microsoft.AspNetCore.Mvc;
using orders_project_app.Model.Dto;
using orders_project_app.Service.Interface;

namespace orders_project_app.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpGet]
        public async Task<List<OrderDto>> GetOrders()
        {
            return await orderService.GetOrders();
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetOrderById(int id)
        {
            return await orderService.GetOrderById(id);
        }

        [HttpPost]
        public async Task AddOrder(OrderCreateDto order)
        {
            await orderService.AddOrder(order);
        }

        [HttpPut]
        public async Task UpdateOrder(OrderCreateDto order)
        {
            await orderService.UpdateOrder(order);
        }

        [HttpDelete("{id}")]
        public async Task DeleteOrder(int id)
        {
            await orderService.DeleteOrder(id);
        }
    }
}
