using System;
using System.Collections.Generic;
using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Concrete
{
    public class OrderMapping : BaseEntityMapping<OrderEntity>
    {
        public override void upConfigure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.HasOne(x => x.Customer).WithMany(x => x.OrderEntities).HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Products).WithMany(x => x.OrderEntities);

            builder.HasOne(x => x.Address).WithMany(x => x.Orders).HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(

                // Data Ekleme
                new List<OrderEntity>()
                {
                    new OrderEntity()
                    {
                        Id = 1,
                        Quantity = 1,
                        Price = 180,
                        Status = "Transferred",
                        CustomerId = 1,
                        AddressId = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new OrderEntity()
                    {
                        Id = 2,
                        Quantity = 2,
                        Price = 5500,
                        Status = "NotPaid",
                        CustomerId = 2,
                        AddressId = 2,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new OrderEntity()
                    {
                        Id = 3,
                        Quantity = 3,
                        Price = 800,
                        Status = "Success",
                        CustomerId = 3,
                        AddressId = 4,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new OrderEntity()
                    {
                        Id = 4,
                        Quantity = 4,
                        Price = 225,
                        Status = "WaitingOrder",
                        CustomerId = 4,
                        AddressId = 3,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                }

            );
        }
    }
}