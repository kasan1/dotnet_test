using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddStatusToApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_StatusId",
                table: "LoanApplications",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanHistoryStatuses_StatusId",
                table: "LoanApplications",
                column: "StatusId",
                principalTable: "DicLoanHistoryStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanHistoryStatuses_StatusId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_StatusId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "LoanApplications");
        }
    }
}
