using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class DicDecision_LoanApplicationHistoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DecisionId",
                table: "LoanApplicationHistories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DicDecisions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicDecisions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationHistories_DecisionId",
                table: "LoanApplicationHistories",
                column: "DecisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationHistories_DicDecisions_DecisionId",
                table: "LoanApplicationHistories",
                column: "DecisionId",
                principalTable: "DicDecisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationHistories_DicDecisions_DecisionId",
                table: "LoanApplicationHistories");

            migrationBuilder.DropTable(
                name: "DicDecisions");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationHistories_DecisionId",
                table: "LoanApplicationHistories");

            migrationBuilder.DropColumn(
                name: "DecisionId",
                table: "LoanApplicationHistories");
        }
    }
}
