using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class DicTaskStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleStatuses_DicLoanHistoryStatuses_StatusId",
                table: "RoleStatuses");

            migrationBuilder.CreateTable(
                name: "DicTaskStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTaskStatus", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleStatuses_DicTaskStatus_StatusId",
                table: "RoleStatuses",
                column: "StatusId",
                principalTable: "DicTaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleStatuses_DicTaskStatus_StatusId",
                table: "RoleStatuses");

            migrationBuilder.DropTable(
                name: "DicTaskStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleStatuses_DicLoanHistoryStatuses_StatusId",
                table: "RoleStatuses",
                column: "StatusId",
                principalTable: "DicLoanHistoryStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
