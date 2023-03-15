using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Agro.Shared.Data.Configurations.Dictionaries
{
    public class DicCheckingListTypeConfiguration : BaseDictionaryConfigurations<DicCheckingListType>
    {
        #region Public

        public override void Configure(EntityTypeBuilder<DicCheckingListType> builder)
        {
            base.Configure(builder);

            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicCheckingListType}"/></param>
        public static void SeedData(EntityTypeBuilder<DicCheckingListType> builder)
        {
            builder.HasData(
                new DicCheckingListType
                {
                    Id = Guid.Parse("EC8EAAEF-15AA-4180-9405-BD27BC7BAFE8"),
                    Code = "SpecialRelations",
                    NameRu = "Особые отношения",
                    NameKk = "Ерекше байланыстар"
                },
                new DicCheckingListType
                {
                    Id = Guid.Parse("11C06DE2-7ED7-4415-8E94-A01B48529C56"),
                    Code = "AffiliationPersonalities",
                    NameRu = "Аффилированные лица",
                    NameKk = "Аффилированные лица"
                }
            );
        }

        #endregion
    }
}
