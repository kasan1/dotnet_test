using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Primitives;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicLoanTypeConfiguration : BaseDictionaryConfigurations<DicLoanType>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicLoanType> builder)
        {
            base.Configure(builder);

            var converter = new EnumToNumberConverter<LoanTypeEnum, int>();
            builder.Property(e => e.Value)
                .HasConversion(converter)
                .IsRequired();

            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicLoanType}"/></param>
        public static void SeedData(EntityTypeBuilder<DicLoanType> builder)
        {
            builder.HasData(
                new DicLoanType
                {
                    Id = Guid.Parse("763B5CE2-7013-481C-A7D2-D237A4793035"),
                    Code = "1",
                    Value = LoanTypeEnum.Default,
                    NameRu = "ЛИЗИНГ",
                    NameKk = "ЛИЗИНГ"
                },
                new DicLoanType
                {
                    Id = Guid.Parse("FA1FBB94-E3A3-4482-970B-379EF3450B19"),
                    Code = "1.1",
                    Value = LoanTypeEnum.StandartLeasing,
                    NameRu = "Стандартный лизинг",
                    NameKk = "Стандартный лизинг"
                },
                new DicLoanType
                {
                    Id = Guid.Parse("74E65F85-7EC4-4909-8DC9-DE53FE9455EF"),
                    Code = "1.2",
                    Value = LoanTypeEnum.ExpressLeasing,
                    NameRu = "Экспресс лизинг",
                    NameKk = "Экспресс лизинг"
                }
            );
        }

        #endregion
    }
}
