using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddAdministrativeCenterToDicRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "DicRegions",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DicRegions",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DicRegions",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "AdministrativeCenterKk",
                table: "DicRegions",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdministrativeCenterRu",
                table: "DicRegions",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DicRegions_IsDeleted",
                table: "DicRegions",
                column: "IsDeleted");

            migrationBuilder.Sql(@"
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Кокшетау', AdministrativeCenterKk = N'Көкшетау' WHERE Code = 'akmola';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Актобе', AdministrativeCenterKk = N'Ақтөбе' WHERE Code = 'aktobe';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Талдыкорган', AdministrativeCenterKk = N'Талдықорған' WHERE Code = 'almaty';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Атырау', AdministrativeCenterKk = N'Атырау' WHERE Code = 'atyrau';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Усть-Каменогорск', AdministrativeCenterKk = N'Өскемен' WHERE Code = 'vko';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Тараз', AdministrativeCenterKk = N'Тараз' WHERE Code = 'zhambyl';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Уральск', AdministrativeCenterKk = N'Орал' WHERE Code = 'zko';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Караганда', AdministrativeCenterKk = N'Қарағанды' WHERE Code = 'karagandy';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Костанай', AdministrativeCenterKk = N'Қостанай' WHERE Code = 'kostanai';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Кызылорда', AdministrativeCenterKk = N'Қызылорда' WHERE Code = 'kyzylorda';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Актау', AdministrativeCenterKk = N'Ақтау' WHERE Code = 'mangystau';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Павлодар', AdministrativeCenterKk = N'Павлодар' WHERE Code = 'pavlodar';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Петропавловск', AdministrativeCenterKk = N'Петропавл' WHERE Code = 'sko';
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = 'Туркестан', AdministrativeCenterKk = N'Түркістан' WHERE Code = 'turk';
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE [KAF].[dbo].[DicRegions] SET AdministrativeCenterRu = NULL, AdministrativeCenterKk = NULL;
            ");

            migrationBuilder.DropIndex(
                name: "IX_DicRegions_IsDeleted",
                table: "DicRegions");

            migrationBuilder.DropColumn(
                name: "AdministrativeCenterKk",
                table: "DicRegions");

            migrationBuilder.DropColumn(
                name: "AdministrativeCenterRu",
                table: "DicRegions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "DicRegions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DicRegions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DicRegions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getDate()");
        }
    }
}
