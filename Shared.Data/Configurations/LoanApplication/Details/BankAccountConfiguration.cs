using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class BankAccountConfiguration : BaseEntityConfigurations<BankAccount>
    {
        public override void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.BIC).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Number).HasMaxLength(100).IsRequired();
        }
    }
}
