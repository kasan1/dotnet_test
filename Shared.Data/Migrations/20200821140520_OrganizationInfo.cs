using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class OrganizationInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ClientTypeId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    clientSegmentId = table.Column<Guid>(nullable: true),
                    Series = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    KatoCode = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    IsNDS = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationInfos_DicClientTypes_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "DicClientTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationInfos_DicClientSegmentes_clientSegmentId",
                        column: x => x.clientSegmentId,
                        principalTable: "DicClientSegmentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationInfos_ClientTypeId",
                table: "OrganizationInfos",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationInfos_UserId",
                table: "OrganizationInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationInfos_clientSegmentId",
                table: "OrganizationInfos",
                column: "clientSegmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationInfos");
        }
    }
}
