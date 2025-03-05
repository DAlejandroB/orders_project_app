using Microsoft.AspNetCore.Mvc;
using orders_project_app.Model;
using orders_project_app.Service.Interface;

namespace orders_project_app.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpGet]
        public async Task<List<Order>> GetOrders()
        {
            return await orderService.GetOrders();
        }

        [HttpGet("{id}")]
        public async Task<Order> GetOrderById(int id)
        {
            return await orderService.GetOrderById(id);
        }

        [HttpPost]
        public async Task AddOrder(Order order)
        {
            await orderService.AddOrder(order);
        }

        [HttpPut]
        public async Task UpdateOrder(Order order)
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
