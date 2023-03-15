using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Okaps_Added_Calculator_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "PeriodPart");

            migrationBuilder.AddColumn<int>(
                name: "maxDuration",
                table: "PeriodPart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "minDuration",
                table: "PeriodPart",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maxDuration",
                table: "PeriodPart");

            migrationBuilder.DropColumn(
                name: "minDuration",
                table: "PeriodPart");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "PeriodPart",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
