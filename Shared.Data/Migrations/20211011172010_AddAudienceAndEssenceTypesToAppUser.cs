using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddAudienceAndEssenceTypesToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EssenceType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserAudienceType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04239152-33af-4071-8b84-686660c6c151"),
                column: "ConcurrencyStamp",
                value: "04239152-33AF-4071-8B84-686660C6C151");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("09704848-58d2-47d4-8939-08d86ffedb1d"),
                column: "ConcurrencyStamp",
                value: "09704848-58D2-47D4-8939-08D86FFEDB1D");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1764f9f3-f36c-473b-9204-96e4182d9405"),
                column: "ConcurrencyStamp",
                value: "1764F9F3-F36C-473B-9204-96E4182D9405");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("26b33317-91d0-42b8-905d-08d8e1ea76a3"),
                column: "ConcurrencyStamp",
                value: "26B33317-91D0-42B8-905D-08D8E1EA76A3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f237466-b4f1-48b9-b14c-b6cf717ed224"),
                column: "ConcurrencyStamp",
                value: "2F237466-B4F1-48B9-B14C-B6CF717ED224");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("380cad1c-20c1-44f5-af25-606b2be0ea48"),
                column: "ConcurrencyStamp",
                value: "380CAD1C-20C1-44F5-AF25-606B2BE0EA48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3debea62-3b35-485c-988f-421105b1bbea"),
                column: "ConcurrencyStamp",
                value: "3DEBEA62-3B35-485C-988F-421105B1BBEA");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5fb9f021-e553-46b3-bee4-e3d96f995e80"),
                column: "ConcurrencyStamp",
                value: "5FB9F021-E553-46B3-BEE4-E3D96F995E80");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6b20b2f2-2fbe-4d6f-91e5-f1e5c1db8e90"),
                column: "ConcurrencyStamp",
                value: "6B20B2F2-2FBE-4D6F-91E5-F1E5C1DB8E90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("883a571b-58bf-4b70-a324-7adb7bb1fa81"),
                column: "ConcurrencyStamp",
                value: "883A571B-58BF-4B70-A324-7ADB7BB1FA81");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d033b74-856f-4fa4-95c5-ea7b55c8a4ce"),
                column: "ConcurrencyStamp",
                value: "8D033B74-856F-4FA4-95C5-EA7B55C8A4CE");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8f7f4e3c-d607-4060-47c1-08d91f280430"),
                column: "ConcurrencyStamp",
                value: "8F7F4E3C-D607-4060-47C1-08D91F280430");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aecf3004-49ca-4b71-b5c6-e0c69373af28"),
                column: "ConcurrencyStamp",
                value: "AECF3004-49CA-4B71-B5C6-E0C69373AF28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bafc5489-4359-49ed-d251-08d8e1ecba81"),
                column: "ConcurrencyStamp",
                value: "BAFC5489-4359-49ED-D251-08D8E1ECBA81");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c6d623fc-ecc9-4c8a-8f01-0c543aab70d9"),
                column: "ConcurrencyStamp",
                value: "C6D623FC-ECC9-4C8A-8F01-0C543AAB70D9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fc7a5055-4e94-4cf5-9b6f-1ed968ef425f"),
                column: "ConcurrencyStamp",
                value: "FC7A5055-4E94-4CF5-9B6F-1ED968EF425F");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe9f6cd7-bc2c-4875-af30-6acb6cdd9cd7"),
                column: "ConcurrencyStamp",
                value: "FE9F6CD7-BC2C-4875-AF30-6ACB6CDD9CD7");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EssenceType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserAudienceType",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04239152-33af-4071-8b84-686660c6c151"),
                column: "ConcurrencyStamp",
                value: "394e97ab-4421-4b88-a203-c462bda4a591");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("09704848-58d2-47d4-8939-08d86ffedb1d"),
                column: "ConcurrencyStamp",
                value: "508debf1-3ee0-4ecc-8d5e-bde630ae2616");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1764f9f3-f36c-473b-9204-96e4182d9405"),
                column: "ConcurrencyStamp",
                value: "0d2f1278-5b5f-47f8-bbb6-58edff7ce76a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("26b33317-91d0-42b8-905d-08d8e1ea76a3"),
                column: "ConcurrencyStamp",
                value: "73860d07-d571-4290-9076-5c0dbd246620");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f237466-b4f1-48b9-b14c-b6cf717ed224"),
                column: "ConcurrencyStamp",
                value: "79f9ce82-3ade-462d-a2e5-1a58bb799430");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("380cad1c-20c1-44f5-af25-606b2be0ea48"),
                column: "ConcurrencyStamp",
                value: "c00d018e-d74d-4f62-a296-c0cfba15fc89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3debea62-3b35-485c-988f-421105b1bbea"),
                column: "ConcurrencyStamp",
                value: "b3077ea7-4afa-4f20-b3ae-9018eef2a8af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5fb9f021-e553-46b3-bee4-e3d96f995e80"),
                column: "ConcurrencyStamp",
                value: "504be3a3-6bce-40aa-9138-57f7ef7d97ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6b20b2f2-2fbe-4d6f-91e5-f1e5c1db8e90"),
                column: "ConcurrencyStamp",
                value: "3ac084f8-ce93-4d32-929f-50572c9fd448");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("883a571b-58bf-4b70-a324-7adb7bb1fa81"),
                column: "ConcurrencyStamp",
                value: "2b57021c-9391-4ef5-8051-061003757a26");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d033b74-856f-4fa4-95c5-ea7b55c8a4ce"),
                column: "ConcurrencyStamp",
                value: "bc25c461-1fa0-482c-8f4c-82a228e1b357");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8f7f4e3c-d607-4060-47c1-08d91f280430"),
                column: "ConcurrencyStamp",
                value: "1c01dce6-7879-4299-bd73-99873519e602");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aecf3004-49ca-4b71-b5c6-e0c69373af28"),
                column: "ConcurrencyStamp",
                value: "0ee1ee73-135f-4fcf-a7cf-919d44246b23");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bafc5489-4359-49ed-d251-08d8e1ecba81"),
                column: "ConcurrencyStamp",
                value: "6f8f2372-90e1-4c81-9e0a-3d0b913c57dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c6d623fc-ecc9-4c8a-8f01-0c543aab70d9"),
                column: "ConcurrencyStamp",
                value: "b5e0466a-3027-4c49-96fc-f1a0dcddeb93");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fc7a5055-4e94-4cf5-9b6f-1ed968ef425f"),
                column: "ConcurrencyStamp",
                value: "41c351c4-9cc3-43b9-b1fe-781d96c2cda4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe9f6cd7-bc2c-4875-af30-6acb6cdd9cd7"),
                column: "ConcurrencyStamp",
                value: "4b46e788-bbdf-4bb9-93b5-d911b3e2bb97");
        }
    }
}
