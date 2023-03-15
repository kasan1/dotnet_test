using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class OKaps_App_Activity_Finish_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessTechCalculators",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Rate = table.Column<string>(nullable: true),
                    Sofinanc = table.Column<string>(nullable: true),
                    Period = table.Column<string>(nullable: true),
                    sum = table.Column<string>(nullable: true),
                    SelectedAccessoryTechId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTechCalculators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessTechCalculators_SelectedAccessoryTeches_SelectedAccessoryTechId",
                        column: x => x.SelectedAccessoryTechId,
                        principalTable: "SelectedAccessoryTeches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MainTechCalculators",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Rate = table.Column<string>(nullable: true),
                    Sofinanc = table.Column<string>(nullable: true),
                    Period = table.Column<string>(nullable: true),
                    sum = table.Column<string>(nullable: true),
                    SelectedMainTechId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainTechCalculators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainTechCalculators_SelectedMainTeches_SelectedMainTechId",
                        column: x => x.SelectedMainTechId,
                        principalTable: "SelectedMainTeches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessTechCalculators_SelectedAccessoryTechId",
                table: "AccessTechCalculators",
                column: "SelectedAccessoryTechId",
                unique: true,
                filter: "[SelectedAccessoryTechId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MainTechCalculators_SelectedMainTechId",
                table: "MainTechCalculators",
                column: "SelectedMainTechId",
                unique: true,
                filter: "[SelectedMainTechId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessTechCalculators");

            migrationBuilder.DropTable(
                name: "MainTechCalculators");
        }
    }
}
