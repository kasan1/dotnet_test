using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class FileDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DicDocumentTypes",
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
                    table.PrimaryKey("PK_DicDocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicFileTypes",
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
                    table.PrimaryKey("PK_DicFileTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    IsOriginal = table.Column<bool>(nullable: false),
                    DicDocumentTypeId = table.Column<Guid>(nullable: true),
                    DocumentCode = table.Column<string>(nullable: true),
                    PageCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocInformations_DicDocumentTypes_DicDocumentTypeId",
                        column: x => x.DicDocumentTypeId,
                        principalTable: "DicDocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgroFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    FileTypeId = table.Column<Guid>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    DeleteDateTime = table.Column<DateTime>(nullable: true),
                    DeletedUserId = table.Column<Guid>(nullable: true),
                    IsActual = table.Column<bool>(nullable: false),
                    DocInformationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgroFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgroFiles_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgroFiles_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgroFiles_DocInformations_DocInformationId",
                        column: x => x.DocInformationId,
                        principalTable: "DocInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgroFiles_DicFileTypes_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "DicFileTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgroFiles_CreatorUserId",
                table: "AgroFiles",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AgroFiles_DeletedUserId",
                table: "AgroFiles",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AgroFiles_DocInformationId",
                table: "AgroFiles",
                column: "DocInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_AgroFiles_FileTypeId",
                table: "AgroFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocInformations_DicDocumentTypeId",
                table: "DocInformations",
                column: "DicDocumentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgroFiles");

            migrationBuilder.DropTable(
                name: "DocInformations");

            migrationBuilder.DropTable(
                name: "DicFileTypes");

            migrationBuilder.DropTable(
                name: "DicDocumentTypes");
        }
    }
}
