using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicOrganizationTypeConfiguration : BaseDictionaryConfigurations<DicOrganizationType>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicOrganizationType> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicOrganizationType}"/></param>
        public static void SeedData(EntityTypeBuilder<DicOrganizationType> builder)
        {
            builder.HasData(
                new DicOrganizationType
                {
                    Id = Guid.Parse("e042625a-7e7b-45ab-8c3d-27aae5a7ff8c"),
                    Code = "1",
                    NameRu = "Юридическое лицо",
                    NameKk = "Заңды тұлға"
                },
                new DicOrganizationType
                {
                    Id = Guid.Parse("c1a9c736-2e5a-483c-9bf7-ff809d8efd60"),
                    Code = "2",
                    NameRu = "Индивидуальный предприниматель",
                    NameKk = "Жеке кәсіпкер"
                },
                new DicOrganizationType
                {
                    Id = Guid.Parse("e449c89b-3845-4081-aa8c-a6de6fad72fe"),
                    Code = "3",
                    NameRu = "Крестьянское хозяйство",
                    NameKk = "Крестьяндық шаруашылық"
                },
                new DicOrganizationType
                {
                    Id = Guid.Parse("8a3307a1-1b2e-4528-9c1f-1c82fb45e178"),
                    Code = "4",
                    NameRu = "Фермерское хозяйство",
                    NameKk = "Фермерлік шаруашылық"
                }
            );
        }

        #endregion
    }
}
