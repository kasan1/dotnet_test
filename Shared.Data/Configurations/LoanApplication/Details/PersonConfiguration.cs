using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class PersonConfiguration : BaseEntityConfigurations<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.BirthPlace).HasMaxLength(1000);
            builder.Property(e => e.Spouse).HasMaxLength(500);
            builder.Property(e => e.Education).HasMaxLength(1000);
        }
    }
}
