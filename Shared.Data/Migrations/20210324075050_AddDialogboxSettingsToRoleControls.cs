using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddDialogboxSettingsToRoleControls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DialogMessageKk",
                table: "RoleControlsButtons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DialogMessageRu",
                table: "RoleControlsButtons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DialogTitleKk",
                table: "RoleControlsButtons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DialogTitleRu",
                table: "RoleControlsButtons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DialogMessageKk",
                table: "RoleControlsButtons");

            migrationBuilder.DropColumn(
                name: "DialogMessageRu",
                table: "RoleControlsButtons");

            migrationBuilder.DropColumn(
                name: "DialogTitleKk",
                table: "RoleControlsButtons");

            migrationBuilder.DropColumn(
                name: "DialogTitleRu",
                table: "RoleControlsButtons");
        }
    }
}
