using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicOwnershipFormConfiguration : BaseDictionaryConfigurations<DicOwnershipForm>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicOwnershipForm> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicOwnershipForm}"/></param>
        public static void SeedData(EntityTypeBuilder<DicOwnershipForm> builder)
        {
            builder.HasData(
                new DicOrganizationType
                {
                    Id = Guid.Parse("173ba8e8-4f8b-40d6-802c-86987f9d1d29"),
                    Code = "1",
                    NameRu = "Индивидуальная собственность",
                    NameKk = "Жеке меншік"
                },
                new DicOrganizationType
                {
                    Id = Guid.Parse("c51c579e-a95a-440f-acf3-19ce2cb4e9bc"),
                    Code = "2",
                    NameRu = "Коллективная собственность",
                    NameKk = "Ұжымдық меншік"
                }
            );
        }

        #endregion
    }
}
