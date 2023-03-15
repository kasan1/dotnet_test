using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class ChangeUserForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProfiles_Users_UserId",
                table: "ClientProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditCommitteeResults_Users_UserId",
                table: "CreditCommitteeResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpertiseResults_Users_UserId",
                table: "ExpertiseResults");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationHistories_Users_UserId",
                table: "LoanApplicationHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Branches_BranchId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanTypes_DicLoanTypeId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanProducts_LoanProductId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanHistoryStatuses_StatusId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Users_UserId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationTasks_Users_UserId",
                table: "LoanApplicationTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_UserId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_Users_UserId",
                table: "UserBranches");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1764f9f3-f36c-473b-9204-96e4182d9405"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe9f6cd7-bc2c-4875-af30-6acb6cdd9cd7"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "LoanApplications",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "LoanApplications",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "DicLoanProductId",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getDate()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "ModifiedDate", "Name", "NameKk", "NameRu", "NormalizedName", "RoleType" },
                values: new object[] { new Guid("5e41bc02-51d1-4fff-8f11-bef3e042cb75"), "5E41BC02-51D1-4FFF-8F11-BEF3E042CB75", null, "CreditCommitteeChairman", null, "Председатель кредитного комитета", "CREDITCOMMITTEECHAIRMAN", 21 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "ModifiedDate", "Name", "NameKk", "NameRu", "NormalizedName", "RoleType" },
                values: new object[] { new Guid("3386622f-39ae-48d0-87fc-58653c60ae6b"), "3386622F-39AE-48D0-87FC-58653C60AE6B", null, "Logist", null, "Логист", "LOGIST", 22 });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DicLoanProductId",
                table: "LoanApplications",
                column: "DicLoanProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_IsDeleted",
                table: "LoanApplications",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProfiles_AspNetUsers_UserId",
                table: "ClientProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCommitteeResults_AspNetUsers_UserId",
                table: "CreditCommitteeResults",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertiseResults_AspNetUsers_UserId",
                table: "ExpertiseResults",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationHistories_AspNetUsers_UserId",
                table: "LoanApplicationHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Branches_BranchId",
                table: "LoanApplications",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanProducts_DicLoanProductId",
                table: "LoanApplications",
                column: "DicLoanProductId",
                principalTable: "DicLoanProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanTypes_DicLoanTypeId",
                table: "LoanApplications",
                column: "DicLoanTypeId",
                principalTable: "DicLoanTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanProducts_LoanProductId",
                table: "LoanApplications",
                column: "LoanProductId",
                principalTable: "DicLoanProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanHistoryStatuses_StatusId",
                table: "LoanApplications",
                column: "StatusId",
                principalTable: "DicLoanHistoryStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_AspNetUsers_UserId",
                table: "LoanApplications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationTasks_AspNetUsers_UserId",
                table: "LoanApplicationTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_AspNetUsers_UserId",
                table: "Positions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_AspNetUsers_UserId",
                table: "UserBranches",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProfiles_AspNetUsers_UserId",
                table: "ClientProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditCommitteeResults_AspNetUsers_UserId",
                table: "CreditCommitteeResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpertiseResults_AspNetUsers_UserId",
                table: "ExpertiseResults");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationHistories_AspNetUsers_UserId",
                table: "LoanApplicationHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Branches_BranchId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanProducts_DicLoanProductId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanTypes_DicLoanTypeId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanProducts_LoanProductId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicLoanHistoryStatuses_StatusId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_AspNetUsers_UserId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationTasks_AspNetUsers_UserId",
                table: "LoanApplicationTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_AspNetUsers_UserId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_AspNetUsers_UserId",
                table: "UserBranches");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_DicLoanProductId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_IsDeleted",
                table: "LoanApplications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3386622f-39ae-48d0-87fc-58653c60ae6b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5e41bc02-51d1-4fff-8f11-bef3e042cb75"));

            migrationBuilder.DropColumn(
                name: "DicLoanProductId",
                table: "LoanApplications");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "LoanApplications",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "LoanApplications",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "ModifiedDate", "Name", "NameKk", "NameRu", "NormalizedName", "RoleType" },
                values: new object[] { new Guid("1764f9f3-f36c-473b-9204-96e4182d9405"), "1764F9F3-F36C-473B-9204-96E4182D9405", null, "CreditCommitteeChairman", null, "Председатель кредитного комитета", "CREDITCOMMITTEECHAIRMAN", 21 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "ModifiedDate", "Name", "NameKk", "NameRu", "NormalizedName", "RoleType" },
                values: new object[] { new Guid("fe9f6cd7-bc2c-4875-af30-6acb6cdd9cd7"), "FE9F6CD7-BC2C-4875-AF30-6ACB6CDD9CD7", null, "Logist", null, "Логист", "LOGIST", 22 });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProfiles_Users_UserId",
                table: "ClientProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCommitteeResults_Users_UserId",
                table: "CreditCommitteeResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertiseResults_Users_UserId",
                table: "ExpertiseResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationHistories_Users_UserId",
                table: "LoanApplicationHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Branches_BranchId",
                table: "LoanApplications",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanTypes_DicLoanTypeId",
                table: "LoanApplications",
                column: "DicLoanTypeId",
                principalTable: "DicLoanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanProducts_LoanProductId",
                table: "LoanApplications",
                column: "LoanProductId",
                principalTable: "DicLoanProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicLoanHistoryStatuses_StatusId",
                table: "LoanApplications",
                column: "StatusId",
                principalTable: "DicLoanHistoryStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Users_UserId",
                table: "LoanApplications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationTasks_Users_UserId",
                table: "LoanApplicationTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_UserId",
                table: "Positions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_Users_UserId",
                table: "UserBranches",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
