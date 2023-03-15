using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddedCalculatorsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calculators",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    Sofinanc = table.Column<int>(nullable: false),
                    DicTechTypeId = table.Column<Guid>(nullable: true),
                    DicCountryId = table.Column<Guid>(nullable: true),
                    DicProviderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calculators_DicCountries_DicCountryId",
                        column: x => x.DicCountryId,
                        principalTable: "DicCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calculators_DicProviders_DicProviderId",
                        column: x => x.DicProviderId,
                        principalTable: "DicProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calculators_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_DicCountryId",
                table: "Calculators",
                column: "DicCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_DicProviderId",
                table: "Calculators",
                column: "DicProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_DicTechTypeId",
                table: "Calculators",
                column: "DicTechTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculators");
        }
    }
}
