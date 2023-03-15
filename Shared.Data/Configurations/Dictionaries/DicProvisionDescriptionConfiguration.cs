using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicProvisionDescriptionConfiguration : BaseDictionaryConfigurations<DicProvisionDescription>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicProvisionDescription> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicProvisionDescription}"/></param>
        public static void SeedData(EntityTypeBuilder<DicProvisionDescription> builder)
        {
            builder.HasData(
                new DicProvisionDescription
                {
                    Id = Guid.Parse("03723EEB-7807-44A8-92B4-EBE52825B652"),
                    Code = "0",
                    NameRu = "Не указано",
                    NameKk = ""
                }
            );
        }

        #endregion
    }
}
