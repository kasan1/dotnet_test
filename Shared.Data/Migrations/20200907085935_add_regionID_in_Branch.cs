using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class add_regionID_in_Branch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "Branches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_RegionId",
                table: "Branches",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_DicRegions_RegionId",
                table: "Branches",
                column: "RegionId",
                principalTable: "DicRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_DicRegions_RegionId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_RegionId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Branches");
        }
    }
}
