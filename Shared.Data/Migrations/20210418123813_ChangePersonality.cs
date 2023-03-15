using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class ChangePersonality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personalities_WorkExperiences_WorkExperienceId",
                table: "Personalities");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkExperienceId",
                table: "Personalities",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Personalities_WorkExperiences_WorkExperienceId",
                table: "Personalities",
                column: "WorkExperienceId",
                principalTable: "WorkExperiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personalities_WorkExperiences_WorkExperienceId",
                table: "Personalities");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkExperienceId",
                table: "Personalities",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personalities_WorkExperiences_WorkExperienceId",
                table: "Personalities",
                column: "WorkExperienceId",
                principalTable: "WorkExperiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
