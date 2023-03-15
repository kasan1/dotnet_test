using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateClientProfile_ClientTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientTypeCode",
                table: "ClientProfiles");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientTypeId",
                table: "ClientProfiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientProfiles_ClientTypeId",
                table: "ClientProfiles",
                column: "ClientTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProfiles_DicClientTypes_ClientTypeId",
                table: "ClientProfiles",
                column: "ClientTypeId",
                principalTable: "DicClientTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProfiles_DicClientTypes_ClientTypeId",
                table: "ClientProfiles");

            migrationBuilder.DropIndex(
                name: "IX_ClientProfiles_ClientTypeId",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "ClientTypeId",
                table: "ClientProfiles");

            migrationBuilder.AddColumn<string>(
                name: "ClientTypeCode",
                table: "ClientProfiles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
