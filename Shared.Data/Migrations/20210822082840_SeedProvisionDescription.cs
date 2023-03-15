using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class SeedProvisionDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DicProvisionDescription",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[] { new Guid("03723eeb-7807-44a8-92b4-ebe52825b652"), "0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Не указано", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DicProvisionDescription",
                keyColumn: "Id",
                keyValue: new Guid("03723eeb-7807-44a8-92b4-ebe52825b652"));
        }
    }
}
