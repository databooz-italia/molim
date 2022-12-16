using Microsoft.EntityFrameworkCore.Migrations;

namespace Molim.Backend.API.Migrations
{
    public partial class Adattamenti_Vari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.AddColumn<long>(
                name: "Dimensione",
                table: "immagini",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "IdImmagine",
                table: "features_esame",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_features_esame_IdImmagine",
                table: "features_esame",
                column: "IdImmagine");

            migrationBuilder.CreateIndex(
                name: "IX_esami_IdTipoEsame_IdPatologia",
                table: "esami",
                columns: new[] { "IdTipoEsame", "IdPatologia" });            

            migrationBuilder.AddForeignKey(
                name: "FK_esami_tipi_esami_IdTipoEsame_IdPatologia",
                table: "esami",
                columns: new[] { "IdTipoEsame", "IdPatologia" },
                principalTable: "tipi_esami",
                principalColumns: new[] { "IdTipoEsame", "IdPatologia" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_features_esame_immagini_IdImmagine",
                table: "features_esame",
                column: "IdImmagine",
                principalTable: "immagini",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_esami_tipi_esami_IdTipoEsame_IdPatologia",
                table: "esami");

            migrationBuilder.DropForeignKey(
                name: "FK_features_esame_immagini_IdImmagine",
                table: "features_esame");

            migrationBuilder.DropIndex(
                name: "IX_features_esame_IdImmagine",
                table: "features_esame");

            migrationBuilder.DropIndex(
                name: "IX_esami_IdTipoEsame_IdPatologia",
                table: "esami");

            migrationBuilder.DropColumn(
                name: "Dimensione",
                table: "immagini");

            migrationBuilder.DropColumn(
                name: "IdImmagine",
                table: "features_esame");
        }
    }
}
