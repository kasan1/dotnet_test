using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddLoanCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Amount = table.Column<decimal>(nullable: true),
                    Duration = table.Column<short>(nullable: true),
                    Transh = table.Column<short>(nullable: true),
                    Method = table.Column<short>(nullable: true),
                    PeriodOd = table.Column<short>(nullable: true),
                    PeriodPercent = table.Column<short>(nullable: true),
                    PaymentOd = table.Column<short>(nullable: true),
                    PaymentPercent = table.Column<short>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: true),
                    LoanApplicationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanConditions_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanConditions_LoanApplicationId",
                table: "LoanConditions",
                column: "LoanApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanConditions");
        }
    }
}
