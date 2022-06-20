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
            
        }
    }
}