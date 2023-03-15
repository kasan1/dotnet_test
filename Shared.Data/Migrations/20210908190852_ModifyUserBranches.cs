using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class ModifyUserBranches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_Users_UserId",
                table: "UserBranches");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_BranchId",
                table: "UserBranches",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_Users_BranchId",
                table: "UserBranches",
                column: "BranchId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_Users_BranchId",
                table: "UserBranches");

            migrationBuilder.DropIndex(
                name: "IX_UserBranches_BranchId",
                table: "UserBranches");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_Users_UserId",
                table: "UserBranches",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
