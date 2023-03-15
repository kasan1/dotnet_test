using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AlterPlansrenameCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_DicActivityTypes_ActivityTypeId1",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_AgroFiles_FileSocialId1",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_AgroFiles_FileStandartId1",
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

            migrationBuilder.DropIndex(
                name: "IX_Plans_FileSocialId1",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_FileStandartId1",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_LoanFinancingSourceId1",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_RegionId1",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ActivityTypeId1",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "FileSocialId1",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "FileStandartId1",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "LoanFinancingSourceId1",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "RegionId1",
                table: "Plans");

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityTypeId",
                table: "Plans",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FileSocialId",
                table: "Plans",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FileStandartId",
                table: "Plans",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoanFinancingSourceId",
                table: "Plans",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "Plans",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Plans_ActivityTypeId",
                table: "Plans",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_FileSocialId",
                table: "Plans",
                column: "FileSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_FileStandartId",
                table: "Plans",
                column: "FileStandartId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_LoanFinancingSourceId",
                table: "Plans",
                column: "LoanFinancingSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_RegionId",
                table: "Plans",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_DicActivityTypes_ActivityTypeId",
                table: "Plans",
                column: "ActivityTypeId",
                principalTable: "DicActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_AgroFiles_FileSocialId",
                table: "Plans",
                column: "FileSocialId",
                principalTable: "AgroFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_AgroFiles_FileStandartId",
                table: "Plans",
                column: "FileStandartId",
                principalTable: "AgroFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_DicLoanFinancingSources_LoanFinancingSourceId",
                table: "Plans",
                column: "LoanFinancingSourceId",
                principalTable: "DicLoanFinancingSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_DicRegions_RegionId",
                table: "Plans",
                column: "RegionId",
                principalTable: "DicRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_DicActivityTypes_ActivityTypeId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_AgroFiles_FileSocialId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_AgroFiles_FileStandartId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_DicLoanFinancingSources_LoanFinancingSourceId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_DicRegions_RegionId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_ActivityTypeId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_FileSocialId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_FileStandartId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_LoanFinancingSourceId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_RegionId",
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

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityTypeId1",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FileSocialId1",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FileStandartId1",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoanFinancingSourceId1",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RegionId1",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Plans_ActivityTypeId1",
                table: "Plans",
                column: "ActivityTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_FileSocialId1",
                table: "Plans",
                column: "FileSocialId1");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_FileStandartId1",
                table: "Plans",
                column: "FileStandartId1");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_LoanFinancingSourceId1",
                table: "Plans",
                column: "LoanFinancingSourceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_RegionId1",
                table: "Plans",
                column: "RegionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_DicActivityTypes_ActivityTypeId1",
                table: "Plans",
                column: "ActivityTypeId1",
                principalTable: "DicActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_AgroFiles_FileSocialId1",
                table: "Plans",
                column: "FileSocialId1",
                principalTable: "AgroFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_AgroFiles_FileStandartId1",
                table: "Plans",
                column: "FileStandartId1",
                principalTable: "AgroFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
