using System;
using System.Collections.Generic;
using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Concrete
{
    public class ProductMapping : BaseEntityMapping<ProductEntity>
    {
        public override void upConfigure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired();

            // Data Ekleme
            builder.HasData(
                new List<ProductEntity>()
                {
                    new ProductEntity()
                    {
                        Id = 1,
                        Name = "1. Product",
                        ImageUrl = "https://w.wallhaven.cc/full/k7/wallhaven-k7q9m7.png",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ProductEntity()
                    {
                        Id = 2,
                        Name = "2. Product",
                        ImageUrl = "https://w.wallhaven.cc/full/k7/wallhaven-k7q9m7.png",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ProductEntity()
                    {
                        Id = 3,
                        Name = "3. Product",
                        ImageUrl = "https://w.wallhaven.cc/full/k7/wallhaven-k7q9m7.png",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ProductEntity()
                    {
                        Id = 4,
                        Name = "4. Product",
                        ImageUrl = "https://w.wallhaven.cc/full/k7/wallhaven-k7q9m7.png",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ProductEntity()
                    {
                        Id = 5,
                        Name = "5. Product",
                        ImageUrl = "https://w.wallhaven.cc/full/k7/wallhaven-k7q9m7.png",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                }

            );

        }
    }
}