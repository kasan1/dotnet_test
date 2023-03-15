using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("7c58bace-25be-4ef2-86e9-01f86de4f315"));

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("9a9e37a1-dc21-4a54-9bb8-31c988bf2492"));

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: new Guid("fdca3c77-aff4-4235-9686-619f7a6e7402"));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    RoleControlsFieldId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_RoleControlsFields_RoleControlsFieldId",
                        column: x => x.RoleControlsFieldId,
                        principalTable: "RoleControlsFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationId",
                table: "Comments",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RoleControlsFieldId",
                table: "Comments",
                column: "RoleControlsFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

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

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Description", "EntityTypeId", "ModifiedDate", "SystemName" },
                values: new object[] { new Guid("9a9e37a1-dc21-4a54-9bb8-31c988bf2492"), "Заявка", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LoanApplication" });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Description", "EntityTypeId", "ModifiedDate", "SystemName" },
                values: new object[] { new Guid("7c58bace-25be-4ef2-86e9-01f86de4f315"), "Задачи по заявке", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LoanApplicationTask" });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Description", "EntityTypeId", "ModifiedDate", "SystemName" },
                values: new object[] { new Guid("fdca3c77-aff4-4235-9686-619f7a6e7402"), "Файл из интеграции с PKB", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PKB" });
        }
    }
}
