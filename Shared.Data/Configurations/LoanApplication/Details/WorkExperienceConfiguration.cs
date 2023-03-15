using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class WorkExperienceConfiguration : BaseEntityConfigurations<WorkExperience>
    {
        public override void Configure(EntityTypeBuilder<WorkExperience> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Total).HasMaxLength(200);
            builder.Property(e => e.Agriculture).HasMaxLength(200);
        }
    }
}
