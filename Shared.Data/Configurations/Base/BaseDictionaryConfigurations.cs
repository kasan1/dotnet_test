using Agro.Shared.Data.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.Base
{
    /// <summary>
    /// Base dictionary fields configuration
    /// </summary>
    public class BaseDictionaryConfigurations<TEntity> : BaseEntityConfigurations<TEntity>
        where TEntity : BaseDictionary
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Code).HasMaxLength(50).IsRequired();
            builder.Property(e => e.NameRu).HasMaxLength(200).IsRequired();
            builder.Property(e => e.NameKk).HasMaxLength(200).IsRequired();
        }

        #endregion
    }
}
