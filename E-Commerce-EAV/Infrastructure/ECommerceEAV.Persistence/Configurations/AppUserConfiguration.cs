using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceEAV.Domain.Models;

namespace ECommerceEAV.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasIndex(x => x.UserName)
                .IsUnique();

            builder.HasOne(x => x.Profile)
                .WithOne(x => x.AppUser)
                .HasForeignKey<AppUserProfile>(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}







