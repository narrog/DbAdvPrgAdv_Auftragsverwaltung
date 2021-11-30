﻿// <auto-generated />
using System;
using DbAdvPrgAdv_Auftragsverwaltung;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbAdvPrgAdv_Auftragsverwaltung.Migrations
{
    [DbContext(typeof(OrderContext))]
    partial class OrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Artikel", b =>
                {
                    b.Property<int>("ArtikelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bezeichnung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GruppeID")
                        .HasColumnType("int");

                    b.Property<int>("Gruppe_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("Preis")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("ArtikelID");

                    b.HasIndex("GruppeID");

                    b.ToTable("Artikel");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Auftrag", b =>
                {
                    b.Property<int>("AuftragID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KundeID")
                        .HasColumnType("int");

                    b.Property<int>("Kunde_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("PreisTotal")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("AuftragID");

                    b.HasIndex("KundeID");

                    b.ToTable("Aufträge");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Gruppe", b =>
                {
                    b.Property<int>("GruppeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GruppeID");

                    b.ToTable("Gruppen");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Kunde", b =>
                {
                    b.Property<int>("KundeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrtID")
                        .HasColumnType("int");

                    b.Property<int>("Ort_ID")
                        .HasColumnType("int");

                    b.Property<string>("Passwort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strasse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vorname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Webseite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KundeID");

                    b.HasIndex("OrtID");

                    b.ToTable("Kunden");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Ort", b =>
                {
                    b.Property<int>("OrtID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ortschaft")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PLZ")
                        .HasColumnType("int");

                    b.HasKey("OrtID");

                    b.ToTable("Orte");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Position", b =>
                {
                    b.Property<int>("Auftrag_ID")
                        .HasColumnType("int");

                    b.Property<int>("Artikel_ID")
                        .HasColumnType("int");

                    b.Property<int>("Anzahl")
                        .HasColumnType("int");

                    b.Property<int?>("ArtikelID")
                        .HasColumnType("int");

                    b.Property<int?>("AuftragID")
                        .HasColumnType("int");

                    b.Property<int>("Nummer")
                        .HasColumnType("int");

                    b.HasKey("Auftrag_ID", "Artikel_ID");

                    b.HasIndex("ArtikelID");

                    b.HasIndex("AuftragID");

                    b.ToTable("Positionen");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Artikel", b =>
                {
                    b.HasOne("DbAdvPrgAdv_Auftragsverwaltung.Model.Gruppe", "Gruppe")
                        .WithMany("Artikels")
                        .HasForeignKey("GruppeID");

                    b.Navigation("Gruppe");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Auftrag", b =>
                {
                    b.HasOne("DbAdvPrgAdv_Auftragsverwaltung.Model.Kunde", "Kunde")
                        .WithMany("Auftraege")
                        .HasForeignKey("KundeID");

                    b.Navigation("Kunde");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Kunde", b =>
                {
                    b.HasOne("DbAdvPrgAdv_Auftragsverwaltung.Model.Ort", "Ort")
                        .WithMany("Kunden")
                        .HasForeignKey("OrtID");

                    b.Navigation("Ort");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Position", b =>
                {
                    b.HasOne("DbAdvPrgAdv_Auftragsverwaltung.Model.Artikel", "Artikel")
                        .WithMany("Positionen")
                        .HasForeignKey("ArtikelID");

                    b.HasOne("DbAdvPrgAdv_Auftragsverwaltung.Model.Auftrag", "Auftrag")
                        .WithMany("Positionen")
                        .HasForeignKey("AuftragID");

                    b.Navigation("Artikel");

                    b.Navigation("Auftrag");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Artikel", b =>
                {
                    b.Navigation("Positionen");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Auftrag", b =>
                {
                    b.Navigation("Positionen");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Gruppe", b =>
                {
                    b.Navigation("Artikels");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Kunde", b =>
                {
                    b.Navigation("Auftraege");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Ort", b =>
                {
                    b.Navigation("Kunden");
                });
#pragma warning restore 612, 618
        }
    }
}
