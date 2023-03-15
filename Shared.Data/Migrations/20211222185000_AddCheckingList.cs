using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddCheckingList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DicCheckingListTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Sort = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    NameRu = table.Column<string>(maxLength: 200, nullable: false),
                    NameKk = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicCheckingListTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckingList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Identifier = table.Column<string>(maxLength: 12, nullable: false),
                    Fullname = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    TypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckingList_DicCheckingListTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DicCheckingListTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DicCheckingListTypes",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[] { new Guid("ec8eaaef-15aa-4180-9405-bd27bc7bafe8"), "SpecialRelations", null, "Ерекше байланыстар", "Особые отношения", 0 });

            migrationBuilder.InsertData(
                table: "DicCheckingListTypes",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[] { new Guid("11c06de2-7ed7-4415-8e94-a01b48529c56"), "AffiliationPersonalities", null, "Аффилированные лица", "Аффилированные лица", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_DicLoanHistoryStatuses_StatusId",
                table: "DicLoanHistoryStatuses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingList_IsDeleted",
                table: "CheckingList",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingList_TypeId",
                table: "CheckingList",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DicCheckingListTypes_IsDeleted",
                table: "DicCheckingListTypes",
                column: "IsDeleted");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckingList");

            migrationBuilder.DropTable(
                name: "DicCheckingListTypes");
        }
    }
}
