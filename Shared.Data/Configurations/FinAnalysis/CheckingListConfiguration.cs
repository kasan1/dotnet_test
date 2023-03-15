using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.FinAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.FinAnalysis
{
    public class CheckingListConfiguration : BaseCheckItemConfigurations<CheckingList>
    {
        #region Public functions

        public override void Configure(EntityTypeBuilder<CheckingList> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Description).HasMaxLength(2000);
        }

        #endregion

    }
}
