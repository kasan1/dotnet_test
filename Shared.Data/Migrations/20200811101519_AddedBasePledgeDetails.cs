using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddedBasePledgeDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BpmNokId",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChargeeId",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "BasePledge",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "HasLegalTransactionsAndClaims",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectEgov",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsCorrectEgovNote",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectLaw",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsCorrectLawNote",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEncumbered",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEncumberedAtFund",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNokAssessment",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Kato",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LiquidityId",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NokOrManualSum",
                table: "BasePledge",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSum",
                table: "BasePledge",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "BasePledge",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chargees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IIN = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    FIORus = table.Column<string>(nullable: true),
                    FIOKaz = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    MaritalStatus = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DocumentType = table.Column<string>(nullable: true),
                    DocumentDateStart = table.Column<DateTime>(nullable: false),
                    DocumentDateEnd = table.Column<DateTime>(nullable: false),
                    DocumentIssuedBy = table.Column<string>(nullable: true),
                    DocumentIdNumber = table.Column<string>(nullable: true),
                    RegIndex = table.Column<string>(nullable: true),
                    RegRegion = table.Column<string>(nullable: true),
                    RegStreet = table.Column<string>(nullable: true),
                    RegStreetKz = table.Column<string>(nullable: true),
                    RegHouseNumber = table.Column<string>(nullable: true),
                    RegFlatNumber = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    AdditionalNumber = table.Column<string>(nullable: true),
                    IsCorrectEgov = table.Column<bool>(nullable: false),
                    IsCorrectLaw = table.Column<bool>(nullable: false),
                    IsCorrectEgovNote = table.Column<string>(nullable: true),
                    IsCorrectLawNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chargees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Liquidities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PledgeType = table.Column<int>(nullable: false),
                    LiquidityType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Coefficient = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasePledge_ChargeeId",
                table: "BasePledge",
                column: "ChargeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BasePledge_LiquidityId",
                table: "BasePledge",
                column: "LiquidityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePledge_Chargees_ChargeeId",
                table: "BasePledge",
                column: "ChargeeId",
                principalTable: "Chargees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasePledge_Liquidities_LiquidityId",
                table: "BasePledge",
                column: "LiquidityId",
                principalTable: "Liquidities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasePledge_Chargees_ChargeeId",
                table: "BasePledge");

            migrationBuilder.DropForeignKey(
                name: "FK_BasePledge_Liquidities_LiquidityId",
                table: "BasePledge");

            migrationBuilder.DropTable(
                name: "Chargees");

            migrationBuilder.DropTable(
                name: "Liquidities");

            migrationBuilder.DropIndex(
                name: "IX_BasePledge_ChargeeId",
                table: "BasePledge");

            migrationBuilder.DropIndex(
                name: "IX_BasePledge_LiquidityId",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "BpmNokId",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "ChargeeId",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "HasLegalTransactionsAndClaims",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "IsCorrectEgov",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "IsCorrectEgovNote",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "IsCorrectLaw",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "IsCorrectLawNote",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "IsEncumbered",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "IsEncumberedAtFund",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "IsNokAssessment",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "Kato",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "LiquidityId",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "NokOrManualSum",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "TotalSum",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "BasePledge");
        }
    }
}
