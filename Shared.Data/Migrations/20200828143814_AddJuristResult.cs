using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddJuristResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capital",
                table: "LoanApplications");

            migrationBuilder.CreateTable(
                name: "JuristResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    WarningClassificationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuristResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuristResults_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuristResults_DicWarningClassifications_WarningClassificationId",
                        column: x => x.WarningClassificationId,
                        principalTable: "DicWarningClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JuristResults_ApplicationId",
                table: "JuristResults",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_JuristResults_WarningClassificationId",
                table: "JuristResults",
                column: "WarningClassificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JuristResults");

            migrationBuilder.AddColumn<bool>(
                name: "Capital",
                table: "LoanApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
