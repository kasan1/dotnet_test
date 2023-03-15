using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddUserIdToContracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Contracts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.Sql(@"update Contracts
set UserId = app.UserId
from Contracts c inner join LoanApplications app on c.LoanApplicationId = app.id;");

            migrationBuilder.InsertData(
                table: "DicContractStatus",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[] { new Guid("a9e17d62-72e1-4f4e-a361-3badd4cd990d"), "Temp", null, "", "Временный", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_UserId",
                table: "Contracts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AspNetUsers_UserId",
                table: "Contracts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AspNetUsers_UserId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_UserId",
                table: "Contracts");

            migrationBuilder.DeleteData(
                table: "DicContractStatus",
                keyColumn: "Id",
                keyValue: new Guid("a9e17d62-72e1-4f4e-a361-3badd4cd990d"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contracts");
        }
    }
}
