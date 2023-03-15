using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class SeedUserImageEntityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Description", "EntityTypeId", "ModifiedDate", "SystemName" },
                values: new object[] { new Guid("4b5b026a-72b9-4ffb-b398-4d6c85181549"), "Фото пользователя", 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserImage" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("4b5b026a-72b9-4ffb-b398-4d6c85181549"));
        }
    }
}
