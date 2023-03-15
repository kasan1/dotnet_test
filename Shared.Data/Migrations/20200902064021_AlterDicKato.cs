using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AlterDicKato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ab",
                table: "DicKato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cd",
                table: "DicKato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ef",
                table: "DicKato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hij",
                table: "DicKato",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ab",
                table: "DicKato");

            migrationBuilder.DropColumn(
                name: "Cd",
                table: "DicKato");

            migrationBuilder.DropColumn(
                name: "Ef",
                table: "DicKato");

            migrationBuilder.DropColumn(
                name: "Hij",
                table: "DicKato");
        }
    }
}
