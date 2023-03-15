using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Okaps_Added_Calculator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculators_DicCountries_DicCountryId",
                table: "Calculators");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculators_DicProviders_DicProviderId",
                table: "Calculators");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculators_DicTechTypes_DicTechTypeId",
                table: "Calculators");

            migrationBuilder.DropIndex(
                name: "IX_Calculators_DicCountryId",
                table: "Calculators");

            migrationBuilder.DropIndex(
                name: "IX_Calculators_DicProviderId",
                table: "Calculators");

            migrationBuilder.DropIndex(
                name: "IX_Calculators_DicTechTypeId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "DicCountryId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "DicProviderId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "DicTechTypeId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "Sofinanc",
                table: "Calculators");

            migrationBuilder.AddColumn<Guid>(
                name: "PeriodPartId",
                table: "Calculators",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RatePartId",
                table: "Calculators",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SofinancPartId",
                table: "Calculators",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PeriodPart",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DicTechTypeId = table.Column<Guid>(nullable: true),
                    DicCountryId = table.Column<Guid>(nullable: true),
                    DicProviderId = table.Column<Guid>(nullable: true),
                    Sum = table.Column<decimal>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodPart_DicCountries_DicCountryId",
                        column: x => x.DicCountryId,
                        principalTable: "DicCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodPart_DicProviders_DicProviderId",
                        column: x => x.DicProviderId,
                        principalTable: "DicProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodPart_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RatePart",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DicCountryId = table.Column<Guid>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    DicTechTypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatePart_DicCountries_DicCountryId",
                        column: x => x.DicCountryId,
                        principalTable: "DicCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RatePart_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SofinancPart",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DicTechTypeId = table.Column<Guid>(nullable: true),
                    DicCountryId = table.Column<Guid>(nullable: true),
                    minPercent = table.Column<decimal>(nullable: false),
                    maxPercent = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SofinancPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SofinancPart_DicCountries_DicCountryId",
                        column: x => x.DicCountryId,
                        principalTable: "DicCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SofinancPart_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_PeriodPartId",
                table: "Calculators",
                column: "PeriodPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_RatePartId",
                table: "Calculators",
                column: "RatePartId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_SofinancPartId",
                table: "Calculators",
                column: "SofinancPartId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodPart_DicCountryId",
                table: "PeriodPart",
                column: "DicCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodPart_DicProviderId",
                table: "PeriodPart",
                column: "DicProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodPart_DicTechTypeId",
                table: "PeriodPart",
                column: "DicTechTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RatePart_DicCountryId",
                table: "RatePart",
                column: "DicCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RatePart_DicTechTypeId",
                table: "RatePart",
                column: "DicTechTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SofinancPart_DicCountryId",
                table: "SofinancPart",
                column: "DicCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SofinancPart_DicTechTypeId",
                table: "SofinancPart",
                column: "DicTechTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculators_PeriodPart_PeriodPartId",
                table: "Calculators",
                column: "PeriodPartId",
                principalTable: "PeriodPart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calculators_RatePart_RatePartId",
                table: "Calculators",
                column: "RatePartId",
                principalTable: "RatePart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calculators_SofinancPart_SofinancPartId",
                table: "Calculators",
                column: "SofinancPartId",
                principalTable: "SofinancPart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculators_PeriodPart_PeriodPartId",
                table: "Calculators");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculators_RatePart_RatePartId",
                table: "Calculators");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculators_SofinancPart_SofinancPartId",
                table: "Calculators");

            migrationBuilder.DropTable(
                name: "PeriodPart");

            migrationBuilder.DropTable(
                name: "RatePart");

            migrationBuilder.DropTable(
                name: "SofinancPart");

            migrationBuilder.DropIndex(
                name: "IX_Calculators_PeriodPartId",
                table: "Calculators");

            migrationBuilder.DropIndex(
                name: "IX_Calculators_RatePartId",
                table: "Calculators");

            migrationBuilder.DropIndex(
                name: "IX_Calculators_SofinancPartId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "PeriodPartId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "RatePartId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "SofinancPartId",
                table: "Calculators");

            migrationBuilder.AddColumn<Guid>(
                name: "DicCountryId",
                table: "Calculators",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicProviderId",
                table: "Calculators",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicTechTypeId",
                table: "Calculators",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "Calculators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Calculators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sofinanc",
                table: "Calculators",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Calculators_DicCountries_DicCountryId",
                table: "Calculators",
                column: "DicCountryId",
                principalTable: "DicCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calculators_DicProviders_DicProviderId",
                table: "Calculators",
                column: "DicProviderId",
                principalTable: "DicProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calculators_DicTechTypes_DicTechTypeId",
                table: "Calculators",
                column: "DicTechTypeId",
                principalTable: "DicTechTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
