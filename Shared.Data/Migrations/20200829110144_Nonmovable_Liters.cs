using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Nonmovable_Liters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Liters_BasePledge_BasePledgeId",
                table: "Liters");

            migrationBuilder.DropIndex(
                name: "IX_Liters_BasePledgeId",
                table: "Liters");

            migrationBuilder.DropColumn(
                name: "BasePledgeId",
                table: "Liters");

            migrationBuilder.DropColumn(
                name: "HasLiters",
                table: "BasePledge");

            migrationBuilder.AddColumn<bool>(
                name: "HasLiters",
                table: "Nonmovables",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "NonmovableId",
                table: "Liters",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Liters_NonmovableId",
                table: "Liters",
                column: "NonmovableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Liters_Nonmovables_NonmovableId",
                table: "Liters",
                column: "NonmovableId",
                principalTable: "Nonmovables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Liters_Nonmovables_NonmovableId",
                table: "Liters");

            migrationBuilder.DropIndex(
                name: "IX_Liters_NonmovableId",
                table: "Liters");

            migrationBuilder.DropColumn(
                name: "HasLiters",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "NonmovableId",
                table: "Liters");

            migrationBuilder.AddColumn<Guid>(
                name: "BasePledgeId",
                table: "Liters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "HasLiters",
                table: "BasePledge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Liters_BasePledgeId",
                table: "Liters",
                column: "BasePledgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Liters_BasePledge_BasePledgeId",
                table: "Liters",
                column: "BasePledgeId",
                principalTable: "BasePledge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
