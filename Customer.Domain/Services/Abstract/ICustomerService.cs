using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities.Concrete;

namespace Customer.Domain.Services.Abstract
{
    public interface ICustomerService
    {
        public Task<List<CustomerEntity>>  GetCustomersList();
        public Task<CustomerEntity> GetCustomer(int id);
        
        public Task<bool> CreateCustomer(CustomerEntity entity);
        public Task<bool>  CreateCustomerList(List<CustomerEntity> entity);

        public Task<bool>  UpdateCustomer(CustomerEntity entity);
        public Task<bool>  UpdateCustomerList(List<CustomerEntity> entities);

        public Task<bool>  DeleteCustomer(int id);
        public Task<bool>  DeleteCustomerList(List<CustomerEntity> entities);

    }
}