using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleRentACarProject.DAL.Migrations
{
    public partial class AddIdKeyOnMusteriArac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MusteriAraclar",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusteriAraclar",
                table: "MusteriAraclar",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MusteriAraclar",
                table: "MusteriAraclar");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MusteriAraclar");
        }
    }
}
