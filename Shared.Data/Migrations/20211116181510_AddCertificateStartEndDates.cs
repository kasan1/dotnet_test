using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddCertificateStartEndDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CertificateEndDate",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CertificateStartDate",
                table: "UserProfiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CertificateEndDate",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "CertificateStartDate",
                table: "UserProfiles");
        }
    }
}
