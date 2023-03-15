using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddClassication21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DicDocClassifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    ParagraphNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicDocClassifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicClassificationSubtitles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    DocClassificationId = table.Column<Guid>(nullable: false),
                    ParagraphNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicClassificationSubtitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicClassificationSubtitles_DicDocClassifications_DocClassificationId",
                        column: x => x.DocClassificationId,
                        principalTable: "DicDocClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicWarningClassifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    ClassificationSubtitleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicWarningClassifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicWarningClassifications_DicClassificationSubtitles_ClassificationSubtitleId",
                        column: x => x.ClassificationSubtitleId,
                        principalTable: "DicClassificationSubtitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicClassificationSubtitles_DocClassificationId",
                table: "DicClassificationSubtitles",
                column: "DocClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DicWarningClassifications_ClassificationSubtitleId",
                table: "DicWarningClassifications",
                column: "ClassificationSubtitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DicWarningClassifications");

            migrationBuilder.DropTable(
                name: "DicClassificationSubtitles");

            migrationBuilder.DropTable(
                name: "DicDocClassifications");
        }
    }
}
