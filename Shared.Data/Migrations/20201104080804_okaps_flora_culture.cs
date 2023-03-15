using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class okaps_flora_culture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FloraCultures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    zatratyNa1Ga = table.Column<string>(nullable: true),
                    normaVyseva = table.Column<string>(nullable: true),
                    DicRegionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloraCultures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloraCultures_DicRegions_DicRegionId",
                        column: x => x.DicRegionId,
                        principalTable: "DicRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FloraCultures_DicRegionId",
                table: "FloraCultures",
                column: "DicRegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FloraCultures");
        }
    }
}
