using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddLoanAppJuristComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CliLegalCommentRk",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CliLegalCommentVnd",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CliLegalResultRk",
                table: "LoanApplications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CliLegalResultVnd",
                table: "LoanApplications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CliLegalCommentRk",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "CliLegalCommentVnd",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "CliLegalResultRk",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "CliLegalResultVnd",
                table: "LoanApplications");
        }
    }
}
