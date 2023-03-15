using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class BasePledge2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Agreement",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AsonSum",
                table: "BasePledge",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "CoreId",
                table: "BasePledge",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "ExpertSum",
                table: "BasePledge",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "FirstLevel",
                table: "BasePledge",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NokName",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NokSum",
                table: "BasePledge",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SecondLevel",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThirdLevel",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasePledge_ApplicationId",
                table: "BasePledge",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePledge_LoanApplications_ApplicationId",
                table: "BasePledge",
                column: "ApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasePledge_LoanApplications_ApplicationId",
                table: "BasePledge");

            migrationBuilder.DropIndex(
                name: "IX_BasePledge_ApplicationId",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "Agreement",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "AsonSum",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "CoreId",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "ExpertSum",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "FirstLevel",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "NokName",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "NokSum",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "SecondLevel",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "ThirdLevel",
                table: "BasePledge");
        }
    }
}
