using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class PledgeFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BasePledgeId",
                table: "AgroFiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgroFiles_BasePledgeId",
                table: "AgroFiles",
                column: "BasePledgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgroFiles_BasePledge_BasePledgeId",
                table: "AgroFiles",
                column: "BasePledgeId",
                principalTable: "BasePledge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgroFiles_BasePledge_BasePledgeId",
                table: "AgroFiles");

            migrationBuilder.DropIndex(
                name: "IX_AgroFiles_BasePledgeId",
                table: "AgroFiles");

            migrationBuilder.DropColumn(
                name: "BasePledgeId",
                table: "AgroFiles");
        }
    }
}
