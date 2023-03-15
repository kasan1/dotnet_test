using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class TempBeneficiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryIdentifier",
                table: "ClientDetailses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryPassportCreateDate",
                table: "ClientDetailses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryPassportIssuerName",
                table: "ClientDetailses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryPassportNumber",
                table: "ClientDetailses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiaryIdentifier",
                table: "ClientDetailses");

            migrationBuilder.DropColumn(
                name: "BeneficiaryPassportCreateDate",
                table: "ClientDetailses");

            migrationBuilder.DropColumn(
                name: "BeneficiaryPassportIssuerName",
                table: "ClientDetailses");

            migrationBuilder.DropColumn(
                name: "BeneficiaryPassportNumber",
                table: "ClientDetailses");
        }
    }
}
