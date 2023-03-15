using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class ModifyEntityDicLoanType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameRu",
                table: "DicLoanTypes",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameKk",
                table: "DicLoanTypes",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "DicLoanTypes",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DicLoanTypes",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DicLoanTypes",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "DicLoanTypes",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "DicLoanTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DicLoanTypes",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort", "Value" },
                values: new object[] { new Guid("763b5ce2-7013-481c-a7d2-d237a4793035"), "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ЛИЗИНГ", "ЛИЗИНГ", 0, 0 });

            migrationBuilder.InsertData(
                table: "DicLoanTypes",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort", "Value" },
                values: new object[] { new Guid("fa1fbb94-e3a3-4482-970b-379ef3450b19"), "1.1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Стандартный лизинг", "Стандартный лизинг", 0, 1 });

            migrationBuilder.InsertData(
                table: "DicLoanTypes",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort", "Value" },
                values: new object[] { new Guid("74e65f85-7ec4-4909-8dc9-de53fe9455ef"), "1.2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Экспресс лизинг", "Экспресс лизинг", 0, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_DicLoanTypes_IsDeleted",
                table: "DicLoanTypes",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DicLoanTypes_IsDeleted",
                table: "DicLoanTypes");

            migrationBuilder.DeleteData(
                table: "DicLoanTypes",
                keyColumn: "Id",
                keyValue: new Guid("74e65f85-7ec4-4909-8dc9-de53fe9455ef"));

            migrationBuilder.DeleteData(
                table: "DicLoanTypes",
                keyColumn: "Id",
                keyValue: new Guid("763b5ce2-7013-481c-a7d2-d237a4793035"));

            migrationBuilder.DeleteData(
                table: "DicLoanTypes",
                keyColumn: "Id",
                keyValue: new Guid("fa1fbb94-e3a3-4482-970b-379ef3450b19"));

            migrationBuilder.DropColumn(
                name: "Value",
                table: "DicLoanTypes");

            migrationBuilder.AlterColumn<string>(
                name: "NameRu",
                table: "DicLoanTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "NameKk",
                table: "DicLoanTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "DicLoanTypes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DicLoanTypes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DicLoanTypes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "DicLoanTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
