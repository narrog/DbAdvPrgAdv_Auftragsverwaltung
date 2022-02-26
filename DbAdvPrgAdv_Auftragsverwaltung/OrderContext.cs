using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung
{
    class OrderContext : DbContext
    {
        // DBs "erstellen"
        public DbSet<Article> Articles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Position> Positions { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verbindung aufbauen
            optionsBuilder.UseSqlServer("Data Source=.; Database=DbAdvPrgAdv_Auftragsverwaltung; Trusted_Connection=True");
            optionsBuilder.UseLazyLoadingProxies();

            // Logs
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PK zusammen bauen aus 2 FK
            modelBuilder.Entity<Position>()
                .HasKey(t => new { t.OrderID, t.ArticleID});

            modelBuilder.Entity<Customer>().ToTable("Customers", c => c.IsTemporal());
            modelBuilder.Entity<Article>().ToTable("Articles", a => a.IsTemporal());

            #region Beispieldaten
            modelBuilder.Entity<City>().HasData(new City() { CityID = 1, PLZ = 9000, CityName = "St. Gallen" });
            modelBuilder.Entity<City>().HasData(new City() { CityID = 2, PLZ = 9000, CityName = "Herisau" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 1, Vorname = "Hans", Name = "Muster", CityID = 1 });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 2, Vorname = "Benjamin", Name = "Peter", CityID = 1 });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 3, Vorname = "Leonie", Name = "Buser", CityID = 2 });

            modelBuilder.Entity<Group>().HasData(new Group() { GroupID = 1, Name = "Elektronik", ParentID = 0 });
            modelBuilder.Entity<Group>().HasData(new Group() { GroupID = 2, Name = "Drucker", ParentID = 1 });
            modelBuilder.Entity<Group>().HasData(new Group() { GroupID = 3, Name = "Autozubehör", ParentID = 0 });
            modelBuilder.Entity<Group>().HasData(new Group() { GroupID = 4, Name = "Laptop", ParentID = 1 });

            modelBuilder.Entity<Article>().HasData(new Article() { ArticleID = 1, Name = "HP LaserJet Pro M404", GroupID = 2, Price = 420.00 });
            modelBuilder.Entity<Article>().HasData(new Article() { ArticleID = 2, Name = "Lenovo ThinkPad L15", GroupID = 4, Price = 900.00 });
            modelBuilder.Entity<Article>().HasData(new Article() { ArticleID = 3, Name = "Chromstahl Felgen 19 Zoll", GroupID = 3, Price = 200.00 });

            // Bestellung 1
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 1, OrderDate = new DateTime(2021, 12, 31), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 1, ArticleID = 1, Count = 1, OrderID = 1 });

            // Bestellung 2
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 2, OrderDate = new DateTime(2022, 01, 03), CustomerID = 1, PriceTotal = 840.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 2, ArticleID = 1, Count = 2, OrderID = 2 });

            // Bestellung 3
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 3, OrderDate = new DateTime(2022, 01, 03), CustomerID = 2, PriceTotal = 1320.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 3, ArticleID = 1, Count = 1, OrderID = 3 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 4, ArticleID = 2, Count = 1, OrderID = 3 });
            #endregion

        }

        // CTE für TreeView
        public List<Group> GroupTree() =>
            Groups.FromSqlRaw(
                    @";with cte as (
	                    SELECT GroupID, Name, ParentID, cast('none' as nvarchar(max)) AS Parent 
                        FROM Groups 
                        WHERE ParentID = 0
	                    UNION ALL
	                    SELECT a.GroupID, a.Name, a.ParentID, (b.Name) AS Parent 
                        FROM Groups a
	                    INNER JOIN cte b 
                            ON a.ParentID = b.GroupID
                    )
                    SELECT * FROM cte;")
                .AsNoTrackingWithIdentityResolution()
                .ToList();
    }
}
