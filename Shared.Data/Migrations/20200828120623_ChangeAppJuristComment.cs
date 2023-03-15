using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class ChangeAppJuristComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientCommentRk",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "ClientCommentVnd",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "ClientResultRk",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "ClientResultVnd",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "ClientCommentRk",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "ClientCommentVnd",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "ClientResultRk",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "ClientResultVnd",
                table: "BasePledge");

            migrationBuilder.AddColumn<string>(
                name: "LegalCommentRk",
                table: "Chargees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalCommentVnd",
                table: "Chargees",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LegalResultRk",
                table: "Chargees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LegalResultVnd",
                table: "Chargees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LegalCommentRk",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalCommentVnd",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LegalResultRk",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LegalResultVnd",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LegalCommentRk",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "LegalCommentVnd",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "LegalResultRk",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "LegalResultVnd",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "LegalCommentRk",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "LegalCommentVnd",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "LegalResultRk",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "LegalResultVnd",
                table: "BasePledge");

            migrationBuilder.AddColumn<string>(
                name: "ClientCommentRk",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientCommentVnd",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ClientResultRk",
                table: "Chargees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClientResultVnd",
                table: "Chargees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ClientCommentRk",
                table: "BasePledge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientCommentVnd",
                table: "BasePledge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ClientResultRk",
                table: "BasePledge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClientResultVnd",
                table: "BasePledge",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
