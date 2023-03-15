using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class okaps_change_tech : Migration
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
                name: "SelectedMainTechId",
                table: "SelectedMainTeches");

            migrationBuilder.DropColumn(
                name: "SelectedAccessoryTechId",
                table: "SelectedAccessoryTeches");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SelectedMainTeches",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "order",
                table: "SelectedMainTeches",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SelectedAccessoryTeches",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "order",
                table: "SelectedAccessoryTeches",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedMainTeches",
                table: "SelectedMainTeches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedAccessoryTeches",
                table: "SelectedAccessoryTeches",
                column: "Id");
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
                name: "Id",
                table: "SelectedMainTeches");

            migrationBuilder.DropColumn(
                name: "order",
                table: "SelectedMainTeches");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SelectedAccessoryTeches");

            migrationBuilder.DropColumn(
                name: "order",
                table: "SelectedAccessoryTeches");

            migrationBuilder.AddColumn<Guid>(
                name: "SelectedMainTechId",
                table: "SelectedMainTeches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SelectedAccessoryTechId",
                table: "SelectedAccessoryTeches",
                type: "uniqueidentifier",
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
    }
}
