using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polizia_Municipale.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anagrafiche",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnagraficaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anagrafiche", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anagrafiche_Anagrafiche_AnagraficaId",
                        column: x => x.AnagraficaId,
                        principalTable: "Anagrafiche",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Violazioni",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violazioni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Verbali",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataViolazione = table.Column<DateOnly>(type: "date", nullable: false),
                    IndirizzoViolazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NominativoAgente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataTrascrizioneVerbale = table.Column<DateOnly>(type: "date", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DecurtamentoPunti = table.Column<int>(type: "int", nullable: false),
                    AnagraficaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViolazioneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbali", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verbali_Anagrafiche_AnagraficaId",
                        column: x => x.AnagraficaId,
                        principalTable: "Anagrafiche",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Verbali_Violazioni_ViolazioneId",
                        column: x => x.ViolazioneId,
                        principalTable: "Violazioni",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anagrafiche_AnagraficaId",
                table: "Anagrafiche",
                column: "AnagraficaId");

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_AnagraficaId",
                table: "Verbali",
                column: "AnagraficaId");

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_ViolazioneId",
                table: "Verbali",
                column: "ViolazioneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verbali");

            migrationBuilder.DropTable(
                name: "Anagrafiche");

            migrationBuilder.DropTable(
                name: "Violazioni");
        }
    }
}
