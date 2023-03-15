using Agro.Shared.Data.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.Base
{
    /// <summary>
    /// Base entity fields configuration
    /// </summary>
    /// <typeparam name="TEntity"><see cref="EntityBase"/> instance</typeparam>
    public class BaseEntityConfigurations<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        #region Public properties

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.CreatedDate).ValueGeneratedOnAdd().HasDefaultValueSql("getDate()").IsRequired();
            builder.Property(e => e.ModifiedDate).ValueGeneratedOnUpdate();
            builder.Property(e => e.IsDeleted).HasDefaultValue(false).IsRequired();

            builder.HasIndex(e => e.IsDeleted);
            builder.HasQueryFilter(e => !e.IsDeleted);
        }

        #endregion
    }
}
