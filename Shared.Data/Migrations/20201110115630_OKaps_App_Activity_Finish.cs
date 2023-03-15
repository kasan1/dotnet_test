using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class OKaps_App_Activity_Finish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edinica",
                table: "BioActivity");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BioActivity");

            migrationBuilder.DropColumn(
                name: "PriceForOne",
                table: "BioActivity");

            migrationBuilder.AddColumn<string>(
                name: "Urozh5",
                table: "FloraCultures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Urozh1",
                table: "FloraActivities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Urozh2",
                table: "FloraActivities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Urozh3",
                table: "FloraActivities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Urozh5",
                table: "FloraActivities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zatraty",
                table: "FloraActivities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "order",
                table: "FloraActivities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EdinicaForDead",
                table: "BioActivity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EdinicaForLive",
                table: "BioActivity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "BioActivity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Urozh5",
                table: "FloraCultures");

            migrationBuilder.DropColumn(
                name: "Urozh1",
                table: "FloraActivities");

            migrationBuilder.DropColumn(
                name: "Urozh2",
                table: "FloraActivities");

            migrationBuilder.DropColumn(
                name: "Urozh3",
                table: "FloraActivities");

            migrationBuilder.DropColumn(
                name: "Urozh5",
                table: "FloraActivities");

            migrationBuilder.DropColumn(
                name: "Zatraty",
                table: "FloraActivities");

            migrationBuilder.DropColumn(
                name: "order",
                table: "FloraActivities");

            migrationBuilder.DropColumn(
                name: "EdinicaForDead",
                table: "BioActivity");

            migrationBuilder.DropColumn(
                name: "EdinicaForLive",
                table: "BioActivity");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BioActivity");

            migrationBuilder.AddColumn<string>(
                name: "Edinica",
                table: "BioActivity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "BioActivity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceForOne",
                table: "BioActivity",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
