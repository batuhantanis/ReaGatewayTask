using System.Collections.Generic;
using Data.Entities.Concrete;

namespace MockOrderService.Abstract
{
    public interface IOrderTestService
    {
        public  List<OrderEntity>  GetOrdersList();
        public OrderEntity GetOrder(int id);
        public bool CreateOrder();
        public bool  UpdateOrder(OrderEntity entity);
        public bool  DeleteOrder(int id);
    }
}