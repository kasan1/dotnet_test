using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Agreement_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LoanApplicationId",
                table: "Agreements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_LoanApplicationId",
                table: "Agreements",
                column: "LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_LoanApplications_LoanApplicationId",
                table: "Agreements",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_LoanApplications_LoanApplicationId",
                table: "Agreements");

            migrationBuilder.DropIndex(
                name: "IX_Agreements_LoanApplicationId",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "Agreements");
        }
    }
}
