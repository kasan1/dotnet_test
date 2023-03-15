using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class Okaps_Adding_LoanApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgroFiles_LoanStatements_LoanStatementId",
                table: "AgroFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AppActiveses_LoanStatements_LoanStatementId",
                table: "AppActiveses");

            migrationBuilder.DropForeignKey(
                name: "FK_AppTechnicses_LoanStatements_LoanStatementId",
                table: "AppTechnicses");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientDetailses_LoanStatements_LoanStatementId",
                table: "ClientDetailses");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanProducts_LoanProductId",
                table: "LoanApplications");

            migrationBuilder.DropTable(
                name: "LoanStatements");

            migrationBuilder.DropIndex(
                name: "IX_ClientDetailses_LoanStatementId",
                table: "ClientDetailses");

            migrationBuilder.DropIndex(
                name: "IX_AppTechnicses_LoanStatementId",
                table: "AppTechnicses");

            migrationBuilder.DropIndex(
                name: "IX_AppActiveses_LoanStatementId",
                table: "AppActiveses");

            migrationBuilder.DropIndex(
                name: "IX_AgroFiles_LoanStatementId",
                table: "AgroFiles");

            migrationBuilder.DropColumn(
                name: "LoanStatementId",
                table: "ClientDetailses");

            migrationBuilder.DropColumn(
                name: "LoanStatementId",
                table: "AppTechnicses");

            migrationBuilder.DropColumn(
                name: "LoanStatementId",
                table: "AppActiveses");

            migrationBuilder.DropColumn(
                name: "LoanStatementId",
                table: "AgroFiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProcessInstanceId",
                table: "LoanApplications",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "LoanProductId",
                table: "LoanApplications",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientTypetId",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoanApplicationId",
                table: "ClientDetailses",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoanApplicationId",
                table: "AppTechnicses",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoanApplicationId",
                table: "AppActiveses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ClientTypetId",
                table: "LoanApplications",
                column: "ClientTypetId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDetailses_LoanApplicationId",
                table: "ClientDetailses",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTechnicses_LoanApplicationId",
                table: "AppTechnicses",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppActiveses_LoanApplicationId",
                table: "AppActiveses",
                column: "LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppActiveses_LoanApplications_LoanApplicationId",
                table: "AppActiveses",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppTechnicses_LoanApplications_LoanApplicationId",
                table: "AppTechnicses",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientDetailses_LoanApplications_LoanApplicationId",
                table: "ClientDetailses",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicClientTypes_ClientTypetId",
                table: "LoanApplications",
                column: "ClientTypetId",
                principalTable: "DicClientTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanProducts_LoanProductId",
                table: "LoanApplications",
                column: "LoanProductId",
                principalTable: "DicLoanProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppActiveses_LoanApplications_LoanApplicationId",
                table: "AppActiveses");

            migrationBuilder.DropForeignKey(
                name: "FK_AppTechnicses_LoanApplications_LoanApplicationId",
                table: "AppTechnicses");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientDetailses_LoanApplications_LoanApplicationId",
                table: "ClientDetailses");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicClientTypes_ClientTypetId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanProducts_LoanProductId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_ClientTypetId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_ClientDetailses_LoanApplicationId",
                table: "ClientDetailses");

            migrationBuilder.DropIndex(
                name: "IX_AppTechnicses_LoanApplicationId",
                table: "AppTechnicses");

            migrationBuilder.DropIndex(
                name: "IX_AppActiveses_LoanApplicationId",
                table: "AppActiveses");

            migrationBuilder.DropColumn(
                name: "ClientTypetId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "ClientDetailses");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "AppTechnicses");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "AppActiveses");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProcessInstanceId",
                table: "LoanApplications",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LoanProductId",
                table: "LoanApplications",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoanStatementId",
                table: "ClientDetailses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoanStatementId",
                table: "AppTechnicses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoanStatementId",
                table: "AppActiveses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoanStatementId",
                table: "AgroFiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoanStatements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessInstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanStatements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientDetailses_LoanStatementId",
                table: "ClientDetailses",
                column: "LoanStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTechnicses_LoanStatementId",
                table: "AppTechnicses",
                column: "LoanStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_AppActiveses_LoanStatementId",
                table: "AppActiveses",
                column: "LoanStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_AgroFiles_LoanStatementId",
                table: "AgroFiles",
                column: "LoanStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanStatements_UserId",
                table: "LoanStatements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgroFiles_LoanStatements_LoanStatementId",
                table: "AgroFiles",
                column: "LoanStatementId",
                principalTable: "LoanStatements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppActiveses_LoanStatements_LoanStatementId",
                table: "AppActiveses",
                column: "LoanStatementId",
                principalTable: "LoanStatements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppTechnicses_LoanStatements_LoanStatementId",
                table: "AppTechnicses",
                column: "LoanStatementId",
                principalTable: "LoanStatements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientDetailses_LoanStatements_LoanStatementId",
                table: "ClientDetailses",
                column: "LoanStatementId",
                principalTable: "LoanStatements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanProducts_LoanProductId",
                table: "LoanApplications",
                column: "LoanProductId",
                principalTable: "DicLoanProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
