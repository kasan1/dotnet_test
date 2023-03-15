using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class okaps_change_loan_application : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DicLoanTypeId",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccountBIK",
                table: "ClientDetailses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactLicoBIK",
                table: "ClientDetailses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DicLoanTypeId",
                table: "LoanApplications",
                column: "DicLoanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanTypes_DicLoanTypeId",
                table: "LoanApplications",
                column: "DicLoanTypeId",
                principalTable: "DicLoanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanTypes_DicLoanTypeId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_DicLoanTypeId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "DicLoanTypeId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BankAccountBIK",
                table: "ClientDetailses");

            migrationBuilder.DropColumn(
                name: "ContactLicoBIK",
                table: "ClientDetailses");
        }
    }
}
