using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Services.Abstract;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpGet("getorderlist")]
        public async Task<List<OrderEntity>> GetOrderList()
        {
            var orders = await _orderService.GetOrdersList();
            return orders;
        }
        
        
        [HttpGet("getorder/{id}")]
        public async Task<OrderEntity> GetOrder(int id)
        {
            var order = await _orderService.GetOrder(id);
            return order;
        }
        
        [HttpPost("createorder")]
        public async Task<bool> CreateOrder([FromBody] OrderEntity entity)
        {
            var res = await _orderService.CreateOrder(entity);
            return res;
        }
        
        [HttpPost("createorderlist")]
        public async Task<bool> CreateOrderList([FromBody] List<OrderEntity> entities)
        {
            var res = await _orderService.CreateOrderList(entities);
            return res;
        }
        
        [HttpPost("updateorder")]
        public async Task<bool> UpdateOrder([FromBody] OrderEntity entity)
        {
            var res = await _orderService.UpdateOrder(entity);
            return res;
        }
        
        [HttpPost("updateorderlist")]
        public async Task<bool> UpdateOrderList([FromBody] List<OrderEntity> entities)
        {
            var res = await _orderService.UpdateOrderList(entities);
            return res;
        }
        
        [HttpDelete("deleteorder/{id}")]
        public async Task<bool> DeleteOrder(int id)
        {
            var res = await _orderService.DeleteOrder(id);
            return res;
        }
        
        [HttpDelete("deleteorderlist")]
        public async Task<bool> DeleteOrderList([FromBody] List<OrderEntity> entities)
        {
            var res = await _orderService.DeleteOrderList(entities);
            return res;
        }

        [HttpPost("changestatus/{id}/{status}")]
        public async Task<bool> ChangeStatus(int id, string status)
        {
            var result = await _orderService.ChangeStatus(id, status);
            return result;
        }
    }
}