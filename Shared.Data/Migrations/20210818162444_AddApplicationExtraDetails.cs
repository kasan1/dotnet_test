using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddApplicationExtraDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanApplicationExtraDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    LoanApplicationId = table.Column<Guid>(nullable: false),
                    VatCertificateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationExtraDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationExtraDetails_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationExtraDetails_Documents_VatCertificateId",
                        column: x => x.VatCertificateId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FlOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ExtraDetailsId = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlOwners_LoanApplicationExtraDetails_ExtraDetailsId",
                        column: x => x.ExtraDetailsId,
                        principalTable: "LoanApplicationExtraDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlOwners_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ExtraDetailsId = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false),
                    Essence = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licenses_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Licenses_LoanApplicationExtraDetails_ExtraDetailsId",
                        column: x => x.ExtraDetailsId,
                        principalTable: "LoanApplicationExtraDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UlOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ExtraDetailsId = table.Column<Guid>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UlOwners_LoanApplicationExtraDetails_ExtraDetailsId",
                        column: x => x.ExtraDetailsId,
                        principalTable: "LoanApplicationExtraDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UlOwners_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlOwners_ExtraDetailsId",
                table: "FlOwners",
                column: "ExtraDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_FlOwners_IsDeleted",
                table: "FlOwners",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FlOwners_PersonId",
                table: "FlOwners",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_DocumentId",
                table: "Licenses",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_ExtraDetailsId",
                table: "Licenses",
                column: "ExtraDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_IsDeleted",
                table: "Licenses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationExtraDetails_IsDeleted",
                table: "LoanApplicationExtraDetails",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationExtraDetails_LoanApplicationId",
                table: "LoanApplicationExtraDetails",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationExtraDetails_VatCertificateId",
                table: "LoanApplicationExtraDetails",
                column: "VatCertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_UlOwners_ExtraDetailsId",
                table: "UlOwners",
                column: "ExtraDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_UlOwners_IsDeleted",
                table: "UlOwners",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UlOwners_OrganizationId",
                table: "UlOwners",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlOwners");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "UlOwners");

            migrationBuilder.DropTable(
                name: "LoanApplicationExtraDetails");
        }
    }
}
