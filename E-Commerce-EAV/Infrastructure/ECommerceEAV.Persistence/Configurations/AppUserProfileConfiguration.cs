using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceEAV.Domain.Models;

namespace ECommerceEAV.Persistence.Configurations
{
    public class AppUserProfileConfiguration : IEntityTypeConfiguration<AppUserProfile>
    {
        public void Configure(EntityTypeBuilder<AppUserProfile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.AppUser)
                .WithOne(x => x.Profile)
                .HasForeignKey<AppUserProfile>(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}







