using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddPledgeAsonLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Level1",
                table: "Nonmovables",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Level2",
                table: "Nonmovables",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Level3",
                table: "Nonmovables",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Level4",
                table: "Nonmovables",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Level5",
                table: "Nonmovables",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level1",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "Level2",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "Level3",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "Level4",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "Level5",
                table: "Nonmovables");
        }
    }
}
