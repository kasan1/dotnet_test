using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class CreditCommitteeResult_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CreditCommitteeResults_UserId",
                table: "CreditCommitteeResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCommitteeResults_Users_UserId",
                table: "CreditCommitteeResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCommitteeResults_Users_UserId",
                table: "CreditCommitteeResults");

            migrationBuilder.DropIndex(
                name: "IX_CreditCommitteeResults_UserId",
                table: "CreditCommitteeResults");
        }
    }
}
