using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicSubjectOfEntrepreneurConfiguration : BaseDictionaryConfigurations<DicSubjectOfEntrepreneur>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicSubjectOfEntrepreneur> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicSubjectOfEntrepreneur}"/></param>
        public static void SeedData(EntityTypeBuilder<DicSubjectOfEntrepreneur> builder)
        {
            builder.HasData(
                new DicSubjectOfEntrepreneur
                {
                    Id = Guid.Parse("70CD9AA2-DA90-40B0-B62E-D1C26FFCD2FD"),
                    Code = "Малый бизнес",
                    NameRu = "Малый бизнес",
                    NameKk = ""
                },
                new DicSubjectOfEntrepreneur
                {
                    Id = Guid.Parse("0182D1E3-D239-4F24-9AB2-696BF41ABE3D"),
                    Code = "Средний бизнес",
                    NameRu = "Средний бизнес",
                    NameKk = ""
                },
                new DicSubjectOfEntrepreneur
                {
                    Id = Guid.Parse("8DC3046C-1D81-48B1-8B08-6D333378FE2E"),
                    Code = "Крупный бизнес",
                    NameRu = "Крупный бизнес",
                    NameKk = ""
                }
            );
        }

        #endregion
    }
}
