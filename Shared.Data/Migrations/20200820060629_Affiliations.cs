using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Affiliations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DicAffiliations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicAffiliations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicAffiliationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    CodeAFN2 = table.Column<string>(nullable: true),
                    CodeKazAgro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicAffiliationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicAffiliationRelationships",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AffiliationId = table.Column<Guid>(nullable: false),
                    AffiliationTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicAffiliationRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicAffiliationRelationships_DicAffiliations_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "DicAffiliations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DicAffiliationRelationships_DicAffiliationTypes_AffiliationTypeId",
                        column: x => x.AffiliationTypeId,
                        principalTable: "DicAffiliationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicAffiliationRelationships_AffiliationId",
                table: "DicAffiliationRelationships",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "IX_DicAffiliationRelationships_AffiliationTypeId",
                table: "DicAffiliationRelationships",
                column: "AffiliationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DicAffiliationRelationships");

            migrationBuilder.DropTable(
                name: "DicAffiliations");

            migrationBuilder.DropTable(
                name: "DicAffiliationTypes");
        }
    }
}
