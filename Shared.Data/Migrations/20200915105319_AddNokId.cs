using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddNokId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DicNokId",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasePledge_DicNokId",
                table: "BasePledge",
                column: "DicNokId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePledge_DicNoks_DicNokId",
                table: "BasePledge",
                column: "DicNokId",
                principalTable: "DicNoks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasePledge_DicNoks_DicNokId",
                table: "BasePledge");

            migrationBuilder.DropIndex(
                name: "IX_BasePledge_DicNokId",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "DicNokId",
                table: "BasePledge");
        }
    }
}
