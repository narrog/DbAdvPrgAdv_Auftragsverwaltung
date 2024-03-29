﻿// <auto-generated />
using System;
using DbAdvPrgAdv_Auftragsverwaltung;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbAdvPrgAdv_Auftragsverwaltung.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20220223194151_AddSampleData_GroupsArticles")]
    partial class AddSampleData_GroupsArticles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Article", b =>
                {
                    b.Property<int>("ArticleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("ArticleID");

                    b.HasIndex("GroupID");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            ArticleID = 1,
                            GroupID = 2,
                            Name = "HP LaserJet Pro M404",
                            Price = 420m
                        },
                        new
                        {
                            ArticleID = 2,
                            GroupID = 4,
                            Name = "Lenovo ThinkPad L15",
                            Price = 900m
                        },
                        new
                        {
                            ArticleID = 3,
                            GroupID = 3,
                            Name = "Chromstahl Felgen 19 Zoll",
                            Price = 200m
                        });
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PLZ")
                        .HasColumnType("int");

                    b.HasKey("CityID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityID = 1,
                            CityName = "St. Gallen",
                            PLZ = 9000
                        },
                        new
                        {
                            CityID = 2,
                            CityName = "Herisau",
                            PLZ = 9000
                        });
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vorname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.HasIndex("CityID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 1,
                            CityID = 1,
                            Name = "Muster",
                            Vorname = "Hans"
                        },
                        new
                        {
                            CustomerID = 2,
                            CityID = 1,
                            Name = "Peter",
                            Vorname = "Benjamin"
                        },
                        new
                        {
                            CustomerID = 3,
                            CityID = 2,
                            Name = "Buser",
                            Vorname = "Leonie"
                        });
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.HasKey("GroupID");

                    b.HasIndex("ParentID");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupID = 1,
                            Name = "Elektronik",
                            ParentID = 0
                        },
                        new
                        {
                            GroupID = 2,
                            Name = "Drucker",
                            ParentID = 1
                        },
                        new
                        {
                            GroupID = 3,
                            Name = "Autozubehör",
                            ParentID = 0
                        },
                        new
                        {
                            GroupID = 4,
                            Name = "Laptop",
                            ParentID = 1
                        });
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PriceTotal")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Position", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ArticleID")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("OrderID", "ArticleID");

                    b.HasIndex("ArticleID");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Article", b =>
                {
                    b.HasOne("DbAdvPrgAdv_Auftragsverwaltung.Model.Group", "Group")
                        .WithMany("Articles")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Customer", b =>
                {
                    b.HasOne("DbAdvPrgAdv_Auftragsverwaltung.Model.City", "City")
                        .WithMany("Customers")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Group", b =>
                {
                    b.HasOne("DbAdvPrgAdv_Auftragsverwaltung.Model.Group", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentID");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Order", b =>
                {
                    b.HasOne("DbAdvPrgAdv_Auftragsverwaltung.Model.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Position", b =>
                {
                    b.HasOne("DbAdvPrgAdv_Auftragsverwaltung.Model.Article", "Article")
                        .WithMany("Positions")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbAdvPrgAdv_Auftragsverwaltung.Model.Order", "Order")
                        .WithMany("Positions")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Article", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.City", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Group", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Children");
                });

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Order", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
