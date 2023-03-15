using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class SeqRegnumber_UpdateClientProfile_Branch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "seqRegnumber03");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber04");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber05");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber06");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber07");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber08");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber09");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber10");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber11");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber12");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber13");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber14");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber15");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationAddressDistrictCode",
                table: "ClientProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationAddressRegionCode",
                table: "ClientProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Branches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "seqRegnumber03");

            migrationBuilder.DropSequence(
                name: "seqRegnumber04");

            migrationBuilder.DropSequence(
                name: "seqRegnumber05");

            migrationBuilder.DropSequence(
                name: "seqRegnumber06");

            migrationBuilder.DropSequence(
                name: "seqRegnumber07");

            migrationBuilder.DropSequence(
                name: "seqRegnumber08");

            migrationBuilder.DropSequence(
                name: "seqRegnumber09");

            migrationBuilder.DropSequence(
                name: "seqRegnumber10");

            migrationBuilder.DropSequence(
                name: "seqRegnumber11");

            migrationBuilder.DropSequence(
                name: "seqRegnumber12");

            migrationBuilder.DropSequence(
                name: "seqRegnumber13");

            migrationBuilder.DropSequence(
                name: "seqRegnumber14");

            migrationBuilder.DropSequence(
                name: "seqRegnumber15");

            migrationBuilder.DropColumn(
                name: "RegistrationAddressDistrictCode",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "RegistrationAddressRegionCode",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Branches");
        }
    }
}
