using Microsoft.EntityFrameworkCore.Migrations;

namespace IcerikYonetimSistemi.Data.Migrations
{
    public partial class GuncellenmisEtiketIcerikIliskisi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtiketIcerik_Etiket_EtiketlerID",
                table: "EtiketIcerik");

            migrationBuilder.DropForeignKey(
                name: "FK_EtiketIcerik_Icerik_IceriklerID",
                table: "EtiketIcerik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EtiketIcerik",
                table: "EtiketIcerik");

            migrationBuilder.DropIndex(
                name: "IX_EtiketIcerik_IceriklerID",
                table: "EtiketIcerik");

            migrationBuilder.RenameColumn(
                name: "IceriklerID",
                table: "EtiketIcerik",
                newName: "IcerikID");

            migrationBuilder.RenameColumn(
                name: "EtiketlerID",
                table: "EtiketIcerik",
                newName: "EtiketID");

            migrationBuilder.AddColumn<int>(
                name: "EtiketIcerikID",
                table: "Icerik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "EtiketIcerik",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EtiketIcerikID",
                table: "Etiket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EtiketIcerik",
                table: "EtiketIcerik",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Icerik_EtiketIcerikID",
                table: "Icerik",
                column: "EtiketIcerikID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Etiket_EtiketIcerikID",
                table: "Etiket",
                column: "EtiketIcerikID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Etiket_EtiketIcerik_EtiketIcerikID",
                table: "Etiket",
                column: "EtiketIcerikID",
                principalTable: "EtiketIcerik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Icerik_EtiketIcerik_EtiketIcerikID",
                table: "Icerik",
                column: "EtiketIcerikID",
                principalTable: "EtiketIcerik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etiket_EtiketIcerik_EtiketIcerikID",
                table: "Etiket");

            migrationBuilder.DropForeignKey(
                name: "FK_Icerik_EtiketIcerik_EtiketIcerikID",
                table: "Icerik");

            migrationBuilder.DropIndex(
                name: "IX_Icerik_EtiketIcerikID",
                table: "Icerik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EtiketIcerik",
                table: "EtiketIcerik");

            migrationBuilder.DropIndex(
                name: "IX_Etiket_EtiketIcerikID",
                table: "Etiket");

            migrationBuilder.DropColumn(
                name: "EtiketIcerikID",
                table: "Icerik");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "EtiketIcerik");

            migrationBuilder.DropColumn(
                name: "EtiketIcerikID",
                table: "Etiket");

            migrationBuilder.RenameColumn(
                name: "IcerikID",
                table: "EtiketIcerik",
                newName: "IceriklerID");

            migrationBuilder.RenameColumn(
                name: "EtiketID",
                table: "EtiketIcerik",
                newName: "EtiketlerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EtiketIcerik",
                table: "EtiketIcerik",
                columns: new[] { "EtiketlerID", "IceriklerID" });

            migrationBuilder.CreateIndex(
                name: "IX_EtiketIcerik_IceriklerID",
                table: "EtiketIcerik",
                column: "IceriklerID");

            migrationBuilder.AddForeignKey(
                name: "FK_EtiketIcerik_Etiket_EtiketlerID",
                table: "EtiketIcerik",
                column: "EtiketlerID",
                principalTable: "Etiket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EtiketIcerik_Icerik_IceriklerID",
                table: "EtiketIcerik",
                column: "IceriklerID",
                principalTable: "Icerik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
