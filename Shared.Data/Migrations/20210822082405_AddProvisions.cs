using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddProvisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DicProvisionDescription",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Sort = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    NameRu = table.Column<string>(maxLength: 200, nullable: false),
                    NameKk = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicProvisionDescription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicProvisionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Sort = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    NameRu = table.Column<string>(maxLength: 200, nullable: false),
                    NameKk = table.Column<string>(maxLength: 200, nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicProvisionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provisions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ContractId = table.Column<Guid>(nullable: false),
                    ProvisionTypeId = table.Column<Guid>(nullable: true),
                    ProvisionDescriptionId = table.Column<Guid>(nullable: true),
                    Sum = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provisions_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Provisions_DicProvisionDescription_ProvisionDescriptionId",
                        column: x => x.ProvisionDescriptionId,
                        principalTable: "DicProvisionDescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Provisions_DicProvisionTypes_ProvisionTypeId",
                        column: x => x.ProvisionTypeId,
                        principalTable: "DicProvisionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DicProvisionTypes",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort", "Value" },
                values: new object[] { new Guid("8fc3a266-5e33-4138-9284-c47e05696cb3"), "Pledge", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Залог", 0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DicProvisionDescription_IsDeleted",
                table: "DicProvisionDescription",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DicProvisionTypes_IsDeleted",
                table: "DicProvisionTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Provisions_ContractId",
                table: "Provisions",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Provisions_IsDeleted",
                table: "Provisions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Provisions_ProvisionDescriptionId",
                table: "Provisions",
                column: "ProvisionDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Provisions_ProvisionTypeId",
                table: "Provisions",
                column: "ProvisionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provisions");

            migrationBuilder.DropTable(
                name: "DicProvisionDescription");

            migrationBuilder.DropTable(
                name: "DicProvisionTypes");
        }
    }
}
