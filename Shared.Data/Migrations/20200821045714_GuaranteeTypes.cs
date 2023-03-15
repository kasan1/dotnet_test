using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class GuaranteeTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DicGuaranteeTypeId",
                table: "Guarantees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DicGuaranteeType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicGuaranteeType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guarantees_DicGuaranteeTypeId",
                table: "Guarantees",
                column: "DicGuaranteeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guarantees_DicGuaranteeType_DicGuaranteeTypeId",
                table: "Guarantees",
                column: "DicGuaranteeTypeId",
                principalTable: "DicGuaranteeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guarantees_DicGuaranteeType_DicGuaranteeTypeId",
                table: "Guarantees");

            migrationBuilder.DropTable(
                name: "DicGuaranteeType");

            migrationBuilder.DropIndex(
                name: "IX_Guarantees_DicGuaranteeTypeId",
                table: "Guarantees");

            migrationBuilder.DropColumn(
                name: "DicGuaranteeTypeId",
                table: "Guarantees");
        }
    }
}
