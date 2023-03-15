using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AlterPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_DicLoanFinancingSources_LoanFinancingSourceId1",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_DicRegions_RegionId1",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_DicActivityTypes_TypeId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_TypeId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ActivityTypeId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "FileSocialId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "FileStandartId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "LoanFinancingSourceId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Plans");

            migrationBuilder.AlterColumn<Guid>(
                name: "RegionId1",
                table: "Plans",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LoanFinancingSourceId1",
                table: "Plans",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityTypeId1",
                table: "Plans",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Plans_ActivityTypeId1",
                table: "Plans",
                column: "ActivityTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_DicActivityTypes_ActivityTypeId1",
                table: "Plans",
                column: "ActivityTypeId1",
                principalTable: "DicActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_DicLoanFinancingSources_LoanFinancingSourceId1",
                table: "Plans",
                column: "LoanFinancingSourceId1",
                principalTable: "DicLoanFinancingSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_DicRegions_RegionId1",
                table: "Plans",
                column: "RegionId1",
                principalTable: "DicRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_DicActivityTypes_ActivityTypeId1",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_DicLoanFinancingSources_LoanFinancingSourceId1",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_DicRegions_RegionId1",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_ActivityTypeId1",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ActivityTypeId1",
                table: "Plans");

            migrationBuilder.AlterColumn<Guid>(
                name: "RegionId1",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "LoanFinancingSourceId1",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<int>(
                name: "ActivityTypeId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FileSocialId",
                table: "Plans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileStandartId",
                table: "Plans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoanFinancingSourceId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plans_TypeId",
                table: "Plans",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_DicLoanFinancingSources_LoanFinancingSourceId1",
                table: "Plans",
                column: "LoanFinancingSourceId1",
                principalTable: "DicLoanFinancingSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_DicRegions_RegionId1",
                table: "Plans",
                column: "RegionId1",
                principalTable: "DicRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_DicActivityTypes_TypeId",
                table: "Plans",
                column: "TypeId",
                principalTable: "DicActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
