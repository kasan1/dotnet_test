using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicTaxTreatmentConfiguration : BaseDictionaryConfigurations<DicTaxTreatment>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicTaxTreatment> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicTaxTreatment}"/></param>
        public static void SeedData(EntityTypeBuilder<DicTaxTreatment> builder)
        {
            builder.HasData(
                new DicTaxTreatment
                {
                    Id = Guid.Parse("5586A71E-1277-4E90-9004-BAAD6745373A"),
                    Code = "Общеустановленный режим",
                    NameRu = "Общеустановленный режим",
                    NameKk = ""
                },
                new DicTaxTreatment
                {
                    Id = Guid.Parse("6E4E04A8-C8B2-4FAF-9A23-9A7D97DC60D0"),
                    Code = "Упрощенный режим",
                    NameRu = "Упрощенный режим",
                    NameKk = ""
                }
            );
        }

        #endregion
    }
}
