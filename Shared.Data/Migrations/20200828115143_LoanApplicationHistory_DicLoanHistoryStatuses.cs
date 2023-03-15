using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class LoanApplicationHistory_DicLoanHistoryStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WithoutFood",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "LegalComment",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "LegalComment",
                table: "BasePledge");

            migrationBuilder.AddColumn<bool>(
                name: "WithFood",
                table: "LoanApplications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ClientCommentRk",
                table: "Chargees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientCommentVnd",
                table: "Chargees",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ClientResultRk",
                table: "Chargees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClientResultVnd",
                table: "Chargees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ClientCommentRk",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientCommentVnd",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ClientResultRk",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClientResultVnd",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DicLoanHistoryStatuses",
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
                    table.PrimaryKey("PK_DicLoanHistoryStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    AppointmentDate = table.Column<DateTime>(nullable: true),
                    PlanEndDate = table.Column<DateTime>(nullable: true),
                    FactEndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationHistories_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationHistories_DicLoanHistoryStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "DicLoanHistoryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationHistories_ApplicationId",
                table: "LoanApplicationHistories",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationHistories_StatusId",
                table: "LoanApplicationHistories",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationHistories_UserId",
                table: "LoanApplicationHistories",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationHistories");

            migrationBuilder.DropTable(
                name: "DicLoanHistoryStatuses");

            migrationBuilder.DropColumn(
                name: "WithFood",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "ClientCommentRk",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "ClientCommentVnd",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "ClientResultRk",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "ClientResultVnd",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "ClientCommentRk",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "ClientCommentVnd",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "ClientResultRk",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "ClientResultVnd",
                table: "BasePledge");

            migrationBuilder.AddColumn<bool>(
                name: "WithoutFood",
                table: "LoanApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LegalComment",
                table: "Chargees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalComment",
                table: "BasePledge",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
