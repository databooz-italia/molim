using Microsoft.EntityFrameworkCore.Migrations;

namespace Molim.Backend.API.Migrations
{
    public partial class Adattamenti_Vari_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_diagnosi_esami1",
                table: "diagnosi");

            migrationBuilder.DropForeignKey(
                name: "fk_diagnosi_regioni_di_interesse1",
                table: "diagnosi");

            migrationBuilder.DropIndex(
                name: "fk_diagnosi_esami1_idx",
                table: "diagnosi");

            migrationBuilder.DropIndex(
                name: "fk_diagnosi_regioni_di_interesse1_idx",
                table: "diagnosi");

            migrationBuilder.DropColumn(
                name: "IdEsame",
                table: "diagnosi");

            migrationBuilder.DropColumn(
                name: "IdRegioneDiInteresse",
                table: "diagnosi");

            migrationBuilder.AddColumn<string>(
                name: "IdPatologia",
                table: "diagnosi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdPaziente",
                table: "diagnosi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "fk_diagnosi_patologie1_idx",
                table: "diagnosi",
                column: "IdPatologia");

            migrationBuilder.CreateIndex(
                name: "IX_diagnosi_IdPaziente",
                table: "diagnosi",
                column: "IdPaziente");

            migrationBuilder.AddForeignKey(
                name: "fk_diagnosi_patologie1",
                table: "diagnosi",
                column: "IdPatologia",
                principalTable: "patologie",
                principalColumn: "IdPatologia",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_diagnosi_pazienti1",
                table: "diagnosi",
                column: "IdPaziente",
                principalTable: "pazienti",
                principalColumn: "IdPaziente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_diagnosi_patologie1",
                table: "diagnosi");

            migrationBuilder.DropForeignKey(
                name: "fk_diagnosi_pazienti1",
                table: "diagnosi");

            migrationBuilder.DropIndex(
                name: "fk_diagnosi_patologie1_idx",
                table: "diagnosi");

            migrationBuilder.DropIndex(
                name: "IX_diagnosi_IdPaziente",
                table: "diagnosi");

            migrationBuilder.DropColumn(
                name: "IdPatologia",
                table: "diagnosi");

            migrationBuilder.DropColumn(
                name: "IdPaziente",
                table: "diagnosi");

            migrationBuilder.AddColumn<int>(
                name: "IdEsame",
                table: "diagnosi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdRegioneDiInteresse",
                table: "diagnosi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "fk_diagnosi_esami1_idx",
                table: "diagnosi",
                column: "IdEsame");

            migrationBuilder.CreateIndex(
                name: "fk_diagnosi_regioni_di_interesse1_idx",
                table: "diagnosi",
                column: "IdRegioneDiInteresse");

            migrationBuilder.AddForeignKey(
                name: "fk_diagnosi_esami1",
                table: "diagnosi",
                column: "IdEsame",
                principalTable: "esami",
                principalColumn: "IdEsame",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_diagnosi_regioni_di_interesse1",
                table: "diagnosi",
                column: "IdRegioneDiInteresse",
                principalTable: "regioni_di_interesse",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
