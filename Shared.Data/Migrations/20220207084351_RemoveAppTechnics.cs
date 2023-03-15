using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class RemoveAppTechnics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AppTechnicses_AppTechnicsId",
                table: "Contracts");

            migrationBuilder.DropTable(
                name: "AffiliatedCompanieses");

            migrationBuilder.DropTable(
                name: "BioActivity");

            migrationBuilder.DropTable(
                name: "ClientCredits");

            migrationBuilder.DropTable(
                name: "DicAffiliationRelationships");

            migrationBuilder.DropTable(
                name: "FloraActivities");

            migrationBuilder.DropTable(
                name: "LandActivities");

            migrationBuilder.DropTable(
                name: "TechActivity");

            migrationBuilder.DropTable(
                name: "ClientDetails");

            migrationBuilder.DropTable(
                name: "DicAffiliations");

            migrationBuilder.DropTable(
                name: "DicAffiliationTypes");

            migrationBuilder.DropTable(
                name: "AppActives");
                        
            migrationBuilder.AddColumn<Guid>(
                name: "LoanApplicationId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_LoanApplicationId",
                table: "Contracts",
                column: "LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_LoanApplications_LoanApplicationId",
                table: "Contracts",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(@"update Contracts
set LoanApplicationId = atc.LoanApplicationId
from Contracts c inner
join AppTechnicses atc on c.AppTechnicsId = atc.Id;");

            migrationBuilder.DropTable(
               name: "AppTechnicses");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_AppTechnicsId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "AppTechnicsId",
                table: "Contracts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_LoanApplications_LoanApplicationId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_LoanApplicationId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "Contracts");

            migrationBuilder.AddColumn<Guid>(
                name: "AppTechnicsId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppActives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppActives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppActives_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppTechnicses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTechnicses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTechnicses_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BINForJuridical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountBIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountIIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryIsResident = table.Column<bool>(type: "bit", nullable: false),
                    BeneficiaryPassportCreateDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryPassportIssuerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryPassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuhgalterBornDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuhgalterBornPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuhgalterFIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuhgalterFaktAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuhgalterHomeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuhgalterPassportCreateDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuhgalterPassportIssuerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuhgalterPassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuhgalterPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuhgalterRegisterAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuhgalterWorkNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactLico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactLicoBIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacticalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IINForIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    JuridicalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderBornDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderBornPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderFIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderFaktAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderHomeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderRegistrAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderWorkNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MainActivityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MentorHolding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberRegisterEvidence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obrazovanie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnershipTypeForJuristical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportCreateDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportIssuerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterEvidenceDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SemeinoePolozhenie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StazhRaboty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StazhSelhoz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuprugName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientDetails_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DicAffiliations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicAffiliations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicAffiliationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeAFN2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeKazAgro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NameKk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicAffiliationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BioActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppActivesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EdinicaForDead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdinicaForLive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BioActivity_AppActives_AppActivesId",
                        column: x => x.AppActivesId,
                        principalTable: "AppActives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FloraActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppActivesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CultureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NormaPoseva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanningPosevSquare = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceRealization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urozh1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urozh2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urozh3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urozh5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zatraty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloraActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloraActivities_AppActives_AppActivesId",
                        column: x => x.AppActivesId,
                        principalTable: "AppActives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LandActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppActivesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandSquare = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandActivities_AppActives_AppActivesId",
                        column: x => x.AppActivesId,
                        principalTable: "AppActives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppActivesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CultureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Obremeneniya = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhomAndWhyZalozheno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkCorrectlyCount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechActivity_AppActives_AppActivesId",
                        column: x => x.AppActivesId,
                        principalTable: "AppActives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffiliatedCompanieses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DolyaVacionernomKapitale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganizationNameAndAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServingBanksAndAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SsudnyiZadolzhennostWithBanks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliatedCompanieses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AffiliatedCompanieses_ClientDetails_ClientDetailsId",
                        column: x => x.ClientDetailsId,
                        principalTable: "ClientDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientCredits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateCreditDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumdDebt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnredeemedDebt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCredits_ClientDetails_ClientDetailsId",
                        column: x => x.ClientDetailsId,
                        principalTable: "ClientDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DicAffiliationRelationships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AffiliationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AffiliationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicAffiliationRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicAffiliationRelationships_DicAffiliations_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "DicAffiliations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DicAffiliationRelationships_DicAffiliationTypes_AffiliationTypeId",
                        column: x => x.AffiliationTypeId,
                        principalTable: "DicAffiliationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_AppTechnicsId",
                table: "Contracts",
                column: "AppTechnicsId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliatedCompanieses_ClientDetailsId",
                table: "AffiliatedCompanieses",
                column: "ClientDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppActives_LoanApplicationId",
                table: "AppActives",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTechnicses_LoanApplicationId",
                table: "AppTechnicses",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_BioActivity_AppActivesId",
                table: "BioActivity",
                column: "AppActivesId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCredits_ClientDetailsId",
                table: "ClientCredits",
                column: "ClientDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDetails_LoanApplicationId",
                table: "ClientDetails",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DicAffiliationRelationships_AffiliationId",
                table: "DicAffiliationRelationships",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "IX_DicAffiliationRelationships_AffiliationTypeId",
                table: "DicAffiliationRelationships",
                column: "AffiliationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FloraActivities_AppActivesId",
                table: "FloraActivities",
                column: "AppActivesId");

            migrationBuilder.CreateIndex(
                name: "IX_LandActivities_AppActivesId",
                table: "LandActivities",
                column: "AppActivesId");

            migrationBuilder.CreateIndex(
                name: "IX_TechActivity_AppActivesId",
                table: "TechActivity",
                column: "AppActivesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AppTechnicses_AppTechnicsId",
                table: "Contracts",
                column: "AppTechnicsId",
                principalTable: "AppTechnicses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
