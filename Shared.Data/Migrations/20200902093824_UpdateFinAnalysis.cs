using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateFinAnalysis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CountDPDPastInToYears",
                table: "FinAnalyses",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "ExistDPDPastInToYears",
                table: "FinAnalyses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "SumOverdueAmount",
                table: "FinAnalyses",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountDPDPastInToYears",
                table: "FinAnalyses");

            migrationBuilder.DropColumn(
                name: "ExistDPDPastInToYears",
                table: "FinAnalyses");

            migrationBuilder.DropColumn(
                name: "SumOverdueAmount",
                table: "FinAnalyses");
        }
    }
}
