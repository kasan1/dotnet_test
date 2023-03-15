using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class RemovePlanLoanCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanConditions");

            migrationBuilder.DropTable(
                name: "Plans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalCount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeedSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FileSocialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FileStandartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHasFeed = table.Column<bool>(type: "bit", nullable: false),
                    LoanFinancingSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfitYearSocial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfitYearStandart = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Version = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_DicActivityTypes_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "DicActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plans_AgroFiles_FileSocialId",
                        column: x => x.FileSocialId,
                        principalTable: "AgroFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_AgroFiles_FileStandartId",
                        column: x => x.FileStandartId,
                        principalTable: "AgroFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_DicLoanFinancingSources_LoanFinancingSourceId",
                        column: x => x.LoanFinancingSourceId,
                        principalTable: "DicLoanFinancingSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plans_DicRegions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "DicRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<short>(type: "smallint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<short>(type: "smallint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDay = table.Column<short>(type: "smallint", nullable: true),
                    PaymentOd = table.Column<short>(type: "smallint", nullable: true),
                    PaymentPercent = table.Column<short>(type: "smallint", nullable: true),
                    PeriodOd = table.Column<short>(type: "smallint", nullable: true),
                    PeriodPercent = table.Column<short>(type: "smallint", nullable: true),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Transh = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanConditions_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanConditions_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanConditions_LoanApplicationId",
                table: "LoanConditions",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanConditions_PlanId",
                table: "LoanConditions",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_ActivityTypeId",
                table: "Plans",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_FileSocialId",
                table: "Plans",
                column: "FileSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_FileStandartId",
                table: "Plans",
                column: "FileStandartId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_LoanFinancingSourceId",
                table: "Plans",
                column: "LoanFinancingSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_RegionId",
                table: "Plans",
                column: "RegionId");
        }
    }
}
