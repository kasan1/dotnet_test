using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class SeedEntityTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityType",
                table: "EntityType");

            migrationBuilder.RenameTable(
                name: "EntityType",
                newName: "EntityTypes");

            migrationBuilder.RenameIndex(
                name: "IX_EntityType_SystemName",
                table: "EntityTypes",
                newName: "IX_EntityTypes_SystemName");

            migrationBuilder.RenameIndex(
                name: "IX_EntityType_IsDeleted",
                table: "EntityTypes",
                newName: "IX_EntityTypes_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityTypes",
                table: "EntityTypes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Description", "EntityTypeId", "ModifiedDate", "SystemName" },
                values: new object[] { new Guid("9a9e37a1-dc21-4a54-9bb8-31c988bf2492"), "Заявка", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LoanApplication" });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Description", "EntityTypeId", "ModifiedDate", "SystemName" },
                values: new object[] { new Guid("7c58bace-25be-4ef2-86e9-01f86de4f315"), "Задачи по заявке", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LoanApplicationTask" });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Description", "EntityTypeId", "ModifiedDate", "SystemName" },
                values: new object[] { new Guid("fdca3c77-aff4-4235-9686-619f7a6e7402"), "Файл из интеграции с PKB", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PKB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityTypes",
                table: "EntityTypes");

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("7c58bace-25be-4ef2-86e9-01f86de4f315"));

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("9a9e37a1-dc21-4a54-9bb8-31c988bf2492"));

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("fdca3c77-aff4-4235-9686-619f7a6e7402"));

            migrationBuilder.RenameTable(
                name: "EntityTypes",
                newName: "EntityType");

            migrationBuilder.RenameIndex(
                name: "IX_EntityTypes_SystemName",
                table: "EntityType",
                newName: "IX_EntityType_SystemName");

            migrationBuilder.RenameIndex(
                name: "IX_EntityTypes_IsDeleted",
                table: "EntityType",
                newName: "IX_EntityType_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityType",
                table: "EntityType",
                column: "Id");
        }
    }
}
