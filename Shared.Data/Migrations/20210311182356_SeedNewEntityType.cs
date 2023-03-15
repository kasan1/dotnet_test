using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class SeedNewEntityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DicVerificationStatus",
                table: "DicVerificationStatus");

            migrationBuilder.RenameTable(
                name: "DicVerificationStatus",
                newName: "DicVerificationStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_DicVerificationStatus_IsDeleted",
                table: "DicVerificationStatuses",
                newName: "IX_DicVerificationStatuses_IsDeleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Files",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "EntityTypes",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "DicVerificationStatuses",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DicVerificationStatuses",
                table: "DicVerificationStatuses",
                column: "Id");

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Description", "EntityTypeId", "ModifiedDate", "SystemName" },
                values: new object[] { new Guid("87301b5b-c361-4fe4-8a9f-5aa2e30ae24e"), "Файл из интеграции с GKB", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GKB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DicVerificationStatuses",
                table: "DicVerificationStatuses");

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("87301b5b-c361-4fe4-8a9f-5aa2e30ae24e"));

            migrationBuilder.RenameTable(
                name: "DicVerificationStatuses",
                newName: "DicVerificationStatus");

            migrationBuilder.RenameIndex(
                name: "IX_DicVerificationStatuses_IsDeleted",
                table: "DicVerificationStatus",
                newName: "IX_DicVerificationStatus_IsDeleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Files",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "EntityTypes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "DicVerificationStatus",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DicVerificationStatus",
                table: "DicVerificationStatus",
                column: "Id");
        }
    }
}
