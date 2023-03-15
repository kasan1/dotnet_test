using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddSpecialRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasSpecialRelations",
                table: "FinAnalyses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAffiliated",
                table: "FinAnalyses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AffiliationPersonalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Identifier = table.Column<string>(maxLength: 12, nullable: false),
                    Fullname = table.Column<string>(maxLength: 500, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliationPersonalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Identifier = table.Column<string>(maxLength: 12, nullable: false),
                    Fullname = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialRelations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AffiliationPersonalities_IsDeleted",
                table: "AffiliationPersonalities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialRelations_IsDeleted",
                table: "SpecialRelations",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AffiliationPersonalities");

            migrationBuilder.DropTable(
                name: "SpecialRelations");

            migrationBuilder.DropColumn(
                name: "HasSpecialRelations",
                table: "FinAnalyses");

            migrationBuilder.DropColumn(
                name: "IsAffiliated",
                table: "FinAnalyses");
        }
    }
}
