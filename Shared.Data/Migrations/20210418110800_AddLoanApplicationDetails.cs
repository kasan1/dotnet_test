using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddLoanApplicationDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameRu",
                table: "DicDocumentTypes",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameKk",
                table: "DicDocumentTypes",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "DicDocumentTypes",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DicDocumentTypes",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DicDocumentTypes",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "DicDocumentTypes",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "DicDocumentTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Fact = table.Column<string>(maxLength: 1000, nullable: false),
                    Register = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicMariageStatuses",
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
                    table.PrimaryKey("PK_DicMariageStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicOKED",
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
                    table.PrimaryKey("PK_DicOKED", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicOrganizationTypes",
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
                    table.PrimaryKey("PK_DicOrganizationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicOwnershipForms",
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
                    table.PrimaryKey("PK_DicOwnershipForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DocumentTypeId = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(maxLength: 100, nullable: false),
                    Issuer = table.Column<string>(maxLength: 500, nullable: false),
                    DateIssue = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_DicDocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DicDocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    HasBeneficiary = table.Column<bool>(nullable: false),
                    LoanApplicationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationDetails_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Home = table.Column<string>(maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(maxLength: 20, nullable: true),
                    Work = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Total = table.Column<string>(maxLength: 200, nullable: true),
                    Agriculture = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Identifier = table.Column<string>(maxLength: 20, nullable: true),
                    FullName = table.Column<string>(maxLength: 1000, nullable: true),
                    Fax = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    PhoneId = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    WorkExperienceId = table.Column<Guid>(nullable: false),
                    RegionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personalities_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personalities_Phones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personalities_DicRegions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "DicRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personalities_WorkExperiences_WorkExperienceId",
                        column: x => x.WorkExperienceId,
                        principalTable: "WorkExperiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    BIC = table.Column<string>(maxLength: 50, nullable: false),
                    Number = table.Column<string>(maxLength: 100, nullable: false),
                    PersonalityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    PersonalityId = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(maxLength: 1000, nullable: false),
                    DateIssue = table.Column<DateTime>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    Sum = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditHistory_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationDetailsPersonalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    PersonalityType = table.Column<int>(nullable: false),
                    DetailsId = table.Column<Guid>(nullable: false),
                    PersonalityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationDetailsPersonalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationDetailsPersonalities_LoanApplicationDetails_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "LoanApplicationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationDetailsPersonalities_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    PersonalityId = table.Column<Guid>(nullable: false),
                    OrganizationTypeId = table.Column<Guid>(nullable: false),
                    OwnershipFormId = table.Column<Guid>(nullable: true),
                    Parent = table.Column<string>(maxLength: 1000, nullable: true),
                    IsAffiliated = table.Column<bool>(nullable: false),
                    AffiliatedOrganizatonId = table.Column<Guid>(nullable: true),
                    ShareInCapital = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_DicOrganizationTypes_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "DicOrganizationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizations_DicOwnershipForms_OwnershipFormId",
                        column: x => x.OwnershipFormId,
                        principalTable: "DicOwnershipForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organizations_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    PersonalityId = table.Column<Guid>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BirthPlace = table.Column<string>(maxLength: 1000, nullable: true),
                    IsResident = table.Column<bool>(nullable: false),
                    MariageStatusId = table.Column<Guid>(nullable: false),
                    Spouse = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_DicMariageStatuses_MariageStatusId",
                        column: x => x.MariageStatusId,
                        principalTable: "DicMariageStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalityDepts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    PersonalityId = table.Column<Guid>(nullable: false),
                    BIC = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalityDepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalityDepts_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalityDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    PersonalityId = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalityDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalityDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalityDocuments_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationOKED",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    OkedId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationOKED", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationOKED_DicOKED_OkedId",
                        column: x => x.OkedId,
                        principalTable: "DicOKED",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationOKED_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DicDocumentTypes",
                columns: new[] { "Id", "Code", "DocumentType", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("fb5701f8-c3c3-444d-b9e3-c601b66f8d19"), "1", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Анықталмаған", "Не определен", 0 },
                    { new Guid("069ced37-3155-48a7-855a-25b2c4a2cc4c"), "2", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Идентифицирующий", "Идентифицирующий", 0 },
                    { new Guid("e4672721-4794-423b-adcc-fcdcfa95017d"), "3", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тіркеу туралы", "Регистрационный", 0 }
                });

            migrationBuilder.InsertData(
                table: "DicMariageStatuses",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("3528f2e8-478a-45bf-9271-26fcf09c7a5b"), "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бойдақ", "Холост", 0 },
                    { new Guid("b5a5a1cf-b18d-4d2e-9f4e-e6c840a43419"), "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Неке құрған", "Состоит в браке", 0 }
                });

            migrationBuilder.InsertData(
                table: "DicOKED",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("102a2954-ea3e-4e86-aea9-a43e8516e372"), "0111", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дәнді дақылдарды (күріштен басқа), бұршақ және майлы дақылдарды өсіру", "Выращивание зерновых (кроме риса), бобовых и масличных культур", 0 },
                    { new Guid("8e27ebdf-16ea-4376-b74f-011c87a1877f"), "0113", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Көкөністер, бақша дақылдарын, тамыр жемістілер мен түйнек жемістілерді өсіру", "Выращивание овощей, бахчевых, корнеплодов и клубнеплодов", 0 }
                });

            migrationBuilder.InsertData(
                table: "DicOrganizationTypes",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("e042625a-7e7b-45ab-8c3d-27aae5a7ff8c"), "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Заңды тұлға", "Юридическое лицо", 0 },
                    { new Guid("c1a9c736-2e5a-483c-9bf7-ff809d8efd60"), "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Жеке кәсіпкер", "Индивидуальный предприниматель", 0 },
                    { new Guid("e449c89b-3845-4081-aa8c-a6de6fad72fe"), "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Крестьяндық шаруашылық", "Крестьянское хозяйство", 0 },
                    { new Guid("8a3307a1-1b2e-4528-9c1f-1c82fb45e178"), "4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Фермерлік шаруашылық", "Фермерское хозяйство", 0 }
                });

            migrationBuilder.InsertData(
                table: "DicOwnershipForms",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("173ba8e8-4f8b-40d6-802c-86987f9d1d29"), "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Жеке меншік", "Индивидуальная собственность", 0 },
                    { new Guid("c51c579e-a95a-440f-acf3-19ce2cb4e9bc"), "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ұжымдық меншік", "Коллективная собственность", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicDocumentTypes_IsDeleted",
                table: "DicDocumentTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_IsDeleted",
                table: "Addresses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_IsDeleted",
                table: "BankAccounts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_PersonalityId",
                table: "BankAccounts",
                column: "PersonalityId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditHistory_IsDeleted",
                table: "CreditHistory",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CreditHistory_PersonalityId",
                table: "CreditHistory",
                column: "PersonalityId");

            migrationBuilder.CreateIndex(
                name: "IX_DicMariageStatuses_IsDeleted",
                table: "DicMariageStatuses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DicOKED_IsDeleted",
                table: "DicOKED",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DicOrganizationTypes_IsDeleted",
                table: "DicOrganizationTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DicOwnershipForms_IsDeleted",
                table: "DicOwnershipForms",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IsDeleted",
                table: "Documents",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationDetails_IsDeleted",
                table: "LoanApplicationDetails",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationDetails_LoanApplicationId",
                table: "LoanApplicationDetails",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationDetailsPersonalities_DetailsId",
                table: "LoanApplicationDetailsPersonalities",
                column: "DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationDetailsPersonalities_IsDeleted",
                table: "LoanApplicationDetailsPersonalities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationDetailsPersonalities_PersonalityId",
                table: "LoanApplicationDetailsPersonalities",
                column: "PersonalityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationOKED_OkedId",
                table: "OrganizationOKED",
                column: "OkedId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationOKED_OrganizationId",
                table: "OrganizationOKED",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_IsDeleted",
                table: "Organizations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationTypeId",
                table: "Organizations",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OwnershipFormId",
                table: "Organizations",
                column: "OwnershipFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_PersonalityId",
                table: "Organizations",
                column: "PersonalityId");

            migrationBuilder.CreateIndex(
                name: "IX_People_IsDeleted",
                table: "People",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_People_MariageStatusId",
                table: "People",
                column: "MariageStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonalityId",
                table: "People",
                column: "PersonalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Personalities_AddressId",
                table: "Personalities",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Personalities_IsDeleted",
                table: "Personalities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Personalities_PhoneId",
                table: "Personalities",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Personalities_RegionId",
                table: "Personalities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Personalities_WorkExperienceId",
                table: "Personalities",
                column: "WorkExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalityDepts_IsDeleted",
                table: "PersonalityDepts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalityDepts_PersonalityId",
                table: "PersonalityDepts",
                column: "PersonalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalityDocuments_DocumentId",
                table: "PersonalityDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalityDocuments_IsDeleted",
                table: "PersonalityDocuments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalityDocuments_PersonalityId",
                table: "PersonalityDocuments",
                column: "PersonalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_IsDeleted",
                table: "Phones",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_IsDeleted",
                table: "WorkExperiences",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "CreditHistory");

            migrationBuilder.DropTable(
                name: "LoanApplicationDetailsPersonalities");

            migrationBuilder.DropTable(
                name: "OrganizationOKED");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "PersonalityDepts");

            migrationBuilder.DropTable(
                name: "PersonalityDocuments");

            migrationBuilder.DropTable(
                name: "LoanApplicationDetails");

            migrationBuilder.DropTable(
                name: "DicOKED");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "DicMariageStatuses");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DicOrganizationTypes");

            migrationBuilder.DropTable(
                name: "DicOwnershipForms");

            migrationBuilder.DropTable(
                name: "Personalities");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_DicDocumentTypes_IsDeleted",
                table: "DicDocumentTypes");

            migrationBuilder.DeleteData(
                table: "DicDocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("069ced37-3155-48a7-855a-25b2c4a2cc4c"));

            migrationBuilder.DeleteData(
                table: "DicDocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("e4672721-4794-423b-adcc-fcdcfa95017d"));

            migrationBuilder.DeleteData(
                table: "DicDocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("fb5701f8-c3c3-444d-b9e3-c601b66f8d19"));

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "DicDocumentTypes");

            migrationBuilder.AlterColumn<string>(
                name: "NameRu",
                table: "DicDocumentTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "NameKk",
                table: "DicDocumentTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "DicDocumentTypes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DicDocumentTypes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DicDocumentTypes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "DicDocumentTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
