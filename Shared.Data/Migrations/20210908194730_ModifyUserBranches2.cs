using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class ModifyUserBranches2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_Users_BranchId",
                table: "UserBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_Branches_UserId",
                table: "UserBranches");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_Branches_BranchId",
                table: "UserBranches",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_Users_UserId",
                table: "UserBranches",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_Branches_BranchId",
                table: "UserBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_Users_UserId",
                table: "UserBranches");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_Users_BranchId",
                table: "UserBranches",
                column: "BranchId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_Branches_UserId",
                table: "UserBranches",
                column: "UserId",
                principalTable: "Branches",
                principalColumn: "Id");
        }
    }
}
