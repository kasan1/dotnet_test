using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddActivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    LoanApplicationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicLandTypes",
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
                    table.PrimaryKey("PK_DicLandTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicLivestockTypes",
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
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicLivestockTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicOwnershipTypes",
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
                    table.PrimaryKey("PK_DicOwnershipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloraActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ActivityId = table.Column<Guid>(nullable: false),
                    FloraCultureId = table.Column<Guid>(nullable: false),
                    PlannedSquare = table.Column<decimal>(nullable: false),
                    PriceRealization = table.Column<decimal>(nullable: false),
                    SeedingRate = table.Column<decimal>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloraActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloraActivity_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FloraActivity_FloraCultures_FloraCultureId",
                        column: x => x.FloraCultureId,
                        principalTable: "FloraCultures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ActivityId = table.Column<Guid>(nullable: false),
                    Fullname = table.Column<string>(maxLength: 1000, nullable: false),
                    DateIssue = table.Column<DateTime>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    CountOfCorrect = table.Column<int>(nullable: false),
                    IsPledged = table.Column<bool>(nullable: false),
                    PledgeDescription = table.Column<string>(maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicActivity_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivestockActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ActivityId = table.Column<Guid>(nullable: false),
                    LivestockTypeId = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    SlaughterWeight = table.Column<decimal>(nullable: false),
                    LiveWeight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivestockActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivestockActivity_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivestockActivity_DicLivestockTypes_LivestockTypeId",
                        column: x => x.LivestockTypeId,
                        principalTable: "DicLivestockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ActivityId = table.Column<Guid>(nullable: false),
                    LandTypeId = table.Column<Guid>(nullable: false),
                    OwnershipTypeId = table.Column<Guid>(nullable: false),
                    Square = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandActivity_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandActivity_DicLandTypes_LandTypeId",
                        column: x => x.LandTypeId,
                        principalTable: "DicLandTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandActivity_DicOwnershipTypes_OwnershipTypeId",
                        column: x => x.OwnershipTypeId,
                        principalTable: "DicOwnershipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FloraProductivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    FloraActivityId = table.Column<Guid>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloraProductivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloraProductivity_FloraActivity_FloraActivityId",
                        column: x => x.FloraActivityId,
                        principalTable: "FloraActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DicLandTypes",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("21854d74-6899-4216-a3e1-6537dc977586"), "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Посевная площадь", "Посевная площадь", 0 },
                    { new Guid("6c293f35-6171-43b1-868a-67632db8d1a4"), "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пастбище", "Пастбище", 0 },
                    { new Guid("422adcdf-e13d-441e-a4aa-c88fdc741457"), "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Прочие земли", "Прочие земли", 0 }
                });

            migrationBuilder.InsertData(
                table: "DicLivestockTypes",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "ParentId", "Sort" },
                values: new object[,]
                {
                    { new Guid("39420e10-9f02-476e-9825-cb5bb723f6d7"), "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ірі-қара", "КРС", null, 0 },
                    { new Guid("8e357937-2187-4bc6-a86c-9e1027e8a00e"), "101", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сиыр", "Коровы", new Guid("39420e10-9f02-476e-9825-cb5bb723f6d7"), 0 },
                    { new Guid("d42d930f-516f-4878-9ebb-b6840004f9fd"), "102", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бұқалар", "Быки-производители", new Guid("39420e10-9f02-476e-9825-cb5bb723f6d7"), 0 },
                    { new Guid("19de03b5-a84d-45dc-9144-ec12bcb65229"), "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Жылқылар", "Лошади", null, 0 },
                    { new Guid("38906768-e79a-42a6-ab41-6edc04a45ab6"), "201", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Жеребцы-производели", "Жеребцы-производели", new Guid("19de03b5-a84d-45dc-9144-ec12bcb65229"), 0 },
                    { new Guid("c64ce880-75f5-4945-baf7-ce9d386aa124"), "202", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Конематки", "Конематки", new Guid("19de03b5-a84d-45dc-9144-ec12bcb65229"), 0 },
                    { new Guid("75c47257-4c30-4766-9d7c-eca44cd5246f"), "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "МРС", "МРС", null, 0 },
                    { new Guid("103eec83-a1fc-4aed-9f40-006eefe5560f"), "301", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бараны-производители", "Бараны-производители", new Guid("75c47257-4c30-4766-9d7c-eca44cd5246f"), 0 },
                    { new Guid("6130aa9f-e554-4a58-8dbf-d87cda176b5c"), "302", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Овцематки", "Овцематки", new Guid("75c47257-4c30-4766-9d7c-eca44cd5246f"), 0 }
                });

            migrationBuilder.InsertData(
                table: "DicOwnershipTypes",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("80f0bb4b-1742-47e3-9edd-14ac1a0885d9"), "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Меншік", "Собственность", 0 },
                    { new Guid("64767e74-6f0d-40b6-97e5-4ed609286204"), "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Жалға алу", "Аренда", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_IsDeleted",
                table: "Activities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_LoanApplicationId",
                table: "Activities",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DicLandTypes_IsDeleted",
                table: "DicLandTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DicLivestockTypes_IsDeleted",
                table: "DicLivestockTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DicOwnershipTypes_IsDeleted",
                table: "DicOwnershipTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FloraActivity_ActivityId",
                table: "FloraActivity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_FloraActivity_FloraCultureId",
                table: "FloraActivity",
                column: "FloraCultureId");

            migrationBuilder.CreateIndex(
                name: "IX_FloraActivity_IsDeleted",
                table: "FloraActivity",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FloraProductivity_FloraActivityId",
                table: "FloraProductivity",
                column: "FloraActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_FloraProductivity_IsDeleted",
                table: "FloraProductivity",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_LandActivity_ActivityId",
                table: "LandActivity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_LandActivity_IsDeleted",
                table: "LandActivity",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_LandActivity_LandTypeId",
                table: "LandActivity",
                column: "LandTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LandActivity_OwnershipTypeId",
                table: "LandActivity",
                column: "OwnershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LivestockActivity_ActivityId",
                table: "LivestockActivity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_LivestockActivity_IsDeleted",
                table: "LivestockActivity",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_LivestockActivity_LivestockTypeId",
                table: "LivestockActivity",
                column: "LivestockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicActivity_ActivityId",
                table: "TechnicActivity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicActivity_IsDeleted",
                table: "TechnicActivity",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FloraProductivity");

            migrationBuilder.DropTable(
                name: "LandActivity");

            migrationBuilder.DropTable(
                name: "LivestockActivity");

            migrationBuilder.DropTable(
                name: "TechnicActivity");

            migrationBuilder.DropTable(
                name: "FloraActivity");

            migrationBuilder.DropTable(
                name: "DicLandTypes");

            migrationBuilder.DropTable(
                name: "DicOwnershipTypes");

            migrationBuilder.DropTable(
                name: "DicLivestockTypes");

            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
