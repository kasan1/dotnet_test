using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateChargee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasePledge_Chargees_ChargeeId",
                table: "BasePledge");

            migrationBuilder.DropIndex(
                name: "IX_BasePledge_ChargeeId",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "AdditionalNumber",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "DocumentDateEnd",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "DocumentDateStart",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "DocumentIdNumber",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "DocumentIssuedBy",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "FIOKaz",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "FIORus",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "IsCorrectEgov",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "IsCorrectEgovNote",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "IsCorrectLaw",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "IsCorrectLawNote",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "RegFlatNumber",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "RegHouseNumber",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "RegIndex",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "RegRegion",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "RegStreet",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "RegStreetKz",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "ChargeeId",
                table: "BasePledge");

            migrationBuilder.RenameColumn(
                name: "IIN",
                table: "Chargees",
                newName: "Iin");

            migrationBuilder.AlterColumn<string>(
                name: "Iin",
                table: "Chargees",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DocumentBeginDate",
                table: "Chargees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DocumentEndDate",
                table: "Chargees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "Chargees",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentOrganizationName",
                table: "Chargees",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Chargees",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "SamePerson",
                table: "Chargees",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentBeginDate",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "DocumentEndDate",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "DocumentOrganizationName",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "SamePerson",
                table: "Chargees");

            migrationBuilder.RenameColumn(
                name: "Iin",
                table: "Chargees",
                newName: "IIN");

            migrationBuilder.AlterColumn<string>(
                name: "IIN",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalNumber",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Chargees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DocumentDateEnd",
                table: "Chargees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DocumentDateStart",
                table: "Chargees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DocumentIdNumber",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentIssuedBy",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FIOKaz",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FIORus",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Chargees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectEgov",
                table: "Chargees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsCorrectEgovNote",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectLaw",
                table: "Chargees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsCorrectLawNote",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "Chargees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegFlatNumber",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegHouseNumber",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegIndex",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegRegion",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegStreet",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegStreetKz",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChargeeId",
                table: "BasePledge",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasePledge_ChargeeId",
                table: "BasePledge",
                column: "ChargeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePledge_Chargees_ChargeeId",
                table: "BasePledge",
                column: "ChargeeId",
                principalTable: "Chargees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
