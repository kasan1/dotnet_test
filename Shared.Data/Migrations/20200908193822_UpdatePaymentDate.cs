using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdatePaymentDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "LoanConditions");

            migrationBuilder.AddColumn<short>(
                name: "PaymentDay",
                table: "LoanConditions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDay",
                table: "LoanConditions");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "LoanConditions",
                type: "datetime2",
                nullable: true);
        }
    }
}
