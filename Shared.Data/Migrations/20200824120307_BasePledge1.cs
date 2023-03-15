using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class BasePledge1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BpmNokId",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "CoreId",
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
                name: "IsObtain",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "Kato",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "NokOrManualSum",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "PledgeType",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "TotalSum",
                table: "BasePledge");

            migrationBuilder.AlterColumn<float>(
                name: "TotalArea",
                table: "Nonmovables",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "LivingArea",
                table: "Nonmovables",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "LandArea",
                table: "Nonmovables",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "BuiltYear",
                table: "Nonmovables",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Nonmovables",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "CommercialType",
                table: "Nonmovables",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Rent",
                table: "Nonmovables",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "RentedFor",
                table: "Nonmovables",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "CommercialType",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "Rent",
                table: "Nonmovables");

            migrationBuilder.DropColumn(
                name: "RentedFor",
                table: "Nonmovables");

            migrationBuilder.AlterColumn<double>(
                name: "TotalArea",
                table: "Nonmovables",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<double>(
                name: "LivingArea",
                table: "Nonmovables",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "LandArea",
                table: "Nonmovables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "BuiltYear",
                table: "Nonmovables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(short));

            migrationBuilder.AddColumn<int>(
                name: "BpmNokId",
                table: "BasePledge",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoreId",
                table: "BasePledge",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasLegalTransactionsAndClaims",
                table: "BasePledge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectEgov",
                table: "BasePledge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsCorrectEgovNote",
                table: "BasePledge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectLaw",
                table: "BasePledge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsCorrectLawNote",
                table: "BasePledge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEncumbered",
                table: "BasePledge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEncumberedAtFund",
                table: "BasePledge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNokAssessment",
                table: "BasePledge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsObtain",
                table: "BasePledge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "BasePledge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Kato",
                table: "BasePledge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NokOrManualSum",
                table: "BasePledge",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PledgeType",
                table: "BasePledge",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSum",
                table: "BasePledge",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
