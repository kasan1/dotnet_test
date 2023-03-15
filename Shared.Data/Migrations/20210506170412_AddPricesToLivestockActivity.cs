using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class AddPricesToLivestockActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AffiliatedCompanieses_ClientDetailses_ClientDetailsId",
                table: "AffiliatedCompanieses");

            migrationBuilder.DropForeignKey(
                name: "FK_AppActiveses_LoanApplications_LoanApplicationId",
                table: "AppActiveses");

            migrationBuilder.DropForeignKey(
                name: "FK_BioActivity_AppActiveses_AppActivesId",
                table: "BioActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCredits_ClientDetailses_ClientDetailsId",
                table: "ClientCredits");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientDetailses_LoanApplications_LoanApplicationId",
                table: "ClientDetailses");

            migrationBuilder.DropForeignKey(
                name: "FK_FloraActivities_AppActiveses_AppActivesId",
                table: "FloraActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_LandActivities_AppActiveses_AppActivesId",
                table: "LandActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_TechActivities_AppActiveses_AppActivesId",
                table: "TechActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechActivities",
                table: "TechActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientDetailses",
                table: "ClientDetailses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppActiveses",
                table: "AppActiveses");

            migrationBuilder.RenameTable(
                name: "TechActivities",
                newName: "TechActivity");

            migrationBuilder.RenameTable(
                name: "ClientDetailses",
                newName: "ClientDetails");

            migrationBuilder.RenameTable(
                name: "AppActiveses",
                newName: "AppActives");

            migrationBuilder.RenameIndex(
                name: "IX_TechActivities_AppActivesId",
                table: "TechActivity",
                newName: "IX_TechActivity_AppActivesId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientDetailses_LoanApplicationId",
                table: "ClientDetails",
                newName: "IX_ClientDetails_LoanApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_AppActiveses_LoanApplicationId",
                table: "AppActives",
                newName: "IX_AppActives_LoanApplicationId");

            migrationBuilder.AddColumn<decimal>(
                name: "LivePrice",
                table: "LivestockActivity",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SlaughterPrice",
                table: "LivestockActivity",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechActivity",
                table: "TechActivity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientDetails",
                table: "ClientDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppActives",
                table: "AppActives",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliatedCompanieses_ClientDetails_ClientDetailsId",
                table: "AffiliatedCompanieses",
                column: "ClientDetailsId",
                principalTable: "ClientDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppActives_LoanApplications_LoanApplicationId",
                table: "AppActives",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BioActivity_AppActives_AppActivesId",
                table: "BioActivity",
                column: "AppActivesId",
                principalTable: "AppActives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCredits_ClientDetails_ClientDetailsId",
                table: "ClientCredits",
                column: "ClientDetailsId",
                principalTable: "ClientDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientDetails_LoanApplications_LoanApplicationId",
                table: "ClientDetails",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FloraActivities_AppActives_AppActivesId",
                table: "FloraActivities",
                column: "AppActivesId",
                principalTable: "AppActives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LandActivities_AppActives_AppActivesId",
                table: "LandActivities",
                column: "AppActivesId",
                principalTable: "AppActives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechActivity_AppActives_AppActivesId",
                table: "TechActivity",
                column: "AppActivesId",
                principalTable: "AppActives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AffiliatedCompanieses_ClientDetails_ClientDetailsId",
                table: "AffiliatedCompanieses");

            migrationBuilder.DropForeignKey(
                name: "FK_AppActives_LoanApplications_LoanApplicationId",
                table: "AppActives");

            migrationBuilder.DropForeignKey(
                name: "FK_BioActivity_AppActives_AppActivesId",
                table: "BioActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCredits_ClientDetails_ClientDetailsId",
                table: "ClientCredits");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientDetails_LoanApplications_LoanApplicationId",
                table: "ClientDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FloraActivities_AppActives_AppActivesId",
                table: "FloraActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_LandActivities_AppActives_AppActivesId",
                table: "LandActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_TechActivity_AppActives_AppActivesId",
                table: "TechActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechActivity",
                table: "TechActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientDetails",
                table: "ClientDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppActives",
                table: "AppActives");

            migrationBuilder.DropColumn(
                name: "LivePrice",
                table: "LivestockActivity");

            migrationBuilder.DropColumn(
                name: "SlaughterPrice",
                table: "LivestockActivity");

            migrationBuilder.RenameTable(
                name: "TechActivity",
                newName: "TechActivities");

            migrationBuilder.RenameTable(
                name: "ClientDetails",
                newName: "ClientDetailses");

            migrationBuilder.RenameTable(
                name: "AppActives",
                newName: "AppActiveses");

            migrationBuilder.RenameIndex(
                name: "IX_TechActivity_AppActivesId",
                table: "TechActivities",
                newName: "IX_TechActivities_AppActivesId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientDetails_LoanApplicationId",
                table: "ClientDetailses",
                newName: "IX_ClientDetailses_LoanApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_AppActives_LoanApplicationId",
                table: "AppActiveses",
                newName: "IX_AppActiveses_LoanApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechActivities",
                table: "TechActivities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientDetailses",
                table: "ClientDetailses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppActiveses",
                table: "AppActiveses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliatedCompanieses_ClientDetailses_ClientDetailsId",
                table: "AffiliatedCompanieses",
                column: "ClientDetailsId",
                principalTable: "ClientDetailses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppActiveses_LoanApplications_LoanApplicationId",
                table: "AppActiveses",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BioActivity_AppActiveses_AppActivesId",
                table: "BioActivity",
                column: "AppActivesId",
                principalTable: "AppActiveses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCredits_ClientDetailses_ClientDetailsId",
                table: "ClientCredits",
                column: "ClientDetailsId",
                principalTable: "ClientDetailses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientDetailses_LoanApplications_LoanApplicationId",
                table: "ClientDetailses",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FloraActivities_AppActiveses_AppActivesId",
                table: "FloraActivities",
                column: "AppActivesId",
                principalTable: "AppActiveses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LandActivities_AppActiveses_AppActivesId",
                table: "LandActivities",
                column: "AppActivesId",
                principalTable: "AppActiveses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechActivities_AppActiveses_AppActivesId",
                table: "TechActivities",
                column: "AppActivesId",
                principalTable: "AppActiveses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
