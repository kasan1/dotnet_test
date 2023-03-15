using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.Dictionaries
{
    public class DicApplicationStatusConfiguration : BaseDictionaryConfigurations<DicApplicationStatus>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicApplicationStatus> builder)
        {
            base.Configure(builder);

            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicApplicationStatus}"/></param>
        public static void SeedData(EntityTypeBuilder<DicApplicationStatus> builder)
        {
            builder.HasData(
                new DicApplicationStatus
                {
                    Id = Guid.Parse("3B8AC585-0FFB-40A8-B07F-403EE97472ED"),
                    Code = "Created",
                    NameRu = "Создан",
                    NameKk = "Құрылды"
                },
                new DicApplicationStatus
                {
                    Id = Guid.Parse("1F99F0DC-A463-4EB2-9F7C-DF736255AB06"),
                    Code = "Cancelled",
                    NameRu = "Отказано",
                    NameKk = "Қайтарылды"
                },
                new DicApplicationStatus
                {
                    Id = Guid.Parse("C010443C-A805-49FA-8C5D-3359F9575E0E"),
                    Code = "InWork",
                    NameRu = "В работе",
                    NameKk = "Қаралуда"
                },
                new DicApplicationStatus
                {
                    Id = Guid.Parse("6358C3D5-8E26-4BD9-92EA-150F89285381"),
                    Code = "Completed",
                    NameRu = "Завершено",
                    NameKk = "Аяқталды"
                }
            );
        }

        #endregion
    }
}
