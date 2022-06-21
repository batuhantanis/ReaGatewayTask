using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities.Concrete;

namespace Order.Domain.Services.Abstract
{
    public interface IOrderService
    {
        public Task<List<OrderEntity>>  GetOrdersList();
        public Task<OrderEntity> GetOrder(int id);
        
        public Task<bool> CreateOrder(OrderEntity entity);
        public Task<bool>  CreateOrderList(List<OrderEntity> entity);

        public Task<bool>  UpdateOrder(OrderEntity entity);
        public Task<bool>  UpdateOrderList(List<OrderEntity> entities);

        public Task<bool>  DeleteOrder(int id);
        public Task<bool>  DeleteOrderList(List<OrderEntity> entities);

        public Task<bool> ChangeStatus(int id,string status);
    }
}