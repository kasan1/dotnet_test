using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicLivestockTypeConfiguration : BaseDictionaryConfigurations<DicLivestockType>
    {
        #region Public functions

        public override void Configure(EntityTypeBuilder<DicLivestockType> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicLivestockType}"/></param>
        public static void SeedData(EntityTypeBuilder<DicLivestockType> builder)
        {
            builder.HasData(
            #region КРС
                new DicLivestockType
                {
                    Id = Guid.Parse("39420e10-9f02-476e-9825-cb5bb723f6d7"),
                    Code = "1",
                    NameRu = "КРС",
                    NameKk = "Ірі-қара"
                },
                new DicLivestockType
                {
                    Id = Guid.Parse("8e357937-2187-4bc6-a86c-9e1027e8a00e"),
                    ParentId = Guid.Parse("39420e10-9f02-476e-9825-cb5bb723f6d7"),
                    Code = "101",
                    NameRu = "Коровы",
                    NameKk = "Сиыр"
                },
                new DicLivestockType
                {
                    Id = Guid.Parse("d42d930f-516f-4878-9ebb-b6840004f9fd"),
                    ParentId = Guid.Parse("39420e10-9f02-476e-9825-cb5bb723f6d7"),
                    Code = "102",
                    NameRu = "Быки-производители",
                    NameKk = "Бұқалар"
                },
            #endregion
            #region Лошади
                new DicLivestockType
                {
                    Id = Guid.Parse("19de03b5-a84d-45dc-9144-ec12bcb65229"),
                    Code = "2",
                    NameRu = "Лошади",
                    NameKk = "Жылқылар"
                },
                new DicLivestockType
                {
                    Id= Guid.Parse("38906768-e79a-42a6-ab41-6edc04a45ab6"),
                    ParentId = Guid.Parse("19de03b5-a84d-45dc-9144-ec12bcb65229"),
                    Code = "201",
                    NameRu = "Жеребцы-производели",
                    NameKk = "Жеребцы-производели"
                },
                new DicLivestockType
                {
                    Id = Guid.Parse("c64ce880-75f5-4945-baf7-ce9d386aa124"),
                    ParentId = Guid.Parse("19de03b5-a84d-45dc-9144-ec12bcb65229"),
                    Code = "202",
                    NameRu = "Конематки",
                    NameKk = "Конематки"
                },
            #endregion
            #region МРС
                new DicLivestockType
                {
                    Id = Guid.Parse("75c47257-4c30-4766-9d7c-eca44cd5246f"),
                    Code = "3",
                    NameRu = "МРС",
                    NameKk = "МРС"
                },
                new DicLivestockType
                {
                    Id = Guid.Parse("103eec83-a1fc-4aed-9f40-006eefe5560f"),
                    ParentId = Guid.Parse("75c47257-4c30-4766-9d7c-eca44cd5246f"),
                    Code = "301",
                    NameRu = "Бараны-производители",
                    NameKk = "Бараны-производители"
                },
                new DicLivestockType
                {
                    Id = Guid.Parse("6130aa9f-e554-4a58-8dbf-d87cda176b5c"),
                    ParentId = Guid.Parse("75c47257-4c30-4766-9d7c-eca44cd5246f"),
                    Code = "302",
                    NameRu = "Овцематки",
                    NameKk = "Овцематки"
                }

                #endregion
            );
        }

        #endregion
    }
}
