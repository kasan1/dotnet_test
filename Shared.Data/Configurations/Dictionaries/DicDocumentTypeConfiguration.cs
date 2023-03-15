using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Primitives;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicDocumentTypeConfiguration : BaseDictionaryConfigurations<DicDocumentType>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicDocumentType> builder)
        {
            base.Configure(builder);

            var converter = new EnumToNumberConverter<DocumentTypeEnum, int>();
            builder.Property(e => e.DocumentType)
                .HasConversion(converter)
                .IsRequired();

            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicDocumentType}"/></param>
        public static void SeedData(EntityTypeBuilder<DicDocumentType> builder)
        {
            builder.HasData(
                new DicDocumentType
                {
                    Id = Guid.Parse("fb5701f8-c3c3-444d-b9e3-c601b66f8d19"),
                    Code = ((int)DocumentTypeEnum.Default).ToString(),
                    DocumentType = DocumentTypeEnum.Default,
                    NameRu = "Не определен",
                    NameKk = "Анықталмаған"
                },
                new DicDocumentType
                {
                    Id = Guid.Parse("069ced37-3155-48a7-855a-25b2c4a2cc4c"),
                    Code = ((int)DocumentTypeEnum.Identification).ToString(),
                    DocumentType = DocumentTypeEnum.Identification,
                    NameRu = "Идентифицирующий",
                    NameKk = "Идентифицирующий"
                },
                new DicDocumentType
                {
                    Id = Guid.Parse("e4672721-4794-423b-adcc-fcdcfa95017d"),
                    Code = ((int)DocumentTypeEnum.Registration).ToString(),
                    DocumentType = DocumentTypeEnum.Registration,
                    NameRu = "Регистрационный",
                    NameKk = "Тіркеу туралы"
                },
                new DicDocumentType
                {
                    Id = Guid.Parse("A1D306C4-8724-4254-9571-7FEA556AAC0B"),
                    Code = ((int)DocumentTypeEnum.License).ToString(),
                    DocumentType = DocumentTypeEnum.License,
                    NameRu = "License",
                    NameKk = ""
                },
                new DicDocumentType
                {
                    Id = Guid.Parse("C081BE33-A850-4A4C-A2B8-99E6486E7DAE"),
                    Code = ((int)DocumentTypeEnum.VatCertificate).ToString(),
                    DocumentType = DocumentTypeEnum.VatCertificate,
                    NameRu = "VatCertificate",
                    NameKk = ""
                }
            );
        }

        #endregion
    }
}
