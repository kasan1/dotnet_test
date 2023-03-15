using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.FinAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.FinAnalysis
{
    public class AffiliationPersonalityConfiguration : BaseCheckItemConfigurations<AffiliationPersonality>
    {
        #region Public functions

        public override void Configure(EntityTypeBuilder<AffiliationPersonality> builder)
        {
            base.Configure(builder);
        }

        #endregion

    }
}
