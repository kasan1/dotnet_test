using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Okaps_ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DicTechItemses_DicTechSubTypeses_DicTechSubTypesId",
                table: "DicTechItemses");

            migrationBuilder.DropForeignKey(
                name: "FK_DicTechItemses_DicTechTypes_DicTechTypeId",
                table: "DicTechItemses");

            migrationBuilder.DropTable(
                name: "DicTechSubTypeses");

            migrationBuilder.DropIndex(
                name: "IX_DicTechItemses_DicTechSubTypesId",
                table: "DicTechItemses");

            migrationBuilder.DropColumn(
                name: "DicTechSubTypesId",
                table: "DicTechItemses");

            migrationBuilder.AlterColumn<Guid>(
                name: "DicTechTypeId",
                table: "DicTechItemses",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "DicTechClassTypesId",
                table: "DicTechItemses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DicTechClassTypeses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    DicTechTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTechClassTypeses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicTechClassTypeses_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicTechItemses_DicTechClassTypesId",
                table: "DicTechItemses",
                column: "DicTechClassTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechClassTypeses_DicTechTypeId",
                table: "DicTechClassTypeses",
                column: "DicTechTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DicTechItemses_DicTechClassTypeses_DicTechClassTypesId",
                table: "DicTechItemses",
                column: "DicTechClassTypesId",
                principalTable: "DicTechClassTypeses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DicTechItemses_DicTechTypes_DicTechTypeId",
                table: "DicTechItemses",
                column: "DicTechTypeId",
                principalTable: "DicTechTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DicTechItemses_DicTechClassTypeses_DicTechClassTypesId",
                table: "DicTechItemses");

            migrationBuilder.DropForeignKey(
                name: "FK_DicTechItemses_DicTechTypes_DicTechTypeId",
                table: "DicTechItemses");

            migrationBuilder.DropTable(
                name: "DicTechClassTypeses");

            migrationBuilder.DropIndex(
                name: "IX_DicTechItemses_DicTechClassTypesId",
                table: "DicTechItemses");

            migrationBuilder.DropColumn(
                name: "DicTechClassTypesId",
                table: "DicTechItemses");

            migrationBuilder.AlterColumn<Guid>(
                name: "DicTechTypeId",
                table: "DicTechItemses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicTechSubTypesId",
                table: "DicTechItemses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DicTechSubTypeses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DicTechTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameKz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameRu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTechSubTypeses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicTechSubTypeses_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicTechItemses_DicTechSubTypesId",
                table: "DicTechItemses",
                column: "DicTechSubTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechSubTypeses_DicTechTypeId",
                table: "DicTechSubTypeses",
                column: "DicTechTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DicTechItemses_DicTechSubTypeses_DicTechSubTypesId",
                table: "DicTechItemses",
                column: "DicTechSubTypesId",
                principalTable: "DicTechSubTypeses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DicTechItemses_DicTechTypes_DicTechTypeId",
                table: "DicTechItemses",
                column: "DicTechTypeId",
                principalTable: "DicTechTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
