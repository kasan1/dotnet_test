using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddSortToDics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "RoleControlsFields");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "RoleControlsButtons");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "RoleControls");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicWarningClassifications");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicWallMaterial");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicVerificationStatuses");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicTransportType");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicTransportSteeringWheel");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicTransportFuel");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicTransportBodyType");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicTechTypes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicTechProducts");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicTechModels");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicTaskStatuses");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicStockType");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicRegions");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicProviders");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicProducts");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicPledgeTypes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicNoks");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicLoanTypes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicLoanRepaymentTypes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicLoanPurposes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicLoanProducts");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicLoanHistoryStatuses");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicLoanFinancingSources");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicLandPurpose");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicKato");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicGuaranteeType");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicFirstDocTypes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicFileTypes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicEquipmentPurpose");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicDocumentTypes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicDocClassifications");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicDecisions");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicCountries");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicCommercialОbjectType");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicCommercialОbjectPurpose");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicCommercialОbjectName");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicClientTypes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicClientSegmentes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicClientLocationTypes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicClientCategories");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicClassificationSubtitles");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicBanks");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicAgriculturalMachineryPurpose");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicAffiliationTypes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicActivityTypes");

            migrationBuilder.DropColumn(
                name: "NameKz",
                table: "DicAccessorieses");

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "RoleControlsFields",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "RoleControlsFields",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "RoleControlsButtons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "RoleControlsButtons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "RoleControls",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "RoleControls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicWarningClassifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicWarningClassifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicWallMaterial",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicWallMaterial",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicVerificationStatuses",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicVerificationStatuses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicTransportType",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicTransportType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicTransportSteeringWheel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicTransportSteeringWheel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicTransportFuel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicTransportFuel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicTransportBodyType",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicTransportBodyType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicTechTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicTechTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicTechProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicTechProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicTechModels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicTechModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicTaskStatuses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicTaskStatuses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicStockType",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicStockType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicRegions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicRegions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicProviders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicProviders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicPledgeTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicPledgeTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicNoks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicNoks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicLoanTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicLoanTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicLoanRepaymentTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicLoanRepaymentTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicLoanPurposes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicLoanPurposes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicLoanProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicLoanProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicLoanHistoryStatuses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicLoanHistoryStatuses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicLoanFinancingSources",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicLoanFinancingSources",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicLandPurpose",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicLandPurpose",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicKato",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicKato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicGuaranteeType",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicGuaranteeType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicFirstDocTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicFirstDocTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicFileTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicFileTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicEquipmentPurpose",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicEquipmentPurpose",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicDocumentTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicDocumentTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicDocClassifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicDocClassifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicDecisions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicDecisions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicCountries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicCountries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicCommercialОbjectType",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicCommercialОbjectType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicCommercialОbjectPurpose",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicCommercialОbjectPurpose",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicCommercialОbjectName",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicCommercialОbjectName",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicClientTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicClientTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicClientSegmentes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicClientSegmentes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicClientLocationTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicClientLocationTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicClientCategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicClientCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicClassificationSubtitles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicClassificationSubtitles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicBanks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicBanks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicAgriculturalMachineryPurpose",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicAgriculturalMachineryPurpose",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicAffiliationTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicAffiliationTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicActivityTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicActivityTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "DicAccessorieses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "DicAccessorieses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DicVerificationStatuses",
                keyColumn: "Id",
                keyValue: new Guid("5c792135-6524-4a12-bf48-dea59580f552"),
                column: "NameKk",
                value: "Тексеруден өтті");

            migrationBuilder.UpdateData(
                table: "DicVerificationStatuses",
                keyColumn: "Id",
                keyValue: new Guid("9147caff-1fd0-4fb2-9216-1d4d354cd9a0"),
                column: "NameKk",
                value: "Қызмет қол жетімді емес");

            migrationBuilder.UpdateData(
                table: "DicVerificationStatuses",
                keyColumn: "Id",
                keyValue: new Guid("9be3e547-c44e-418e-a9c7-6acfba833f71"),
                column: "NameKk",
                value: "Жөнделетін");

            migrationBuilder.UpdateData(
                table: "DicVerificationStatuses",
                keyColumn: "Id",
                keyValue: new Guid("c60a9da0-816b-46e6-84a1-a3d4188a1e4a"),
                column: "NameKk",
                value: "Жөнделмейтін");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "RoleControlsFields");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "RoleControlsFields");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "RoleControlsButtons");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "RoleControlsButtons");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "RoleControls");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "RoleControls");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicWarningClassifications");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicWarningClassifications");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicWallMaterial");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicWallMaterial");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicVerificationStatuses");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicVerificationStatuses");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicTransportType");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicTransportType");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicTransportSteeringWheel");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicTransportSteeringWheel");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicTransportFuel");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicTransportFuel");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicTransportBodyType");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicTransportBodyType");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicTechTypes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicTechTypes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicTechProducts");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicTechProducts");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicTechModels");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicTechModels");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicTaskStatuses");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicTaskStatuses");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicStockType");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicStockType");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicRegions");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicRegions");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicProviders");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicProviders");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicProducts");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicProducts");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicPledgeTypes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicPledgeTypes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicNoks");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicNoks");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicLoanTypes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicLoanTypes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicLoanRepaymentTypes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicLoanRepaymentTypes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicLoanPurposes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicLoanPurposes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicLoanProducts");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicLoanProducts");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicLoanHistoryStatuses");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicLoanHistoryStatuses");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicLoanFinancingSources");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicLoanFinancingSources");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicLandPurpose");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicLandPurpose");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicKato");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicKato");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicGuaranteeType");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicGuaranteeType");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicFirstDocTypes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicFirstDocTypes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicFileTypes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicFileTypes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicEquipmentPurpose");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicEquipmentPurpose");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicDocumentTypes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicDocumentTypes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicDocClassifications");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicDocClassifications");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicDecisions");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicDecisions");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicCountries");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicCountries");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicCommercialОbjectType");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicCommercialОbjectType");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicCommercialОbjectPurpose");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicCommercialОbjectPurpose");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicCommercialОbjectName");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicCommercialОbjectName");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicClientTypes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicClientTypes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicClientSegmentes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicClientSegmentes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicClientLocationTypes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicClientLocationTypes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicClientCategories");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicClientCategories");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicClassificationSubtitles");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicClassificationSubtitles");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicBanks");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicBanks");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicAgriculturalMachineryPurpose");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicAgriculturalMachineryPurpose");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicAffiliationTypes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicAffiliationTypes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicActivityTypes");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicActivityTypes");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "DicAccessorieses");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "DicAccessorieses");

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "RoleControlsFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "RoleControlsButtons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "RoleControls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicWarningClassifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicWallMaterial",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicVerificationStatuses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicTransportType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicTransportSteeringWheel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicTransportFuel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicTransportBodyType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicTechTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicTechProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicTechModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicTaskStatuses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicStockType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicRegions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicProviders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicPledgeTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicNoks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicLoanTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicLoanRepaymentTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicLoanPurposes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicLoanProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicLoanHistoryStatuses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicLoanFinancingSources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicLandPurpose",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicKato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicGuaranteeType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicFirstDocTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicFileTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicEquipmentPurpose",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicDocumentTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicDocClassifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicDecisions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicCountries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicCommercialОbjectType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicCommercialОbjectPurpose",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicCommercialОbjectName",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicClientTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicClientSegmentes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicClientLocationTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicClientCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicClassificationSubtitles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicBanks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicAgriculturalMachineryPurpose",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicAffiliationTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicActivityTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKz",
                table: "DicAccessorieses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DicVerificationStatuses",
                keyColumn: "Id",
                keyValue: new Guid("5c792135-6524-4a12-bf48-dea59580f552"),
                column: "NameKz",
                value: "Тексеруден өтті");

            migrationBuilder.UpdateData(
                table: "DicVerificationStatuses",
                keyColumn: "Id",
                keyValue: new Guid("9147caff-1fd0-4fb2-9216-1d4d354cd9a0"),
                column: "NameKz",
                value: "Қызмет қол жетімді емес");

            migrationBuilder.UpdateData(
                table: "DicVerificationStatuses",
                keyColumn: "Id",
                keyValue: new Guid("9be3e547-c44e-418e-a9c7-6acfba833f71"),
                column: "NameKz",
                value: "Жөнделетін");

            migrationBuilder.UpdateData(
                table: "DicVerificationStatuses",
                keyColumn: "Id",
                keyValue: new Guid("c60a9da0-816b-46e6-84a1-a3d4188a1e4a"),
                column: "NameKz",
                value: "Жөнделмейтін");
        }
    }
}
