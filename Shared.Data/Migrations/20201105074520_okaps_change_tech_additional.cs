using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class okaps_change_tech_additional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "AppTechnicses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                table: "AppTechnicses");
        }
    }
}
