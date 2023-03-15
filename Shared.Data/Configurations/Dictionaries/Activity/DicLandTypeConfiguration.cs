using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicLandTypeConfiguration : BaseDictionaryConfigurations<DicLandType>
    {
        #region Public functions

        public override void Configure(EntityTypeBuilder<DicLandType> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicLandType}"/></param>
        public static void SeedData(EntityTypeBuilder<DicLandType> builder)
        {
            builder.HasData(
                new DicLandType
                {
                    Id = Guid.Parse("21854d74-6899-4216-a3e1-6537dc977586"),
                    Code = "1",
                    NameRu = "Посевная площадь",
                    NameKk = "Посевная площадь"
                },
                new DicLandType
                {
                    Id = Guid.Parse("6c293f35-6171-43b1-868a-67632db8d1a4"),
                    Code = "2",
                    NameRu = "Пастбище",
                    NameKk = "Пастбище"
                },
                new DicLandType
                {
                    Id = Guid.Parse("422adcdf-e13d-441e-a4aa-c88fdc741457"),
                    Code = "3",
                    NameRu = "Прочие земли",
                    NameKk = "Прочие земли"
                }
            );
        }

        #endregion
    }
}
