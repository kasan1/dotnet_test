using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateLoanApplicationTask2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationTasks_DicTaskStatus_TaskStatusId",
                table: "LoanApplicationTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleStatuses_DicTaskStatus_StatusId",
                table: "RoleStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DicTaskStatus",
                table: "DicTaskStatus");

            migrationBuilder.RenameTable(
                name: "DicTaskStatus",
                newName: "DicTaskStatuses");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LoanApplicationTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DicTaskStatuses",
                table: "DicTaskStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationTasks_DicTaskStatuses_TaskStatusId",
                table: "LoanApplicationTasks",
                column: "TaskStatusId",
                principalTable: "DicTaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleStatuses_DicTaskStatuses_StatusId",
                table: "RoleStatuses",
                column: "StatusId",
                principalTable: "DicTaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationTasks_DicTaskStatuses_TaskStatusId",
                table: "LoanApplicationTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleStatuses_DicTaskStatuses_StatusId",
                table: "RoleStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DicTaskStatuses",
                table: "DicTaskStatuses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LoanApplicationTasks");

            migrationBuilder.RenameTable(
                name: "DicTaskStatuses",
                newName: "DicTaskStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DicTaskStatus",
                table: "DicTaskStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationTasks_DicTaskStatus_TaskStatusId",
                table: "LoanApplicationTasks",
                column: "TaskStatusId",
                principalTable: "DicTaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleStatuses_DicTaskStatus_StatusId",
                table: "RoleStatuses",
                column: "StatusId",
                principalTable: "DicTaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
