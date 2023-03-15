using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class DeptConfiguration : BaseEntityConfigurations<Dept>
    {
        public override void Configure(EntityTypeBuilder<Dept> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.BIC).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Value).IsRequired();
        }
    }
}
