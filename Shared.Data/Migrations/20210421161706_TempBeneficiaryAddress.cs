using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class TempBeneficiaryAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryAddress",
                table: "ClientDetailses",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BeneficiaryIsResident",
                table: "ClientDetailses",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiaryAddress",
                table: "ClientDetailses");

            migrationBuilder.DropColumn(
                name: "BeneficiaryIsResident",
                table: "ClientDetailses");
        }
    }
}
