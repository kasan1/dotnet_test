using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AlterJuristResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                table: "JuristResults",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFixed",
                table: "JuristResults",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_JuristResults_FileId",
                table: "JuristResults",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_JuristResults_AgroFiles_FileId",
                table: "JuristResults",
                column: "FileId",
                principalTable: "AgroFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JuristResults_AgroFiles_FileId",
                table: "JuristResults");

            migrationBuilder.DropIndex(
                name: "IX_JuristResults_FileId",
                table: "JuristResults");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "JuristResults");

            migrationBuilder.DropColumn(
                name: "IsFixed",
                table: "JuristResults");
        }
    }
}
