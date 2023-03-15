using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class DocumentDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Page",
                table: "DocInformations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "DocInformations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "AgroFiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgroFiles_ApplicationId",
                table: "AgroFiles",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgroFiles_LoanApplications_ApplicationId",
                table: "AgroFiles",
                column: "ApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgroFiles_LoanApplications_ApplicationId",
                table: "AgroFiles");

            migrationBuilder.DropIndex(
                name: "IX_AgroFiles_ApplicationId",
                table: "AgroFiles");

            migrationBuilder.DropColumn(
                name: "Page",
                table: "DocInformations");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "DocInformations");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "AgroFiles");
        }
    }
}
