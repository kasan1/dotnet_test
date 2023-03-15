using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddFinalysis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinAnalyses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LoanApplicationId = table.Column<Guid>(nullable: false),
                    FalseBusiness = table.Column<int>(nullable: false),
                    Bankrupt = table.Column<int>(nullable: false),
                    WantedIncome = table.Column<int>(nullable: false),
                    Inactive = table.Column<int>(nullable: false),
                    TaxesBankrupt = table.Column<int>(nullable: false),
                    TaxArrear = table.Column<int>(nullable: false),
                    TerrorList = table.Column<int>(nullable: false),
                    Aliment = table.Column<int>(nullable: false),
                    Pedophily = table.Column<int>(nullable: false),
                    LostPeople = table.Column<int>(nullable: false),
                    Affiliation = table.Column<int>(nullable: false),
                    AffiliationId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsASA = table.Column<bool>(nullable: true),
                    IsManyChildren = table.Column<bool>(nullable: true),
                    AnnualPay = table.Column<double>(nullable: false),
                    AnnualPaySuccess = table.Column<bool>(nullable: false),
                    ExistenceOfAmountDPD = table.Column<bool>(nullable: false),
                    GKBReuslt = table.Column<int>(nullable: false),
                    CreditReportId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinAnalyses_DicAffiliations_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "DicAffiliations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinAnalyses_AgroFiles_CreditReportId",
                        column: x => x.CreditReportId,
                        principalTable: "AgroFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinAnalyses_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinAnalysisQueueTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ErrorMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinAnalysisQueueTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinAnalysisQueueTasks_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinAnalysisIncomes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FinAnalysisId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sum = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinAnalysisIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinAnalysisIncomes_FinAnalyses_FinAnalysisId",
                        column: x => x.FinAnalysisId,
                        principalTable: "FinAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinAnalysisLoanPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FinAnalysisId = table.Column<Guid>(nullable: false),
                    Payments = table.Column<double>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    FinInstitut = table.Column<string>(nullable: true),
                    PeriodPayments = table.Column<double>(nullable: false),
                    PeriodPaymentsName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinAnalysisLoanPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinAnalysisLoanPayments_FinAnalyses_FinAnalysisId",
                        column: x => x.FinAnalysisId,
                        principalTable: "FinAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinAnalyses_AffiliationId",
                table: "FinAnalyses",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "IX_FinAnalyses_CreditReportId",
                table: "FinAnalyses",
                column: "CreditReportId");

            migrationBuilder.CreateIndex(
                name: "IX_FinAnalyses_LoanApplicationId",
                table: "FinAnalyses",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_FinAnalysisIncomes_FinAnalysisId",
                table: "FinAnalysisIncomes",
                column: "FinAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_FinAnalysisLoanPayments_FinAnalysisId",
                table: "FinAnalysisLoanPayments",
                column: "FinAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_FinAnalysisQueueTasks_ApplicationId",
                table: "FinAnalysisQueueTasks",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinAnalysisIncomes");

            migrationBuilder.DropTable(
                name: "FinAnalysisLoanPayments");

            migrationBuilder.DropTable(
                name: "FinAnalysisQueueTasks");

            migrationBuilder.DropTable(
                name: "FinAnalyses");
        }
    }
}
