using Microsoft.EntityFrameworkCore.Migrations;

namespace Molim.Backend.API.Migrations
{
    public partial class IntegrazioneServizi_051021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_richiesteesecuzione_tipi_esami_IdTipoEsame_IdPatologia",
                table: "richiesteesecuzione");

            migrationBuilder.DropIndex(
                name: "IX_richiesteesecuzione_IdTipoEsame_IdPatologia",
                table: "richiesteesecuzione");

            migrationBuilder.DropColumn(
                name: "IdTipoEsame",
                table: "richiesteesecuzione");

            migrationBuilder.AddColumn<int>(
                name: "IdImmagine",
                table: "richiesteesecuzione",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdRegioneDiInteresse",
                table: "richiesteesecuzione",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_richiesteesecuzione_IdImmagine",
                table: "richiesteesecuzione",
                column: "IdImmagine");

            migrationBuilder.CreateIndex(
                name: "IX_richiesteesecuzione_IdRegioneDiInteresse",
                table: "richiesteesecuzione",
                column: "IdRegioneDiInteresse");

            migrationBuilder.AddForeignKey(
                name: "FK_richiesteesecuzione_immagini_IdImmagine",
                table: "richiesteesecuzione",
                column: "IdImmagine",
                principalTable: "immagini",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_richiesteesecuzione_regioni_di_interesse_IdRegioneDiInteresse",
                table: "richiesteesecuzione",
                column: "IdRegioneDiInteresse",
                principalTable: "regioni_di_interesse",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_richiesteesecuzione_immagini_IdImmagine",
                table: "richiesteesecuzione");

            migrationBuilder.DropForeignKey(
                name: "FK_richiesteesecuzione_regioni_di_interesse_IdRegioneDiInteresse",
                table: "richiesteesecuzione");

            migrationBuilder.DropIndex(
                name: "IX_richiesteesecuzione_IdImmagine",
                table: "richiesteesecuzione");

            migrationBuilder.DropIndex(
                name: "IX_richiesteesecuzione_IdRegioneDiInteresse",
                table: "richiesteesecuzione");

            migrationBuilder.DropColumn(
                name: "IdImmagine",
                table: "richiesteesecuzione");

            migrationBuilder.DropColumn(
                name: "IdRegioneDiInteresse",
                table: "richiesteesecuzione");

            migrationBuilder.AddColumn<string>(
                name: "IdTipoEsame",
                table: "richiesteesecuzione",
                type: "varchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_richiesteesecuzione_IdTipoEsame_IdPatologia",
                table: "richiesteesecuzione",
                columns: new[] { "IdTipoEsame", "IdPatologia" });

            migrationBuilder.AddForeignKey(
                name: "FK_richiesteesecuzione_tipi_esami_IdTipoEsame_IdPatologia",
                table: "richiesteesecuzione",
                columns: new[] { "IdTipoEsame", "IdPatologia" },
                principalTable: "tipi_esami",
                principalColumns: new[] { "IdTipoEsame", "IdPatologia" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
