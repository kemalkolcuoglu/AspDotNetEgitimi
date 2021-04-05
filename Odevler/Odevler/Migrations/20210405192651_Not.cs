using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Odevler.Migrations
{
    public partial class Not : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Not",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detay = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Oncelik = table.Column<int>(type: "int", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Not", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Not");
        }
    }
}
