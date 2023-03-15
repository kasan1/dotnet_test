using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Add1CDictionaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LegalFormId",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectOfEntrepreneurId",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TaxTreatmentId",
                table: "Organizations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DicOrganizationAndLegalForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Sort = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    NameRu = table.Column<string>(maxLength: 200, nullable: false),
                    NameKk = table.Column<string>(maxLength: 200, nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicOrganizationAndLegalForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicRelationWithCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Sort = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    NameRu = table.Column<string>(maxLength: 200, nullable: false),
                    NameKk = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicRelationWithCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicSubjectOfEntrepreneur",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Sort = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    NameRu = table.Column<string>(maxLength: 200, nullable: false),
                    NameKk = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicSubjectOfEntrepreneur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicTaxTreatments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Sort = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    NameRu = table.Column<string>(maxLength: 200, nullable: false),
                    NameKk = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTaxTreatments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicTypeOfRelationWithCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Sort = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    NameRu = table.Column<string>(maxLength: 200, nullable: false),
                    NameKk = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTypeOfRelationWithCompany", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DicOrganizationAndLegalForms",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort", "Value" },
                values: new object[,]
                {
                    { new Guid("31045f1d-e216-4724-b733-0c813458df47"), "78", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Индивидуальное предпринимательство (личное)", 0, 0 },
                    { new Guid("c7a713d5-46b3-4019-8682-5abe54779263"), "51", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "ИП (совместное) - Семейное предпринимательство", 0, 0 },
                    { new Guid("e48790c7-c7e1-4368-97d0-6dba8b7800d5"), "50", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "ИП (совместное) - Предпринимательство супругов", 0, 0 },
                    { new Guid("fcd4a268-39c0-41e7-b78c-8327ff3606f0"), "99", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Простое товарищество", 0, 0 },
                    { new Guid("4c4ca9c9-0678-4f9d-bce7-0b172c2525ef"), "99", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "ЛП", 0, 0 },
                    { new Guid("b1c33fc0-91fa-4126-b4c7-eb3137c8e005"), "52", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Сельскохозяйственные товарищества", 0, 0 },
                    { new Guid("5e3a4716-0300-44f1-b39a-2dc9f009b9b9"), "40", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Объединения юридических лиц в форме ассоциаций", 0, 0 },
                    { new Guid("bf201f21-e129-428b-b64c-f5e769b56598"), "39", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Религиозные объединения", 0, 0 },
                    { new Guid("13fc0db5-b864-4003-91f3-38c40c75c28b"), "38", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Фонды", 0, 0 },
                    { new Guid("c5113802-4685-4e58-8b02-ece7855936e7"), "37", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Потребительские кооперативы", 0, 0 },
                    { new Guid("365d1398-7ecc-466a-b29b-f873b91b0723"), "36", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Общественные объединения", 0, 0 },
                    { new Guid("05ecbbfc-c105-4c2a-ac03-29771bdaa214"), "35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Учреждения", 0, 0 },
                    { new Guid("697855da-0e5b-4330-a726-92e549b9627a"), "27", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Производственные кооперативы", 0, 0 },
                    { new Guid("9614b496-8fac-4764-aea1-a8ca47776a93"), "53", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Иная организационно-правовая форма некоммерческой организации", 0, 0 },
                    { new Guid("f3ece3a8-467e-4a12-88ff-5951019bbf88"), "24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Акционерные общества", 0, 0 },
                    { new Guid("a558fb37-9629-46c7-a166-e412d5b68c8b"), "21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Товарищества с дополнительной ответственностью", 0, 0 },
                    { new Guid("d2bb8c4b-bdee-4243-9f51-acae44eb2b6f"), "20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Товарищества с ограниченной ответственностью", 0, 1 },
                    { new Guid("8eade30a-1320-4154-bc6e-e7a9b02f7268"), "19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Коммандитные товарищества", 0, 0 },
                    { new Guid("c1f24c5e-7486-4bd6-8090-5f65c4adb99d"), "18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Полные товарищества", 0, 0 },
                    { new Guid("c2aa4f5c-1ff6-47af-8e34-fa13d0fbed43"), "99", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "ХТ", 0, 0 },
                    { new Guid("633d6f99-eafc-4cf0-8c5a-2370281c06e0"), "12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Государственные предприятия на праве оперативного управления (казенные)", 0, 0 },
                    { new Guid("3d037d07-88e2-4526-92fd-cbc9b448da7e"), "11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Государственные предприятия на праве хозяйственного ведения", 0, 0 },
                    { new Guid("aa7dfc1a-f9c7-4421-9442-5c7e2d7d039f"), "10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Государственные предприятия", 0, 0 },
                    { new Guid("761db84d-fca9-4259-a877-1b191064a392"), "99", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Физическое лицо", 0, 0 },
                    { new Guid("d0fd8c31-85c6-4c1e-8c19-9c889bb30f54"), "79", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Индивидуальное предпринимательство на основе совместного предпринимательства", 0, 0 },
                    { new Guid("acc57629-9cba-4d9d-ab00-463ca6a67021"), "46", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Другая организационно-правовая форма", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "DicRelationWithCompany",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("f64e5fd1-eee3-4f25-b170-a10411a2f73d"), "65", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, связанное с банком  (организации, осуществляющей отдельные виды банковских", 0 },
                    { new Guid("a846b2ec-02a9-4872-8bdf-a2bd16a83caf"), "75", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", 0 },
                    { new Guid("8473c3ba-37a3-45b5-b439-dec78dca145e"), "74", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", 0 },
                    { new Guid("6aca42c6-99bf-4c5c-87a7-9304faab71f7"), "73", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", 0 },
                    { new Guid("ff98992d-f404-4025-9262-ac6c859aca76"), "67", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", 0 },
                    { new Guid("9040b8a5-90e6-48de-9845-0b2d20c7cef2"), "71", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", 0 },
                    { new Guid("927f02be-7198-4a1d-996a-72d042a37e00"), "69", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", 0 },
                    { new Guid("7cfe085b-f7d2-43a2-b743-189572168b0e"), "68", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", 0 },
                    { new Guid("6ad3241e-d59e-4a8c-bab7-6d9c72ae1531"), "34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Первый руководитель филиала банка  (организации, осуществляющей отдельные виды б", 0 },
                    { new Guid("3f12e6f2-4d35-4255-a7dd-0ec5973c2741"), "72", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", 0 },
                    { new Guid("235e210a-efb3-4948-8fe1-2101e921d2fc"), "56", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, в котором лицо, состоящее в близком родстве, браке, а также св", 0 },
                    { new Guid("d824f24f-9436-44fb-9dca-ebee194ced74"), "57", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, в котором лицо, состоящее в близком родстве, браке, а также св", 0 },
                    { new Guid("d5049a82-1230-47c7-901a-a25d8223a829"), "47", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, в котором должностное лицо или руководящий работник банка (орг", 0 },
                    { new Guid("17fa4259-0515-4c4d-88f6-8cf96c740880"), "24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, в котором крупный участник банка является крупным участником (", 0 },
                    { new Guid("e885ad91-d564-4541-8678-a4453944a715"), "52", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, в котором лицо, состоящее в близком родстве, браке, а также св", 0 },
                    { new Guid("f47074e1-554f-484d-8077-022f0e76272d"), "53", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, в котором лицо, состоящее в близком родстве, браке, а также св", 0 },
                    { new Guid("a34f4e99-1201-4571-a83f-101984e06266"), "48", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, в котором первый руководитель филиала банка  (организации, осу", 0 },
                    { new Guid("4f2088fa-ed57-4a38-9298-d048b25ee38e"), "63", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, которое контролируется лицом, являющимся должностным лицом бан", 0 },
                    { new Guid("bae8172d-6159-459f-b7f9-ca5e8c0ea908"), "62", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, которое контролируется лицом, являющимся крупным акционером (у", 0 },
                    { new Guid("4223ef34-beff-4d70-b166-a2e0df19b88e"), "61", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, которое контролируется лицом, являющимся крупным участником ба", 0 },
                    { new Guid("2db87d97-d704-42cd-ab9f-263ac59d762b"), "64", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, которое совместно с банком (организации, осуществляющей отдель", 0 },
                    { new Guid("5e9911c7-d9ff-4b14-950c-9c25cf0f58bb"), "58", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, по отношению к которому банк  (организация, осуществляющая отд", 0 },
                    { new Guid("9d95dec1-fb27-404a-85e8-2099dc6dc3e9"), "66", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", 0 },
                    { new Guid("2eccc65f-a08d-4435-9672-b10767d6be28"), "54", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, в котором должностное лицо крупного участника банка (организац", 0 },
                    { new Guid("421b39d2-17cf-480f-bc71-d00a4c717dc4"), "60", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Крупный участник (акционер) крупного участника (акционера) организации, осуществ", 0 },
                    { new Guid("d13bde36-4612-4fd9-8e73-588ef8b84c54"), "70", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", 0 },
                    { new Guid("0124802c-f147-4504-b0fa-bbac7054deda"), "80", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Иное лицо, связанное с банком (организацией, осуществляющей отдельные виды банко", 0 },
                    { new Guid("9b2e900d-208d-44c3-aaee-55607a1c34a3"), "59", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Крупный акционер (участник) организации, осуществляющей отдельные виды банковски", 0 },
                    { new Guid("53145abc-a5b4-4e2a-8a8f-64bc353fd5f2"), "51", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Связан не исп", 0 },
                    { new Guid("28d70007-cbf2-4ca1-8ad7-87380c3df261"), "50", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Не связан", 0 },
                    { new Guid("97250ced-612d-4dd7-a6f6-b57a40e4edc8"), "13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Близкий родственник должностного лица или руководящего работника банка", 0 },
                    { new Guid("444dd655-4a34-4063-95a1-fbe7f5d12834"), "16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Крупный участник банка", 0 },
                    { new Guid("e9470491-55a2-4eb1-a653-984491c9a38d"), "18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Должностное лицо крупного участника банка", 0 },
                    { new Guid("251967fa-ac3b-4c10-8ebb-2230f3d26ed7"), "06", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Близкий родственник должностного лица крупного участника банка", 0 },
                    { new Guid("99f737cf-d0a8-4d5d-b2ad-22a39465195a"), "20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, в котором лицо, состоящее в близком родстве, браке, а также св", 0 },
                    { new Guid("0f4298e1-4177-4306-af65-e20643db1d35"), "22", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Должностное лицо юридического лица, по отношению к которому банк является крупны", 0 },
                    { new Guid("4753ac66-3704-4f9e-af2c-5271d77fa971"), "23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Близкий родственник должностного лица юридического лица, по отношению к ко-тором", 0 },
                    { new Guid("cd231ca4-d76f-47ee-935e-cb11a53edf56"), "21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юридическое лицо, в котором главный бухгалтер филиала банка  (организации, осуще", 0 },
                    { new Guid("534123ef-9881-441a-9ea2-624afa68ba3c"), "42", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Крупный участник крупного участника банка, банковского холдинга", 0 },
                    { new Guid("69ac17aa-13f4-4464-9a73-6cf1119c130d"), "12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Должностное лицо или руководящий работник банка (организации, осуществляющей отд", 0 },
                    { new Guid("71de6cd0-353a-4894-a75a-14be1f764a0c"), "41", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, состоящее в близком родстве, браке, а также свойстве с лицом, являющимся г", 0 },
                    { new Guid("28cfdc7c-995a-41bb-9a57-1502b7d8748d"), "46", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, состоящее в близком родстве, браке, а также свойстве с лицом, являющимся д", 0 },
                    { new Guid("401ff648-d1f7-4778-9cf4-f075df8265b5"), "45", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, состоящее в близком родстве, браке, а также свойстве с лицом, являющимся к", 0 },
                    { new Guid("6297e3d4-f6a3-4698-8bc6-a06bc5c120b3"), "39", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, состоящее в близком родстве, браке, а также свойстве с лицом, являющимся п", 0 },
                    { new Guid("f64a44d3-0ba6-41c7-8b89-afbe726ca051"), "35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Главный бухгалтер филиала банка  (организации, осуществляющей отдельные виды бан", 0 },
                    { new Guid("eea13ad1-280d-4ace-8ddb-9afde9a8db4c"), "43", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Должностное лицо крупного акционера организации, осуществляющей отдельные виды б", 0 },
                    { new Guid("81216e55-db6e-4ddc-af1b-95e64457c93d"), "78", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Должностное лицо юридического лица, которое контролируется должностным лицом бан", 0 },
                    { new Guid("4d05865a-8417-46e7-9aee-b9cf71b5eab5"), "76", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Должностное лицо юридического лица, которое контролируется крупным участником ба", 0 },
                    { new Guid("b95aafab-e501-46a4-8b6a-9b6993040a1e"), "44", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Лицо, состоящее в близком родстве, браке, а также свойстве с лицом, являющимся к", 0 },
                    { new Guid("17b7b008-b96e-4a02-ba6e-7913bfa72dd0"), "79", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Должностное лицо юридического лица, которое контролируется должностным лицом бан", 0 },
                    { new Guid("baf15e3c-9423-4786-9c8b-41338530cd7a"), "77", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Должностное лицо юридического лица, которое контролируется крупным акционером ор", 0 }
                });

            migrationBuilder.InsertData(
                table: "DicSubjectOfEntrepreneur",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("70cd9aa2-da90-40b0-b62e-d1c26ffcd2fd"), "Малый бизнес", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Малый бизнес", 0 },
                    { new Guid("0182d1e3-d239-4f24-9ab2-696bf41abe3d"), "Средний бизнес", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Средний бизнес", 0 },
                    { new Guid("8dc3046c-1d81-48b1-8b08-6d333378fe2e"), "Крупный бизнес", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Крупный бизнес", 0 }
                });

            migrationBuilder.InsertData(
                table: "DicTaxTreatments",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("6e4e04a8-c8b2-4faf-9a23-9a7d97dc60d0"), "Упрощенный режим", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Упрощенный режим", 0 },
                    { new Guid("5586a71e-1277-4e90-9004-baad6745373a"), "Общеустановленный режим", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Общеустановленный режим", 0 }
                });

            migrationBuilder.InsertData(
                table: "DicTypeOfRelationWithCompany",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("8dfcd4dc-e072-4330-b5bf-4a0722d18a6f"), "000000017", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Аффилированные", 0 },
                    { new Guid("35d567b5-3d9d-4772-a70c-d512a0fd235a"), "000000030", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Joint", 0 },
                    { new Guid("69f5c23b-1900-4254-ae81-d5bb5fac448d"), "000000029", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Guardian", 0 },
                    { new Guid("79883ab5-31a1-4009-81a2-55d80ba4a469"), "000000028", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Boss", 0 },
                    { new Guid("d8a6e535-236d-41a8-8537-6307274ee1fd"), "000000027", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Secondary", 0 },
                    { new Guid("03313dcf-b5ff-4000-b6c3-9cadf9588ccc"), "000000026", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Parents", 0 },
                    { new Guid("83eae627-2161-4630-b575-3a2719225d82"), "000000025", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Alumni", 0 },
                    { new Guid("8008987f-12e9-4b75-a8e7-e24db0a86d14"), "000000024", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Faculty", 0 },
                    { new Guid("f9e7adf5-31e6-437a-9c7f-ad254d290d56"), "000000023", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Staff", 0 },
                    { new Guid("18cf36a5-e5f7-422c-96e3-43b0be6649b9"), "000000022", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Student", 0 },
                    { new Guid("b4814c99-cfdf-4ac6-a961-b3a887c21134"), "000000021", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Proxy User", 0 },
                    { new Guid("84ac8ab6-9d69-4b3d-ad59-c3b5ae64db82"), "000000020", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Плательщик", 0 },
                    { new Guid("1f8251bd-8dfb-440b-8dfc-b16aadb40d0a"), "000000019", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Получатель счета", 0 },
                    { new Guid("9057aba8-ab78-4702-92dc-b659b1349291"), "000000018", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Не указано", 0 },
                    { new Guid("6394b7ab-dc12-4832-8524-4886d9353f60"), "000000016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Подчиненный", 0 },
                    { new Guid("e1afc962-9bf0-4421-8298-d055a1cc5806"), "000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Супруг(а)", 0 },
                    { new Guid("f75c4816-48e1-44e9-b71a-dc75033ada5a"), "000000014", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Финансирующая компания", 0 },
                    { new Guid("df0cca7f-0a9f-49d3-a31c-2bf206210d4d"), "000000013", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Источник влияния", 0 },
                    { new Guid("cec13040-cf0f-4dd8-b179-4e52bff32a0b"), "000000012", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Относится к", 0 },
                    { new Guid("584a502d-8bc0-4a50-893b-347c2a4d6f35"), "000000011", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Личный помощник", 0 },
                    { new Guid("744e3f2f-81b0-4612-9404-5f38b0fff5d6"), "000000010", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Партнер", 0 },
                    { new Guid("bb3fb840-94d3-44ed-a080-fc9fd1e04b8d"), "000000009", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Связанный филиал", 0 },
                    { new Guid("b935c06b-e47a-48d7-8503-edb54e0439d1"), "000000008", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Инвестор", 0 },
                    { new Guid("f66f263a-bc09-43a3-b968-5d8dced67a52"), "000000007", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Конкурент", 0 },
                    { new Guid("b651fa25-bca1-40be-80a0-4df61e72c95d"), "000000006", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Помощник администратора", 0 },
                    { new Guid("d348ed82-6ad8-4660-8844-1aa4c9c056e5"), "000000005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Член совета директоров", 0 },
                    { new Guid("4afb7a4a-932c-4c61-956d-1d1f9d58500e"), "000000004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Юрист", 0 },
                    { new Guid("3f83c606-2623-42fd-b283-9e715b035e4d"), "000000003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Учредитель/Участник", 0 },
                    { new Guid("c061fd0d-15f5-4647-a1d3-bcfccb2bc231"), "000000002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Получатель отчета", 0 },
                    { new Guid("688e34a5-5bbc-4be5-ad3a-c765448ac948"), "000000031", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PLS", 0 },
                    { new Guid("bb70353f-7547-49ba-ac7a-cb610377dc16"), "000000015", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Другое", 0 },
                    { new Guid("66b7c5d2-70f6-4b20-93f2-88f67dd4f6bf"), "000000032", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PMS", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_LegalFormId",
                table: "Organizations",
                column: "LegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_SubjectOfEntrepreneurId",
                table: "Organizations",
                column: "SubjectOfEntrepreneurId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_TaxTreatmentId",
                table: "Organizations",
                column: "TaxTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DicOrganizationAndLegalForms_IsDeleted",
                table: "DicOrganizationAndLegalForms",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DicRelationWithCompany_IsDeleted",
                table: "DicRelationWithCompany",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DicSubjectOfEntrepreneur_IsDeleted",
                table: "DicSubjectOfEntrepreneur",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DicTaxTreatments_IsDeleted",
                table: "DicTaxTreatments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DicTypeOfRelationWithCompany_IsDeleted",
                table: "DicTypeOfRelationWithCompany",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_DicOrganizationAndLegalForms_LegalFormId",
                table: "Organizations",
                column: "LegalFormId",
                principalTable: "DicOrganizationAndLegalForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_DicSubjectOfEntrepreneur_SubjectOfEntrepreneurId",
                table: "Organizations",
                column: "SubjectOfEntrepreneurId",
                principalTable: "DicSubjectOfEntrepreneur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_DicTaxTreatments_TaxTreatmentId",
                table: "Organizations",
                column: "TaxTreatmentId",
                principalTable: "DicTaxTreatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_DicOrganizationAndLegalForms_LegalFormId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_DicSubjectOfEntrepreneur_SubjectOfEntrepreneurId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_DicTaxTreatments_TaxTreatmentId",
                table: "Organizations");

            migrationBuilder.DropTable(
                name: "DicOrganizationAndLegalForms");

            migrationBuilder.DropTable(
                name: "DicRelationWithCompany");

            migrationBuilder.DropTable(
                name: "DicSubjectOfEntrepreneur");

            migrationBuilder.DropTable(
                name: "DicTaxTreatments");

            migrationBuilder.DropTable(
                name: "DicTypeOfRelationWithCompany");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_LegalFormId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_SubjectOfEntrepreneurId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_TaxTreatmentId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "LegalFormId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "SubjectOfEntrepreneurId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "TaxTreatmentId",
                table: "Organizations");
        }
    }
}
