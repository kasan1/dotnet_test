using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicOwnershipTypeConfiguration : BaseDictionaryConfigurations<DicOwnershipType>
    {
        #region Public functions

        public override void Configure(EntityTypeBuilder<DicOwnershipType> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicOwnershipType}"/></param>
        public static void SeedData(EntityTypeBuilder<DicOwnershipType> builder)
        {
            builder.HasData(
                new DicOwnershipType
                {
                    Id = Guid.Parse("80f0bb4b-1742-47e3-9edd-14ac1a0885d9"),
                    Code = "1",
                    NameRu = "Собственность",
                    NameKk = "Меншік"
                },
                new DicOwnershipType
                {
                    Id = Guid.Parse("64767e74-6f0d-40b6-97e5-4ed609286204"),
                    Code = "2",
                    NameRu = "Аренда",
                    NameKk = "Жалға алу"
                }
            );
        }

        #endregion
    }
}
