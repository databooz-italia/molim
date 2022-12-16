using Microsoft.EntityFrameworkCore.Migrations;

namespace Molim.Backend.API.Migrations
{
    public partial class Add_FeatureAlgoritmo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RichiedeFeatures",
                table: "tipi_esami");

            migrationBuilder.CreateTable(
                name: "features_algoritmi",
                columns: table => new
                {
                    IdAlgoritmo = table.Column<int>(nullable: false),
                    IdFeature = table.Column<int>(nullable: false),
                    Obbligatorio = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_features_algoritmi", x => new { x.IdAlgoritmo, x.IdFeature });
                    table.ForeignKey(
                        name: "fk_algoritmifeatures_algoritmi",
                        column: x => x.IdAlgoritmo,
                        principalTable: "algoritmi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_algoritmifeatures_features",
                        column: x => x.IdFeature,
                        principalTable: "features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_features_algoritmi_IdFeature",
                table: "features_algoritmi",
                column: "IdFeature");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "features_algoritmi");

            migrationBuilder.AddColumn<bool>(
                name: "RichiedeFeatures",
                table: "tipi_esami",
                type: "bit(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
