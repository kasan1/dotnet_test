using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddJuristComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LegalComment",
                table: "Chargees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalComment",
                table: "BasePledge",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LegalComment",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "LegalComment",
                table: "BasePledge");
        }
    }
}
