using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities.Concrete;
using Data.Repository.Abstract;
using Order.Domain.Services.Abstract;

namespace Order.Domain.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<OrderEntity>> GetOrdersList()
        {
            var orders = await _unitOfWork.Order.GetAll(null,null,new List<string>(){"Customer.Address","Address","Products"});
            return orders.ToList();
        }

        public async Task<OrderEntity> GetOrder(int id)
        {
            var order = await _unitOfWork.Order.Get(x => x.Id == id,new List<string>(){"Customer.Address","Address","Products"});
            return order;
        }

        public async Task<bool> CreateOrder(OrderEntity entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Order.Insert(entity);
                await _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public async Task<bool> CreateOrderList(List<OrderEntity> entities)
        {
            if (entities.Count != 0 )
            {
                await _unitOfWork.Order.InsertRange(entities);
                await _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateOrder(OrderEntity entity)
        {
            if (entity != null)
            {
                _unitOfWork.Order.Update(entity);
                await _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateOrderList(List<OrderEntity> entities)
        {
            if (entities.Count != 0)
            {
                foreach (OrderEntity entity in entities)
                {
                    _unitOfWork.Order.Update(entity);
                }
                
                await _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            if (id != 0)
            {
                await _unitOfWork.Order.Delete(id);
                await _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteOrderList(List<OrderEntity> entities)
        {
            if (entities.Any())
            {
                 _unitOfWork.Order.DeleteRange(entities);
                 await _unitOfWork.Save();
                 return true;
            }

            return false;
        }

        public async Task<bool> ChangeStatus(int id,string status)
        {
            if (id != 0 && !string.IsNullOrEmpty(status))
            {
               var order = await _unitOfWork.Order.Get(x => x.Id == id);
               order.Status = status;
               _unitOfWork.Order.Update(order);
               await _unitOfWork.Save();
               return true;
            }

            return false;
        }
    }
}