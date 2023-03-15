using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class FinancingSourceOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanFinancingSources_LoanFinancingSourceId",
                table: "LoanApplications");

            migrationBuilder.AlterColumn<Guid>(
                name: "LoanFinancingSourceId",
                table: "LoanApplications",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanFinancingSources_LoanFinancingSourceId",
                table: "LoanApplications",
                column: "LoanFinancingSourceId",
                principalTable: "DicLoanFinancingSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanFinancingSources_LoanFinancingSourceId",
                table: "LoanApplications");

            migrationBuilder.AlterColumn<Guid>(
                name: "LoanFinancingSourceId",
                table: "LoanApplications",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanFinancingSources_LoanFinancingSourceId",
                table: "LoanApplications",
                column: "LoanFinancingSourceId",
                principalTable: "DicLoanFinancingSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
