using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.Notifications;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.Notifications
{
    public class NotificationConfiguration : BaseEntityConfigurations<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.TitleKk)
               .HasMaxLength(200);

            builder.Property(e => e.TitleRu)
                .HasMaxLength(200);
            
            builder.Property(e => e.BodyKk)
                .HasMaxLength(1000);

            builder.Property(e => e.BodyRu)
                .HasMaxLength(1000);
        }
    }
}
