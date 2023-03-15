using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class PledgeTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "BasePledge");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "BasePledge");

            migrationBuilder.AddColumn<bool>(
                name: "IsObtain",
                table: "BasePledge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DicAgriculturalMachineryPurpose",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicAgriculturalMachineryPurpose", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicCommercialОbjectName",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicCommercialОbjectName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicCommercialОbjectPurpose",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicCommercialОbjectPurpose", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicCommercialОbjectType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicCommercialОbjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicEquipmentPurpose",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicEquipmentPurpose", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicLandPurpose",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicLandPurpose", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicStockType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicStockType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicTransportBodyType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTransportBodyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicTransportFuel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTransportFuel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicTransportSteeringWheel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTransportSteeringWheel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicTransportType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTransportType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicWallMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicWallMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guarantees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    ValidThrough = table.Column<DateTime>(nullable: true),
                    Guarantor = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guarantees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Liter",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ContentLiterRus = table.Column<string>(nullable: true),
                    ContentLiterKz = table.Column<string>(nullable: true),
                    AreaLiter = table.Column<string>(nullable: true),
                    CommentLiter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NameRus = table.Column<string>(nullable: true),
                    NameKaz = table.Column<string>(nullable: true),
                    IssuedYear = table.Column<string>(nullable: true),
                    IssuedBy = table.Column<string>(nullable: true),
                    AdditionalEquipment = table.Column<string>(nullable: true),
                    FactoryNumber = table.Column<string>(nullable: true),
                    InventoryNumber = table.Column<string>(nullable: true),
                    RegAddress = table.Column<string>(nullable: true),
                    DicAgriculturalMachineryPurposeId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Kind = table.Column<string>(nullable: true),
                    Birthdate = table.Column<string>(nullable: true),
                    FactAddress = table.Column<string>(nullable: true),
                    AgeGroup = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    DicEquipmentPurposeId = table.Column<Guid>(nullable: true),
                    EquipmentType = table.Column<string>(nullable: true),
                    ObtainYear = table.Column<string>(nullable: true),
                    ConfirmDoc = table.Column<string>(nullable: true),
                    ConfirmDocNumber = table.Column<string>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    TechPassport = table.Column<string>(nullable: true),
                    QualificationAkt = table.Column<string>(nullable: true),
                    DepositAmount = table.Column<decimal>(nullable: false),
                    DepositCurrency = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    DepositOpen = table.Column<DateTime>(nullable: true),
                    DicStockTypeId = table.Column<Guid>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DocNumber = table.Column<string>(nullable: true),
                    DateIssue = table.Column<DateTime>(nullable: true),
                    AvailabilityRes = table.Column<string>(nullable: true),
                    AvailabilityNoRes = table.Column<string>(nullable: true),
                    VPNumber = table.Column<string>(nullable: true),
                    RegNumber = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    DicTransportTypeId = table.Column<Guid>(nullable: true),
                    DicTransportBodyTypeId = table.Column<Guid>(nullable: true),
                    BodyNumber = table.Column<string>(nullable: true),
                    EngineNumber = table.Column<string>(nullable: true),
                    ChassisNumber = table.Column<string>(nullable: true),
                    DicTransportFuelId = table.Column<Guid>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    RegYear = table.Column<string>(nullable: true),
                    ImporterCountry = table.Column<string>(nullable: true),
                    VINNumber = table.Column<string>(nullable: true),
                    DicTransportSteeringWheelId = table.Column<Guid>(nullable: true),
                    TechnicalPassportIssuedDate = table.Column<DateTime>(nullable: true),
                    TechnicalPassportNumber = table.Column<string>(nullable: true),
                    NOKPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movables_DicAgriculturalMachineryPurpose_DicAgriculturalMachineryPurposeId",
                        column: x => x.DicAgriculturalMachineryPurposeId,
                        principalTable: "DicAgriculturalMachineryPurpose",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movables_DicEquipmentPurpose_DicEquipmentPurposeId",
                        column: x => x.DicEquipmentPurposeId,
                        principalTable: "DicEquipmentPurpose",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movables_DicStockType_DicStockTypeId",
                        column: x => x.DicStockTypeId,
                        principalTable: "DicStockType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movables_DicTransportBodyType_DicTransportBodyTypeId",
                        column: x => x.DicTransportBodyTypeId,
                        principalTable: "DicTransportBodyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movables_DicTransportFuel_DicTransportFuelId",
                        column: x => x.DicTransportFuelId,
                        principalTable: "DicTransportFuel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movables_DicTransportSteeringWheel_DicTransportSteeringWheelId",
                        column: x => x.DicTransportSteeringWheelId,
                        principalTable: "DicTransportSteeringWheel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movables_DicTransportType_DicTransportTypeId",
                        column: x => x.DicTransportTypeId,
                        principalTable: "DicTransportType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nonmovables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CadastralNumber = table.Column<string>(nullable: true),
                    WallMaterialId = table.Column<Guid>(nullable: true),
                    RoomCount = table.Column<int>(nullable: false),
                    TotalArea = table.Column<double>(nullable: false),
                    LivingArea = table.Column<double>(nullable: false),
                    FloorNumber = table.Column<double>(nullable: false),
                    FloorCount = table.Column<double>(nullable: false),
                    BuiltYear = table.Column<string>(nullable: true),
                    LandArea = table.Column<string>(nullable: true),
                    LiterId = table.Column<Guid>(nullable: true),
                    DicLandPurposeId = table.Column<Guid>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    DicСommercialОbjectTypeId = table.Column<Guid>(nullable: true),
                    DicСommercialОbjectNameId = table.Column<Guid>(nullable: true),
                    DicСommercialОbjectPurposeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nonmovables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nonmovables_DicLandPurpose_DicLandPurposeId",
                        column: x => x.DicLandPurposeId,
                        principalTable: "DicLandPurpose",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nonmovables_DicCommercialОbjectName_DicСommercialОbjectNameId",
                        column: x => x.DicСommercialОbjectNameId,
                        principalTable: "DicCommercialОbjectName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nonmovables_DicCommercialОbjectPurpose_DicСommercialОbjectPurposeId",
                        column: x => x.DicСommercialОbjectPurposeId,
                        principalTable: "DicCommercialОbjectPurpose",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nonmovables_DicCommercialОbjectType_DicСommercialОbjectTypeId",
                        column: x => x.DicСommercialОbjectTypeId,
                        principalTable: "DicCommercialОbjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nonmovables_Liter_LiterId",
                        column: x => x.LiterId,
                        principalTable: "Liter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nonmovables_Chargees_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Chargees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nonmovables_DicWallMaterial_WallMaterialId",
                        column: x => x.WallMaterialId,
                        principalTable: "DicWallMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicAgriculturalMachineryPurposeId",
                table: "Movables",
                column: "DicAgriculturalMachineryPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicEquipmentPurposeId",
                table: "Movables",
                column: "DicEquipmentPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicStockTypeId",
                table: "Movables",
                column: "DicStockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicTransportBodyTypeId",
                table: "Movables",
                column: "DicTransportBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicTransportFuelId",
                table: "Movables",
                column: "DicTransportFuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicTransportSteeringWheelId",
                table: "Movables",
                column: "DicTransportSteeringWheelId");

            migrationBuilder.CreateIndex(
                name: "IX_Movables_DicTransportTypeId",
                table: "Movables",
                column: "DicTransportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_DicLandPurposeId",
                table: "Nonmovables",
                column: "DicLandPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_DicСommercialОbjectNameId",
                table: "Nonmovables",
                column: "DicСommercialОbjectNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_DicСommercialОbjectPurposeId",
                table: "Nonmovables",
                column: "DicСommercialОbjectPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_DicСommercialОbjectTypeId",
                table: "Nonmovables",
                column: "DicСommercialОbjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_LiterId",
                table: "Nonmovables",
                column: "LiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_OwnerId",
                table: "Nonmovables",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Nonmovables_WallMaterialId",
                table: "Nonmovables",
                column: "WallMaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guarantees");

            migrationBuilder.DropTable(
                name: "Movables");

            migrationBuilder.DropTable(
                name: "Nonmovables");

            migrationBuilder.DropTable(
                name: "DicAgriculturalMachineryPurpose");

            migrationBuilder.DropTable(
                name: "DicEquipmentPurpose");

            migrationBuilder.DropTable(
                name: "DicStockType");

            migrationBuilder.DropTable(
                name: "DicTransportBodyType");

            migrationBuilder.DropTable(
                name: "DicTransportFuel");

            migrationBuilder.DropTable(
                name: "DicTransportSteeringWheel");

            migrationBuilder.DropTable(
                name: "DicTransportType");

            migrationBuilder.DropTable(
                name: "DicLandPurpose");

            migrationBuilder.DropTable(
                name: "DicCommercialОbjectName");

            migrationBuilder.DropTable(
                name: "DicCommercialОbjectPurpose");

            migrationBuilder.DropTable(
                name: "DicCommercialОbjectType");

            migrationBuilder.DropTable(
                name: "Liter");

            migrationBuilder.DropTable(
                name: "DicWallMaterial");

            migrationBuilder.DropColumn(
                name: "IsObtain",
                table: "BasePledge");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "BasePledge",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "BasePledge",
                type: "datetime2",
                nullable: true);
        }
    }
}
