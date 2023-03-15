using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class LoanApplicationTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanApplicationTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    AppointmentDate = table.Column<DateTime>(nullable: true),
                    PlanEndDate = table.Column<DateTime>(nullable: true),
                    FactEndDate = table.Column<DateTime>(nullable: true),
                    DecisionId = table.Column<Guid>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationTasks_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationTasks_DicDecisions_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "DicDecisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanApplicationTasks_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanApplicationTasks_DicLoanHistoryStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "DicLoanHistoryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationTasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationTasks_ApplicationId",
                table: "LoanApplicationTasks",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationTasks_DecisionId",
                table: "LoanApplicationTasks",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationTasks_RoleId",
                table: "LoanApplicationTasks",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationTasks_StatusId",
                table: "LoanApplicationTasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationTasks_UserId",
                table: "LoanApplicationTasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationTasks");
        }
    }
}
