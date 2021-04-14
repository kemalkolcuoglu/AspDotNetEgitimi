using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IcerikYonetimSistemi.Data.Migrations
{
    public partial class KendiModellerimiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etiket",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiket", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EPosta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Detay = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gorsel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Yol = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Etkin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorsel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ikon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    EkAlan = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    AcilirMenuMu = table.Column<bool>(type: "bit", nullable: false),
                    Etkin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sayfa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    SEOTitle = table.Column<string>(type: "nvarchar(126)", maxLength: 126, nullable: false),
                    SEODescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EkAlan = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Etkin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sayfa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sayfa_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Icerik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SayfaID = table.Column<int>(type: "int", nullable: false),
                    Detay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gorsel = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SEOTitle = table.Column<string>(type: "nvarchar(126)", maxLength: 126, nullable: false),
                    SEODescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EkAlan = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Etkin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icerik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Icerik_Sayfa_SayfaID",
                        column: x => x.SayfaID,
                        principalTable: "Sayfa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtiketIcerik",
                columns: table => new
                {
                    EtiketlerID = table.Column<int>(type: "int", nullable: false),
                    IceriklerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiketIcerik", x => new { x.EtiketlerID, x.IceriklerID });
                    table.ForeignKey(
                        name: "FK_EtiketIcerik_Etiket_EtiketlerID",
                        column: x => x.EtiketlerID,
                        principalTable: "Etiket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtiketIcerik_Icerik_IceriklerID",
                        column: x => x.IceriklerID,
                        principalTable: "Icerik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtiketIcerik_IceriklerID",
                table: "EtiketIcerik",
                column: "IceriklerID");

            migrationBuilder.CreateIndex(
                name: "IX_Icerik_SayfaID",
                table: "Icerik",
                column: "SayfaID");

            migrationBuilder.CreateIndex(
                name: "IX_Sayfa_MenuID",
                table: "Sayfa",
                column: "MenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtiketIcerik");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "Gorsel");

            migrationBuilder.DropTable(
                name: "Etiket");

            migrationBuilder.DropTable(
                name: "Icerik");

            migrationBuilder.DropTable(
                name: "Sayfa");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
