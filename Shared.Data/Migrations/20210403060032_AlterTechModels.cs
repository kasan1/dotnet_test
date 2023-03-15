using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AlterTechModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sum",
                table: "Calculators",
                newName: "Sum");

            migrationBuilder.CreateTable(
                name: "DicCountryProvider",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DicCountryId = table.Column<Guid>(nullable: false),
                    DicProviderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicCountryProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicCountryProvider_DicCountries_DicCountryId",
                        column: x => x.DicCountryId,
                        principalTable: "DicCountries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DicCountryProvider_DicProviders_DicProviderId",
                        column: x => x.DicProviderId,
                        principalTable: "DicProviders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DicCountryTechModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DicCountryId = table.Column<Guid>(nullable: false),
                    DicTechModelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicCountryTechModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicCountryTechModel_DicCountries_DicCountryId",
                        column: x => x.DicCountryId,
                        principalTable: "DicCountries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DicCountryTechModel_DicTechModels_DicTechModelId",
                        column: x => x.DicTechModelId,
                        principalTable: "DicTechModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicCountryProvider_DicCountryId",
                table: "DicCountryProvider",
                column: "DicCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DicCountryProvider_DicProviderId",
                table: "DicCountryProvider",
                column: "DicProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_DicCountryProvider_IsDeleted",
                table: "DicCountryProvider",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DicCountryTechModel_DicCountryId",
                table: "DicCountryTechModel",
                column: "DicCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DicCountryTechModel_DicTechModelId",
                table: "DicCountryTechModel",
                column: "DicTechModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DicCountryTechModel_IsDeleted",
                table: "DicCountryTechModel",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DicCountryProvider");

            migrationBuilder.DropTable(
                name: "DicCountryTechModel");

            migrationBuilder.RenameColumn(
                name: "Sum",
                table: "Calculators",
                newName: "sum");
        }
    }
}
