using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class ChangeContracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessTechCalculators");

            migrationBuilder.DropTable(
                name: "MainTechCalculators");

            migrationBuilder.DropTable(
                name: "SelectedAccessoryTeches");

            migrationBuilder.DropTable(
                name: "SelectedMainTeches");

            migrationBuilder.DropIndex(
                name: "IX_Calculators_ContractId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "Sofinanc",
                table: "Calculators");

            migrationBuilder.AlterColumn<decimal>(
                name: "Sum",
                table: "Calculators",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Calculators",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Period",
                table: "Calculators",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CoFinancing",
                table: "Calculators",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "SelectedAccessories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ContractId = table.Column<Guid>(nullable: false),
                    TechModelId = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    ProviderId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Count = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedAccessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedAccessories_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedAccessories_DicCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "DicCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedAccessories_DicProviders_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "DicProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedAccessories_DicTechModels_TechModelId",
                        column: x => x.TechModelId,
                        principalTable: "DicTechModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedTechnics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ContractId = table.Column<Guid>(nullable: false),
                    TechModelId = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    ProviderId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Count = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedTechnics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedTechnics_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedTechnics_DicCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "DicCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedTechnics_DicProviders_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "DicProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedTechnics_DicTechModels_TechModelId",
                        column: x => x.TechModelId,
                        principalTable: "DicTechModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_ContractId",
                table: "Calculators",
                column: "ContractId",
                unique: true,
                filter: "[ContractId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedAccessories_ContractId",
                table: "SelectedAccessories",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedAccessories_CountryId",
                table: "SelectedAccessories",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedAccessories_ProviderId",
                table: "SelectedAccessories",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedAccessories_TechModelId",
                table: "SelectedAccessories",
                column: "TechModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedTechnics_ContractId",
                table: "SelectedTechnics",
                column: "ContractId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SelectedTechnics_CountryId",
                table: "SelectedTechnics",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedTechnics_ProviderId",
                table: "SelectedTechnics",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedTechnics_TechModelId",
                table: "SelectedTechnics",
                column: "TechModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedAccessories");

            migrationBuilder.DropTable(
                name: "SelectedTechnics");

            migrationBuilder.DropIndex(
                name: "IX_Calculators_ContractId",
                table: "Calculators");

            migrationBuilder.DropColumn(
                name: "CoFinancing",
                table: "Calculators");

            migrationBuilder.AlterColumn<string>(
                name: "Sum",
                table: "Calculators",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Rate",
                table: "Calculators",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Period",
                table: "Calculators",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Sofinanc",
                table: "Calculators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SelectedAccessoryTeches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parentCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parentItem = table.Column<int>(type: "int", nullable: false),
                    parentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    parentTechSubType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parentTechType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    techProduct = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    providerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subTechType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subTechTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    techProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    techType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    techTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    techTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "AccessTechCalculators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedAccessoryTechId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sofinanc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTechCalculators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessTechCalculators_SelectedAccessoryTeches_SelectedAccessoryTechId",
                        column: x => x.SelectedAccessoryTechId,
                        principalTable: "SelectedAccessoryTeches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MainTechCalculators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedMainTechId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sofinanc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainTechCalculators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainTechCalculators_SelectedMainTeches_SelectedMainTechId",
                        column: x => x.SelectedMainTechId,
                        principalTable: "SelectedMainTeches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_ContractId",
                table: "Calculators",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessTechCalculators_SelectedAccessoryTechId",
                table: "AccessTechCalculators",
                column: "SelectedAccessoryTechId",
                unique: true,
                filter: "[SelectedAccessoryTechId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MainTechCalculators_SelectedMainTechId",
                table: "MainTechCalculators",
                column: "SelectedMainTechId",
                unique: true,
                filter: "[SelectedMainTechId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedAccessoryTeches_ContractId",
                table: "SelectedAccessoryTeches",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedMainTeches_ContractId",
                table: "SelectedMainTeches",
                column: "ContractId");
        }
    }
}
