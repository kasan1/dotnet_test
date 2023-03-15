using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class RoleStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameRu",
                table: "Roles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleStatuses_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleStatuses_DicLoanHistoryStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "DicLoanHistoryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleStatuses_RoleId",
                table: "RoleStatuses",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleStatuses_StatusId",
                table: "RoleStatuses",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleStatuses");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NameRu",
                table: "Roles");
        }
    }
}
