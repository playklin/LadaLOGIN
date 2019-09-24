using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LadaLOGIN.Data.Migrations
{
    public partial class AddSpisok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spisoks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RepairTime = table.Column<DateTime>(nullable: false),
                    data1 = table.Column<string>(nullable: true),
                    WorkTotal = table.Column<string>(nullable: true),
                    PriceTotal = table.Column<int>(nullable: false),
                    Spare = table.Column<string>(nullable: true),
                    SparePrice = table.Column<int>(nullable: false),
                    Spare1 = table.Column<string>(nullable: true),
                    SparePrice1 = table.Column<int>(nullable: false),
                    Spare2 = table.Column<string>(nullable: true),
                    SparePrice2 = table.Column<int>(nullable: false),
                    Work = table.Column<string>(nullable: true),
                    WorkPrice = table.Column<int>(nullable: false),
                    Img1 = table.Column<string>(nullable: true),
                    Img2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spisoks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spisoks");
        }
    }
}
