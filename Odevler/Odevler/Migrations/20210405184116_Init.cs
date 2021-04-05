using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Odevler.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Yazar = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");
        }
    }
}
