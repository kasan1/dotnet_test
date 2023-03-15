using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Okaps_Add_TechTypeCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DicTechModels_DicTechProducts_DicTechProductId",
                table: "DicTechModels");

            migrationBuilder.AddColumn<string>(
                name: "TechTypeCode",
                table: "DicTechTypes",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DicTechProductId",
                table: "DicTechModels",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DicTechModels_DicTechProducts_DicTechProductId",
                table: "DicTechModels",
                column: "DicTechProductId",
                principalTable: "DicTechProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DicTechModels_DicTechProducts_DicTechProductId",
                table: "DicTechModels");

            migrationBuilder.DropColumn(
                name: "TechTypeCode",
                table: "DicTechTypes");

            migrationBuilder.AlterColumn<Guid>(
                name: "DicTechProductId",
                table: "DicTechModels",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_DicTechModels_DicTechProducts_DicTechProductId",
                table: "DicTechModels",
                column: "DicTechProductId",
                principalTable: "DicTechProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
