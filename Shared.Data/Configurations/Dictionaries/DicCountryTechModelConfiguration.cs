using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicCountryTechModelConfiguration : BaseEntityConfigurations<DicCountryTechModel>
    {
        #region Public

        public override void Configure(EntityTypeBuilder<DicCountryTechModel> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.DicCountry)
                .WithMany(e => e.DicCountryTechModels)
                .HasForeignKey(e => e.DicCountryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.DicTechModel)
                .WithMany(e => e.DicCountryTechModels)
                .HasForeignKey(e => e.DicTechModelId)
                .OnDelete(DeleteBehavior.NoAction);

        }

        #endregion

        
    }
}
