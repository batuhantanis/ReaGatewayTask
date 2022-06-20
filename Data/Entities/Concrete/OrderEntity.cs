using System.Collections.Generic;
using Data.Entities.Abstract;

namespace Data.Entities.Concrete
{
    public class OrderEntity : BaseEntity,IEntity
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }


        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }


        
        public ICollection<ProductEntity> Products { get; set; }


        public int AddressId { get; set; }
        public AddressEntity Address { get; set; }
    }
}