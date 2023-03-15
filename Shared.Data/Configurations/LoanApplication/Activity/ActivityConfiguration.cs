using Agro.Shared.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Activity
{
    public class ActivityConfiguration : BaseEntityConfigurations<Context.LoanApplications.Activity.Activity>
    {
        public override void Configure(EntityTypeBuilder<Context.LoanApplications.Activity.Activity> builder)
        {
            base.Configure(builder);
        }
    }
}
