using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class RemoveDicLoanFinancingSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DicProducts");

            migrationBuilder.DropTable(
                name: "LoanGracePeriodConditions");

            migrationBuilder.DropTable(
                name: "LoanMaxAmountConditions");

            migrationBuilder.DropTable(
                name: "LoanMinAmountConditions");

            migrationBuilder.DropTable(
                name: "LoanRateConditions");

            migrationBuilder.DropTable(
                name: "LoanRepaymentFrequencyFee");

            migrationBuilder.DropTable(
                name: "LoanRepaymentFrequencyOD");

            migrationBuilder.DropTable(
                name: "LoanTermConditions");

            migrationBuilder.DropTable(
                name: "DicLoanFinancingSources");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DicLoanFinancingSources",
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
                    table.PrimaryKey("PK_DicLoanFinancingSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicProducts",
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
                    table.PrimaryKey("PK_DicProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanGracePeriodConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fee = table.Column<int>(type: "int", nullable: false),
                    FinancingSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MainDebt = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurposeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanGracePeriodConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanGracePeriodConditions_DicLoanFinancingSources_FinancingSourceId",
                        column: x => x.FinancingSourceId,
                        principalTable: "DicLoanFinancingSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanGracePeriodConditions_DicLoanProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "DicLoanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanGracePeriodConditions_DicLoanPurposes_PurposeId",
                        column: x => x.PurposeId,
                        principalTable: "DicLoanPurposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanMaxAmountConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientLocationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinancingSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanMaxAmountConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanMaxAmountConditions_DicClientLocationTypes_ClientLocationTypeId",
                        column: x => x.ClientLocationTypeId,
                        principalTable: "DicClientLocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanMaxAmountConditions_DicLoanFinancingSources_FinancingSourceId",
                        column: x => x.FinancingSourceId,
                        principalTable: "DicLoanFinancingSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanMaxAmountConditions_DicLoanProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "DicLoanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanMinAmountConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinancingSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LoanProductActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanMinAmountConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanMinAmountConditions_DicLoanFinancingSources_FinancingSourceId",
                        column: x => x.FinancingSourceId,
                        principalTable: "DicLoanFinancingSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanMinAmountConditions_LoanProductActivities_LoanProductActivityId",
                        column: x => x.LoanProductActivityId,
                        principalTable: "LoanProductActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanRateConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientSegmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinancingSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PercentRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRateConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanRateConditions_DicClientSegmentes_ClientSegmentId",
                        column: x => x.ClientSegmentId,
                        principalTable: "DicClientSegmentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRateConditions_DicLoanFinancingSources_FinancingSourceId",
                        column: x => x.FinancingSourceId,
                        principalTable: "DicLoanFinancingSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRateConditions_DicLoanProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "DicLoanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanRepaymentFrequencyFee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinancingSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepaymentTypeFeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRepaymentFrequencyFee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanRepaymentFrequencyFee_DicLoanFinancingSources_FinancingSourceId",
                        column: x => x.FinancingSourceId,
                        principalTable: "DicLoanFinancingSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRepaymentFrequencyFee_DicLoanProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "DicLoanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRepaymentFrequencyFee_DicLoanRepaymentTypes_RepaymentTypeFeeId",
                        column: x => x.RepaymentTypeFeeId,
                        principalTable: "DicLoanRepaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanRepaymentFrequencyOD",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinancingSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepaymentTypeODId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRepaymentFrequencyOD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanRepaymentFrequencyOD_DicLoanFinancingSources_FinancingSourceId",
                        column: x => x.FinancingSourceId,
                        principalTable: "DicLoanFinancingSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRepaymentFrequencyOD_DicLoanProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "DicLoanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRepaymentFrequencyOD_DicLoanRepaymentTypes_RepaymentTypeODId",
                        column: x => x.RepaymentTypeODId,
                        principalTable: "DicLoanRepaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanTermConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinancingSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurposeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Term = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTermConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanTermConditions_DicClientTypes_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "DicClientTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanTermConditions_DicLoanFinancingSources_FinancingSourceId",
                        column: x => x.FinancingSourceId,
                        principalTable: "DicLoanFinancingSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanTermConditions_DicLoanProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "DicLoanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanTermConditions_DicLoanPurposes_PurposeId",
                        column: x => x.PurposeId,
                        principalTable: "DicLoanPurposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanGracePeriodConditions_FinancingSourceId",
                table: "LoanGracePeriodConditions",
                column: "FinancingSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanGracePeriodConditions_ProductId",
                table: "LoanGracePeriodConditions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanGracePeriodConditions_PurposeId",
                table: "LoanGracePeriodConditions",
                column: "PurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanMaxAmountConditions_ClientLocationTypeId",
                table: "LoanMaxAmountConditions",
                column: "ClientLocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanMaxAmountConditions_FinancingSourceId",
                table: "LoanMaxAmountConditions",
                column: "FinancingSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanMaxAmountConditions_ProductId",
                table: "LoanMaxAmountConditions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanMinAmountConditions_FinancingSourceId",
                table: "LoanMinAmountConditions",
                column: "FinancingSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanMinAmountConditions_LoanProductActivityId",
                table: "LoanMinAmountConditions",
                column: "LoanProductActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRateConditions_ClientSegmentId",
                table: "LoanRateConditions",
                column: "ClientSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRateConditions_FinancingSourceId",
                table: "LoanRateConditions",
                column: "FinancingSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRateConditions_ProductId",
                table: "LoanRateConditions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRepaymentFrequencyFee_FinancingSourceId",
                table: "LoanRepaymentFrequencyFee",
                column: "FinancingSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRepaymentFrequencyFee_ProductId",
                table: "LoanRepaymentFrequencyFee",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRepaymentFrequencyFee_RepaymentTypeFeeId",
                table: "LoanRepaymentFrequencyFee",
                column: "RepaymentTypeFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRepaymentFrequencyOD_FinancingSourceId",
                table: "LoanRepaymentFrequencyOD",
                column: "FinancingSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRepaymentFrequencyOD_ProductId",
                table: "LoanRepaymentFrequencyOD",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRepaymentFrequencyOD_RepaymentTypeODId",
                table: "LoanRepaymentFrequencyOD",
                column: "RepaymentTypeODId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanTermConditions_ClientTypeId",
                table: "LoanTermConditions",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanTermConditions_FinancingSourceId",
                table: "LoanTermConditions",
                column: "FinancingSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanTermConditions_ProductId",
                table: "LoanTermConditions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanTermConditions_PurposeId",
                table: "LoanTermConditions",
                column: "PurposeId");
        }
    }
}
