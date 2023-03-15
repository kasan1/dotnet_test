using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agro.Shared.Data.Configurations.System
{
    /// <summary>
    /// Entity type fields configuration
    /// </summary>
    public class EntityTypeConfiguration : BaseEntityConfigurations<Entities.System.EntityType>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<Entities.System.EntityType> builder)
        {
            base.Configure(builder);

            builder.HasKey(e => e.Id);
            builder.Property(e => e.SystemName).HasMaxLength(100).IsRequired();
            builder.HasIndex(e => e.SystemName).IsUnique();
            builder.Property(e => e.Description).HasMaxLength(500).IsRequired();

            var converter = new EnumToNumberConverter<Enums.System.EntityType, int>();
            builder.Property(e => e.EntityTypeId)
                .HasConversion(converter)
                .IsRequired();

            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{EntityType}"/></param>
        public static void SeedData(EntityTypeBuilder<Entities.System.EntityType> builder)
        {
            builder.HasData(
                new Entities.System.EntityType
                {
                    Id = Guid.Parse("1C32C956-310F-4ACF-9316-788E3D002D6E"),
                    SystemName = "LoanApplication",
                    Description = "Заявка",
                    EntityTypeId = Enums.System.EntityType.LoanApplication
                },
                new Entities.System.EntityType
                {
                    Id = Guid.Parse("99A11953-E980-4839-871C-E88659401AC6"),
                    SystemName = "LoanApplicationTask",
                    Description = "Задачи по заявке",
                    EntityTypeId = Enums.System.EntityType.LoanApplicationTask
                },
                new Entities.System.EntityType
                {
                    Id = Guid.Parse("71F8FFC5-8F64-41DF-9004-41529398DE84"),
                    SystemName = "PKB",
                    Description = "Файл из интеграции с PKB",
                    EntityTypeId = Enums.System.EntityType.PKB
                },
                new Entities.System.EntityType
                {
                    Id = Guid.Parse("83697C38-A05B-4A62-BB6D-17E1C51295B9"),
                    SystemName = "Comment",
                    Description = "Файл замечания",
                    EntityTypeId = Enums.System.EntityType.Comment
                },
                new Entities.System.EntityType
                {
                    Id = Guid.Parse("87301b5b-c361-4fe4-8a9f-5aa2e30ae24e"),
                    SystemName = "GKB",
                    Description = "Файл из интеграции с GKB",
                    EntityTypeId = Enums.System.EntityType.GKB
                },
                new Entities.System.EntityType
                {
                    Id = Guid.Parse("70c12155-26c0-41b2-b437-0a2ab751426e"),
                    SystemName = "Personality",
                    Description = "Личные данные",
                    EntityTypeId = Enums.System.EntityType.Personality
                },
                new Entities.System.EntityType
                {
                    Id = Guid.Parse("4b5b026a-72b9-4ffb-b398-4d6c85181549"),
                    SystemName = "UserImage",
                    Description = "Фото пользователя",
                    EntityTypeId = Enums.System.EntityType.UserImage
                },
                new EntityType
                {
                    Id = Guid.Parse("7DC0C71F-4A8E-4BC7-9FFD-1AB292845140"),
                    SystemName = nameof(Enums.System.EntityType.PaymentSchedule),
                    EntityTypeId = Enums.System.EntityType.PaymentSchedule,
                    Description = "Файл графика платежей"
                }
            );
        }

        #endregion
    }
}
