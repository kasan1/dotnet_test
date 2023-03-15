using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddCountryToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "People",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_CountryId",
                table: "People",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_DicCountries_CountryId",
                table: "People",
                column: "CountryId",
                principalTable: "DicCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_DicCountries_CountryId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CountryId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "People");
        }
    }
}
