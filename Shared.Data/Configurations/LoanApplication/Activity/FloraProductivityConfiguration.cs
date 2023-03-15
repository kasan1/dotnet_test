using Agro.Shared.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Activity
{
    public class FloraProductivityConfiguration : BaseEntityConfigurations<Context.LoanApplications.Activity.FloraProductivity>
    {
        public override void Configure(EntityTypeBuilder<Context.LoanApplications.Activity.FloraProductivity> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Year).IsRequired();
            builder.Property(e => e.Value).IsRequired();
        }
    }
}
