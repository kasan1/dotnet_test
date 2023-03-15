using Agro.Shared.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.Identity
{
    /// <summary>
    /// User entity configurations
    /// </summary>
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getDate()")
                .IsRequired();

            builder.Property(e => e.ModifiedDate)
                .ValueGeneratedOnUpdate();

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.UserAudienceType)
                .HasConversion<int>()
                .IsRequired();
            builder.Property(e => e.EssenceType)
                .HasConversion<int>()
                .IsRequired();

            builder.HasIndex(e => e.IsDeleted);
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(e => e.Profile)
                .WithOne(e => e.User)
                .HasForeignKey<UserProfile>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
