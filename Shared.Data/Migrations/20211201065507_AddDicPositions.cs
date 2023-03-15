using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddDicPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DicPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Sort = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    NameRu = table.Column<string>(maxLength: 200, nullable: false),
                    NameKk = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicPositions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DicPositions",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("68fd6f1c-1a18-4416-8e16-9ab1710fb5af"), "director", null, "Директор филиала АО «КазАгроФинанс»", "Директор филиала АО «КазАгроФинанс»", 0 },
                    { new Guid("3f556caf-98be-44b3-8015-c05a9f09bf36"), "credit-admin", null, "Кредитный администратор филиала", "Кредитный администратор филиала", 0 },
                    { new Guid("34082404-0c92-40a7-98f3-691159e61a0b"), "deputy-director", null, "Заместитель директора", "Заместитель директора", 0 },
                    { new Guid("bb9f2320-bdd7-4083-9589-897c21eaae34"), "jurist-consultant", null, "Юристконсульт филиала", "Юристконсульт филиала", 0 },
                    { new Guid("d04cea35-1965-484c-8cff-daa0c3aa44b7"), "risk-manager", null, "Риск-менеджер филиала", "Риск-менеджер филиала", 0 },
                    { new Guid("4cfc6d3d-5bdb-44bd-a059-c216d7e88624"), "appraiser", null, "Специалист-оценщик филиала", "Специалист-оценщик филиала", 0 },
                    { new Guid("148064c7-1247-484a-a1de-a43d6df9b262"), "manager", null, "Менеджер", "Менеджер", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicPositions_IsDeleted",
                table: "DicPositions",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DicPositions");
        }
    }
}
