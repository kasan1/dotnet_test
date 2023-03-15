using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class RemoveDicActivityTypeDicBankDicKatoDicLoanPurpose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DicBanks_BankId",
                table: "LoanApplications");

            migrationBuilder.DropTable(
                name: "DicBanks");

            migrationBuilder.DropTable(
                name: "DicKato");

            migrationBuilder.DropTable(
                name: "DicLoanPurposes");

            migrationBuilder.DropTable(
                name: "LoanProductActivities");

            migrationBuilder.DropTable(
                name: "DicActivityTypes");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_BankId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "Step1",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "Step2",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "Step3",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "Step4",
                table: "LoanApplications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BankId",
                table: "LoanApplications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Step1",
                table: "LoanApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Step2",
                table: "LoanApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Step3",
                table: "LoanApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Step4",
                table: "LoanApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DicActivityTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code1c = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameKk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicActivityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicBanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameKk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentSystemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicBanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicKato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ab = table.Column<int>(type: "int", nullable: false),
                    Cd = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeOld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ef = table.Column<int>(type: "int", nullable: false),
                    Hij = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameKk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OblastId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicKato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicKato_DicKato_ParentId",
                        column: x => x.ParentId,
                        principalTable: "DicKato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DicLoanPurposes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameKk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicLoanPurposes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanProductActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanProductActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanProductActivities_DicActivityTypes_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "DicActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanProductActivities_DicLoanProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "DicLoanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BankId",
                table: "LoanApplications",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_DicKato_ParentId",
                table: "DicKato",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProductActivities_ActivityTypeId",
                table: "LoanProductActivities",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProductActivities_ProductId",
                table: "LoanProductActivities",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DicBanks_BankId",
                table: "LoanApplications",
                column: "BankId",
                principalTable: "DicBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
