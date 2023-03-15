using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class BankInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankAccount",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BankId",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BankId",
                table: "LoanApplications",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicBanks_BankId",
                table: "LoanApplications",
                column: "BankId",
                principalTable: "DicBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicBanks_BankId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_BankId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BankAccount",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "LoanApplications");
        }
    }
}
