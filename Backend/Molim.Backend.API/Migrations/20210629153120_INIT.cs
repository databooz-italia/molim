using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Molim.Backend.API.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.CreateTable(
                name: "patologie",
                columns: table => new
                {
                    IdPatologia = table.Column<string>(maxLength: 5, nullable: false),
                    Descrizione = table.Column<string>(maxLength: 100, nullable: false),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdPatologia);
                });

            migrationBuilder.CreateTable(
                name: "pazienti",
                columns: table => new
                {
                    IdPaziente = table.Column<string>(maxLength: 50, nullable: false),
                    NomePaziente = table.Column<string>(maxLength: 20, nullable: true),
                    CognomePaziente = table.Column<string>(maxLength: 20, nullable: true),
                    AnnoNascita = table.Column<int>(nullable: true),
                    Sesso = table.Column<string>(maxLength: 10, nullable: true),
                    City = table.Column<string>(maxLength: 500, nullable: true),
                    CodiceFiscale = table.Column<string>(maxLength: 20, nullable: true),
                    Indirizzo = table.Column<string>(maxLength: 500, nullable: true),
                    IndirizzoMail = table.Column<string>(maxLength: 500, nullable: true),
                    NumeroCellulare = table.Column<string>(maxLength: 20, nullable: true),
                    Education = table.Column<int>(nullable: true),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdPaziente);
                });

            migrationBuilder.CreateTable(
                name: "profili",
                columns: table => new
                {
                    Tipo = table.Column<string>(maxLength: 20, nullable: false),
                    Descrizione = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Tipo);
                });

            migrationBuilder.CreateTable(
                name: "stili_di_vita",
                columns: table => new
                {
                    IdStileDiVita = table.Column<string>(maxLength: 5, nullable: false),
                    Descrizione = table.Column<string>(maxLength: 100, nullable: false),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdStileDiVita);
                });

            migrationBuilder.CreateTable(
                name: "features",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdFeature = table.Column<string>(maxLength: 50, nullable: false),
                    IdPatologia = table.Column<string>(maxLength: 5, nullable: false),
                    TipoValore = table.Column<int>(nullable: false),
                    IdTipoEsame = table.Column<string>(maxLength: 5, nullable: false),
                    Descrizione = table.Column<string>(maxLength: 100, nullable: false),
                    ValoreMin = table.Column<int>(nullable: true),
                    ValoreMax = table.Column<int>(nullable: true),
                    Regex = table.Column<string>(nullable: true),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    DataFineValidita = table.Column<DateTime>(nullable: false),
                    DataInizioValidita = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_features", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgettiTest_Progetti_IdProgetto",
                        column: x => x.IdPatologia,
                        principalTable: "patologie",
                        principalColumn: "IdPatologia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tipi_esami",
                columns: table => new
                {
                    IdTipoEsame = table.Column<string>(maxLength: 5, nullable: false),
                    IdPatologia = table.Column<string>(maxLength: 5, nullable: false),
                    Descrizione = table.Column<string>(maxLength: 100, nullable: false),
                    RichiedeImmagini = table.Column<bool>(type: "bit(1)", nullable: false),
                    RichiedeFeatures = table.Column<bool>(type: "bit(1)", nullable: false),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.IdTipoEsame, x.IdPatologia });
                    table.ForeignKey(
                        name: "fk_tipi_esami_patologie1",
                        column: x => x.IdPatologia,
                        principalTable: "patologie",
                        principalColumn: "IdPatologia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "esami",
                columns: table => new
                {
                    IdEsame = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdPaziente = table.Column<string>(maxLength: 50, nullable: false),
                    IdPatologia = table.Column<string>(maxLength: 5, nullable: false),
                    IdTipoEsame = table.Column<string>(maxLength: 5, nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdEsame);
                    table.ForeignKey(
                        name: "fk_patologia_esami",
                        column: x => x.IdPatologia,
                        principalTable: "patologie",
                        principalColumn: "IdPatologia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EsitiTestPazienti_Pazienti_IdPaziente",
                        column: x => x.IdPaziente,
                        principalTable: "pazienti",
                        principalColumn: "IdPaziente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TipoRuolo = table.Column<string>(nullable: true),
                    Username = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Cognome = table.Column<string>(maxLength: 250, nullable: true),
                    Nome = table.Column<string>(maxLength: 250, nullable: true),
                    Version = table.Column<long>(nullable: false),
                    CreatorAccountId = table.Column<int>(nullable: true),
                    UpdaterAccountId = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    ResetPassword = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "fk_account_role",
                        column: x => x.TipoRuolo,
                        principalTable: "profili",
                        principalColumn: "Tipo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "permessi_profili",
                columns: table => new
                {
                    TipoRuolo = table.Column<string>(maxLength: 20, nullable: false),
                    Permesso = table.Column<string>(maxLength: 50, nullable: false),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.TipoRuolo, x.Permesso });
                    table.ForeignKey(
                        name: "fk_roles_permissions",
                        column: x => x.TipoRuolo,
                        principalTable: "profili",
                        principalColumn: "Tipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stili_di_vita_pazienti",
                columns: table => new
                {
                    IdPaziente = table.Column<string>(maxLength: 50, nullable: false),
                    IdStileDiVita = table.Column<string>(maxLength: 5, nullable: false),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.IdStileDiVita, x.IdPaziente });
                    table.ForeignKey(
                        name: "FK_StiliDiVitaPazienti_Pazienti_IdPaziente",
                        column: x => x.IdPaziente,
                        principalTable: "pazienti",
                        principalColumn: "IdPaziente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StiliDiVitaPazienti_StiliDiVita_IdStileDiVita",
                        column: x => x.IdStileDiVita,
                        principalTable: "stili_di_vita",
                        principalColumn: "IdStileDiVita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "normalizzazione_features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdFeature = table.Column<int>(nullable: false),
                    DaValore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AValore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValoreNormalizzato = table.Column<int>(nullable: false),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_normalizzazione_features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NormalizzazioneRisultatiTest_ProgettiTest_IdProgettoTest",
                        column: x => x.IdFeature,
                        principalTable: "features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "algoritmi",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdTipoEsame = table.Column<string>(maxLength: 5, nullable: false),
                    IdPatologia = table.Column<string>(maxLength: 5, nullable: false),
                    Tipo = table.Column<string>(maxLength: 20, nullable: false),
                    Descrizione = table.Column<string>(maxLength: 45, nullable: false),
                    EndpointRest = table.Column<string>(maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_algoritmi", x => x.ID);
                    table.ForeignKey(
                        name: "fk_algoritmi_tipi_esami1",
                        columns: x => new { x.IdTipoEsame, x.IdPatologia },
                        principalTable: "tipi_esami",
                        principalColumns: new[] { "IdTipoEsame", "IdPatologia" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "immagini",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdEsame = table.Column<int>(nullable: false),
                    NomeFile = table.Column<string>(maxLength: 250, nullable: false),
                    DataCaricamento = table.Column<DateTime>(type: "date", nullable: false),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_immagini", x => x.ID);
                    table.ForeignKey(
                        name: "fk_immagini_esami1",
                        column: x => x.IdEsame,
                        principalTable: "esami",
                        principalColumn: "IdEsame",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "regioni_di_interesse",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdImmagine = table.Column<int>(nullable: false),
                    NomeFile = table.Column<string>(maxLength: 250, nullable: false),
                    DataCaricamento = table.Column<DateTime>(type: "date", nullable: false),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regioni_di_interesse", x => x.ID);
                    table.ForeignKey(
                        name: "fk_regions_of_interest_immagini1",
                        column: x => x.IdImmagine,
                        principalTable: "immagini",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "diagnosi",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdEsame = table.Column<int>(nullable: false),
                    IdRegioneDiInteresse = table.Column<int>(nullable: true),
                    IdAlgoritmo = table.Column<int>(nullable: false),
                    Stato = table.Column<string>(maxLength: 250, nullable: true),
                    DataStato = table.Column<DateTime>(type: "date", nullable: true),
                    Esito = table.Column<string>(maxLength: 500, nullable: true),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnosi", x => x.ID);
                    table.ForeignKey(
                        name: "fk_diagnosi_algoritmi1",
                        column: x => x.IdAlgoritmo,
                        principalTable: "algoritmi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_diagnosi_esami1",
                        column: x => x.IdEsame,
                        principalTable: "esami",
                        principalColumn: "IdEsame",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_diagnosi_regioni_di_interesse1",
                        column: x => x.IdRegioneDiInteresse,
                        principalTable: "regioni_di_interesse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "features_esame",
                columns: table => new
                {
                    IdEsame = table.Column<int>(nullable: false),
                    IdFeature = table.Column<int>(nullable: false),
                    IdRegioneDiInteresse = table.Column<int>(nullable: true),
                    Valore = table.Column<string>(maxLength: 500, nullable: false),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.IdEsame, x.IdFeature });
                    table.ForeignKey(
                        name: "FK_DettagliEsitiTestPazienti_EsitiTestPazienti_IdEsitoTestPazie~",
                        column: x => x.IdEsame,
                        principalTable: "esami",
                        principalColumn: "IdEsame",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DettagliEsitiTestPazienti_ProgettiTest_IdProgettoTest",
                        column: x => x.IdFeature,
                        principalTable: "features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dettagli_esami_regions_of_interest1",
                        column: x => x.IdRegioneDiInteresse,
                        principalTable: "regioni_di_interesse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "score_diagnosi",
                columns: table => new
                {
                    IdDiagnosi = table.Column<int>(nullable: false),
                    Descrizione = table.Column<string>(maxLength: 200, nullable: false),
                    Valore = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Descrizione, x.IdDiagnosi });
                    table.ForeignKey(
                        name: "fk_score_diagnosi_diagnosi1",
                        column: x => x.IdDiagnosi,
                        principalTable: "diagnosi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_TipoRuolo",
                table: "Accounts",
                column: "TipoRuolo");

            migrationBuilder.CreateIndex(
                name: "fk_algoritmi_tipi_esami1_idx",
                table: "algoritmi",
                columns: new[] { "IdTipoEsame", "IdPatologia" });

            migrationBuilder.CreateIndex(
                name: "fk_diagnosi_algoritmi1_idx",
                table: "diagnosi",
                column: "IdAlgoritmo");

            migrationBuilder.CreateIndex(
                name: "fk_diagnosi_esami1_idx",
                table: "diagnosi",
                column: "IdEsame");

            migrationBuilder.CreateIndex(
                name: "fk_diagnosi_regioni_di_interesse1_idx",
                table: "diagnosi",
                column: "IdRegioneDiInteresse");

            migrationBuilder.CreateIndex(
                name: "fk_patologia_esami_idx",
                table: "esami",
                column: "IdPatologia");

            migrationBuilder.CreateIndex(
                name: "IX_EsitiTestPazienti_IdPaziente",
                table: "esami",
                column: "IdPaziente");

            migrationBuilder.CreateIndex(
                name: "fk_esami_tipi_esami1_idx",
                table: "esami",
                column: "IdTipoEsame");

            migrationBuilder.CreateIndex(
                name: "IX_ProgettiTest_IdProgetto",
                table: "features",
                column: "IdPatologia");

            migrationBuilder.CreateIndex(
                name: "IX_ProgettiTest_IdTipoTest",
                table: "features",
                column: "IdTipoEsame");

            migrationBuilder.CreateIndex(
                name: "IX_DettagliEsitiTestPazienti_IdProgettoTest",
                table: "features_esame",
                column: "IdFeature");

            migrationBuilder.CreateIndex(
                name: "fk_dettagli_esami_regions_of_interest1_idx",
                table: "features_esame",
                column: "IdRegioneDiInteresse");

            migrationBuilder.CreateIndex(
                name: "fk_immagini_esami1_idx",
                table: "immagini",
                column: "IdEsame");

            migrationBuilder.CreateIndex(
                name: "IX_NormalizzazioneRisultatiTest_IdProgettoTest",
                table: "normalizzazione_features",
                column: "IdFeature");

            migrationBuilder.CreateIndex(
                name: "fk_regions_of_interest_immagini1_idx",
                table: "regioni_di_interesse",
                column: "IdImmagine");

            migrationBuilder.CreateIndex(
                name: "fk_score_diagnosi_diagnosi1_idx",
                table: "score_diagnosi",
                column: "IdDiagnosi");

            migrationBuilder.CreateIndex(
                name: "IX_StiliDiVitaPazienti_IdPaziente",
                table: "stili_di_vita_pazienti",
                column: "IdPaziente");

            migrationBuilder.CreateIndex(
                name: "fk_tipi_esami_patologie1_idx",
                table: "tipi_esami",
                column: "IdPatologia");
            */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "features_esame");

            migrationBuilder.DropTable(
                name: "normalizzazione_features");

            migrationBuilder.DropTable(
                name: "permessi_profili");

            migrationBuilder.DropTable(
                name: "score_diagnosi");

            migrationBuilder.DropTable(
                name: "stili_di_vita_pazienti");

            migrationBuilder.DropTable(
                name: "features");

            migrationBuilder.DropTable(
                name: "profili");

            migrationBuilder.DropTable(
                name: "diagnosi");

            migrationBuilder.DropTable(
                name: "stili_di_vita");

            migrationBuilder.DropTable(
                name: "algoritmi");

            migrationBuilder.DropTable(
                name: "regioni_di_interesse");

            migrationBuilder.DropTable(
                name: "tipi_esami");

            migrationBuilder.DropTable(
                name: "immagini");

            migrationBuilder.DropTable(
                name: "esami");

            migrationBuilder.DropTable(
                name: "patologie");

            migrationBuilder.DropTable(
                name: "pazienti");
            */
        }
    }
}
