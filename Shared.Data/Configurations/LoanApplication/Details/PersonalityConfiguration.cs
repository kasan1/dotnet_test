using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class PersonalityConfiguration : BaseEntityConfigurations<Personality>
    {
        public override void Configure(EntityTypeBuilder<Personality> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Email).HasMaxLength(200);
            builder.Property(e => e.Fax).HasMaxLength(100);
            builder.Property(e => e.Identifier).HasMaxLength(20);
            builder.Property(e => e.FullName).HasMaxLength(1000);
        }
    }
}
