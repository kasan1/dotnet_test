using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Okaps_Add_Anketa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculators_PeriodPart_PeriodPartId",
                table: "Calculators");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculators_RatePart_RatePartId",
                table: "Calculators");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculators_SofinancPart_SofinancPartId",
                table: "Calculators");

            migrationBuilder.DropTable(
                name: "PeriodPart");

            migrationBuilder.DropTable(
                name: "RatePart");

            migrationBuilder.DropTable(
                name: "SofinancPart");

            migrationBuilder.DropIndex(
                name: "IX_Calculators_PeriodPartId",
                table: "Calculators");

            migrationBuilder.DropIndex(
                name: "IX_Calculators_RatePartId",
                table: "Calculators");

            migrationBuilder.DropIndex(
                name: "IX_Calculators_SofinancPartId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "NameRu",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "PeriodPartId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "RatePartId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "SofinancPartId",
                table: "Calculators");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Calculators",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "Calculators",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rate",
                table: "Calculators",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sofinanc",
                table: "Calculators",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sum",
                table: "Calculators",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoanStatementId",
                table: "AgroFiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoanStatements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    RegNumber = table.Column<string>(nullable: true),
                    ProcessInstanceId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanStatements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppActiveses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LoanStatementId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppActiveses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppActiveses_LoanStatements_LoanStatementId",
                        column: x => x.LoanStatementId,
                        principalTable: "LoanStatements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppTechnicses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LoanStatementId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTechnicses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTechnicses_LoanStatements_LoanStatementId",
                        column: x => x.LoanStatementId,
                        principalTable: "LoanStatements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientDetailses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrganizationName = table.Column<string>(nullable: true),
                    JuridicalAddress = table.Column<string>(nullable: true),
                    FacticalAddress = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    Faks = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    OwnershipTypeForJuristical = table.Column<string>(nullable: true),
                    MainActivityType = table.Column<string>(nullable: true),
                    BINForJuridical = table.Column<string>(nullable: true),
                    IINForIp = table.Column<string>(nullable: true),
                    NumberRegisterEvidence = table.Column<string>(nullable: true),
                    RegisterEvidenceDate = table.Column<string>(nullable: true),
                    MentorHolding = table.Column<string>(nullable: true),
                    LeaderFIO = table.Column<string>(nullable: true),
                    LeaderWorkNumber = table.Column<string>(nullable: true),
                    LeaderPhoneNumber = table.Column<string>(nullable: true),
                    LeaderHomeNumber = table.Column<string>(nullable: true),
                    LeaderBornDate = table.Column<string>(nullable: true),
                    LeaderBornPlace = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    PassportCreateDate = table.Column<string>(nullable: true),
                    PassportIssuerName = table.Column<string>(nullable: true),
                    LeaderFaktAddress = table.Column<string>(nullable: true),
                    LeaderRegistrAddress = table.Column<string>(nullable: true),
                    Obrazovanie = table.Column<string>(nullable: true),
                    StazhRaboty = table.Column<string>(nullable: true),
                    StazhSelhoz = table.Column<string>(nullable: true),
                    SemeinoePolozhenie = table.Column<string>(nullable: true),
                    SuprugName = table.Column<string>(nullable: true),
                    BuhgalterFIO = table.Column<string>(nullable: true),
                    BuhgalterPhoneNumber = table.Column<string>(nullable: true),
                    BuhgalterWorkNumber = table.Column<string>(nullable: true),
                    BuhgalterHomeNumber = table.Column<string>(nullable: true),
                    BuhgalterBornDate = table.Column<string>(nullable: true),
                    BuhgalterBornPlace = table.Column<string>(nullable: true),
                    BuhgalterPassportNumber = table.Column<string>(nullable: true),
                    BuhgalterPassportCreateDate = table.Column<string>(nullable: true),
                    BuhgalterPassportIssuerName = table.Column<string>(nullable: true),
                    BuhgalterFaktAddress = table.Column<string>(nullable: true),
                    BuhgalterRegisterAddress = table.Column<string>(nullable: true),
                    BankAccount = table.Column<string>(nullable: true),
                    ContactLico = table.Column<string>(nullable: true),
                    LoanStatementId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDetailses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientDetailses_LoanStatements_LoanStatementId",
                        column: x => x.LoanStatementId,
                        principalTable: "LoanStatements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BioActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Edinica = table.Column<string>(nullable: true),
                    Count = table.Column<string>(nullable: true),
                    PriceForOne = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    AppActivesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BioActivity_AppActiveses_AppActivesId",
                        column: x => x.AppActivesId,
                        principalTable: "AppActiveses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FloraActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CultureName = table.Column<string>(nullable: true),
                    PlanningPosevSquare = table.Column<string>(nullable: true),
                    NormaPoseva = table.Column<string>(nullable: true),
                    PriceRealization = table.Column<string>(nullable: true),
                    AppActivesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloraActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloraActivities_AppActiveses_AppActivesId",
                        column: x => x.AppActivesId,
                        principalTable: "AppActiveses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LandActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LandName = table.Column<string>(nullable: true),
                    LandSquare = table.Column<string>(nullable: true),
                    LandType = table.Column<string>(nullable: true),
                    AppActivesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandActivities_AppActiveses_AppActivesId",
                        column: x => x.AppActivesId,
                        principalTable: "AppActiveses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CultureName = table.Column<string>(nullable: true),
                    CreateDate = table.Column<string>(nullable: true),
                    Count = table.Column<string>(nullable: true),
                    WorkCorrectlyCount = table.Column<string>(nullable: true),
                    Obremeneniya = table.Column<string>(nullable: true),
                    WhomAndWhyZalozheno = table.Column<string>(nullable: true),
                    AppActivesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechActivities_AppActiveses_AppActivesId",
                        column: x => x.AppActivesId,
                        principalTable: "AppActiveses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AppTechnicsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_AppTechnicses_AppTechnicsId",
                        column: x => x.AppTechnicsId,
                        principalTable: "AppTechnicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffiliatedCompanieses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrganizationNameAndAddress = table.Column<string>(nullable: true),
                    ServingBanksAndAccountNumber = table.Column<string>(nullable: true),
                    DolyaVacionernomKapitale = table.Column<string>(nullable: true),
                    SsudnyiZadolzhennostWithBanks = table.Column<string>(nullable: true),
                    ClientDetailsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliatedCompanieses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AffiliatedCompanieses_ClientDetailses_ClientDetailsId",
                        column: x => x.ClientDetailsId,
                        principalTable: "ClientDetailses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientCredits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrganizationName = table.Column<string>(nullable: true),
                    SumdDebt = table.Column<string>(nullable: true),
                    CreateCreditDate = table.Column<string>(nullable: true),
                    ExpiredDate = table.Column<string>(nullable: true),
                    UnredeemedDebt = table.Column<string>(nullable: true),
                    ClientDetailsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCredits_ClientDetailses_ClientDetailsId",
                        column: x => x.ClientDetailsId,
                        principalTable: "ClientDetailses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_ContractId",
                table: "Calculators",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_AgroFiles_LoanStatementId",
                table: "AgroFiles",
                column: "LoanStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliatedCompanieses_ClientDetailsId",
                table: "AffiliatedCompanieses",
                column: "ClientDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppActiveses_LoanStatementId",
                table: "AppActiveses",
                column: "LoanStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTechnicses_LoanStatementId",
                table: "AppTechnicses",
                column: "LoanStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_BioActivity_AppActivesId",
                table: "BioActivity",
                column: "AppActivesId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCredits_ClientDetailsId",
                table: "ClientCredits",
                column: "ClientDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDetailses_LoanStatementId",
                table: "ClientDetailses",
                column: "LoanStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_AppTechnicsId",
                table: "Contracts",
                column: "AppTechnicsId");

            migrationBuilder.CreateIndex(
                name: "IX_FloraActivities_AppActivesId",
                table: "FloraActivities",
                column: "AppActivesId");

            migrationBuilder.CreateIndex(
                name: "IX_LandActivities_AppActivesId",
                table: "LandActivities",
                column: "AppActivesId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanStatements_UserId",
                table: "LoanStatements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TechActivities_AppActivesId",
                table: "TechActivities",
                column: "AppActivesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgroFiles_LoanStatements_LoanStatementId",
                table: "AgroFiles",
                column: "LoanStatementId",
                principalTable: "LoanStatements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calculators_Contracts_ContractId",
                table: "Calculators",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgroFiles_LoanStatements_LoanStatementId",
                table: "AgroFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculators_Contracts_ContractId",
                table: "Calculators");

            migrationBuilder.DropTable(
                name: "AffiliatedCompanieses");

            migrationBuilder.DropTable(
                name: "BioActivity");

            migrationBuilder.DropTable(
                name: "ClientCredits");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "FloraActivities");

            migrationBuilder.DropTable(
                name: "LandActivities");

            migrationBuilder.DropTable(
                name: "TechActivities");

            migrationBuilder.DropTable(
                name: "ClientDetailses");

            migrationBuilder.DropTable(
                name: "AppTechnicses");

            migrationBuilder.DropTable(
                name: "AppActiveses");

            migrationBuilder.DropTable(
                name: "LoanStatements");

            migrationBuilder.DropIndex(
                name: "IX_Calculators_ContractId",
                table: "Calculators");

            migrationBuilder.DropIndex(
                name: "IX_AgroFiles_LoanStatementId",
                table: "AgroFiles");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "Sofinanc",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "sum",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "LoanStatementId",
                table: "AgroFiles");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Calculators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "Calculators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameRu",
                table: "Calculators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PeriodPartId",
                table: "Calculators",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RatePartId",
                table: "Calculators",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SofinancPartId",
                table: "Calculators",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PeriodPart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DicCountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DicProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DicTechTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    maxDuration = table.Column<int>(type: "int", nullable: false),
                    minDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodPart_DicCountries_DicCountryId",
                        column: x => x.DicCountryId,
                        principalTable: "DicCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodPart_DicProviders_DicProviderId",
                        column: x => x.DicProviderId,
                        principalTable: "DicProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodPart_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RatePart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DicCountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DicTechTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatePart_DicCountries_DicCountryId",
                        column: x => x.DicCountryId,
                        principalTable: "DicCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RatePart_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SofinancPart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DicCountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DicTechTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    maxPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    minPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SofinancPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SofinancPart_DicCountries_DicCountryId",
                        column: x => x.DicCountryId,
                        principalTable: "DicCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SofinancPart_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_PeriodPartId",
                table: "Calculators",
                column: "PeriodPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_RatePartId",
                table: "Calculators",
                column: "RatePartId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_SofinancPartId",
                table: "Calculators",
                column: "SofinancPartId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodPart_DicCountryId",
                table: "PeriodPart",
                column: "DicCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodPart_DicProviderId",
                table: "PeriodPart",
                column: "DicProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodPart_DicTechTypeId",
                table: "PeriodPart",
                column: "DicTechTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RatePart_DicCountryId",
                table: "RatePart",
                column: "DicCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RatePart_DicTechTypeId",
                table: "RatePart",
                column: "DicTechTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SofinancPart_DicCountryId",
                table: "SofinancPart",
                column: "DicCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SofinancPart_DicTechTypeId",
                table: "SofinancPart",
                column: "DicTechTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculators_PeriodPart_PeriodPartId",
                table: "Calculators",
                column: "PeriodPartId",
                principalTable: "PeriodPart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calculators_RatePart_RatePartId",
                table: "Calculators",
                column: "RatePartId",
                principalTable: "RatePart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calculators_SofinancPart_SofinancPartId",
                table: "Calculators",
                column: "SofinancPartId",
                principalTable: "SofinancPart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
