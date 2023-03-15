using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddPositionToUserBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserBranches_UserId",
                table: "UserBranches");

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                table: "UserBranches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_PositionId",
                table: "UserBranches",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_UserId_BranchId_PositionId",
                table: "UserBranches",
                columns: new[] { "UserId", "BranchId", "PositionId" },
                unique: true,
                filter: "[PositionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_DicPositions_PositionId",
                table: "UserBranches",
                column: "PositionId",
                principalTable: "DicPositions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_DicPositions_PositionId",
                table: "UserBranches");

            migrationBuilder.DropIndex(
                name: "IX_UserBranches_PositionId",
                table: "UserBranches");

            migrationBuilder.DropIndex(
                name: "IX_UserBranches_UserId_BranchId_PositionId",
                table: "UserBranches");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "UserBranches");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_UserId",
                table: "UserBranches",
                column: "UserId");
        }
    }
}
