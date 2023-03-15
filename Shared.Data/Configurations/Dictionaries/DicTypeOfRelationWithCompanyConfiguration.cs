using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicTypeOfRelationWithCompanyConfiguration : BaseDictionaryConfigurations<DicTypeOfRelationWithCompany>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicTypeOfRelationWithCompany> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicTypeOfRelationWithCompany}"/></param>
        public static void SeedData(EntityTypeBuilder<DicTypeOfRelationWithCompany> builder)
        {
            builder.HasData(
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("E1AFC962-9BF0-4421-8298-D055A1CC5806"), Code = "000000001", NameRu = "Супруг(а)", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("C061FD0D-15F5-4647-A1D3-BCFCCB2BC231"), Code = "000000002", NameRu = "Получатель отчета", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("3F83C606-2623-42FD-B283-9E715B035E4D"), Code = "000000003", NameRu = "Учредитель/Участник", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("4AFB7A4A-932C-4C61-956D-1D1F9D58500E"), Code = "000000004", NameRu = "Юрист", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("D348ED82-6AD8-4660-8844-1AA4C9C056E5"), Code = "000000005", NameRu = "Член совета директоров", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("B651FA25-BCA1-40BE-80A0-4DF61E72C95D"), Code = "000000006", NameRu = "Помощник администратора", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("F66F263A-BC09-43A3-B968-5D8DCED67A52"), Code = "000000007", NameRu = "Конкурент", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("B935C06B-E47A-48D7-8503-EDB54E0439D1"), Code = "000000008", NameRu = "Инвестор", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("BB3FB840-94D3-44ED-A080-FC9FD1E04B8D"), Code = "000000009", NameRu = "Связанный филиал", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("744E3F2F-81B0-4612-9404-5F38B0FFF5D6"), Code = "000000010", NameRu = "Партнер", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("584A502D-8BC0-4A50-893B-347C2A4D6F35"), Code = "000000011", NameRu = "Личный помощник", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("CEC13040-CF0F-4DD8-B179-4E52BFF32A0B"), Code = "000000012", NameRu = "Относится к", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("DF0CCA7F-0A9F-49D3-A31C-2BF206210D4D"), Code = "000000013", NameRu = "Источник влияния", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("F75C4816-48E1-44E9-B71A-DC75033ADA5A"), Code = "000000014", NameRu = "Финансирующая компания", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("BB70353F-7547-49BA-AC7A-CB610377DC16"), Code = "000000015", NameRu = "Другое", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("6394B7AB-DC12-4832-8524-4886D9353F60"), Code = "000000016", NameRu = "Подчиненный", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("8DFCD4DC-E072-4330-B5BF-4A0722D18A6F"), Code = "000000017", NameRu = "Аффилированные", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("9057ABA8-AB78-4702-92DC-B659B1349291"), Code = "000000018", NameRu = "Не указано", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("1F8251BD-8DFB-440B-8DFC-B16AADB40D0A"), Code = "000000019", NameRu = "Получатель счета", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("84AC8AB6-9D69-4B3D-AD59-C3B5AE64DB82"), Code = "000000020", NameRu = "Плательщик", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("B4814C99-CFDF-4AC6-A961-B3A887C21134"), Code = "000000021", NameRu = "Proxy User", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("18CF36A5-E5F7-422C-96E3-43B0BE6649B9"), Code = "000000022", NameRu = "Student", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("F9E7ADF5-31E6-437A-9C7F-AD254D290D56"), Code = "000000023", NameRu = "Staff", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("8008987F-12E9-4B75-A8E7-E24DB0A86D14"), Code = "000000024", NameRu = "Faculty", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("83EAE627-2161-4630-B575-3A2719225D82"), Code = "000000025", NameRu = "Alumni", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("03313DCF-B5FF-4000-B6C3-9CADF9588CCC"), Code = "000000026", NameRu = "Parents", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("D8A6E535-236D-41A8-8537-6307274EE1FD"), Code = "000000027", NameRu = "Secondary", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("79883AB5-31A1-4009-81A2-55D80BA4A469"), Code = "000000028", NameRu = "Boss", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("69F5C23B-1900-4254-AE81-D5BB5FAC448D"), Code = "000000029", NameRu = "Guardian", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("35D567B5-3D9D-4772-A70C-D512A0FD235A"), Code = "000000030", NameRu = "Joint", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("688E34A5-5BBC-4BE5-AD3A-C765448AC948"), Code = "000000031", NameRu = "PLS", NameKk = "" },
                new DicTypeOfRelationWithCompany { Id = Guid.Parse("66B7C5D2-70F6-4B20-93F2-88F67DD4F6BF"), Code = "000000032", NameRu = "PMS", NameKk = "" });
        }

        #endregion
    }
}
