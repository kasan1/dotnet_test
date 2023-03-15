using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class SeedDocumentTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DicDocumentTypes",
                columns: new[] { "Id", "Code", "DocumentType", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[] { new Guid("a1d306c4-8724-4254-9571-7fea556aac0b"), "4", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "License", 0 });

            migrationBuilder.InsertData(
                table: "DicDocumentTypes",
                columns: new[] { "Id", "Code", "DocumentType", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[] { new Guid("c081be33-a850-4a4c-a2b8-99e6486e7dae"), "5", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "VatCertificate", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DicDocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("a1d306c4-8724-4254-9571-7fea556aac0b"));

            migrationBuilder.DeleteData(
                table: "DicDocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("c081be33-a850-4a4c-a2b8-99e6486e7dae"));
        }
    }
}
