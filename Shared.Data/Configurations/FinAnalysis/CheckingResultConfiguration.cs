using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.FinAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.FinAnalysis
{
    public class CheckingResultConfiguration : BaseEntityConfigurations<CheckingResult>
    {
        #region Public functions

        public override void Configure(EntityTypeBuilder<CheckingResult> builder)
        {
            base.Configure(builder);
        }

        #endregion

    }
}
