using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddJuristResultFixFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "FixFileId",
                table: "JuristResults",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FixReason",
                table: "JuristResults",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JuristResults_FixFileId",
                table: "JuristResults",
                column: "FixFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_JuristResults_AgroFiles_FixFileId",
                table: "JuristResults",
                column: "FixFileId",
                principalTable: "AgroFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JuristResults_AgroFiles_FixFileId",
                table: "JuristResults");

            migrationBuilder.DropIndex(
                name: "IX_JuristResults_FixFileId",
                table: "JuristResults");

            migrationBuilder.DropColumn(
                name: "FixFileId",
                table: "JuristResults");

            migrationBuilder.DropColumn(
                name: "FixReason",
                table: "JuristResults");

            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                table: "JuristResults",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
