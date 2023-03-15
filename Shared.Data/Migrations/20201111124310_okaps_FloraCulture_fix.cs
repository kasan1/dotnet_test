using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class okaps_FloraCulture_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccount",
                table: "ClientDetailses");

            migrationBuilder.AddColumn<string>(
                name: "BankAccountIIN",
                table: "ClientDetailses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountIIN",
                table: "ClientDetailses");

            migrationBuilder.AddColumn<string>(
                name: "BankAccount",
                table: "ClientDetailses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
