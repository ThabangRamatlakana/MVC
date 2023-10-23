using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disasters",
                columns: table => new
                {
                    disasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    disasterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    disasterDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aidType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disasters", x => x.disasterId);
                });

            migrationBuilder.CreateTable(
                name: "goodDonation",
                columns: table => new
                {
                    goodsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    donationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    goodsCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numberOfItems = table.Column<int>(type: "int", nullable: false),
                    goodsDescription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goodDonation", x => x.goodsId);
                });

            migrationBuilder.CreateTable(
                name: "monetaryGoods",
                columns: table => new
                {
                    moneyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    donationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    moneyAmount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monetaryGoods", x => x.moneyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disasters");

            migrationBuilder.DropTable(
                name: "goodDonation");

            migrationBuilder.DropTable(
                name: "monetaryGoods");
        }
    }
}
