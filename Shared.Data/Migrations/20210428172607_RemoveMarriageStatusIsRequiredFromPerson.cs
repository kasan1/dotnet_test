using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class RemoveMarriageStatusIsRequiredFromPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_DicMariageStatuses_MariageStatusId",
                table: "People");

            migrationBuilder.AlterColumn<Guid>(
                name: "MariageStatusId",
                table: "People",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_People_DicMariageStatuses_MariageStatusId",
                table: "People",
                column: "MariageStatusId",
                principalTable: "DicMariageStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_DicMariageStatuses_MariageStatusId",
                table: "People");

            migrationBuilder.AlterColumn<Guid>(
                name: "MariageStatusId",
                table: "People",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_People_DicMariageStatuses_MariageStatusId",
                table: "People",
                column: "MariageStatusId",
                principalTable: "DicMariageStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
