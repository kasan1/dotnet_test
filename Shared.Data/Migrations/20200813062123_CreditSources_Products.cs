using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class CreditSources_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DicProducts",
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
                    table.PrimaryKey("PK_DicProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditSources",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PercentStandart = table.Column<decimal>(nullable: false),
                    PercentEffStandart = table.Column<decimal>(nullable: false),
                    PercentSocial = table.Column<decimal>(nullable: false),
                    PercentEffSocial = table.Column<decimal>(nullable: false),
                    MaxMonth = table.Column<int>(nullable: false),
                    MaxSum = table.Column<decimal>(nullable: false),
                    MaxSumAnchor = table.Column<decimal>(nullable: false),
                    DicProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditSources_DicProducts_DicProductId",
                        column: x => x.DicProductId,
                        principalTable: "DicProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditSources_DicProductId",
                table: "CreditSources",
                column: "DicProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditSources");

            migrationBuilder.DropTable(
                name: "DicProducts");
        }
    }
}
