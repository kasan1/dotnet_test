using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class DicProductModelAndProviderRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DicTechModels_DicCountries_DicCountryId",
                table: "DicTechModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DicTechModels_DicProviders_DicProviderId",
                table: "DicTechModels");

            migrationBuilder.DropIndex(
                name: "IX_DicTechModels_DicCountryId",
                table: "DicTechModels");

            migrationBuilder.DropIndex(
                name: "IX_DicTechModels_DicProviderId",
                table: "DicTechModels");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "DicTechModels");

            migrationBuilder.DropColumn(
                name: "DicCountryId",
                table: "DicTechModels");

            migrationBuilder.DropColumn(
                name: "DicProviderId",
                table: "DicTechModels");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DicTechModels");

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "DicCountryTechModels",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "DicTechModelId",
                table: "DicCountryProviders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DicCountryProviders_DicTechModelId",
                table: "DicCountryProviders",
                column: "DicTechModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_DicCountryProviders_DicTechModels_DicTechModelId",
                table: "DicCountryProviders",
                column: "DicTechModelId",
                principalTable: "DicTechModels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DicCountryProviders_DicTechModels_DicTechModelId",
                table: "DicCountryProviders");

            migrationBuilder.DropIndex(
                name: "IX_DicCountryProviders_DicTechModelId",
                table: "DicCountryProviders");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "DicCountryTechModels");

            migrationBuilder.DropColumn(
                name: "DicTechModelId",
                table: "DicCountryProviders");

            migrationBuilder.AddColumn<string>(
                name: "Count",
                table: "DicTechModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicCountryId",
                table: "DicTechModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DicProviderId",
                table: "DicTechModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "DicTechModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DicTechModels_DicCountryId",
                table: "DicTechModels",
                column: "DicCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechModels_DicProviderId",
                table: "DicTechModels",
                column: "DicProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_DicTechModels_DicCountries_DicCountryId",
                table: "DicTechModels",
                column: "DicCountryId",
                principalTable: "DicCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DicTechModels_DicProviders_DicProviderId",
                table: "DicTechModels",
                column: "DicProviderId",
                principalTable: "DicProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
