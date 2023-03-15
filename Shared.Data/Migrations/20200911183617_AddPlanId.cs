using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddPlanId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualPayment",
                table: "LoanApplications");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanId",
                table: "LoanConditions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanConditions_PlanId",
                table: "LoanConditions",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanConditions_Plans_PlanId",
                table: "LoanConditions",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanConditions_Plans_PlanId",
                table: "LoanConditions");

            migrationBuilder.DropIndex(
                name: "IX_LoanConditions_PlanId",
                table: "LoanConditions");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "LoanConditions");

            migrationBuilder.AddColumn<double>(
                name: "AnnualPayment",
                table: "LoanApplications",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
