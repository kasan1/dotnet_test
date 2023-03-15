using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateBasePledge_Liquidity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Coefficient",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LiquidityType",
                table: "BasePledge",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coefficient",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "LiquidityType",
                table: "BasePledge");
        }
    }
}
