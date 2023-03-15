using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class ModifyApplicationExtraDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlOwners_People_PersonId",
                table: "FlOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_UlOwners_Organizations_OrganizationId",
                table: "UlOwners");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizationId",
                table: "UlOwners",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "VatCertificateId",
                table: "LoanApplicationExtraDetails",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "FlOwners",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_FlOwners_People_PersonId",
                table: "FlOwners",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UlOwners_Organizations_OrganizationId",
                table: "UlOwners",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlOwners_People_PersonId",
                table: "FlOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_UlOwners_Organizations_OrganizationId",
                table: "UlOwners");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizationId",
                table: "UlOwners",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "VatCertificateId",
                table: "LoanApplicationExtraDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "FlOwners",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FlOwners_People_PersonId",
                table: "FlOwners",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UlOwners_Organizations_OrganizationId",
                table: "UlOwners",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
