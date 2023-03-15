using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddPropertiesToContracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Contracts",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contracts",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Contracts",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrincipalDebtBalance",
                table: "Contracts",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DicContractStatus",
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
                    table.PrimaryKey("PK_DicContractStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DicContractStatus",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[] { new Guid("775d4cc1-7419-488f-a00c-29258466aaaf"), "Active", null, "", "Действующий", 0 });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Description", "EntityTypeId", "ModifiedDate", "SystemName" },
                values: new object[] { new Guid("7dc0c71f-4a8e-4bc7-9ffd-1ab292845140"), "Файл графика платежей", 8, null, "PaymentSchedule" });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_IsDeleted",
                table: "Contracts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_StatusId",
                table: "Contracts",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DicContractStatus_IsDeleted",
                table: "DicContractStatus",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_DicContractStatus_StatusId",
                table: "Contracts",
                column: "StatusId",
                principalTable: "DicContractStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_DicContractStatus_StatusId",
                table: "Contracts");

            migrationBuilder.DropTable(
                name: "DicContractStatus");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_IsDeleted",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_StatusId",
                table: "Contracts");

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("7dc0c71f-4a8e-4bc7-9ffd-1ab292845140"));

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "PrincipalDebtBalance",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Contracts");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Contracts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getDate()");
        }
    }
}
