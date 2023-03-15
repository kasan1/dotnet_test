using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class LoanApplicationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LoanFinancingSourceId",
                table: "LoanApplications",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_LoanFinancingSourceId",
                table: "LoanApplications",
                column: "LoanFinancingSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanFinancingSources_LoanFinancingSourceId",
                table: "LoanApplications",
                column: "LoanFinancingSourceId",
                principalTable: "DicLoanFinancingSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanFinancingSources_LoanFinancingSourceId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_LoanFinancingSourceId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "LoanFinancingSourceId",
                table: "LoanApplications");
        }
    }
}
