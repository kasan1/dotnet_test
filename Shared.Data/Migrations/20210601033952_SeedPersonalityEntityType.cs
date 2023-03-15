using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class SeedPersonalityEntityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PledgeDescription",
                table: "TechnicActivity",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

            migrationBuilder.UpdateData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("1c32c956-310f-4acf-9316-788e3d002d6e"),
                column: "CreatedDate",
                value: new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("71f8ffc5-8f64-41df-9004-41529398de84"),
                column: "CreatedDate",
                value: new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("83697c38-a05b-4a62-bb6d-17e1c51295b9"),
                column: "CreatedDate",
                value: new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("87301b5b-c361-4fe4-8a9f-5aa2e30ae24e"),
                column: "CreatedDate",
                value: new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("99a11953-e980-4839-871c-e88659401ac6"),
                column: "CreatedDate",
                value: new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "CreatedDate", "Description", "EntityTypeId", "ModifiedDate", "SystemName" },
                values: new object[] { new Guid("70c12155-26c0-41b2-b437-0a2ab751426e"), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Личные данные", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personality" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("70c12155-26c0-41b2-b437-0a2ab751426e"));

            migrationBuilder.AlterColumn<string>(
                name: "PledgeDescription",
                table: "TechnicActivity",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4000,
                oldNullable: true);
        }
    }
}
