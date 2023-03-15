using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddCatoFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cato",
                table: "Nonmovables",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AtsId",
                table: "ClientProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cato",
                table: "ClientProfiles",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GeonimId",
                table: "ClientProfiles",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Level1",
                table: "ClientProfiles",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Level2",
                table: "ClientProfiles",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Level3",
                table: "ClientProfiles",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Level4",
                table: "ClientProfiles",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Level5",
                table: "ClientProfiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cato",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "AtsId",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "Cato",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "GeonimId",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "Level1",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "Level2",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "Level3",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "Level4",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "Level5",
                table: "ClientProfiles");
        }
    }
}
