using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateNonmovable_Numbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AtsId",
                table: "Nonmovables",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GeonimId",
                table: "Nonmovables",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "HouseNumber",
                table: "Nonmovables",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "Nonmovables",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtsId",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "GeonimId",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Nonmovables");
        }
    }
}
