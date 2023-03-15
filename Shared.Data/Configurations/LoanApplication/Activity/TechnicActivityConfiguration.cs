using Agro.Shared.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Activity
{
    public class TechnicActivityConfiguration : BaseEntityConfigurations<Context.LoanApplications.Activity.TechnicActivity>
    {
        public override void Configure(EntityTypeBuilder<Context.LoanApplications.Activity.TechnicActivity> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Count).IsRequired();
            builder.Property(e => e.DateIssue).IsRequired();
            builder.Property(e => e.Fullname).HasMaxLength(1000).IsRequired();
            builder.Property(e => e.PledgeDescription).HasMaxLength(4000);
        }
    }
}
