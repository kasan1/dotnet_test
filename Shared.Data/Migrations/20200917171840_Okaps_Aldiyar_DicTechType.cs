using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Okaps_Aldiyar_DicTechType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DicLoanTypeId",
                table: "DicLoanProducts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DicLoanTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicLoanTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicTechTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    DicLoanProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTechTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicTechTypes_DicLoanProducts_DicLoanProductId",
                        column: x => x.DicLoanProductId,
                        principalTable: "DicLoanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicTechSubTypeses",
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
                    table.PrimaryKey("PK_DicTechSubTypeses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicTechSubTypeses_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicTechItemses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    DicTechTypeId = table.Column<Guid>(nullable: false),
                    DicTechSubTypesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTechItemses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicTechItemses_DicTechSubTypeses_DicTechSubTypesId",
                        column: x => x.DicTechSubTypesId,
                        principalTable: "DicTechSubTypeses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DicTechItemses_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicLoanProducts_DicLoanTypeId",
                table: "DicLoanProducts",
                column: "DicLoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechItemses_DicTechSubTypesId",
                table: "DicTechItemses",
                column: "DicTechSubTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechItemses_DicTechTypeId",
                table: "DicTechItemses",
                column: "DicTechTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechSubTypeses_DicTechTypeId",
                table: "DicTechSubTypeses",
                column: "DicTechTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechTypes_DicLoanProductId",
                table: "DicTechTypes",
                column: "DicLoanProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DicLoanProducts_DicLoanTypes_DicLoanTypeId",
                table: "DicLoanProducts",
                column: "DicLoanTypeId",
                principalTable: "DicLoanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DicLoanProducts_DicLoanTypes_DicLoanTypeId",
                table: "DicLoanProducts");

            migrationBuilder.DropTable(
                name: "DicLoanTypes");

            migrationBuilder.DropTable(
                name: "DicTechItemses");

            migrationBuilder.DropTable(
                name: "DicTechSubTypeses");

            migrationBuilder.DropTable(
                name: "DicTechTypes");

            migrationBuilder.DropIndex(
                name: "IX_DicLoanProducts_DicLoanTypeId",
                table: "DicLoanProducts");

            migrationBuilder.DropColumn(
                name: "DicLoanTypeId",
                table: "DicLoanProducts");
        }
    }
}
