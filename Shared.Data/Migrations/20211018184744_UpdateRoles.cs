using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class UpdateRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04239152-33af-4071-8b84-686660c6c151"),
                column: "NormalizedName",
                value: "CREDITMANAGER");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("09704848-58d2-47d4-8939-08d86ffedb1d"),
                column: "NormalizedName",
                value: "ADMIN");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1764f9f3-f36c-473b-9204-96e4182d9405"),
                column: "NormalizedName",
                value: "CREDITCOMMITTEECHAIRMAN");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("26b33317-91d0-42b8-905d-08d8e1ea76a3"),
                column: "NormalizedName",
                value: "CREDADMIN");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f237466-b4f1-48b9-b14c-b6cf717ed224"),
                column: "NormalizedName",
                value: "PLEDGER");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("380cad1c-20c1-44f5-af25-606b2be0ea48"),
                column: "NormalizedName",
                value: "CREDITCOMMITTEE2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3debea62-3b35-485c-988f-421105b1bbea"),
                column: "NormalizedName",
                value: "CREDITCOMMITTEE4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5fb9f021-e553-46b3-bee4-e3d96f995e80"),
                column: "NormalizedName",
                value: "PURCHASER");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6b20b2f2-2fbe-4d6f-91e5-f1e5c1db8e90"),
                column: "NormalizedName",
                value: "CREDITCOMMITTEE1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("883a571b-58bf-4b70-a324-7adb7bb1fa81"),
                column: "NormalizedName",
                value: "CREDITCOMMITTEE3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d033b74-856f-4fa4-95c5-ea7b55c8a4ce"),
                column: "NormalizedName",
                value: "CREDITCOMMITTEE5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8f7f4e3c-d607-4060-47c1-08d91f280430"),
                column: "NormalizedName",
                value: "COMPLIANCEMANAGER");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aecf3004-49ca-4b71-b5c6-e0c69373af28"),
                column: "NormalizedName",
                value: "RISKMANAGER");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bafc5489-4359-49ed-d251-08d8e1ecba81"),
                column: "NormalizedName",
                value: "CREDITCOMMITTEE");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c6d623fc-ecc9-4c8a-8f01-0c543aab70d9"),
                column: "NormalizedName",
                value: "JURIST");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fc7a5055-4e94-4cf5-9b6f-1ed968ef425f"),
                column: "NormalizedName",
                value: "SECURITYMANAGER");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe9f6cd7-bc2c-4875-af30-6acb6cdd9cd7"),
                column: "NormalizedName",
                value: "LOGIST");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04239152-33af-4071-8b84-686660c6c151"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("09704848-58d2-47d4-8939-08d86ffedb1d"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1764f9f3-f36c-473b-9204-96e4182d9405"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("26b33317-91d0-42b8-905d-08d8e1ea76a3"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f237466-b4f1-48b9-b14c-b6cf717ed224"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("380cad1c-20c1-44f5-af25-606b2be0ea48"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3debea62-3b35-485c-988f-421105b1bbea"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5fb9f021-e553-46b3-bee4-e3d96f995e80"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6b20b2f2-2fbe-4d6f-91e5-f1e5c1db8e90"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("883a571b-58bf-4b70-a324-7adb7bb1fa81"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d033b74-856f-4fa4-95c5-ea7b55c8a4ce"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8f7f4e3c-d607-4060-47c1-08d91f280430"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aecf3004-49ca-4b71-b5c6-e0c69373af28"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bafc5489-4359-49ed-d251-08d8e1ecba81"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c6d623fc-ecc9-4c8a-8f01-0c543aab70d9"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fc7a5055-4e94-4cf5-9b6f-1ed968ef425f"),
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe9f6cd7-bc2c-4875-af30-6acb6cdd9cd7"),
                column: "NormalizedName",
                value: null);
        }
    }
}
