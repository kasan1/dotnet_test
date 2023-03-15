using Agro.Shared.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Activity
{
    public class LandActivityConfiguration : BaseEntityConfigurations<Context.LoanApplications.Activity.LandActivity>
    {
        public override void Configure(EntityTypeBuilder<Context.LoanApplications.Activity.LandActivity> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Square).IsRequired();
        }
    }
}
