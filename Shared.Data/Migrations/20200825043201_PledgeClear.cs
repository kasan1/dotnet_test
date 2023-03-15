using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class PledgeClear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nonmovables_DicLandPurpose_DicLandPurposeId",
                table: "Nonmovables");

            migrationBuilder.DropForeignKey(
                name: "FK_Nonmovables_DicCommercialОbjectName_DicСommercialОbjectNameId",
                table: "Nonmovables");

            migrationBuilder.DropForeignKey(
                name: "FK_Nonmovables_DicCommercialОbjectPurpose_DicСommercialОbjectPurposeId",
                table: "Nonmovables");

            migrationBuilder.DropForeignKey(
                name: "FK_Nonmovables_DicCommercialОbjectType_DicСommercialОbjectTypeId",
                table: "Nonmovables");

            migrationBuilder.DropForeignKey(
                name: "FK_Nonmovables_Liter_LiterId",
                table: "Nonmovables");

            migrationBuilder.DropForeignKey(
                name: "FK_Nonmovables_Chargees_OwnerId",
                table: "Nonmovables");

            migrationBuilder.DropForeignKey(
                name: "FK_Nonmovables_DicWallMaterial_WallMaterialId",
                table: "Nonmovables");

            migrationBuilder.DropTable(
                name: "Liter");

            migrationBuilder.DropIndex(
                name: "IX_Nonmovables_DicLandPurposeId",
                table: "Nonmovables");

            migrationBuilder.DropIndex(
                name: "IX_Nonmovables_DicСommercialОbjectNameId",
                table: "Nonmovables");

            migrationBuilder.DropIndex(
                name: "IX_Nonmovables_DicСommercialОbjectPurposeId",
                table: "Nonmovables");

            migrationBuilder.DropIndex(
                name: "IX_Nonmovables_DicСommercialОbjectTypeId",
                table: "Nonmovables");

            migrationBuilder.DropIndex(
                name: "IX_Nonmovables_LiterId",
                table: "Nonmovables");

            migrationBuilder.DropIndex(
                name: "IX_Nonmovables_OwnerId",
                table: "Nonmovables");

            migrationBuilder.DropIndex(
                name: "IX_Nonmovables_WallMaterialId",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "DicLandPurposeId",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "DicСommercialОbjectNameId",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "DicСommercialОbjectPurposeId",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "DicСommercialОbjectTypeId",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "FloorCount",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "LiterId",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "RoomCount",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "WallMaterialId",
                table: "Nonmovables");

            migrationBuilder.AddColumn<short>(
                name: "LandPurpose",
                table: "Nonmovables",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LandPurpose",
                table: "Nonmovables");

            migrationBuilder.AddColumn<Guid>(
                name: "DicLandPurposeId",
                table: "Nonmovables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicСommercialОbjectNameId",
                table: "Nonmovables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicСommercialОbjectPurposeId",
                table: "Nonmovables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DicСommercialОbjectTypeId",
                table: "Nonmovables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FloorCount",
                table: "Nonmovables",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FloorNumber",
                table: "Nonmovables",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "LiterId",
                table: "Nonmovables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Nonmovables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomCount",
                table: "Nonmovables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "WallMaterialId",
                table: "Nonmovables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Liter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaLiter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentLiter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentLiterKz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentLiterRus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liter", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_DicLandPurposeId",
                table: "Nonmovables",
                column: "DicLandPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_DicСommercialОbjectNameId",
                table: "Nonmovables",
                column: "DicСommercialОbjectNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_DicСommercialОbjectPurposeId",
                table: "Nonmovables",
                column: "DicСommercialОbjectPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_DicСommercialОbjectTypeId",
                table: "Nonmovables",
                column: "DicСommercialОbjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_LiterId",
                table: "Nonmovables",
                column: "LiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_OwnerId",
                table: "Nonmovables",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_WallMaterialId",
                table: "Nonmovables",
                column: "WallMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nonmovables_DicLandPurpose_DicLandPurposeId",
                table: "Nonmovables",
                column: "DicLandPurposeId",
                principalTable: "DicLandPurpose",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nonmovables_DicCommercialОbjectName_DicСommercialОbjectNameId",
                table: "Nonmovables",
                column: "DicСommercialОbjectNameId",
                principalTable: "DicCommercialОbjectName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nonmovables_DicCommercialОbjectPurpose_DicСommercialОbjectPurposeId",
                table: "Nonmovables",
                column: "DicСommercialОbjectPurposeId",
                principalTable: "DicCommercialОbjectPurpose",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nonmovables_DicCommercialОbjectType_DicСommercialОbjectTypeId",
                table: "Nonmovables",
                column: "DicСommercialОbjectTypeId",
                principalTable: "DicCommercialОbjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nonmovables_Liter_LiterId",
                table: "Nonmovables",
                column: "LiterId",
                principalTable: "Liter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nonmovables_Chargees_OwnerId",
                table: "Nonmovables",
                column: "OwnerId",
                principalTable: "Chargees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nonmovables_DicWallMaterial_WallMaterialId",
                table: "Nonmovables",
                column: "WallMaterialId",
                principalTable: "DicWallMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
