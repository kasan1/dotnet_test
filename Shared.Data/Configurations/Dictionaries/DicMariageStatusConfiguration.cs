using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicMariageStatusConfiguration : BaseDictionaryConfigurations<DicMariageStatus>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicMariageStatus> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicMariageStatus}"/></param>
        public static void SeedData(EntityTypeBuilder<DicMariageStatus> builder)
        {
            builder.HasData(
                new DicMariageStatus
                {
                    Id = Guid.Parse("3528f2e8-478a-45bf-9271-26fcf09c7a5b"),
                    Code = "1",
                    NameRu = "Холост",
                    NameKk = "Бойдақ"
                },
                new DicMariageStatus
                {
                    Id = Guid.Parse("b5a5a1cf-b18d-4d2e-9f4e-e6c840a43419"),
                    Code = "2",
                    NameRu = "Состоит в браке",
                    NameKk = "Неке құрған"
                }
            );
        }

        #endregion
    }
}
