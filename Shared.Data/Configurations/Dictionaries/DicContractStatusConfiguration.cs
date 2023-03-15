using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.Dictionaries
{
    public class DicContractStatusConfiguration : BaseDictionaryConfigurations<DicContractStatus>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicContractStatus> builder)
        {
            base.Configure(builder);

            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicContractStatus}"/></param>
        public static void SeedData(EntityTypeBuilder<DicContractStatus> builder)
        {
            builder.HasData(
                new DicContractStatus
                {
                    Id = Guid.Parse("A9E17D62-72E1-4F4E-A361-3BADD4CD990D"),
                    Code = "Temp",
                    NameRu = "Временный",
                    NameKk = ""
                },
                new DicContractStatus
                {
                    Id = Guid.Parse("775D4CC1-7419-488F-A00C-29258466AAAF"),
                    Code = "Active",
                    NameRu = "Действующий",
                    NameKk = ""
                }
            );
        }

        #endregion
    }
}
