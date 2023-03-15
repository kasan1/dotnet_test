using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddAppClientStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DicApplicationStatusId",
                table: "DicLoanHistoryStatuses",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "DicLoanHistoryStatuses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DicApplicationStatus",
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
                    table.PrimaryKey("PK_DicApplicationStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DicApplicationStatus",
                columns: new[] { "Id", "Code", "ModifiedDate", "NameKk", "NameRu", "Sort" },
                values: new object[,]
                {
                    { new Guid("3b8ac585-0ffb-40a8-b07f-403ee97472ed"), "Created", null, "Құрылды", "Создан", 0 },
                    { new Guid("1f99f0dc-a463-4eb2-9f7c-df736255ab06"), "Cancelled", null, "Қайтарылды", "Отказано", 0 },
                    { new Guid("c010443c-a805-49fa-8c5d-3359f9575e0e"), "InWork", null, "Қаралуда", "В работе", 0 },
                    { new Guid("6358c3d5-8e26-4bd9-92ea-150f89285381"), "Completed", null, "Аяқталды", "Завершено", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicLoanHistoryStatuses_DicApplicationStatusId",
                table: "DicLoanHistoryStatuses",
                column: "DicApplicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DicApplicationStatus_IsDeleted",
                table: "DicApplicationStatus",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_DicLoanHistoryStatuses_DicApplicationStatus_StatusId",
                table: "DicLoanHistoryStatuses",
                column: "StatusId",
                principalTable: "DicApplicationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(@"update DicLoanHistoryStatuses set StatusId = 'c010443c-a805-49fa-8c5d-3359f9575e0e';
	update DicLoanHistoryStatuses set StatusId = '6358c3d5-8e26-4bd9-92ea-150f89285381' where code = 'Completed';
	update DicLoanHistoryStatuses set StatusId = '1f99f0dc-a463-4eb2-9f7c-df736255ab06' where code = 'Reject';
	update DicLoanHistoryStatuses set StatusId = '3b8ac585-0ffb-40a8-b07f-403ee97472ed' where code = 'Temp';");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DicLoanHistoryStatuses_DicApplicationStatus_DicApplicationStatusId",
                table: "DicLoanHistoryStatuses");

            migrationBuilder.DropTable(
                name: "DicApplicationStatus");

            migrationBuilder.DropIndex(
                name: "IX_DicLoanHistoryStatuses_DicApplicationStatusId",
                table: "DicLoanHistoryStatuses");

            migrationBuilder.DropColumn(
                name: "DicApplicationStatusId",
                table: "DicLoanHistoryStatuses");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "DicLoanHistoryStatuses");
        }
    }
}
