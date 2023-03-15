using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    /// <summary>
    /// File fields configuration
    /// </summary>
    public class FileConfiguration : BaseEntityConfigurations<File>
    {
        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<File> builder)
        {
            base.Configure(builder);

            builder.HasKey(e => e.Id);
            builder.Property(e => e.EntityId).HasMaxLength(100).IsRequired();
            builder.Property(e => e.EntityTypeId).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Filename).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Length).IsRequired();
            builder.Property(e => e.ContentType).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Path).HasMaxLength(500).IsRequired();
        }
    }
}
