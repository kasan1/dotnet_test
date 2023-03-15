using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class DicCountryRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DicCountryProvider_DicCountries_DicCountryId",
                table: "DicCountryProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_DicCountryProvider_DicProviders_DicProviderId",
                table: "DicCountryProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_DicCountryTechModel_DicCountries_DicCountryId",
                table: "DicCountryTechModel");

            migrationBuilder.DropForeignKey(
                name: "FK_DicCountryTechModel_DicTechModels_DicTechModelId",
                table: "DicCountryTechModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DicCountryTechModel",
                table: "DicCountryTechModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DicCountryProvider",
                table: "DicCountryProvider");

            migrationBuilder.RenameTable(
                name: "DicCountryTechModel",
                newName: "DicCountryTechModels");

            migrationBuilder.RenameTable(
                name: "DicCountryProvider",
                newName: "DicCountryProviders");

            migrationBuilder.RenameIndex(
                name: "IX_DicCountryTechModel_IsDeleted",
                table: "DicCountryTechModels",
                newName: "IX_DicCountryTechModels_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_DicCountryTechModel_DicTechModelId",
                table: "DicCountryTechModels",
                newName: "IX_DicCountryTechModels_DicTechModelId");

            migrationBuilder.RenameIndex(
                name: "IX_DicCountryTechModel_DicCountryId",
                table: "DicCountryTechModels",
                newName: "IX_DicCountryTechModels_DicCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_DicCountryProvider_IsDeleted",
                table: "DicCountryProviders",
                newName: "IX_DicCountryProviders_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_DicCountryProvider_DicProviderId",
                table: "DicCountryProviders",
                newName: "IX_DicCountryProviders_DicProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_DicCountryProvider_DicCountryId",
                table: "DicCountryProviders",
                newName: "IX_DicCountryProviders_DicCountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DicCountryTechModels",
                table: "DicCountryTechModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DicCountryProviders",
                table: "DicCountryProviders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DicCountryProviders_DicCountries_DicCountryId",
                table: "DicCountryProviders",
                column: "DicCountryId",
                principalTable: "DicCountries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DicCountryProviders_DicProviders_DicProviderId",
                table: "DicCountryProviders",
                column: "DicProviderId",
                principalTable: "DicProviders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DicCountryTechModels_DicCountries_DicCountryId",
                table: "DicCountryTechModels",
                column: "DicCountryId",
                principalTable: "DicCountries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DicCountryTechModels_DicTechModels_DicTechModelId",
                table: "DicCountryTechModels",
                column: "DicTechModelId",
                principalTable: "DicTechModels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DicCountryProviders_DicCountries_DicCountryId",
                table: "DicCountryProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_DicCountryProviders_DicProviders_DicProviderId",
                table: "DicCountryProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_DicCountryTechModels_DicCountries_DicCountryId",
                table: "DicCountryTechModels");

            migrationBuilder.DropForeignKey(
                name: "FK_DicCountryTechModels_DicTechModels_DicTechModelId",
                table: "DicCountryTechModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DicCountryTechModels",
                table: "DicCountryTechModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DicCountryProviders",
                table: "DicCountryProviders");

            migrationBuilder.RenameTable(
                name: "DicCountryTechModels",
                newName: "DicCountryTechModel");

            migrationBuilder.RenameTable(
                name: "DicCountryProviders",
                newName: "DicCountryProvider");

            migrationBuilder.RenameIndex(
                name: "IX_DicCountryTechModels_IsDeleted",
                table: "DicCountryTechModel",
                newName: "IX_DicCountryTechModel_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_DicCountryTechModels_DicTechModelId",
                table: "DicCountryTechModel",
                newName: "IX_DicCountryTechModel_DicTechModelId");

            migrationBuilder.RenameIndex(
                name: "IX_DicCountryTechModels_DicCountryId",
                table: "DicCountryTechModel",
                newName: "IX_DicCountryTechModel_DicCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_DicCountryProviders_IsDeleted",
                table: "DicCountryProvider",
                newName: "IX_DicCountryProvider_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_DicCountryProviders_DicProviderId",
                table: "DicCountryProvider",
                newName: "IX_DicCountryProvider_DicProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_DicCountryProviders_DicCountryId",
                table: "DicCountryProvider",
                newName: "IX_DicCountryProvider_DicCountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DicCountryTechModel",
                table: "DicCountryTechModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DicCountryProvider",
                table: "DicCountryProvider",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DicCountryProvider_DicCountries_DicCountryId",
                table: "DicCountryProvider",
                column: "DicCountryId",
                principalTable: "DicCountries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DicCountryProvider_DicProviders_DicProviderId",
                table: "DicCountryProvider",
                column: "DicProviderId",
                principalTable: "DicProviders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DicCountryTechModel_DicCountries_DicCountryId",
                table: "DicCountryTechModel",
                column: "DicCountryId",
                principalTable: "DicCountries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DicCountryTechModel_DicTechModels_DicTechModelId",
                table: "DicCountryTechModel",
                column: "DicTechModelId",
                principalTable: "DicTechModels",
                principalColumn: "Id");
        }
    }
}
