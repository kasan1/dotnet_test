using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateLoanApplicationTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "LoanApplicationTasks");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskStatusId",
                table: "LoanApplicationTasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationTasks_TaskStatusId",
                table: "LoanApplicationTasks",
                column: "TaskStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationTasks_DicTaskStatus_TaskStatusId",
                table: "LoanApplicationTasks",
                column: "TaskStatusId",
                principalTable: "DicTaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationTasks_DicTaskStatus_TaskStatusId",
                table: "LoanApplicationTasks");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationTasks_TaskStatusId",
                table: "LoanApplicationTasks");

            migrationBuilder.DropColumn(
                name: "TaskStatusId",
                table: "LoanApplicationTasks");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LoanApplicationTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
