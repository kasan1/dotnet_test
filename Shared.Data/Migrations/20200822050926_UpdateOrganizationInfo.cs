using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateOrganizationInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationInfos_DicClientTypes_ClientTypeId",
                table: "OrganizationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationInfos_DicClientSegmentes_clientSegmentId",
                table: "OrganizationInfos");

            migrationBuilder.RenameColumn(
                name: "clientSegmentId",
                table: "OrganizationInfos",
                newName: "ClientSegmentId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationInfos_clientSegmentId",
                table: "OrganizationInfos",
                newName: "IX_OrganizationInfos_ClientSegmentId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientSegmentId",
                table: "OrganizationInfos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientTypeId",
                table: "OrganizationInfos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationInfos_DicClientSegmentes_ClientSegmentId",
                table: "OrganizationInfos",
                column: "ClientSegmentId",
                principalTable: "DicClientSegmentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationInfos_DicClientTypes_ClientTypeId",
                table: "OrganizationInfos",
                column: "ClientTypeId",
                principalTable: "DicClientTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationInfos_DicClientSegmentes_ClientSegmentId",
                table: "OrganizationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationInfos_DicClientTypes_ClientTypeId",
                table: "OrganizationInfos");

            migrationBuilder.RenameColumn(
                name: "ClientSegmentId",
                table: "OrganizationInfos",
                newName: "clientSegmentId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationInfos_ClientSegmentId",
                table: "OrganizationInfos",
                newName: "IX_OrganizationInfos_clientSegmentId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientTypeId",
                table: "OrganizationInfos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "clientSegmentId",
                table: "OrganizationInfos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationInfos_DicClientTypes_ClientTypeId",
                table: "OrganizationInfos",
                column: "ClientTypeId",
                principalTable: "DicClientTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationInfos_DicClientSegmentes_clientSegmentId",
                table: "OrganizationInfos",
                column: "clientSegmentId",
                principalTable: "DicClientSegmentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
