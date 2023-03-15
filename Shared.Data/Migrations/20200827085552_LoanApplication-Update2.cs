using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class LoanApplicationUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActivityTypeId",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientSegmentId",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoanPurposeId",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurposeDetail",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ActivityTypeId",
                table: "LoanApplications",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ClientSegmentId",
                table: "LoanApplications",
                column: "ClientSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_LoanPurposeId",
                table: "LoanApplications",
                column: "LoanPurposeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicActivityTypes_ActivityTypeId",
                table: "LoanApplications",
                column: "ActivityTypeId",
                principalTable: "DicActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicClientSegmentes_ClientSegmentId",
                table: "LoanApplications",
                column: "ClientSegmentId",
                principalTable: "DicClientSegmentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanPurposes_LoanPurposeId",
                table: "LoanApplications",
                column: "LoanPurposeId",
                principalTable: "DicLoanPurposes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicActivityTypes_ActivityTypeId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicClientSegmentes_ClientSegmentId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanPurposes_LoanPurposeId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_ActivityTypeId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_ClientSegmentId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_LoanPurposeId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "ActivityTypeId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "ClientSegmentId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "LoanPurposeId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "PurposeDetail",
                table: "LoanApplications");
        }
    }
}
