using Agro.Shared.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.ExtraDetails
{
    public class FlOwnerConfiguration : BaseEntityConfigurations<Entities.ClientExtraDetails.FlOwner>
    {
        public override void Configure(EntityTypeBuilder<Entities.ClientExtraDetails.FlOwner> builder)
        {
            base.Configure(builder);
        }
    }
}
