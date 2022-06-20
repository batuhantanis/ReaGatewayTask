using System;
using System.Threading.Tasks;
using Data.Entities.Concrete;

namespace Data.Repository.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<OrderEntity> Order { get; }
        IGenericRepository<CustomerEntity> Customer { get; }
        IGenericRepository<ProductEntity> Product { get; }
        IGenericRepository<AddressEntity> Address { get; }
        Task Save();
    }
}