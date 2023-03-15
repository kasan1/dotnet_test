using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class RemoveAgroFilesDocInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinAnalyses_AgroFiles_CreditReportId",
                table: "FinAnalyses");

            migrationBuilder.DropForeignKey(
                name: "FK_JuristResults_AgroFiles_FixFileId",
                table: "JuristResults");

            migrationBuilder.DropTable(
                name: "AgroFiles");

            migrationBuilder.DropTable(
                name: "DocInformations");

            migrationBuilder.DropIndex(
                name: "IX_JuristResults_FixFileId",
                table: "JuristResults");

            migrationBuilder.DropIndex(
                name: "IX_FinAnalyses_CreditReportId",
                table: "FinAnalyses");

            migrationBuilder.DropColumn(
                name: "FixFileId",
                table: "JuristResults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FixFileId",
                table: "JuristResults",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DicDocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsOriginal = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Page = table.Column<int>(type: "int", nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    PageInterval = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FileTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActual = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgroFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgroFiles_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_JuristResults_FixFileId",
                table: "JuristResults",
                column: "FixFileId");

            migrationBuilder.CreateIndex(
                name: "IX_FinAnalyses_CreditReportId",
                table: "FinAnalyses",
                column: "CreditReportId");

            migrationBuilder.CreateIndex(
                name: "IX_AgroFiles_ApplicationId",
                table: "AgroFiles",
                column: "ApplicationId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_FinAnalyses_AgroFiles_CreditReportId",
                table: "FinAnalyses",
                column: "CreditReportId",
                principalTable: "AgroFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JuristResults_AgroFiles_FixFileId",
                table: "JuristResults",
                column: "FixFileId",
                principalTable: "AgroFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
