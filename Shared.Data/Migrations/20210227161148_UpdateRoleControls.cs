using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateRoleControls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TaskStatusId",
                table: "RoleControlsButtons",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LoanHistoryStatusId",
                table: "RoleControls",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RoleControlsButtons_TaskStatusId",
                table: "RoleControlsButtons",
                column: "TaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleControls_LoanHistoryStatusId",
                table: "RoleControls",
                column: "LoanHistoryStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleControls_DicLoanHistoryStatuses_LoanHistoryStatusId",
                table: "RoleControls",
                column: "LoanHistoryStatusId",
                principalTable: "DicLoanHistoryStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleControlsButtons_DicTaskStatuses_TaskStatusId",
                table: "RoleControlsButtons",
                column: "TaskStatusId",
                principalTable: "DicTaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleControls_DicLoanHistoryStatuses_LoanHistoryStatusId",
                table: "RoleControls");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleControlsButtons_DicTaskStatuses_TaskStatusId",
                table: "RoleControlsButtons");

            migrationBuilder.DropIndex(
                name: "IX_RoleControlsButtons_TaskStatusId",
                table: "RoleControlsButtons");

            migrationBuilder.DropIndex(
                name: "IX_RoleControls_LoanHistoryStatusId",
                table: "RoleControls");

            migrationBuilder.DropColumn(
                name: "TaskStatusId",
                table: "RoleControlsButtons");

            migrationBuilder.DropColumn(
                name: "LoanHistoryStatusId",
                table: "RoleControls");
        }
    }
}
