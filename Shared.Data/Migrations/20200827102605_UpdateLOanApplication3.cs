using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateLOanApplication3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AnnualPayment",
                table: "LoanApplications",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "Capital",
                table: "LoanApplications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProjectDescription",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WithoutFood",
                table: "LoanApplications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualPayment",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "Capital",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "ProjectDescription",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "WithoutFood",
                table: "LoanApplications");
        }
    }
}
