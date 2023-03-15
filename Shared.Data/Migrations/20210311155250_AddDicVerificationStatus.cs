using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddDicVerificationStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DicVerificationStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    NameRu = table.Column<string>(maxLength: 200, nullable: false),
                    NameKz = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicVerificationStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DicVerificationStatus",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKz", "NameRu", "Status" },
                values: new object[,]
                {
                    { new Guid("9147caff-1fd0-4fb2-9216-1d4d354cd9a0"), "0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Қызмет қол жетімді емес", "Сервис не доступен", 0 },
                    { new Guid("5c792135-6524-4a12-bf48-dea59580f552"), "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тексеруден өтті", "Проверка пройдена", 1 },
                    { new Guid("9be3e547-c44e-418e-a9c7-6acfba833f71"), "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Жөнделетін", "Устраняемый", 2 },
                    { new Guid("c60a9da0-816b-46e6-84a1-a3d4188a1e4a"), "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Жөнделмейтін", "Не устраняемый", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicVerificationStatus_IsDeleted",
                table: "DicVerificationStatus",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DicVerificationStatus");
        }
    }
}
