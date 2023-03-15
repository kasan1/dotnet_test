using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class AddressConfiguration : BaseEntityConfigurations<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Fact).HasMaxLength(1000);
            builder.Property(e => e.Register).HasMaxLength(1000);
        }
    }
}
