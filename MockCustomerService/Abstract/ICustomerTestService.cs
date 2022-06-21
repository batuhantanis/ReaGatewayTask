using System.Collections.Generic;
using Data.Entities.Concrete;

namespace MockCustomerService.Abstract
{
    public interface ICustomerTestService
    {
        public List<CustomerEntity> GetCustomersList();
        
        public CustomerEntity GetCustomer(int id);
        
        public bool CreateCustomer();

        public bool  UpdateCustomer(CustomerEntity entity);

        public bool  DeleteCustomer(int id);
    }
}