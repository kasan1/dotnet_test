using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class okaps_change_app_technics_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedMainTeches",
                table: "SelectedMainTeches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedAccessoryTeches",
                table: "SelectedAccessoryTeches");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SelectedMainTeches");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SelectedAccessoryTeches");

            migrationBuilder.AddColumn<Guid>(
                name: "SelectedMainTechId",
                table: "SelectedMainTeches",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SelectedAccessoryTechId",
                table: "SelectedAccessoryTeches",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedMainTeches",
                table: "SelectedMainTeches",
                column: "SelectedMainTechId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedAccessoryTeches",
                table: "SelectedAccessoryTeches",
                column: "SelectedAccessoryTechId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedMainTeches",
                table: "SelectedMainTeches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedAccessoryTeches",
                table: "SelectedAccessoryTeches");

            migrationBuilder.DropColumn(
                name: "SelectedMainTechId",
                table: "SelectedMainTeches");

            migrationBuilder.DropColumn(
                name: "SelectedAccessoryTechId",
                table: "SelectedAccessoryTeches");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SelectedMainTeches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SelectedAccessoryTeches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedMainTeches",
                table: "SelectedMainTeches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedAccessoryTeches",
                table: "SelectedAccessoryTeches",
                column: "Id");
        }
    }
}
