﻿// <auto-generated />
using System;
using DbAdvPrgAdv_Auftragsverwaltung;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbAdvPrgAdv_Auftragsverwaltung.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20220226155725_AddTemporalTables")]
    partial class AddTemporalTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DbAdvPrgAdv_Auftragsverwaltung.Model.Article", b =>
                {
                    b.Property<int>("ArticleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleID"), 1L, 1);

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("ArticleID");

                    b.HasIndex("GroupID");

                    b.ToTable("Articles", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));

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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityID"), 1L, 1);

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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"), 1L, 1);

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

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("Vorname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.HasIndex("CityID");

                    b.ToTable("Customers", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));

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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupID"), 1L, 1);

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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PriceTotal")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            CustomerID = 1,
                            OrderDate = new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PriceTotal = 420m
                        },
                        new
                        {
                            OrderID = 2,
                            CustomerID = 1,
                            OrderDate = new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PriceTotal = 840m
                        },
                        new
                        {
                            OrderID = 3,
                            CustomerID = 2,
                            OrderDate = new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PriceTotal = 1320m
                        });
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

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            ArticleID = 1,
                            Count = 1,
                            Number = 1
                        },
                        new
                        {
                            OrderID = 2,
                            ArticleID = 1,
                            Count = 2,
                            Number = 2
                        },
                        new
                        {
                            OrderID = 3,
                            ArticleID = 1,
                            Count = 1,
                            Number = 3
                        },
                        new
                        {
                            OrderID = 3,
                            ArticleID = 2,
                            Count = 1,
                            Number = 4
                        });
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
