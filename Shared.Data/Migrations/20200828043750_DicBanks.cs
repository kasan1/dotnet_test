﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agro.Shared.Data.Migrations
{
    public partial class DicBanks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DicBanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    PaymentSystemCode = table.Column<string>(nullable: true),
                    BIK = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicBanks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DicBanks");
        }
    }
}
