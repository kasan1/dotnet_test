using Agro.Shared.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.ExtraDetails
{
    public class LicenseConfiguration : BaseEntityConfigurations<Entities.ClientExtraDetails.License>
    {
        public override void Configure(EntityTypeBuilder<Entities.ClientExtraDetails.License> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Essence).HasMaxLength(500).IsRequired();
        }
    }
}
