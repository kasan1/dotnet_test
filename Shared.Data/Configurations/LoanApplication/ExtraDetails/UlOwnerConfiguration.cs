using Agro.Shared.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.ExtraDetails
{
    public class UlOwnerConfiguration : BaseEntityConfigurations<Entities.ClientExtraDetails.UlOwner>
    {
        public override void Configure(EntityTypeBuilder<Entities.ClientExtraDetails.UlOwner> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Rate).IsRequired();
        }
    }
}
