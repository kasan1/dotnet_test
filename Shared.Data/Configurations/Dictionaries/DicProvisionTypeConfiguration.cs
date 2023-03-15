using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.Dictionaries;
using Agro.Shared.Data.Primitives;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agro.Shared.Data.Configurations.System
{
    /// <summary>
    /// Verification status dictionary fields configuration
    /// </summary>
    public class DicProvisionTypeConfiguration : BaseDictionaryConfigurations<DicProvisionType>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicProvisionType> builder)
        {
            base.Configure(builder);

            var converter = new EnumToNumberConverter<ProvisionTypeEnum, int>();
            builder.Property(e => e.Value)
                .HasConversion(converter)
                .IsRequired();

            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicProvisionType}"/></param>
        public static void SeedData(EntityTypeBuilder<DicProvisionType> builder)
        {
            builder.HasData(
                new DicProvisionType
                {
                    Id = Guid.Parse("8FC3A266-5E33-4138-9284-C47E05696CB3"),
                    Code = nameof(ProvisionTypeEnum.Pledge),
                    Value = ProvisionTypeEnum.Pledge,
                    NameRu = "Залог",
                    NameKk = ""
                }
            );
        }

        #endregion
    }
}
