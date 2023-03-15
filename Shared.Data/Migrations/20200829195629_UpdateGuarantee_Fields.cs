using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateGuarantee_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guarantees_DicGuaranteeType_DicGuaranteeTypeId",
                table: "Guarantees");

            migrationBuilder.DropIndex(
                name: "IX_Guarantees_DicGuaranteeTypeId",
                table: "Guarantees");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Guarantees");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Guarantees");

            migrationBuilder.DropColumn(
                name: "DicGuaranteeTypeId",
                table: "Guarantees");

            migrationBuilder.DropColumn(
                name: "Guarantor",
                table: "Guarantees");

            migrationBuilder.DropColumn(
                name: "IssuedDate",
                table: "Guarantees");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Guarantees");

            migrationBuilder.DropColumn(
                name: "ValidThrough",
                table: "Guarantees");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Guarantees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuaranteeCode",
                table: "Guarantees",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "ValidFor",
                table: "Guarantees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Guarantees");

            migrationBuilder.DropColumn(
                name: "GuaranteeCode",
                table: "Guarantees");

            migrationBuilder.DropColumn(
                name: "ValidFor",
                table: "Guarantees");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Guarantees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Guarantees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "DicGuaranteeTypeId",
                table: "Guarantees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guarantor",
                table: "Guarantees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssuedDate",
                table: "Guarantees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Guarantees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidThrough",
                table: "Guarantees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guarantees_DicGuaranteeTypeId",
                table: "Guarantees",
                column: "DicGuaranteeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guarantees_DicGuaranteeType_DicGuaranteeTypeId",
                table: "Guarantees",
                column: "DicGuaranteeTypeId",
                principalTable: "DicGuaranteeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
