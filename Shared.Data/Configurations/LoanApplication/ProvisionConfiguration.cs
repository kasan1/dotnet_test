using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication
{
    public class ProvisionConfiguration : BaseEntityConfigurations<Provision>
    {
        public override void Configure(EntityTypeBuilder<Provision> builder)
        {
            base.Configure(builder);
        }
    }
}
