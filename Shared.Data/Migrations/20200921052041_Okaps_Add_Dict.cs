using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Okaps_Add_Dict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DicTechItemses");

            migrationBuilder.DropTable(
                name: "DicTechClassTypeses");

            migrationBuilder.DropColumn(
                name: "HasChildType",
                table: "DicTechTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "DicTechTypes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DicProviders",
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
                    table.PrimaryKey("PK_DicProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicTechProducts",
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
                    table.PrimaryKey("PK_DicTechProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicTechProducts_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicTechModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    DicCountryId = table.Column<Guid>(nullable: false),
                    DicProviderId = table.Column<Guid>(nullable: false),
                    Price = table.Column<string>(nullable: true),
                    Count = table.Column<string>(nullable: true),
                    DicTechProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTechModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicTechModels_DicCountries_DicCountryId",
                        column: x => x.DicCountryId,
                        principalTable: "DicCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DicTechModels_DicProviders_DicProviderId",
                        column: x => x.DicProviderId,
                        principalTable: "DicProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DicTechModels_DicTechProducts_DicTechProductId",
                        column: x => x.DicTechProductId,
                        principalTable: "DicTechProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicTechTypes_ParentId",
                table: "DicTechTypes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechModels_DicCountryId",
                table: "DicTechModels",
                column: "DicCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechModels_DicProviderId",
                table: "DicTechModels",
                column: "DicProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechModels_DicTechProductId",
                table: "DicTechModels",
                column: "DicTechProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechProducts_DicTechTypeId",
                table: "DicTechProducts",
                column: "DicTechTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DicTechTypes_DicTechTypes_ParentId",
                table: "DicTechTypes",
                column: "ParentId",
                principalTable: "DicTechTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DicTechTypes_DicTechTypes_ParentId",
                table: "DicTechTypes");

            migrationBuilder.DropTable(
                name: "DicTechModels");

            migrationBuilder.DropTable(
                name: "DicProviders");

            migrationBuilder.DropTable(
                name: "DicTechProducts");

            migrationBuilder.DropIndex(
                name: "IX_DicTechTypes_ParentId",
                table: "DicTechTypes");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "DicTechTypes");

            migrationBuilder.AddColumn<bool>(
                name: "HasChildType",
                table: "DicTechTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DicTechClassTypeses",
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
                    table.PrimaryKey("PK_DicTechClassTypeses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicTechClassTypeses_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicTechItemses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DicTechClassTypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DicTechTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameKz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameRu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTechItemses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicTechItemses_DicTechClassTypeses_DicTechClassTypesId",
                        column: x => x.DicTechClassTypesId,
                        principalTable: "DicTechClassTypeses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DicTechItemses_DicTechTypes_DicTechTypeId",
                        column: x => x.DicTechTypeId,
                        principalTable: "DicTechTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicTechClassTypeses_DicTechTypeId",
                table: "DicTechClassTypeses",
                column: "DicTechTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechItemses_DicTechClassTypesId",
                table: "DicTechItemses",
                column: "DicTechClassTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTechItemses_DicTechTypeId",
                table: "DicTechItemses",
                column: "DicTechTypeId");
        }
    }
}
