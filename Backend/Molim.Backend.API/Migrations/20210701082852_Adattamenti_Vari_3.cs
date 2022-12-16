using Microsoft.EntityFrameworkCore.Migrations;

namespace Molim.Backend.API.Migrations
{
    public partial class Adattamenti_Vari_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EsitoPredizione",
                table: "diagnosi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsitoPredizione",
                table: "diagnosi");
        }
    }
}
