using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Molim.Backend.API.Migrations
{
    public partial class RichiesteEsecuzione_IntegrazioneServiziEsterni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.AlterColumn<DateTime>(
                name: "DataInizioValidita",
                table: "features",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFineValidita",
                table: "features",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
            */

            migrationBuilder.CreateTable(
                name: "esecutoririchieste",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 30, nullable: false),
                    Abilitato = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_esecutoririchieste", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "richiesteesecuzione",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdAlgoritmo = table.Column<int>(nullable: false),
                    IdPaziente = table.Column<string>(maxLength: 50, nullable: false),
                    IdTipoEsame = table.Column<string>(maxLength: 5, nullable: false),
                    IdPatologia = table.Column<string>(maxLength: 5, nullable: false),
                    Parametri = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    IdEsecutore = table.Column<string>(maxLength: 30, nullable: false),
                    Risultato = table.Column<string>(nullable: true),
                    DataCompletamento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_richiesteesecuzione", x => x.ID);
                    table.ForeignKey(
                        name: "FK_richiesteesecuzione_algoritmi_IdAlgoritmo",
                        column: x => x.IdAlgoritmo,
                        principalTable: "algoritmi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_richiesteesecuzione_esecutoririchieste_IdEsecutore",
                        column: x => x.IdEsecutore,
                        principalTable: "esecutoririchieste",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_richiesteesecuzione_pazienti_IdPaziente",
                        column: x => x.IdPaziente,
                        principalTable: "pazienti",
                        principalColumn: "IdPaziente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_richiesteesecuzione_tipi_esami_IdTipoEsame_IdPatologia",
                        columns: x => new { x.IdTipoEsame, x.IdPatologia },
                        principalTable: "tipi_esami",
                        principalColumns: new[] { "IdTipoEsame", "IdPatologia" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "richiestaesecuzionefasi",
                columns: table => new
                {
                    IdRichiestaEsecuzione = table.Column<int>(nullable: false),
                    IdFase = table.Column<string>(maxLength: 100, nullable: false),
                    Ordine = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 250, nullable: true),
                    DataUltimaEsecuzione = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_richiestaesecuzionefasi", x => new { x.IdRichiestaEsecuzione, x.IdFase, x.Ordine });
                    table.ForeignKey(
                        name: "FK_richiestaesecuzionefasi_richiesteesecuzione_IdRichiestaEsecu~",
                        column: x => x.IdRichiestaEsecuzione,
                        principalTable: "richiesteesecuzione",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_features_IdTipoEsame_IdPatologia",
                table: "features",
                columns: new[] { "IdTipoEsame", "IdPatologia" });

            migrationBuilder.CreateIndex(
                name: "IX_richiesteesecuzione_IdAlgoritmo",
                table: "richiesteesecuzione",
                column: "IdAlgoritmo");

            migrationBuilder.CreateIndex(
                name: "IX_richiesteesecuzione_IdEsecutore",
                table: "richiesteesecuzione",
                column: "IdEsecutore");

            migrationBuilder.CreateIndex(
                name: "IX_richiesteesecuzione_IdPaziente",
                table: "richiesteesecuzione",
                column: "IdPaziente");

            migrationBuilder.CreateIndex(
                name: "IX_richiesteesecuzione_IdTipoEsame_IdPatologia",
                table: "richiesteesecuzione",
                columns: new[] { "IdTipoEsame", "IdPatologia" });

            migrationBuilder.AddForeignKey(
                name: "FK_features_tipi_esami_IdTipoEsame_IdPatologia",
                table: "features",
                columns: new[] { "IdTipoEsame", "IdPatologia" },
                principalTable: "tipi_esami",
                principalColumns: new[] { "IdTipoEsame", "IdPatologia" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_features_tipi_esami_IdTipoEsame_IdPatologia",
                table: "features");

            migrationBuilder.DropTable(
                name: "richiestaesecuzionefasi");

            migrationBuilder.DropTable(
                name: "richiesteesecuzione");

            migrationBuilder.DropTable(
                name: "esecutoririchieste");

            migrationBuilder.DropIndex(
                name: "IX_features_IdTipoEsame_IdPatologia",
                table: "features");

            /*
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInizioValidita",
                table: "features",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
            */
            /*
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFineValidita",
                table: "features",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
            */
        }
    }
}
