using Agro.Shared.Data.Entities.FinAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.Base
{
    public class BaseCheckItemConfigurations<TEntity> : BaseEntityConfigurations<TEntity>
        where TEntity : BaseCheckItem
    {
        #region Public functions

        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Identifier).HasMaxLength(12).IsRequired();
            builder.Property(x => x.Fullname).HasMaxLength(500).IsRequired();
        }

        #endregion
    }
}
