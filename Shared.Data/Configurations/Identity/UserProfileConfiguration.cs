using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.Identity
{
    public class UserProfileConfiguration : BaseEntityConfigurations<UserProfile>
    {
        public override void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(e => e.LastName)
                .HasMaxLength(100);
            builder.Property(e => e.Patronymic)
                .HasMaxLength(100);

            builder.Property(e => e.Identifier)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
