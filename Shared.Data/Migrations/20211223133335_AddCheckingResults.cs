using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddCheckingResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinAnalyses_DicAffiliations_AffiliationId",
                table: "FinAnalyses");

            migrationBuilder.DropIndex(
                name: "IX_FinAnalyses_AffiliationId",
                table: "FinAnalyses");

            migrationBuilder.DropColumn(
                name: "AffiliationId",
                table: "FinAnalyses");

            migrationBuilder.CreateTable(
                name: "CheckingResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DetailsPersonalityId = table.Column<Guid>(nullable: false),
                    CheckingListId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckingResults_CheckingList_CheckingListId",
                        column: x => x.CheckingListId,
                        principalTable: "CheckingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingResults_LoanApplicationDetailsPersonalities_DetailsPersonalityId",
                        column: x => x.DetailsPersonalityId,
                        principalTable: "LoanApplicationDetailsPersonalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckingResults_CheckingListId",
                table: "CheckingResults",
                column: "CheckingListId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingResults_DetailsPersonalityId",
                table: "CheckingResults",
                column: "DetailsPersonalityId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingResults_IsDeleted",
                table: "CheckingResults",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckingResults");

            migrationBuilder.AddColumn<Guid>(
                name: "AffiliationId",
                table: "FinAnalyses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinAnalyses_AffiliationId",
                table: "FinAnalyses",
                column: "AffiliationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinAnalyses_DicAffiliations_AffiliationId",
                table: "FinAnalyses",
                column: "AffiliationId",
                principalTable: "DicAffiliations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
