using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class RemovePledgeLiquidityChargee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgroFiles_BasePledge_BasePledgeId",
                table: "AgroFiles");

            migrationBuilder.DropTable(
                name: "Chargees");

            migrationBuilder.DropTable(
                name: "CreditSources");

            migrationBuilder.DropTable(
                name: "BasePledge");

            migrationBuilder.DropTable(
                name: "Liquidities");

            migrationBuilder.DropIndex(
                name: "IX_AgroFiles_BasePledgeId",
                table: "AgroFiles");

            migrationBuilder.DropColumn(
                name: "BasePledgeId",
                table: "AgroFiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BasePledgeId",
                table: "AgroFiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CreditSources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DicProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaxMonth = table.Column<int>(type: "int", nullable: false),
                    MaxSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxSumAnchor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentEffSocial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentEffStandart = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentSocial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentStandart = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditSources_DicProducts_DicProductId",
                        column: x => x.DicProductId,
                        principalTable: "DicProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Liquidities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Coefficient = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LiquidityType = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PledgeType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasePledge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Agreement = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AsonSum = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Coefficient = table.Column<float>(type: "real", nullable: true),
                    CoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DicNokId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExpertSum = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpertiseSum = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FinalSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstLevel = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false),
                    LegalCommentRk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalCommentVnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalResultRk = table.Column<bool>(type: "bit", nullable: false),
                    LegalResultVnd = table.Column<bool>(type: "bit", nullable: false),
                    LiquidityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LiquidityType = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NokName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NokSum = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SecondLevel = table.Column<int>(type: "int", nullable: true),
                    ThirdLevel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePledge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasePledge_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasePledge_DicNoks_DicNokId",
                        column: x => x.DicNokId,
                        principalTable: "DicNoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasePledge_Liquidities_LiquidityId",
                        column: x => x.LiquidityId,
                        principalTable: "Liquidities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chargees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasePledgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentBeginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocumentOrganizationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Iin = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LegalCommentRk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalCommentVnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalResultRk = table.Column<bool>(type: "bit", nullable: false),
                    LegalResultVnd = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SamePerson = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chargees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chargees_BasePledge_BasePledgeId",
                        column: x => x.BasePledgeId,
                        principalTable: "BasePledge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgroFiles_BasePledgeId",
                table: "AgroFiles",
                column: "BasePledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_BasePledge_ApplicationId",
                table: "BasePledge",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_BasePledge_DicNokId",
                table: "BasePledge",
                column: "DicNokId");

            migrationBuilder.CreateIndex(
                name: "IX_BasePledge_LiquidityId",
                table: "BasePledge",
                column: "LiquidityId");

            migrationBuilder.CreateIndex(
                name: "IX_Chargees_BasePledgeId",
                table: "Chargees",
                column: "BasePledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditSources_DicProductId",
                table: "CreditSources",
                column: "DicProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgroFiles_BasePledge_BasePledgeId",
                table: "AgroFiles",
                column: "BasePledgeId",
                principalTable: "BasePledge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
