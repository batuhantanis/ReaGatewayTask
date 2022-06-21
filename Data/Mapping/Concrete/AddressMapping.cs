using System;
using System.Collections.Generic;
using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Concrete
{
    public class AddressMapping : BaseEntityMapping<AddressEntity>
    {
        public override void upConfigure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Country).IsRequired();
            builder.Property(x => x.CityCode).IsRequired();
            builder.HasMany(x => x.Customer).WithOne(x => x.Address).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Orders).WithOne(x => x.Address).HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

            
            // Data Ekleme
            
            builder.HasData(
                new List<AddressEntity>()
                {
                    new AddressEntity()
                    {
                        Id = 1,
                        AddressLine = "1",
                        City = "Ankara",
                        Country = "Turkey",
                        CityCode = 6,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new AddressEntity()
                    {
                        Id = 2,
                        AddressLine = "2",
                        City = "İzmir",
                        Country = "Turkey",
                        CityCode = 35,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new AddressEntity()
                    {
                        Id = 3,
                        AddressLine = "3",
                        City = "NewYork",
                        Country = "America",
                        CityCode = 355,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new AddressEntity()
                    {
                        Id = 4,
                        AddressLine = "4",
                        City = "Los Angeles",
                        Country = "America",
                        CityCode = 365,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                }
            );
        }
    }
}