using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class RemoveMovableNonmovableGaranteeLiterAgreements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "Guarantees");

            migrationBuilder.DropTable(
                name: "Liters");

            migrationBuilder.DropTable(
                name: "Movables");

            migrationBuilder.DropTable(
                name: "Nonmovables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgreementType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SignedXml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agreements_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guarantees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuaranteeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidFor = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guarantees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bvu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepositDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepositNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DepositTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GovNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisterNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransportCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Vin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Year = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nonmovables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    AtsId = table.Column<long>(type: "bigint", nullable: true),
                    BuiltYear = table.Column<short>(type: "smallint", nullable: true),
                    CadastralNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cato = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CommercialName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeonimId = table.Column<long>(type: "bigint", nullable: true),
                    HasLiters = table.Column<bool>(type: "bit", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LandArea = table.Column<float>(type: "real", nullable: true),
                    LandPurpose = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Level1 = table.Column<long>(type: "bigint", nullable: true),
                    Level2 = table.Column<long>(type: "bigint", nullable: true),
                    Level3 = table.Column<long>(type: "bigint", nullable: true),
                    Level4 = table.Column<long>(type: "bigint", nullable: true),
                    Level5 = table.Column<long>(type: "bigint", nullable: true),
                    LivingArea = table.Column<float>(type: "real", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rent = table.Column<short>(type: "smallint", nullable: true),
                    RentedFor = table.Column<short>(type: "smallint", nullable: true),
                    RoomNumber = table.Column<int>(type: "int", nullable: true),
                    TotalArea = table.Column<float>(type: "real", nullable: true),
                    WallMaterial = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nonmovables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Liters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Area = table.Column<float>(type: "real", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NonmovableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Liters_Nonmovables_NonmovableId",
                        column: x => x.NonmovableId,
                        principalTable: "Nonmovables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_LoanApplicationId",
                table: "Agreements",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Liters_NonmovableId",
                table: "Liters",
                column: "NonmovableId");
        }
    }
}
