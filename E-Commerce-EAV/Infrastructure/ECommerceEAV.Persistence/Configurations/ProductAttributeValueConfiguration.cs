using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceEAV.Domain.Models;

namespace ECommerceEAV.Persistence.Configurations
{
    public class ProductAttributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasIndex(x => new { x.ProductId, x.ProductAttributeId })
                .IsUnique();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductAttributeValues)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ProductAttribute)
                .WithMany(x => x.ProductAttributeValues)
                .HasForeignKey(x => x.ProductAttributeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}







