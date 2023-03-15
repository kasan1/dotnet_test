using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicRegionConfiguration : BaseEntityConfigurations<DicRegion>
    {
        #region Public

        public override void Configure(EntityTypeBuilder<DicRegion> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.AdministrativeCenterRu).HasMaxLength(100);
            builder.Property(x => x.AdministrativeCenterKk).HasMaxLength(100);
        }

        #endregion

        
    }
}
