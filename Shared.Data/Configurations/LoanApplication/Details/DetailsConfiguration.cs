using Agro.Shared.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class DetailsConfiguration : BaseEntityConfigurations<Context.LoanApplications.Details>
    {
        public override void Configure(EntityTypeBuilder<Context.LoanApplications.Details> builder)
        {
            base.Configure(builder);
        }
    }
}
