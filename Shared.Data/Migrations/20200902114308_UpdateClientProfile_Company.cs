using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateClientProfile_Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientTypeCode",
                table: "ClientProfiles",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyActivity",
                table: "ClientProfiles",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "ClientProfiles",
                maxLength: 400,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "ClientProfiles",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CompanyNdc",
                table: "ClientProfiles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompanyRegisterDate",
                table: "ClientProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyRegisterNumber",
                table: "ClientProfiles",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanySerialNumber",
                table: "ClientProfiles",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientTypeCode",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "CompanyActivity",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "CompanyNdc",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "CompanyRegisterDate",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "CompanyRegisterNumber",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "CompanySerialNumber",
                table: "ClientProfiles");
        }
    }
}
