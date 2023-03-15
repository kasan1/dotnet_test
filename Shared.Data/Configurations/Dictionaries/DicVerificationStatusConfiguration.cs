using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static Agro.Shared.Data.Context.PolicyRules;

namespace Agro.Shared.Data.Configurations.System
{
    /// <summary>
    /// Verification status dictionary fields configuration
    /// </summary>
    public class DicVerificationStatusConfiguration : BaseDictionaryConfigurations<DicVerificationStatus>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicVerificationStatus> builder)
        {
            base.Configure(builder);

            var converter = new EnumToNumberConverter<RejectStatuses, int>();
            builder.Property(e => e.Status)
                .HasConversion(converter)
                .IsRequired();

            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicVerificationStatus}"/></param>
        public static void SeedData(EntityTypeBuilder<DicVerificationStatus> builder)
        {
            builder.HasData(
                new DicVerificationStatus
                {
                    Id = Guid.Parse("9147caff-1fd0-4fb2-9216-1d4d354cd9a0"),
                    Code = ((int)RejectStatuses.ServiceUnavailable).ToString(),
                    Status = RejectStatuses.ServiceUnavailable,
                    NameRu = "Сервис не доступен",
                    NameKk = "Қызмет қол жетімді емес"
                },
                new DicVerificationStatus
                {
                    Id = Guid.Parse("5c792135-6524-4a12-bf48-dea59580f552"),
                    Code = ((int)RejectStatuses.Correct).ToString(),
                    Status = RejectStatuses.Correct,
                    NameRu = "Проверка пройдена",
                    NameKk = "Тексеруден өтті"
                },
                new DicVerificationStatus
                {
                    Id = Guid.Parse("9be3e547-c44e-418e-a9c7-6acfba833f71"),
                    Code = ((int)RejectStatuses.Minor).ToString(),
                    Status = RejectStatuses.Minor,
                    NameRu = "Устраняемый",
                    NameKk = "Жөнделетін"
                },
                new DicVerificationStatus
                {
                    Id = Guid.Parse("c60a9da0-816b-46e6-84a1-a3d4188a1e4a"),
                    Code = ((int)RejectStatuses.Critical).ToString(),
                    Status = RejectStatuses.Critical,
                    NameRu = "Не устраняемый",
                    NameKk = "Жөнделмейтін"
                }
            );
        }

        #endregion
    }
}
