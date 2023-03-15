using Agro.Shared.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Activity
{
    public class LivestockActivityConfiguration : BaseEntityConfigurations<Context.LoanApplications.Activity.LivestockActivity>
    {
        public override void Configure(EntityTypeBuilder<Context.LoanApplications.Activity.LivestockActivity> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Count).IsRequired();
            builder.Property(e => e.LiveWeight).IsRequired();
            builder.Property(e => e.SlaughterWeight).IsRequired();
        }
    }
}
