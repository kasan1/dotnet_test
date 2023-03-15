using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateMovable_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movables_DicAgriculturalMachineryPurpose_DicAgriculturalMachineryPurposeId",
                table: "Movables");

            migrationBuilder.DropForeignKey(
                name: "FK_Movables_DicEquipmentPurpose_DicEquipmentPurposeId",
                table: "Movables");

            migrationBuilder.DropForeignKey(
                name: "FK_Movables_DicStockType_DicStockTypeId",
                table: "Movables");

            migrationBuilder.DropForeignKey(
                name: "FK_Movables_DicTransportBodyType_DicTransportBodyTypeId",
                table: "Movables");

            migrationBuilder.DropForeignKey(
                name: "FK_Movables_DicTransportFuel_DicTransportFuelId",
                table: "Movables");

            migrationBuilder.DropForeignKey(
                name: "FK_Movables_DicTransportSteeringWheel_DicTransportSteeringWheelId",
                table: "Movables");

            migrationBuilder.DropForeignKey(
                name: "FK_Movables_DicTransportType_DicTransportTypeId",
                table: "Movables");

            migrationBuilder.DropIndex(
                name: "IX_Movables_DicAgriculturalMachineryPurposeId",
                table: "Movables");

            migrationBuilder.DropIndex(
                name: "IX_Movables_DicEquipmentPurposeId",
                table: "Movables");

            migrationBuilder.DropIndex(
                name: "IX_Movables_DicStockTypeId",
                table: "Movables");

            migrationBuilder.DropIndex(
                name: "IX_Movables_DicTransportBodyTypeId",
                table: "Movables");

            migrationBuilder.DropIndex(
                name: "IX_Movables_DicTransportFuelId",
                table: "Movables");

            migrationBuilder.DropIndex(
                name: "IX_Movables_DicTransportSteeringWheelId",
                table: "Movables");

            migrationBuilder.DropIndex(
                name: "IX_Movables_DicTransportTypeId",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "AdditionalEquipment",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "AgeGroup",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "AvailabilityNoRes",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "AvailabilityRes",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "BodyNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "Certificate",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "ChassisNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "ConfirmDoc",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "ConfirmDocNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DateIssue",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DepositAmount",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DepositCurrency",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DepositOpen",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DicAgriculturalMachineryPurposeId",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DicEquipmentPurposeId",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DicStockTypeId",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DicTransportBodyTypeId",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DicTransportFuelId",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DicTransportSteeringWheelId",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DicTransportTypeId",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DocNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "EngineNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "EquipmentType",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "FactAddress",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "FactoryNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "ImporterCountry",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "InventoryNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "IssuedBy",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "IssuedYear",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "Kind",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "NOKPrice",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "NameKaz",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "NameRus",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "ObtainYear",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "QualificationAkt",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "RegAddress",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "RegNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "RegYear",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "Specification",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "TechPassport",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "TechnicalPassportIssuedDate",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "TechnicalPassportNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "VINNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "VPNumber",
                table: "Movables");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movables",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Movables",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Movables",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Movables",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepositDate",
                table: "Movables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepositNumber",
                table: "Movables",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DepositTotal",
                table: "Movables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GovNumber",
                table: "Movables",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Movables",
                maxLength: 400,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Movables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisterNumber",
                table: "Movables",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransportCode",
                table: "Movables",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vin",
                table: "Movables",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Year",
                table: "Movables",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DepositDate",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DepositNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "DepositTotal",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "GovNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "RegisterNumber",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "TransportCode",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "Vin",
                table: "Movables");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Movables");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalEquipment",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgeGroup",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvailabilityNoRes",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvailabilityRes",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Birthdate",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BodyNumber",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Certificate",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChassisNumber",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmDoc",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmDocNumber",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateIssue",
                table: "Movables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DepositAmount",
                table: "Movables",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DepositCurrency",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepositOpen",
                table: "Movables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicAgriculturalMachineryPurposeId",
                table: "Movables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicEquipmentPurposeId",
                table: "Movables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicStockTypeId",
                table: "Movables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicTransportBodyTypeId",
                table: "Movables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicTransportFuelId",
                table: "Movables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicTransportSteeringWheelId",
                table: "Movables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicTransportTypeId",
                table: "Movables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocNumber",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineNumber",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquipmentType",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FactAddress",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FactoryNumber",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImporterCountry",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventoryNumber",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuedBy",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuedYear",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kind",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NOKPrice",
                table: "Movables",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "NameKaz",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameRus",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObtainYear",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Movables",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "QualificationAkt",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Movables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RegAddress",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegNumber",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegYear",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specification",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechPassport",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TechnicalPassportIssuedDate",
                table: "Movables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicalPassportNumber",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VINNumber",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VPNumber",
                table: "Movables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicAgriculturalMachineryPurposeId",
                table: "Movables",
                column: "DicAgriculturalMachineryPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicEquipmentPurposeId",
                table: "Movables",
                column: "DicEquipmentPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicStockTypeId",
                table: "Movables",
                column: "DicStockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicTransportBodyTypeId",
                table: "Movables",
                column: "DicTransportBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicTransportFuelId",
                table: "Movables",
                column: "DicTransportFuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicTransportSteeringWheelId",
                table: "Movables",
                column: "DicTransportSteeringWheelId");

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicTransportTypeId",
                table: "Movables",
                column: "DicTransportTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movables_DicAgriculturalMachineryPurpose_DicAgriculturalMachineryPurposeId",
                table: "Movables",
                column: "DicAgriculturalMachineryPurposeId",
                principalTable: "DicAgriculturalMachineryPurpose",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movables_DicEquipmentPurpose_DicEquipmentPurposeId",
                table: "Movables",
                column: "DicEquipmentPurposeId",
                principalTable: "DicEquipmentPurpose",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movables_DicStockType_DicStockTypeId",
                table: "Movables",
                column: "DicStockTypeId",
                principalTable: "DicStockType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movables_DicTransportBodyType_DicTransportBodyTypeId",
                table: "Movables",
                column: "DicTransportBodyTypeId",
                principalTable: "DicTransportBodyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movables_DicTransportFuel_DicTransportFuelId",
                table: "Movables",
                column: "DicTransportFuelId",
                principalTable: "DicTransportFuel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movables_DicTransportSteeringWheel_DicTransportSteeringWheelId",
                table: "Movables",
                column: "DicTransportSteeringWheelId",
                principalTable: "DicTransportSteeringWheel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movables_DicTransportType_DicTransportTypeId",
                table: "Movables",
                column: "DicTransportTypeId",
                principalTable: "DicTransportType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
