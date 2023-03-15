using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Plans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DicRegions",
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
                    table.PrimaryKey("PK_DicRegions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LoanFinancingSourceId = table.Column<int>(nullable: false),
                    LoanFinancingSourceId1 = table.Column<Guid>(nullable: true),
                    ActivityTypeId = table.Column<int>(nullable: false),
                    TypeId = table.Column<Guid>(nullable: true),
                    RegionId = table.Column<int>(nullable: false),
                    RegionId1 = table.Column<Guid>(nullable: true),
                    Sum = table.Column<decimal>(nullable: false),
                    FeedSum = table.Column<decimal>(nullable: false),
                    ProfitYearStandart = table.Column<decimal>(nullable: false),
                    ProfitYearSocial = table.Column<decimal>(nullable: false),
                    AnimalCount = table.Column<int>(nullable: false),
                    IsHasFeed = table.Column<bool>(nullable: false),
                    FileStandartId = table.Column<int>(nullable: true),
                    FileStandartId1 = table.Column<Guid>(nullable: true),
                    FileSocialId = table.Column<int>(nullable: true),
                    FileSocialId1 = table.Column<Guid>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    Version = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_AgroFiles_FileSocialId1",
                        column: x => x.FileSocialId1,
                        principalTable: "AgroFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_AgroFiles_FileStandartId1",
                        column: x => x.FileStandartId1,
                        principalTable: "AgroFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_DicLoanFinancingSources_LoanFinancingSourceId1",
                        column: x => x.LoanFinancingSourceId1,
                        principalTable: "DicLoanFinancingSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_DicRegions_RegionId1",
                        column: x => x.RegionId1,
                        principalTable: "DicRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_DicActivityTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DicActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plans_FileSocialId1",
                table: "Plans",
                column: "FileSocialId1");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_FileStandartId1",
                table: "Plans",
                column: "FileStandartId1");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_LoanFinancingSourceId1",
                table: "Plans",
                column: "LoanFinancingSourceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_RegionId1",
                table: "Plans",
                column: "RegionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_TypeId",
                table: "Plans",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "DicRegions");
        }
    }
}
