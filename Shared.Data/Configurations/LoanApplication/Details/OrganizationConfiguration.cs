using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class OrganizationConfiguration : BaseEntityConfigurations<Organization>
    {
        public override void Configure(EntityTypeBuilder<Organization> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Parent).HasMaxLength(1000);
            builder.Property(e => e.HeadFullName).HasMaxLength(200);
            builder.Property(e => e.HeadIdentifier).HasMaxLength(12);
        }
    }
}
