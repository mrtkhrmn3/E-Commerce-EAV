using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceEAV.Domain.Models;

namespace ECommerceEAV.Persistence.Configurations
{
    public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.HasMany(x => x.ProductAttributeValues)
                .WithOne(x => x.ProductAttribute)
                .HasForeignKey(x => x.ProductAttributeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}







