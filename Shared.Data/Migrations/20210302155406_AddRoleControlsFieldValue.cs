using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddRoleControlsFieldValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("3900f4cb-5a52-45cb-8475-e6a37e2dcd51"));

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("ae8a4ae0-8282-4fd6-bf6e-61fbad25cc66"));

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("b43d07c7-94ac-493d-b6ed-feda78f5b8e0"));

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("db51e56e-afdf-49ec-a892-452178086be2"));

            migrationBuilder.CreateTable(
                name: "RoleControlsFieldValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    RoleControlsFieldId = table.Column<Guid>(nullable: false),
                    Value = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleControlsFieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleControlsFieldValues_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleControlsFieldValues_RoleControlsFields_RoleControlsFieldId",
                        column: x => x.RoleControlsFieldId,
                        principalTable: "RoleControlsFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Description", "EntityTypeId", "ModifiedDate", "SystemName" },
                values: new object[,]
                {
                    { new Guid("1c32c956-310f-4acf-9316-788e3d002d6e"), "Заявка", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LoanApplication" },
                    { new Guid("99a11953-e980-4839-871c-e88659401ac6"), "Задачи по заявке", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LoanApplicationTask" },
                    { new Guid("71f8ffc5-8f64-41df-9004-41529398de84"), "Файл из интеграции с PKB", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PKB" },
                    { new Guid("83697c38-a05b-4a62-bb6d-17e1c51295b9"), "Файл замечания", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleControlsFieldValues_ApplicationId",
                table: "RoleControlsFieldValues",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleControlsFieldValues_RoleControlsFieldId",
                table: "RoleControlsFieldValues",
                column: "RoleControlsFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleControlsFieldValues");

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("1c32c956-310f-4acf-9316-788e3d002d6e"));

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("71f8ffc5-8f64-41df-9004-41529398de84"));

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("83697c38-a05b-4a62-bb6d-17e1c51295b9"));

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("99a11953-e980-4839-871c-e88659401ac6"));

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Description", "EntityTypeId", "ModifiedDate", "SystemName" },
                values: new object[,]
                {
                    { new Guid("b43d07c7-94ac-493d-b6ed-feda78f5b8e0"), "Заявка", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LoanApplication" },
                    { new Guid("ae8a4ae0-8282-4fd6-bf6e-61fbad25cc66"), "Задачи по заявке", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LoanApplicationTask" },
                    { new Guid("3900f4cb-5a52-45cb-8475-e6a37e2dcd51"), "Файл из интеграции с PKB", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PKB" },
                    { new Guid("db51e56e-afdf-49ec-a892-452178086be2"), "Файл замечания", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comment" }
                });
        }
    }
}
