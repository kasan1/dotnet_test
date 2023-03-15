using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Okaps_Adding_AccessoriesForTech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DicAccessoriesId",
                table: "DicTechProducts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DicAccessorieses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    DicTechTypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicAccessorieses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicAccessorieses_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicTechProducts_DicAccessoriesId",
                table: "DicTechProducts",
                column: "DicAccessoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_DicAccessorieses_DicTechTypeId",
                table: "DicAccessorieses",
                column: "DicTechTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DicTechProducts_DicAccessorieses_DicAccessoriesId",
                table: "DicTechProducts",
                column: "DicAccessoriesId",
                principalTable: "DicAccessorieses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DicTechProducts_DicAccessorieses_DicAccessoriesId",
                table: "DicTechProducts");

            migrationBuilder.DropTable(
                name: "DicAccessorieses");

            migrationBuilder.DropIndex(
                name: "IX_DicTechProducts_DicAccessoriesId",
                table: "DicTechProducts");

            migrationBuilder.DropColumn(
                name: "DicAccessoriesId",
                table: "DicTechProducts");
        }
    }
}
