using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddEntityTypeAndFileEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "seqRegnumber03");

            migrationBuilder.DropSequence(
                name: "seqRegnumber04");

            migrationBuilder.DropSequence(
                name: "seqRegnumber05");

            migrationBuilder.DropSequence(
                name: "seqRegnumber06");

            migrationBuilder.DropSequence(
                name: "seqRegnumber07");

            migrationBuilder.DropSequence(
                name: "seqRegnumber08");

            migrationBuilder.DropSequence(
                name: "seqRegnumber09");

            migrationBuilder.DropSequence(
                name: "seqRegnumber10");

            migrationBuilder.DropSequence(
                name: "seqRegnumber11");

            migrationBuilder.DropSequence(
                name: "seqRegnumber12");

            migrationBuilder.DropSequence(
                name: "seqRegnumber13");

            migrationBuilder.DropSequence(
                name: "seqRegnumber14");

            migrationBuilder.DropSequence(
                name: "seqRegnumber15");

            migrationBuilder.CreateTable(
                name: "EntityType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    SystemName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    EntityTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    EntityId = table.Column<Guid>(maxLength: 100, nullable: false),
                    EntityTypeId = table.Column<Guid>(maxLength: 100, nullable: false),
                    Filename = table.Column<string>(maxLength: 100, nullable: false),
                    Length = table.Column<long>(nullable: false),
                    ContentType = table.Column<string>(maxLength: 200, nullable: false),
                    Path = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityType_IsDeleted",
                table: "EntityType",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_EntityType_SystemName",
                table: "EntityType",
                column: "SystemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_IsDeleted",
                table: "Files",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityType");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber03");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber04");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber05");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber06");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber07");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber08");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber09");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber10");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber11");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber12");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber13");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber14");

            migrationBuilder.CreateSequence(
                name: "seqRegnumber15");
        }
    }
}
