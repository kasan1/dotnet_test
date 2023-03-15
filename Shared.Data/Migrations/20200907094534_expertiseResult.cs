using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class expertiseResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpertiseResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    ExpertiseId = table.Column<Guid>(nullable: false),
                    DecisionId = table.Column<Guid>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertiseResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpertiseResults_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertiseResults_DicDecisions_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "DicDecisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpertiseResults_DicLoanHistoryStatuses_ExpertiseId",
                        column: x => x.ExpertiseId,
                        principalTable: "DicLoanHistoryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertiseResults_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpertiseResults_ApplicationId",
                table: "ExpertiseResults",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertiseResults_DecisionId",
                table: "ExpertiseResults",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertiseResults_ExpertiseId",
                table: "ExpertiseResults",
                column: "ExpertiseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertiseResults_UserId",
                table: "ExpertiseResults",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpertiseResults");
        }
    }
}
