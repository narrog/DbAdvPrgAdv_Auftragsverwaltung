using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbAdvPrgAdv_Auftragsverwaltung.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gruppen",
                columns: table => new
                {
                    GruppeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gruppen", x => x.GruppeID);
                });

            migrationBuilder.CreateTable(
                name: "Orte",
                columns: table => new
                {
                    OrtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PLZ = table.Column<int>(type: "int", nullable: false),
                    Ortschaft = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orte", x => x.OrtID);
                });

            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    ArtikelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preis = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    Gruppe_ID = table.Column<int>(type: "int", nullable: false),
                    GruppeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikel", x => x.ArtikelID);
                    table.ForeignKey(
                        name: "FK_Artikel_Gruppen_GruppeID",
                        column: x => x.GruppeID,
                        principalTable: "Gruppen",
                        principalColumn: "GruppeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kunden",
                columns: table => new
                {
                    KundeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strasse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Webseite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passwort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ort_ID = table.Column<int>(type: "int", nullable: false),
                    OrtID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunden", x => x.KundeID);
                    table.ForeignKey(
                        name: "FK_Kunden_Orte_OrtID",
                        column: x => x.OrtID,
                        principalTable: "Orte",
                        principalColumn: "OrtID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aufträge",
                columns: table => new
                {
                    AuftragID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreisTotal = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    Kunde_ID = table.Column<int>(type: "int", nullable: false),
                    KundeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aufträge", x => x.AuftragID);
                    table.ForeignKey(
                        name: "FK_Aufträge_Kunden_KundeID",
                        column: x => x.KundeID,
                        principalTable: "Kunden",
                        principalColumn: "KundeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positionen",
                columns: table => new
                {
                    Auftrag_ID = table.Column<int>(type: "int", nullable: false),
                    Artikel_ID = table.Column<int>(type: "int", nullable: false),
                    Nummer = table.Column<int>(type: "int", nullable: false),
                    AuftragID = table.Column<int>(type: "int", nullable: true),
                    ArtikelID = table.Column<int>(type: "int", nullable: true),
                    Anzahl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positionen", x => new { x.Auftrag_ID, x.Artikel_ID });
                    table.ForeignKey(
                        name: "FK_Positionen_Artikel_ArtikelID",
                        column: x => x.ArtikelID,
                        principalTable: "Artikel",
                        principalColumn: "ArtikelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Positionen_Aufträge_AuftragID",
                        column: x => x.AuftragID,
                        principalTable: "Aufträge",
                        principalColumn: "AuftragID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikel_GruppeID",
                table: "Artikel",
                column: "GruppeID");

            migrationBuilder.CreateIndex(
                name: "IX_Aufträge_KundeID",
                table: "Aufträge",
                column: "KundeID");

            migrationBuilder.CreateIndex(
                name: "IX_Kunden_OrtID",
                table: "Kunden",
                column: "OrtID");

            migrationBuilder.CreateIndex(
                name: "IX_Positionen_ArtikelID",
                table: "Positionen",
                column: "ArtikelID");

            migrationBuilder.CreateIndex(
                name: "IX_Positionen_AuftragID",
                table: "Positionen",
                column: "AuftragID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positionen");

            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Aufträge");

            migrationBuilder.DropTable(
                name: "Gruppen");

            migrationBuilder.DropTable(
                name: "Kunden");

            migrationBuilder.DropTable(
                name: "Orte");
        }
    }
}
