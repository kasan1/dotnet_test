using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class CreditHistoryConfiguration : BaseEntityConfigurations<CreditHistory>
    {
        public override void Configure(EntityTypeBuilder<CreditHistory> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Balance).IsRequired();
            builder.Property(e => e.DateIssue).IsRequired();
            builder.Property(e => e.Sum).IsRequired();
            builder.Property(e => e.Period).IsRequired();
            builder.Property(e => e.FullName).HasMaxLength(1000).IsRequired();
        }
    }
}
