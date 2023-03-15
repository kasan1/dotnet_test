using Agro.Shared.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Activity
{
    public class FloraActivityConfiguration : BaseEntityConfigurations<Context.LoanApplications.Activity.FloraActivity>
    {
        public override void Configure(EntityTypeBuilder<Context.LoanApplications.Activity.FloraActivity> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.PlannedSquare).IsRequired();
            builder.Property(e => e.PriceRealization).IsRequired();
        }
    }
}
