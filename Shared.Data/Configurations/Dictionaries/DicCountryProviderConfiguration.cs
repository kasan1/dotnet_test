using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicCountryProviderConfiguration : BaseEntityConfigurations<DicCountryProvider>
    {
        #region Public

        public override void Configure(EntityTypeBuilder<DicCountryProvider> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.DicCountry)
                .WithMany(e => e.DicCountryProviders)
                .HasForeignKey(e => e.DicCountryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.DicProvider)
                .WithMany(e => e.DicCountryProviders)
                .HasForeignKey(e => e.DicProviderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.DicTechModel)
                .WithMany(e => e.DicCountryProviders)
                .HasForeignKey(e => e.DicTechModelId)
                .OnDelete(DeleteBehavior.NoAction);

        }

        #endregion

        
    }
}
