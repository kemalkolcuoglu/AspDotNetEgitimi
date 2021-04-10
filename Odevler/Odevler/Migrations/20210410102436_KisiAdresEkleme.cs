using Microsoft.EntityFrameworkCore.Migrations;

namespace Odevler.Migrations
{
    public partial class KisiAdresEkleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kisi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlKodu = table.Column<int>(type: "int", nullable: false),
                    AcikAdres = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    KisiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adres_Kisi_KisiID",
                        column: x => x.KisiID,
                        principalTable: "Kisi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adres_KisiID",
                table: "Adres",
                column: "KisiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Kisi");
        }
    }
}
