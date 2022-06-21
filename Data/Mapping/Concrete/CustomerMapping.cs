using System;
using System.Collections.Generic;
using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Concrete
{
    public class CustomerMapping : BaseEntityMapping<CustomerEntity>
    {
        public override void upConfigure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.HasOne(x => x.Address).WithMany(x => x.Customer).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.OrderEntities).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Data Ekleme
            builder.HasData(
                new List<CustomerEntity>()
                {
                    new CustomerEntity()
                    {
                        Id = 1,
                        Name = "Batuhan",
                        Email = "test@hotmail.com",
                        AddressId = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new CustomerEntity()
                    {
                        Id = 2,
                        Name = "Mehmet",
                        Email = "mehmet@hotmail.com",
                        AddressId = 3,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new CustomerEntity()
                    {
                        Id = 3,
                        Name = "Jason",
                        Email = "jason@hotmail.com",
                        AddressId = 2,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new CustomerEntity()
                    {
                        Id = 4,
                        Name = "Haluk",
                        Email = "haluk@hotmail.com",
                        AddressId = 4,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                }
            );
        }
    }
}