using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateBasePledge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BasePledgeId",
                table: "Chargees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Chargees_BasePledgeId",
                table: "Chargees",
                column: "BasePledgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chargees_BasePledge_BasePledgeId",
                table: "Chargees",
                column: "BasePledgeId",
                principalTable: "BasePledge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chargees_BasePledge_BasePledgeId",
                table: "Chargees");

            migrationBuilder.DropIndex(
                name: "IX_Chargees_BasePledgeId",
                table: "Chargees");

            migrationBuilder.DropColumn(
                name: "BasePledgeId",
                table: "Chargees");
        }
    }
}
