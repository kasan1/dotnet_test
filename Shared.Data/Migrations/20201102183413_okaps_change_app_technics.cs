using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class okaps_change_app_technics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SelectedAccessoryTeches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    techProduct = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    manufacturer = table.Column<string>(nullable: true),
                    provider = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    parentItem = table.Column<int>(nullable: false),
                    parentPrice = table.Column<decimal>(nullable: false),
                    parentTechType = table.Column<string>(nullable: true),
                    parentTechSubType = table.Column<string>(nullable: true),
                    parentCountry = table.Column<string>(nullable: true),
                    parentId = table.Column<string>(nullable: true),
                    ContractId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedAccessoryTeches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedAccessoryTeches_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectedMainTeches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    techProduct = table.Column<string>(nullable: true),
                    techType = table.Column<string>(nullable: true),
                    techTypeCode = table.Column<string>(nullable: true),
                    subTechType = table.Column<string>(nullable: true),
                    subTechTypeCode = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    manufacturer = table.Column<string>(nullable: true),
                    provider = table.Column<string>(nullable: true),
                    providerId = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    techTypeName = table.Column<string>(nullable: true),
                    ContractId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedMainTeches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedMainTeches_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelectedAccessoryTeches_ContractId",
                table: "SelectedAccessoryTeches",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedMainTeches_ContractId",
                table: "SelectedMainTeches",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedAccessoryTeches");

            migrationBuilder.DropTable(
                name: "SelectedMainTeches");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Contracts");
        }
    }
}
