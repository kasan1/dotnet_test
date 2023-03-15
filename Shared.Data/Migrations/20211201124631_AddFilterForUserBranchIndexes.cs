using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddFilterForUserBranchIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserBranches_UserId_BranchId_PositionId",
                table: "UserBranches");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_UserId_BranchId_PositionId",
                table: "UserBranches",
                columns: new[] { "UserId", "BranchId", "PositionId" },
                unique: true,
                filter: "[IsDeleted] = 0 AND [PositionId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserBranches_UserId_BranchId_PositionId",
                table: "UserBranches");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_UserId_BranchId_PositionId",
                table: "UserBranches",
                columns: new[] { "UserId", "BranchId", "PositionId" },
                unique: true,
                filter: "[PositionId] IS NOT NULL");
        }
    }
}
