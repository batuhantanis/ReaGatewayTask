using System.Collections;
using System.Collections.Generic;
using Data.Entities.Abstract;

namespace Data.Entities.Concrete
{
    public class AddressEntity : BaseEntity,IEntity
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
        public List<CustomerEntity> Customer { get; set; }

        public ICollection<OrderEntity> Orders { get; set; }
    }
}