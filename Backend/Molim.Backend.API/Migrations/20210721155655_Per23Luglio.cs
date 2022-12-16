using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Molim.Backend.API.Migrations
{
    public partial class Per23Luglio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropForeignKey(
                name: "fk_diagnosi_algoritmi1",
                table: "diagnosi");
            */
            migrationBuilder.DropTable(
                name: "score_diagnosi");

            /*
            migrationBuilder.DropPrimaryKey(
                name: "PK_diagnosi",
                table: "diagnosi");

            migrationBuilder.DropIndex(
                name: "fk_diagnosi_algoritmi1_idx",
                table: "diagnosi");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "diagnosi");

            migrationBuilder.DropColumn(
                name: "DataStato",
                table: "diagnosi");

            migrationBuilder.DropColumn(
                name: "EsitoPredizione",
                table: "diagnosi");

            migrationBuilder.DropColumn(
                name: "IdAlgoritmo",
                table: "diagnosi");

            migrationBuilder.DropColumn(
                name: "Stato",
                table: "diagnosi");            

            migrationBuilder.RenameIndex(
                name: "IX_diagnosi_IdPaziente",
                table: "diagnosi",
                newName: "fk_diagnosi_pazienti1_idx");

            */

            migrationBuilder.AlterColumn<string>(
                name: "IdPaziente",
                table: "diagnosi",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdPatologia",
                table: "diagnosi",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldNullable: true);

            /*

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "diagnosi",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OggettoDiPredizione",
                table: "algoritmi",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            */

            migrationBuilder.AddPrimaryKey(
                name: "PK_diagnosi",
                table: "diagnosi",
                columns: new[] { "IdPaziente", "IdPatologia", "Date" });

            migrationBuilder.CreateTable(
                name: "predizioni",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdPaziente = table.Column<string>(nullable: true),
                    IdPatologia = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_predizioni", x => x.ID);
                    table.ForeignKey(
                        name: "fk_predizioni_algoritmi1",
                        column: x => x.IdAlgoritmo,
                        principalTable: "algoritmi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_predizioni_patologie1",
                        column: x => x.IdPatologia,
                        principalTable: "patologie",
                        principalColumn: "IdPatologia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_predizioni_pazienti1",
                        column: x => x.IdPaziente,
                        principalTable: "pazienti",
                        principalColumn: "IdPaziente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "score_predizioni",
                columns: table => new
                {
                    IdPredizione = table.Column<int>(nullable: false),
                    Descrizione = table.Column<string>(maxLength: 200, nullable: false),
                    Valore = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorAccount_ID = table.Column<int>(nullable: true),
                    UpdaterAccount_ID = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Descrizione, x.IdPredizione });
                    table.ForeignKey(
                        name: "fk_score_predizioni_diagnosi1",
                        column: x => x.IdPredizione,
                        principalTable: "predizioni",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fk_predizioni_algoritmi1_idx",
                table: "predizioni",
                column: "IdAlgoritmo");

            migrationBuilder.CreateIndex(
                name: "fk_predizioni_patologie1_idx",
                table: "predizioni",
                column: "IdPatologia");

            migrationBuilder.CreateIndex(
                name: "IX_predizioni_IdPaziente",
                table: "predizioni",
                column: "IdPaziente");

            migrationBuilder.CreateIndex(
                name: "fk_score_predizioni_diagnosi1_idx",
                table: "score_predizioni",
                column: "IdPredizione");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "score_predizioni");

            migrationBuilder.DropTable(
                name: "predizioni");

            migrationBuilder.DropPrimaryKey(
                name: "PK_diagnosi",
                table: "diagnosi");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "diagnosi");

            migrationBuilder.DropColumn(
                name: "OggettoDiPredizione",
                table: "algoritmi");

            migrationBuilder.RenameIndex(
                name: "fk_diagnosi_pazienti1_idx",
                table: "diagnosi",
                newName: "IX_diagnosi_IdPaziente");

            migrationBuilder.AlterColumn<string>(
                name: "IdPatologia",
                table: "diagnosi",
                type: "varchar(5)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "IdPaziente",
                table: "diagnosi",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "diagnosi",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataStato",
                table: "diagnosi",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EsitoPredizione",
                table: "diagnosi",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAlgoritmo",
                table: "diagnosi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Stato",
                table: "diagnosi",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_diagnosi",
                table: "diagnosi",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "score_diagnosi",
                columns: table => new
                {
                    Descrizione = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    IdDiagnosi = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatorAccount_ID = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdaterAccount_ID = table.Column<int>(type: "int", nullable: true),
                    Valore = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
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
                name: "fk_diagnosi_algoritmi1_idx",
                table: "diagnosi",
                column: "IdAlgoritmo");

            migrationBuilder.CreateIndex(
                name: "fk_score_diagnosi_diagnosi1_idx",
                table: "score_diagnosi",
                column: "IdDiagnosi");

            migrationBuilder.AddForeignKey(
                name: "fk_diagnosi_algoritmi1",
                table: "diagnosi",
                column: "IdAlgoritmo",
                principalTable: "algoritmi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
