using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class MatTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "ClientDetailses");

            migrationBuilder.AddColumn<bool>(
                name: "Step1",
                table: "LoanApplications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Step2",
                table: "LoanApplications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Step3",
                table: "LoanApplications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Step4",
                table: "LoanApplications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Step1",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "Step2",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "Step3",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "Step4",
                table: "LoanApplications");

            migrationBuilder.AddColumn<Guid>(
                name: "Region",
                table: "ClientDetailses",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
