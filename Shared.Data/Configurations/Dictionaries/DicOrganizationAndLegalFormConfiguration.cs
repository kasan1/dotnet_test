using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicOrganizationAndLegalFormConfiguration : BaseDictionaryConfigurations<DicOrganizationAndLegalForm>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicOrganizationAndLegalForm> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicOrganizationAndLegalForm}"/></param>
        public static void SeedData(EntityTypeBuilder<DicOrganizationAndLegalForm> builder)
        {
            builder.HasData(
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("31045F1D-E216-4724-B733-0C813458DF47"),
                    Code = "78",
                    NameRu = "Индивидуальное предпринимательство (личное)",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("D0FD8C31-85C6-4C1E-8C19-9C889BB30F54"),
                    Code = "79",
                    NameRu = "Индивидуальное предпринимательство на основе совместного предпринимательства",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("761DB84D-FCA9-4259-A877-1B191064A392"),
                    Code = "99",
                    NameRu = "Физическое лицо",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("AA7DFC1A-F9C7-4421-9442-5C7E2D7D039F"),
                    Code = "10",
                    NameRu = "Государственные предприятия",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("3D037D07-88E2-4526-92FD-CBC9B448DA7E"),
                    Code = "11",
                    NameRu = "Государственные предприятия на праве хозяйственного ведения",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("633D6F99-EAFC-4CF0-8C5A-2370281C06E0"),
                    Code = "12",
                    NameRu = "Государственные предприятия на праве оперативного управления (казенные)",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("C2AA4F5C-1FF6-47AF-8E34-FA13D0FBED43"),
                    Code = "99",
                    NameRu = "ХТ",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("C1F24C5E-7486-4BD6-8090-5F65C4ADB99D"),
                    Code = "18",
                    NameRu = "Полные товарищества",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("8EADE30A-1320-4154-BC6E-E7A9B02F7268"),
                    Code = "19",
                    NameRu = "Коммандитные товарищества",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("D2BB8C4B-BDEE-4243-9F51-ACAE44EB2B6F"),
                    Code = "20",
                    NameRu = "Товарищества с ограниченной ответственностью",
                    NameKk = "",
                    Value = Primitives.OrganizationAndLegalFormEnum.Juridical
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("A558FB37-9629-46C7-A166-E412D5B68C8B"),
                    Code = "21",
                    NameRu = "Товарищества с дополнительной ответственностью",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("F3ECE3A8-467E-4A12-88FF-5951019BBF88"),
                    Code = "24",
                    NameRu = "Акционерные общества",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("ACC57629-9CBA-4D9D-AB00-463CA6A67021"),
                    Code = "46",
                    NameRu = "Другая организационно-правовая форма",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("697855DA-0E5B-4330-A726-92E549B9627A"),
                    Code = "27",
                    NameRu = "Производственные кооперативы",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("05ECBBFC-C105-4C2A-AC03-29771BDAA214"),
                    Code = "35",
                    NameRu = "Учреждения",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("365D1398-7ECC-466A-B29B-F873B91B0723"),
                    Code = "36",
                    NameRu = "Общественные объединения",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("C5113802-4685-4E58-8B02-ECE7855936E7"),
                    Code = "37",
                    NameRu = "Потребительские кооперативы",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("13FC0DB5-B864-4003-91F3-38C40C75C28B"),
                    Code = "38",
                    NameRu = "Фонды",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("BF201F21-E129-428B-B64C-F5E769B56598"),
                    Code = "39",
                    NameRu = "Религиозные объединения",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("5E3A4716-0300-44F1-B39A-2DC9F009B9B9"),
                    Code = "40",
                    NameRu = "Объединения юридических лиц в форме ассоциаций",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("B1C33FC0-91FA-4126-B4C7-EB3137C8E005"),
                    Code = "52",
                    NameRu = "Сельскохозяйственные товарищества",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("4C4CA9C9-0678-4F9D-BCE7-0B172C2525EF"),
                    Code = "99",
                    NameRu = "ЛП",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("FCD4A268-39C0-41E7-B78C-8327FF3606F0"),
                    Code = "99",
                    NameRu = "Простое товарищество",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("E48790C7-C7E1-4368-97D0-6DBA8B7800D5"),
                    Code = "50",
                    NameRu = "ИП (совместное) - Предпринимательство супругов",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("C7A713D5-46B3-4019-8682-5ABE54779263"),
                    Code = "51",
                    NameRu = "ИП (совместное) - Семейное предпринимательство",
                    NameKk = ""
                },
                new DicOrganizationAndLegalForm
                {
                    Id = Guid.Parse("9614B496-8FAC-4764-AEA1-A8CA47776A93"),
                    Code = "53",
                    NameRu = "Иная организационно-правовая форма некоммерческой организации",
                    NameKk = ""
                }
            );
        }

        #endregion
    }
}
